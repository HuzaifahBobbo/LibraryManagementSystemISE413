using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using LibraryManagementSystem.BLL.Models;

namespace LibraryManagementSystem.DAL.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryManagementSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("LibraryManagementSystem.BLL.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");
                    b.HasKey("Id");
                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LibraryManagementSystem.BLL.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");
                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");
                    b.HasKey("Id");
                    b.HasIndex("AuthorId");
                    b.HasIndex("CategoryId");
                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryManagementSystem.BLL.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");
                    b.HasKey("Id");
                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LibraryManagementSystem.BLL.Models.Book", b =>
                {
                    b.HasOne("LibraryManagementSystem.BLL.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                    b.HasOne("LibraryManagementSystem.BLL.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryManagementSystem.BLL.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryManagementSystem.BLL.Models.Category", b =>
                {
                    b.Navigation("Books");
                });
        }
    }
}
