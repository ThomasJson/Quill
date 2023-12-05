using MediatR;
using Template.Application.Features.Note.Shared.Dto;
using Template.Application.Features.Note.Shared.Mappers;
using Template.Application.Interfaces.Services;

namespace Template.Application.Features.Note.Queries
{
    public record class CreateNoteQuery(NoteDto NoteDto) : IRequest<NoteDto>;

    internal class CreateNoteQueryHandler : IRequestHandler<CreateNoteQuery, NoteDto>
    {
        private readonly INoteService _noteService;

        public CreateNoteQueryHandler(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<NoteDto> Handle(CreateNoteQuery query, CancellationToken cancellationToken)
        {
            var noteEntity = NoteMapper.ToNoteEntity(query.NoteDto);
            var result = await _noteService.CreateNoteAsync(noteEntity);

            if (result != null)
            {
                return NoteMapper.ToNoteDto(result);
            }
            else
            {
                return null;
            }
        }
    }
}