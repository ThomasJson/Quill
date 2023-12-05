using MediatR;
using Template.Application.Features.Note.Shared.Dto;
using Template.Application.Interfaces.Services;

namespace Template.Application.Features.Note.Queries
{
    public record class DeleteNoteQuery(NoteDto NoteDto) : IRequest<NoteDto>;

    internal class DeleteNoteQueryHandler : IRequestHandler<DeleteNoteQuery, NoteDto>
    {
        private readonly INoteService _noteService;

        public DeleteNoteQueryHandler(INoteService noteService)
        {
            _noteService = noteService;
        }
        public async Task<NoteDto> Handle(DeleteNoteQuery query, CancellationToken cancellationToken)
        {
            var result = await _noteService.DeleteNoteAsync(query.NoteDto.Id);
            if (result != null)
            {
                return query.NoteDto;
            }
            else
            {
                return null;
            }
        }
    }
}