using MyNotes.Application.Contracts;
using MyNotes.Core.Models;
using MyNotes.Infrastructure.Contracts;
using MyNotes.Infrastructure.Repositories;

namespace MyNotes.Application.Services
{
    public class MyNotesService : IMyNotesService
    {
        private readonly IMyNotesRepository _noteRepository;

        public MyNotesService(IMyNotesRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<GetNotesResponse> GetNotes(RequestNoteSearch request)
        {
            var notes = await _noteRepository.GetNotes(request);

            var noteDtos = notes.Select(n => new NoteDto(n.Id, n.Title, n.Description, n.CreatedAt)).ToList();

            return new GetNotesResponse(noteDtos);
        }
        public async Task<Guid> Create(Notes note)
        {
            return await _noteRepository.Create(note);
        }
        public async Task<Guid> Delete(Guid id)
        {
            return await _noteRepository.Delete(id);
        }
        public async Task<Guid> Update(Guid id, string title, string description)
        {
            return await _noteRepository.Update(id, title, description);
        }
    }
}
