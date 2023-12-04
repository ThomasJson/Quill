using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Domain.Entities
{
    public class FolderNoteLinkEntity
    {
        [ForeignKey(nameof(Folder))]
        public int FolderId { get; set; }
        public FolderEntity Folder { get; set; }

        [ForeignKey(nameof(Note))]
        public int NoteId { get; set; }
        public NoteEntity Note { get; set; }
    }
}