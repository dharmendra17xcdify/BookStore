﻿// <auto-generated />
using System;
using BookService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookService.Migrations
{
    [DbContext(typeof(BookDatabaseContext))]
    partial class BookDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookService.Models.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutAuther")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Awards")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Books")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookService.Models.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<Guid>("AuthorId");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<DateTime>("DatePublished");

                    b.Property<string>("Genre");

                    b.Property<string>("Publication")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookService.Models.BookInventory", b =>
                {
                    b.Property<Guid>("InventoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AutherId");

                    b.Property<string>("AutherName")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<Guid>("BookId");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<int>("BookQuantityAvail");

                    b.Property<int>("BookQuantityOnOrder");

                    b.Property<int>("BookQuantitySold");

                    b.Property<int?>("BookQuantityTotal");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventory");
                });
#pragma warning restore 612, 618
        }
    }
}
