using Microsoft.EntityFrameworkCore;
using Template.Domain.Entities;

namespace Template.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<FolderEntity> Folders { get; set; }
        public DbSet<FolderNoteLinkEntity> FolderNoteLinks { get; set; }
        public DbSet<AccountLinksEntity> AccountLinks { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<AccountRoleLinkEntity> AccountRoleLinks { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<NoteEntity> Notes { get; set; }
        public DbSet<NoteCategoryLinkEntity> NoteCategoryLinks { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration de AccountRoleLinks
            modelBuilder.Entity<AccountRoleLinkEntity>()
                .HasKey(arl => new { arl.AccountId, arl.RoleId });

            modelBuilder.Entity<AccountRoleLinkEntity>()
                .HasOne(arl => arl.Account)
                .WithMany(a => a.RolesLink)
                .HasForeignKey(arl => arl.AccountId);

            modelBuilder.Entity<AccountRoleLinkEntity>()
                .HasOne(arl => arl.Role)
                .WithMany(r => r.AccountsLink)
                .HasForeignKey(arl => arl.RoleId);

            // Configuration de NoteCategoryLinks
            modelBuilder.Entity<NoteCategoryLinkEntity>()
                .HasKey(nc => new { nc.NoteId, nc.CategoryId });

            modelBuilder.Entity<NoteCategoryLinkEntity>()
                .HasOne(nc => nc.Note)
                .WithMany(n => n.CategoriesLink)
                .HasForeignKey(nc => nc.NoteId);

            modelBuilder.Entity<NoteCategoryLinkEntity>()
                .HasOne(nc => nc.Category)
                .WithMany(c => c.NotesLink)
                .HasForeignKey(nc => nc.CategoryId);

            // Configuration de FolderNoteLinks
            modelBuilder.Entity<FolderNoteLinkEntity>()
                .HasKey(cnl => new { cnl.FolderId, cnl.NoteId });

            modelBuilder.Entity<FolderNoteLinkEntity>()
                .HasOne(cnl => cnl.Folder)
                .WithMany(c => c.NotesLink)
                .HasForeignKey(cnl => cnl.FolderId);

            modelBuilder.Entity<FolderNoteLinkEntity>()
                .HasOne(cnl => cnl.Note)
                .WithMany(n => n.FoldersLink)
                .HasForeignKey(cnl => cnl.NoteId);

            // Configuration de AccountLinks
            modelBuilder.Entity<AccountLinksEntity>()
                .HasKey(al => new { al.AccountId, al.FolderId, al.NoteId });

            modelBuilder.Entity<AccountLinksEntity>()
                .HasOne(al => al.Account)
                .WithMany(a => a.FoldersLink)
                .HasForeignKey(al => al.AccountId);

            modelBuilder.Entity<AccountLinksEntity>()
                .HasOne(al => al.Folder)
                .WithMany(c => c.AccountsLink)
                .HasForeignKey(al => al.FolderId);

            modelBuilder.Entity<AccountLinksEntity>()
                .HasOne(al => al.Note)
                .WithMany(c => c.AccountsLink)
                .HasForeignKey(al => al.NoteId);
        }
    }
}