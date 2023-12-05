using MediatR;
using Template.Application.Features.Note.Shared.Dto;
using Template.Application.Features.Note.Shared.Mappers;
using Template.Application.Interfaces.Services;

namespace Template.Application.Features.Note.Queries
{
    public record UpdateNoteQuery(NoteDto NoteDto) : IRequest<NoteDto>;

    internal class UpdateNoteQueryHandler : IRequestHandler<UpdateNoteQuery, NoteDto>
    {
        private readonly INoteService _noteService;

        public UpdateNoteQueryHandler(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<NoteDto> Handle(UpdateNoteQuery query, CancellationToken cancellationToken)
        {
            var noteEntity = NoteMapper.ToNoteEntity(query.NoteDto);
            var result = await _noteService.UpdateNoteAsync(noteEntity);
            if(result != null)
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