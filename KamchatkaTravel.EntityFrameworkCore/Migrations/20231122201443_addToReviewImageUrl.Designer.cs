﻿// <auto-generated />
using System;
using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KamchatkaTravel.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(KamchatkaTravelDbContext))]
    [Migration("20231122201443_addToReviewImageUrl")]
    partial class addToReviewImageUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KamchatkaTravel.Domain.ClientRequests.ClientRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.Property<Guid?>("TourId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isProcessed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("TourId");

                    b.HasIndex("Visible");

                    b.ToTable("ClientRequest", "Travel");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.Reviews.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(64)");

                    b.Property<byte[]>("LogoImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LogoImageUrl")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Visible");

                    b.ToTable("Review", "Travel");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.Tours.Day", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<Guid>("TourId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("TourId");

                    b.HasIndex("Visible");

                    b.ToTable("Day", "Travel");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.Tours.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Img")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("Ord")
                        .HasColumnType("int");

                    b.Property<Guid>("TourId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("TourId");

                    b.HasIndex("Visible");

                    b.ToTable("Image", "Travel");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.Tours.Include", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid>("TourId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("isInclude")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("TourId");

                    b.HasIndex("Visible");

                    b.ToTable("Include", "Travel");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.Tours.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(512)");

                    b.Property<int?>("Ord")
                        .HasColumnType("int");

                    b.Property<Guid?>("TourId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("TourId");

                    b.HasIndex("Visible");

                    b.ToTable("Question", "Travel");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.Tours.Tour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("DescriptionImage")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LinkEquipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("LogoImage")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("NightType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(16, 2)");

                    b.Property<int>("SeasonType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Tagline")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("UpdateDt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Visible");

                    b.ToTable("Tour", "Travel");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.Tours.View", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid?>("TourId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Visible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("TourId");

                    b.HasIndex("Visible");

                    b.ToTable("View", "Travel");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.ClientRequests.ClientRequest", b =>
                {
                    b.HasOne("KamchatkaTravel.Domain.Tours.Tour", "tour")
                        .WithMany()
                        .HasForeignKey("TourId");

                    b.Navigation("tour");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.Tours.Day", b =>
                {
                    b.HasOne("KamchatkaTravel.Domain.Tours.Tour", "tour")
                        .WithMany("Days")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tour");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.Tours.Image", b =>
                {
                    b.HasOne("KamchatkaTravel.Domain.Tours.Tour", "tour")
                        .WithMany("Images")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tour");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.Tours.Include", b =>
                {
                    b.HasOne("KamchatkaTravel.Domain.Tours.Tour", "tour")
                        .WithMany("Includes")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tour");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.Tours.Question", b =>
                {
                    b.HasOne("KamchatkaTravel.Domain.Tours.Tour", "tour")
                        .WithMany("Questions")
                        .HasForeignKey("TourId");

                    b.Navigation("tour");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.Tours.View", b =>
                {
                    b.HasOne("KamchatkaTravel.Domain.Tours.Tour", "tour")
                        .WithMany("Views")
                        .HasForeignKey("TourId");

                    b.Navigation("tour");
                });

            modelBuilder.Entity("KamchatkaTravel.Domain.Tours.Tour", b =>
                {
                    b.Navigation("Days");

                    b.Navigation("Images");

                    b.Navigation("Includes");

                    b.Navigation("Questions");

                    b.Navigation("Views");
                });
#pragma warning restore 612, 618
        }
    }
}
