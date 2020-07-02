using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Models
{
    public partial class BookStoreContext : DbContext
    {
        public BookStoreContext()
        {
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<BookSales> BookSales { get; set; }
        public virtual DbSet<Books> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DREAMLAND\\SQLSERVER;Initial Catalog=BookStore;Integrated Security=True;Pooling=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.AuthorId)
                    .HasName("PK__Authors__70DAFC14573D89A2");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<BookSales>(entity =>
            {
                entity.HasKey(e => e.SaleId);

                entity.Property(e => e.SaleId).HasColumnName("SaleID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.SoldOn).HasColumnType("datetime");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookSales)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookSales_Books");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__Books__3DE0C227EB31ED86");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("ISBN")
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PublishedOn).HasColumnType("date");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Authors");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
