using Template.Application.Features.Note.Shared.Dto;
using Template.Domain.Entities;

namespace Template.Application.Features.Note.Shared.Mappers
{
    public static class NoteMapper
    {
        public static List<NoteDto> ToNoteDtoList(List<NoteEntity> noteEntities)
        {
            List<NoteDto> noteDtoList = new List<NoteDto>();

            foreach (NoteEntity noteEntity in noteEntities)
            {
                var noteDto = new NoteDto()
                {
                    Id = noteEntity.Id,
                    Title = noteEntity.Title,
                    Content = noteEntity.Content,
                    CreatedDate = noteEntity.CreatedDate,
                    UpdatedDate = noteEntity.UpdatedDate
                };

                noteDtoList.Add(noteDto);
            }

            return noteDtoList;
        }

        public static NoteDto ToNoteDto(NoteEntity noteEntity)
        {
            var noteDto = new NoteDto()
            {
                Id = noteEntity.Id,
                Title = noteEntity.Title,
                Content = noteEntity.Content,
                CreatedDate = noteEntity.CreatedDate,
                UpdatedDate = noteEntity.UpdatedDate
            };

            return noteDto;
        }

        public static NoteEntity ToNoteEntity(NoteDto noteDto)
        {
            var noteEntity = new NoteEntity()
            {
                Id = noteDto.Id,
                Title = noteDto.Title,
                Content = noteDto.Content,
                CreatedDate = noteDto.CreatedDate,
                UpdatedDate = noteDto.UpdatedDate
            };

            return noteEntity;
        }
    }
}