﻿// <auto-generated />
using System;
using EFCDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFCDataAccess.Migrations
{
    [DbContext(typeof(CanPayDbAccess))]
    [Migration("20230519125816_AddedBillTransactionEntityTable")]
    partial class AddedBillTransactionEntityTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("CanPay")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entity.Model.DebitCardEntity", b =>
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

                    b.ToTable("Cards", "CanPay");
                });

            modelBuilder.Entity("Entity.Model.NotificationEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReceiverUsername")
                        .HasColumnType("text");

                    b.Property<string>("SenderUsername")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverUsername");

                    b.HasIndex("SenderUsername");

                    b.ToTable("Notifications", "CanPay");
                });

            modelBuilder.Entity("Entity.Model.RequestEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<string>("RequestReceiverUsername")
                        .HasColumnType("text");

                    b.Property<string>("RequestSenderUsername")
                        .HasColumnType("text");

                    b.Property<string>("RequestedDate")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RequestReceiverUsername");

                    b.HasIndex("RequestSenderUsername");

                    b.ToTable("Requests", "CanPay");
                });

            modelBuilder.Entity("Entity.Model.TransactionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int?>("Amount")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReceiverUsername")
                        .HasColumnType("text");

                    b.Property<string>("SenderUsername")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverUsername");

                    b.HasIndex("SenderUsername");

                    b.ToTable("Transactions", "CanPay");
                });

            modelBuilder.Entity("Entity.Model.UserEntity", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<int>("Balance")
                        .HasColumnType("integer");

                    b.Property<long>("CardId")
                        .HasColumnType("bigint");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.HasIndex("CardId");

                    b.ToTable("Users", "CanPay");
                });

            modelBuilder.Entity("Entity.Model.NotificationEntity", b =>
                {
                    b.HasOne("Entity.Model.UserEntity", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverUsername");

                    b.HasOne("Entity.Model.UserEntity", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderUsername");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Entity.Model.RequestEntity", b =>
                {
                    b.HasOne("Entity.Model.UserEntity", "RequestReceiver")
                        .WithMany()
                        .HasForeignKey("RequestReceiverUsername");

                    b.HasOne("Entity.Model.UserEntity", "RequestSender")
                        .WithMany()
                        .HasForeignKey("RequestSenderUsername");

                    b.Navigation("RequestReceiver");

                    b.Navigation("RequestSender");
                });

            modelBuilder.Entity("Entity.Model.TransactionEntity", b =>
                {
                    b.HasOne("Entity.Model.UserEntity", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverUsername");

                    b.HasOne("Entity.Model.UserEntity", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderUsername");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Entity.Model.UserEntity", b =>
                {
                    b.HasOne("Entity.Model.DebitCardEntity", "Card")
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
