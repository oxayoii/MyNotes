using MyNotes.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Infrastructure.Contracts
{
    public record GetNotesResponse(List<NoteDto> notes);
}
