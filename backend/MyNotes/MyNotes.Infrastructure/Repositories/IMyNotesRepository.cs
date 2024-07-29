using MyNotes.Application.Contracts;
using MyNotes.Core.Models;
using MyNotes.Infrastructure.Contracts;

namespace MyNotes.Infrastructure.Repositories
{
    public interface IMyNotesRepository
    {
        Task<Guid> Create(Notes notes);
        Task<List<Notes>> GetNotes(RequestNoteSearch request);
        Task<Guid> Delete(Guid id);
        Task<Guid> Update(Guid id, string title, string description);

    }
}