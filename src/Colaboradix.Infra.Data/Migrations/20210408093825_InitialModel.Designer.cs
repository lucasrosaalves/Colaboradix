﻿// <auto-generated />
using System;
using Colaboradix.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Colaboradix.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210408093825_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CS_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Colaboradix.Domain.Entities.Cycle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("cycles");
                });

            modelBuilder.Entity("Colaboradix.Domain.Entities.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CycleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<byte>("Quantity")
                        .HasMaxLength(3)
                        .HasColumnType("smallint");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CycleId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("feedbacks");
                });

            modelBuilder.Entity("Colaboradix.Domain.Entities.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uuid");

                    b.Property<byte>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((byte)2)
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("members");
                });

            modelBuilder.Entity("Colaboradix.Domain.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .HasMaxLength(220)
                        .HasColumnType("character varying(220)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("Colaboradix.Domain.Entities.Cycle", b =>
                {
                    b.HasOne("Colaboradix.Domain.Entities.Team", "Team")
                        .WithMany("Cycles")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Colaboradix.Domain.Entities.Feedback", b =>
                {
                    b.HasOne("Colaboradix.Domain.Entities.Cycle", "Cycle")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Colaboradix.Domain.Entities.Member", "Receiver")
                        .WithMany("ReceivedFeedbacks")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Colaboradix.Domain.Entities.Member", "Sender")
                        .WithMany("SubmittedFeedbacks")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cycle");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Colaboradix.Domain.Entities.Member", b =>
                {
                    b.HasOne("Colaboradix.Domain.Entities.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Colaboradix.Domain.Entities.Cycle", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("Colaboradix.Domain.Entities.Member", b =>
                {
                    b.Navigation("ReceivedFeedbacks");

                    b.Navigation("SubmittedFeedbacks");
                });

            modelBuilder.Entity("Colaboradix.Domain.Entities.Team", b =>
                {
                    b.Navigation("Cycles");

                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
