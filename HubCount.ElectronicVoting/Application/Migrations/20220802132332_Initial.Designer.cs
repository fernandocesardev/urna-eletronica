﻿// <auto-generated />
using System;
using Application.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Application.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220802132332_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Application.Domain.Candidates.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountVote")
                        .HasColumnType("int");

                    b.Property<int>("CandidateLegend")
                        .HasColumnType("int");

                    b.Property<Guid>("ElectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ViceName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.HasIndex("ElectionId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("Application.Domain.Candidates.Election", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Elections");
                });

            modelBuilder.Entity("Application.Domain.Candidates.Electorate", b =>
                {
                    b.Property<string>("SingleVoterTitle")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("SingleVoterTitle");

                    b.ToTable("Electorates");

                    b.HasData(
                        new
                        {
                            SingleVoterTitle = "007321"
                        });
                });

            modelBuilder.Entity("Application.Domain.Votes.Vote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RegisterVote")
                        .HasColumnType("datetime2");

                    b.Property<string>("SingleVoterTitle")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("StatusVote")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TotalCandidateVote")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("CandidateVote", b =>
                {
                    b.Property<Guid>("CandidatesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VotesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CandidatesId", "VotesId");

                    b.HasIndex("VotesId");

                    b.ToTable("VoteCandidates", (string)null);
                });

            modelBuilder.Entity("Application.Domain.Candidates.Candidate", b =>
                {
                    b.HasOne("Application.Domain.Candidates.Election", "Election")
                        .WithMany()
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Election");
                });

            modelBuilder.Entity("CandidateVote", b =>
                {
                    b.HasOne("Application.Domain.Candidates.Candidate", null)
                        .WithMany()
                        .HasForeignKey("CandidatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Domain.Votes.Vote", null)
                        .WithMany()
                        .HasForeignKey("VotesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}