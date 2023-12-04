using System.ComponentModel.DataAnnotations;
using Template.Domain.Common;

namespace Template.Domain.Entities
{
    public class NoteEntity : BaseAuditableEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public ICollection<NoteCategoryLinkEntity> CategoriesLink { get; set; }
        public ICollection<ContainerNoteLinkEntity> ContainersLink { get; set; }
    }
}