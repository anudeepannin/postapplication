using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PostServerApi.Models
{
    public partial class bhavnaContext : DbContext
    {
        public bhavnaContext()
        {
        }
        public bhavnaContext(DbContextOptions<bhavnaContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=bhavna;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CommentText)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CommentsCreatedDate).HasColumnType("date");

                entity.Property(e => e.CommentsUpdatedDate).HasColumnType("date");

                entity.Property(e => e.PostId).HasColumnName("PostID");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");
                entity.Property(e => e.PostId).HasColumnName("PostID");
                entity.Property(e => e.CreatedDate).HasColumnType("date");
                entity.Property(e => e.DescriptionOfPost)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.PostTittle)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("date")
                    .HasColumnName("updatedDate");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
