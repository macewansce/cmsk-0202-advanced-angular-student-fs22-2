﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonManagerApi.Data;

#nullable disable

namespace PersonManagerApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240711235736_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersonManagerApi.Models.GenderType", b =>
                {
                    b.Property<int>("GenderTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderTypeId"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderTypeId");

                    b.ToTable("GenderTypes");
                });

            modelBuilder.Entity("PersonManagerApi.Models.Person", b =>
                {
                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.HasIndex("GenderTypeId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PersonManagerApi.Models.Person", b =>
                {
                    b.HasOne("PersonManagerApi.Models.GenderType", "GenderType")
                        .WithMany("Persons")
                        .HasForeignKey("GenderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GenderType");
                });

            modelBuilder.Entity("PersonManagerApi.Models.GenderType", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
