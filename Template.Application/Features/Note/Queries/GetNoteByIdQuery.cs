using MediatR;
using Template.Application.Features.Note.Shared.Dto;
using Template.Application.Features.Note.Shared.Mappers;
using Template.Application.Interfaces.Services;

namespace Template.Application.Features.Note.Queries
{
    public record GetNoteByIdQuery(int Id) : IRequest<NoteDto>;

    internal class GetNoteByIdQueryHandler : IRequestHandler<GetNoteByIdQuery, NoteDto>
    {
        private readonly INoteService _noteService;
        public GetNoteByIdQueryHandler(INoteService noteService)
        { 
            _noteService = noteService;
        }

        public async Task<NoteDto> Handle(GetNoteByIdQuery query, CancellationToken cancellationToken)
        {
            var noteEntity = await _noteService.GetNoteByIdAsync(query.Id);

            if (noteEntity != null)
            {
                var noteDto = NoteMapper.ToNoteDto(noteEntity);
                return noteDto;
            }
            else
            {
                return null;
            }
        }
    }
}