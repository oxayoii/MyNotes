using MyNotes.Application.Contracts;
using MyNotes.Core.Models;
using MyNotes.Infrastructure.Contracts;

namespace MyNotes.Application.Services
{
    public interface IMyNotesService
    {
        Task<Guid> Create(Notes note);
        Task<Guid> Delete(Guid id);
        Task<GetNotesResponse> GetNotes(RequestNoteSearch request);
        Task<Guid> Update(Guid id, string title, string description);
    }
}