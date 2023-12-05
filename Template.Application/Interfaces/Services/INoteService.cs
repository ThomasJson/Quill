using Template.Domain.Entities;

namespace Template.Application.Interfaces.Services
{
    public interface INoteService
    {
        Task<List<NoteEntity>> GetAllNotesAsync();
        Task<NoteEntity> GetNoteByIdAsync(int id);
        Task<NoteEntity> CreateNoteAsync(NoteEntity noteEntity);
        Task<NoteEntity> UpdateNoteAsync(NoteEntity noteEntity);
        Task<NoteEntity> DeleteNoteAsync(int id);
    }
}