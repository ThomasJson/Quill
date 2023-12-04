using Template.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Template.Domain.Entities
{
    public class CategoryEntity : BaseAuditableEntity
    {
        [Required]
        public string Name { get; set; }

        public ICollection<NoteCategoryLinkEntity> NotesLink { get; set; }
    }
}