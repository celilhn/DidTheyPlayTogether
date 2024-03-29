﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DidTheyPlayTogetherDbContext))]
    partial class DidTheyPlayTogetherDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Contribution", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.ToTable("Contributions");
                });

            modelBuilder.Entity("Domain.Models.Famous", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Age")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DateBirh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Education")
                        .HasColumnType("varchar(200)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("InsertionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Popularity")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePath")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Size")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("SourceID")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Weight")
                        .HasColumnType("varchar(200)");

                    b.HasKey("ID");

                    b.ToTable("Famouses");
                });

            modelBuilder.Entity("Domain.Models.Film", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Director")
                        .HasColumnType("varchar(75)");

                    b.Property<int>("FilmCategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Note")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("OriginalName")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PosterPath")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Producer")
                        .HasColumnType("varchar(400)");

                    b.Property<int>("ReleaseDate")
                        .HasColumnType("int");

                    b.Property<int>("SourceID")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("Subject")
                        .HasColumnType("varchar(1500)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("Domain.Models.PlayedFilm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Character")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("ContributionID")
                        .HasColumnType("int");

                    b.Property<int>("FamousID")
                        .HasColumnType("int");

                    b.Property<int>("FilmID")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.ToTable("PlayedFilms");
                });

            modelBuilder.Entity("Domain.Models.PlayedSerie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Character")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("FamousID")
                        .HasColumnType("int");

                    b.Property<int>("FilmID")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Year")
                        .HasColumnType("varchar(4)");

                    b.HasKey("ID");

                    b.ToTable("PlayedSeries");
                });

            modelBuilder.Entity("Domain.Models.Serie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Channel")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Country")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1200)");

                    b.Property<int>("FirstEpisodeAirDate")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Language")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("LastEpisodeAirDate")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("NumberofEpisodes")
                        .HasColumnType("int");

                    b.Property<int>("NumberofSeasons")
                        .HasColumnType("int");

                    b.Property<string>("OriginalName")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PosterPath")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Producer")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Siciation")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("SourceID")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.ToTable("Series");
                });
#pragma warning restore 612, 618
        }
    }
}
