﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WhatsAppMessageSender;

namespace WhatsAppMessageSender.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    partial class AppDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WhatsAppMessageSender.Compagain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CampaignStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("No_Of_Participants")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Compagains");
                });

            modelBuilder.Entity("WhatsAppMessageSender.CompagainDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("C_Id")
                        .HasColumnType("integer");

                    b.Property<long>("Number")
                        .HasColumnType("bigint");

                    b.Property<bool>("isSend")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("C_Id");

                    b.ToTable("CompagainDetail");
                });

            modelBuilder.Entity("WhatsAppMessageSender.CompagainDetail", b =>
                {
                    b.HasOne("WhatsAppMessageSender.Compagain", "Compagain")
                        .WithMany()
                        .HasForeignKey("C_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}