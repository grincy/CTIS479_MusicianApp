﻿// <auto-generated />
using System;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20240522140232_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PublishedYear")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("DataAccess.Entities.AlbumsMusic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MusicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("MusicId");

                    b.ToTable("AlbumsMusics");
                });

            modelBuilder.Entity("DataAccess.Entities.Music", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MusicianId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PublishedYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MusicianId");

                    b.ToTable("Music");
                });

            modelBuilder.Entity("DataAccess.Entities.Musician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRetired")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Musician");
                });

            modelBuilder.Entity("DataAccess.Entities.AlbumsMusic", b =>
                {
                    b.HasOne("DataAccess.Entities.Album", "Album")
                        .WithMany("AlbumsMusics")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Music", "Music")
                        .WithMany("AlbumsMusics")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Music");
                });

            modelBuilder.Entity("DataAccess.Entities.Music", b =>
                {
                    b.HasOne("DataAccess.Entities.Musician", "Musician")
                        .WithMany("Music")
                        .HasForeignKey("MusicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musician");
                });

            modelBuilder.Entity("DataAccess.Entities.Album", b =>
                {
                    b.Navigation("AlbumsMusics");
                });

            modelBuilder.Entity("DataAccess.Entities.Music", b =>
                {
                    b.Navigation("AlbumsMusics");
                });

            modelBuilder.Entity("DataAccess.Entities.Musician", b =>
                {
                    b.Navigation("Music");
                });
#pragma warning restore 612, 618
        }
    }
}
