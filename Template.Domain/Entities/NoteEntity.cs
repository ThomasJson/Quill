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
        public ICollection<AccountLinksEntity> AccountsLink { get; set; }
        public ICollection<FolderNoteLinkEntity> FoldersLink { get; set; }
    }
}