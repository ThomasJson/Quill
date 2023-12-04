using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Domain.Entities
{
    public class NoteCategoryLinkEntity
    {
        [ForeignKey(nameof(Note))]
        public int NoteId { get; set; }
        public NoteEntity Note { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}