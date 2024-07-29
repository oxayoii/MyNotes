using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Application.Contracts
{
    public record GetNoteRequest(string title, string description);
}
