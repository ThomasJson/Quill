using MediatR;
using Template.Application.Features.Note.Shared.Dto;
using Template.Application.Features.Note.Shared.Mappers;
using Template.Application.Interfaces.Services;

namespace Template.Application.Features.Note.Queries
{
    public record class GetAllNotesQuery : IRequest<List<NoteDto>>;

    internal class GetAllNotesQueryHandler : IRequestHandler<GetAllNotesQuery, List<NoteDto>>
    {
        private readonly INoteService _noteService;

        public GetAllNotesQueryHandler(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<List<NoteDto>> Handle(GetAllNotesQuery query, CancellationToken cancellationToken)
        {
            var noteEntityList = await _noteService.GetAllNotesAsync();
            if (noteEntityList != null)
            {
                var noteDtoList = NoteMapper.ToNoteDtoList(noteEntityList);
                return noteDtoList;
            }
            else
            {
                return null;
            }
        }

    }
}