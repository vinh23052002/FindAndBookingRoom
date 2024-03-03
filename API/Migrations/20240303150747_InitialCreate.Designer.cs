﻿// <auto-generated />
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(RoomContext))]
    [Migration("20240303150747_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Models.District", b =>
                {
                    b.Property<int>("districtID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("districtID"), 1L, 1);

                    b.Property<string>("districtName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("districtType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("provinceID")
                        .HasColumnType("int");

                    b.HasKey("districtID");

                    b.HasIndex("provinceID");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("API.Models.Image", b =>
                {
                    b.Property<int>("imageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("imageID"), 1L, 1);

                    b.Property<int>("order")
                        .HasColumnType("int");

                    b.Property<int>("roomID")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("imageID");

                    b.HasIndex("roomID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("API.Models.Message", b =>
                {
                    b.Property<int>("messageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("messageID"), 1L, 1);

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roomID")
                        .HasColumnType("int");

                    b.Property<string>("sendDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("messageID");

                    b.HasIndex("roomID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("API.Models.Province", b =>
                {
                    b.Property<int>("provinceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("provinceID"), 1L, 1);

                    b.Property<string>("provienceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("provinceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("provinceID");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("API.Models.Review", b =>
                {
                    b.Property<int>("roomID")
                        .HasColumnType("int");

                    b.Property<string>("userID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<float>("grade")
                        .HasColumnType("real");

                    b.Property<DateTime>("reviewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("roomID", "userID");

                    b.HasIndex("userID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Property<int>("roleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleID"), 1L, 1);

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("API.Models.Room", b =>
                {
                    b.Property<int>("roomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roomID"), 1L, 1);

                    b.Property<double>("area")
                        .HasColumnType("float");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("deleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<DateTime>("publicDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("wardID")
                        .HasColumnType("int");

                    b.HasKey("roomID");

                    b.HasIndex("userID");

                    b.HasIndex("wardID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("API.Models.RoomAmenities", b =>
                {
                    b.Property<int>("amenitiesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("amenitiesID"), 1L, 1);

                    b.Property<string>("amenitiesDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("amenitiesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("amenitiesPrice")
                        .HasColumnType("float");

                    b.HasKey("amenitiesID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("API.Models.RoomAmenitiesMapping", b =>
                {
                    b.Property<int>("roomID")
                        .HasColumnType("int");

                    b.Property<int>("amenitiesID")
                        .HasColumnType("int");

                    b.HasKey("roomID", "amenitiesID");

                    b.HasIndex("amenitiesID");

                    b.ToTable("RoomAmenitiesMappings");
                });

            modelBuilder.Entity("API.Models.User", b =>
                {
                    b.Property<string>("userID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("deleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleID")
                        .HasColumnType("int");

                    b.Property<int>("wardID")
                        .HasColumnType("int");

                    b.HasKey("userID");

                    b.HasIndex("roleID");

                    b.HasIndex("wardID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Models.Ward", b =>
                {
                    b.Property<int>("wardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("wardID"), 1L, 1);

                    b.Property<int>("districtID")
                        .HasColumnType("int");

                    b.Property<string>("wardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("wardType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("wardID");

                    b.HasIndex("districtID");

                    b.ToTable("Wards");
                });

            modelBuilder.Entity("API.Models.District", b =>
                {
                    b.HasOne("API.Models.Province", "Province")
                        .WithMany("Districts")
                        .HasForeignKey("provinceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("API.Models.Image", b =>
                {
                    b.HasOne("API.Models.Room", "Room")
                        .WithMany("Images")
                        .HasForeignKey("roomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("API.Models.Message", b =>
                {
                    b.HasOne("API.Models.Room", "Room")
                        .WithMany("Messages")
                        .HasForeignKey("roomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("API.Models.Review", b =>
                {
                    b.HasOne("API.Models.Room", "Room")
                        .WithMany("Reviews")
                        .HasForeignKey("roomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Models.Room", b =>
                {
                    b.HasOne("API.Models.User", "User")
                        .WithMany("Rooms")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("API.Models.Ward", "Ward")
                        .WithMany("Rooms")
                        .HasForeignKey("wardID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Ward");
                });

            modelBuilder.Entity("API.Models.RoomAmenitiesMapping", b =>
                {
                    b.HasOne("API.Models.RoomAmenities", "RoomAmenities")
                        .WithMany("RoomAmenitiesMappings")
                        .HasForeignKey("amenitiesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Room", "Room")
                        .WithMany("RoomAmenitiesMappings")
                        .HasForeignKey("roomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("RoomAmenities");
                });

            modelBuilder.Entity("API.Models.User", b =>
                {
                    b.HasOne("API.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("roleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Ward", "Ward")
                        .WithMany("Users")
                        .HasForeignKey("wardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Ward");
                });

            modelBuilder.Entity("API.Models.Ward", b =>
                {
                    b.HasOne("API.Models.District", "District")
                        .WithMany("Wards")
                        .HasForeignKey("districtID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("API.Models.District", b =>
                {
                    b.Navigation("Wards");
                });

            modelBuilder.Entity("API.Models.Province", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("API.Models.Room", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Messages");

                    b.Navigation("Reviews");

                    b.Navigation("RoomAmenitiesMappings");
                });

            modelBuilder.Entity("API.Models.RoomAmenities", b =>
                {
                    b.Navigation("RoomAmenitiesMappings");
                });

            modelBuilder.Entity("API.Models.User", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("API.Models.Ward", b =>
                {
                    b.Navigation("Rooms");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
