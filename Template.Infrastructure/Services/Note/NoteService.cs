using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Template.Application.Interfaces.Services;
using Template.Domain.Entities;
using Template.Persistence.Contexts;

namespace Template.Infrastructure.Services.Note
{
    public class NoteService(ApplicationDbContext context, ILogger<NoteService> logger) : INoteService
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ILogger<NoteService> _logger = logger;

        public async Task<List<NoteEntity>> GetAllNotesAsync()
        {
            try
            {
                var noteList = await _context.Notes.ToListAsync();
                return noteList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des notes.");
                throw;
            }
        }

        public async Task<NoteEntity> GetNoteByIdAsync(int id)
        {
            try
            {
                var noteEntity = await _context.Notes.FirstOrDefaultAsync(x => x.Id == id);
                return noteEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération de la note.");
                throw;
            }
        }

        public async Task<NoteEntity> CreateNoteAsync(NoteEntity noteEntity)
        {
            try
            {
                var result = await _context.Notes.AddAsync(noteEntity);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la création de la note.");
                throw;
            }
        }

        public async Task<NoteEntity> UpdateNoteAsync(NoteEntity noteEntity)
        {
            try
            {
                var existingEntity = await _context.Notes.FirstOrDefaultAsync(x => x.Id == noteEntity.Id);

                existingEntity.Title = noteEntity.Title;
                existingEntity.Content = noteEntity.Content;
                existingEntity.UpdatedDate = noteEntity.UpdatedDate;

                await _context.SaveChangesAsync();
                return existingEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la modification de la note.");
                throw;
            }
        }

        public async Task<NoteEntity> DeleteNoteAsync(int id)
        {
            try
            {
                var note = await _context.Notes.SingleOrDefaultAsync(x => x.Id == id);
                var result = _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression de la note.");
                throw;
            }
        }
    }
}