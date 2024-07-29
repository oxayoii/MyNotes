using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Infrastructure.Contracts
{
    public record RequestNoteSearch(string? Search, string? SortItem, string? SortOrder);
}
