using System.ComponentModel.DataAnnotations;
using Template.Domain.Common;

namespace Template.Domain.Entities
{
    public class FolderEntity : BaseAuditableEntity
    {
        [Required]
        public string Name { get; set; }

        public ICollection<AccountFolderLinkEntity> AccountsLink { get; set; }
        public ICollection<FolderNoteLinkEntity> NotesLink { get; set; }
    }
}