﻿// <auto-generated />
using EFCDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFCDataAccess.Migrations
{
    [DbContext(typeof(CanPayDbAccess))]
    partial class CanPayDbAccessModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entity.Model.DebitCard", b =>
                {
                    b.Property<long>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("CardId"));

                    b.Property<int>("CVV")
                        .HasColumnType("integer");

                    b.Property<long>("CardNumber")
                        .HasMaxLength(16)
                        .HasColumnType("bigint");

                    b.Property<string>("ExpiryDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CardId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Entity.Model.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<long>("CardId")
                        .HasColumnType("bigint");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.HasIndex("CardId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entity.Model.User", b =>
                {
                    b.HasOne("Entity.Model.DebitCard", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });
#pragma warning restore 612, 618
        }
    }
}
