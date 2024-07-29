using Microsoft.EntityFrameworkCore;
using MyNotes.Application.Contracts;
using MyNotes.Core.Models;
using MyNotes.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Infrastructure.Repositories
{
    public class MyNotesRepository : IMyNotesRepository
    {
        private readonly MyNotesContext _context;
        public MyNotesRepository(MyNotesContext context)
        {
            _context = context;
        }
        public async Task<List<Notes>> GetNotes(RequestNoteSearch request)
        {
            var query = _context.Note
                .Where(n => string.IsNullOrWhiteSpace(request.Search) ||
                n.Title.ToLower().Contains(request.Search.ToLower()));

            Expression<Func<Notes, object>> selectorKey = request.SortItem?.ToLower()
            switch
            {
                "date" => note => note.CreatedAt,
                "title" => note => note.Title,
                _ => note => note.Id,
            };
            query = request.SortOrder == "desc"
                ? query.OrderByDescending(selectorKey) : query.OrderBy(selectorKey);

            return await query.ToListAsync();

        }
        public async Task<Guid> Create(Notes notes)
        {
            var newNote = new Notes(notes.Title, notes.Description);
            await _context.Note.AddAsync(newNote);
            await _context.SaveChangesAsync();
            return newNote.Id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            var note = await _context.Note.FirstOrDefaultAsync(b => b.Id == id);
            if(note != null)
            {
                _context.Note.Remove(note);
                await _context.SaveChangesAsync();
            }
            return id;
        }
        public async Task<Guid> Update(Guid id, string title, string description)
        {
            var note = await _context.Note.FirstOrDefaultAsync(b => b.Id == id);
            if(note != null)
            {
                note.Title = title;
                note.Description = description;

                _context.Note.Update(note);
                await _context.SaveChangesAsync();
            }
            return id;
        }
    }
}
