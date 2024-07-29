using Microsoft.AspNetCore.Mvc;
using MyNotes.Application.Contracts;
using MyNotes.Application.Services;
using MyNotes.Core.Models;
using MyNotes.Infrastructure.Contracts;

namespace MyNotes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : Controller
    {
        private readonly IMyNotesService _myNotesService;
        public NotesController(IMyNotesService myNotesService)
        {
            _myNotesService = myNotesService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestNoteSearch request)
        {
            var responce = await _myNotesService.GetNotes(request);
            return Ok(responce);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] GetNoteRequest request)
        {
            var note = new Notes(request.title, request.description);
            var noteId = await _myNotesService.Create(note);
            return Ok(noteId);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> Update (Guid id, [FromBody] GetNoteRequest request)
        {
            var noteId = await _myNotesService.Update(id, request.title, request.description);
            return Ok(noteId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var noteId = await _myNotesService.Delete(id);
            return Ok(noteId);
        }

    }
}
