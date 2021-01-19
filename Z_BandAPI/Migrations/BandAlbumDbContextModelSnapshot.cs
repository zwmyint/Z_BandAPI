﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Z_BandAPI.DbContexts;

namespace Z_BandAPI.Migrations
{
    [DbContext(typeof(BandAlbumDbContext))]
    partial class BandAlbumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Z_BandAPI.Entities.m_cls_Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BandId");

                    b.Property<string>("Description")
                        .HasMaxLength(400);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc4ccabe-29aa-42c4-9f80-18caea50adf5"),
                            BandId = new Guid("6b1eea43-5597-45a6-bdea-e68c60564247"),
                            Description = "One of the best heavy metal albums ever",
                            Title = "Master Of Puppets"
                        },
                        new
                        {
                            Id = new Guid("e5b6e8bf-5956-4329-a1b3-b1d48eea33ad"),
                            BandId = new Guid("a052a63d-fa53-44d5-a197-83089818a676"),
                            Description = "Amazing Rock album with raw sound",
                            Title = "Appetite for Destruction"
                        },
                        new
                        {
                            Id = new Guid("380c545c-9665-4043-baf2-34a3edefd373"),
                            BandId = new Guid("cb554ed6-8fa7-4b8d-8d90-55cc6a3e0074"),
                            Description = "Very groovy album",
                            Title = "Waterloo"
                        },
                        new
                        {
                            Id = new Guid("0e9a4ab5-4ae6-4ca3-ae7b-5f813e022527"),
                            BandId = new Guid("8e2f0a16-4c09-44c7-ba56-8dc62dfd792d"),
                            Description = "Arguably one of the best albums by Oasis",
                            Title = "Be Here Now"
                        },
                        new
                        {
                            Id = new Guid("8d2744ff-1134-4f36-a300-043febdc64b8"),
                            BandId = new Guid("cab51058-0996-4221-ba63-b841004e89dd"),
                            Description = "Awesome Debut album by A-Ha",
                            Title = "Hunting Hight and Low"
                        });
                });

            modelBuilder.Entity("Z_BandAPI.Entities.m_cls_Band", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Founded");

                    b.Property<string>("MainGenre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Bands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6b1eea43-5597-45a6-bdea-e68c60564247"),
                            Founded = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Heavy Metal",
                            Name = "Metallica"
                        },
                        new
                        {
                            Id = new Guid("a052a63d-fa53-44d5-a197-83089818a676"),
                            Founded = new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Rock",
                            Name = "Guns N Roses"
                        },
                        new
                        {
                            Id = new Guid("cb554ed6-8fa7-4b8d-8d90-55cc6a3e0074"),
                            Founded = new DateTime(1965, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Disco",
                            Name = "ABBA"
                        },
                        new
                        {
                            Id = new Guid("8e2f0a16-4c09-44c7-ba56-8dc62dfd792d"),
                            Founded = new DateTime(1991, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Alternative",
                            Name = "Oasis"
                        },
                        new
                        {
                            Id = new Guid("cab51058-0996-4221-ba63-b841004e89dd"),
                            Founded = new DateTime(1981, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MainGenre = "Pop",
                            Name = "A-ha"
                        });
                });

            modelBuilder.Entity("Z_BandAPI.Entities.m_cls_Album", b =>
                {
                    b.HasOne("Z_BandAPI.Entities.m_cls_Band", "Band")
                        .WithMany("Albums")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
