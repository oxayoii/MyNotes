using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Application.Contracts
{
    public record NoteDto(Guid Id, string Title, string Description, DateTime CreateAt);
}
