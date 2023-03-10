// <auto-generated />
using System;
using GraphQlDemo.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphQlDemo.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230114131330_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GraphQlDemo.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("211b6c4b-5d98-4bbd-8e1e-25fa29c34524"),
                            Description = "Cash account for our users",
                            OwnerId = new Guid("9898dce2-5992-408b-8013-e3717d354d22"),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("2ca18854-8f5f-4fcb-a40e-d0f5859a2587"),
                            Description = "Savings account for our users",
                            OwnerId = new Guid("e6a61f15-e921-45fd-9659-a3185451eb54"),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("c123a587-b0d6-4a24-8679-a0dbb81cfb51"),
                            Description = "Income account for our users",
                            OwnerId = new Guid("e6a61f15-e921-45fd-9659-a3185451eb54"),
                            Type = 3
                        });
                });

            modelBuilder.Entity("GraphQlDemo.Entities.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9898dce2-5992-408b-8013-e3717d354d22"),
                            Address = "John Doe's address",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = new Guid("e6a61f15-e921-45fd-9659-a3185451eb54"),
                            Address = "Jane Doe's address",
                            Name = "Jane Doe"
                        });
                });

            modelBuilder.Entity("GraphQlDemo.Entities.Account", b =>
                {
                    b.HasOne("GraphQlDemo.Entities.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("GraphQlDemo.Entities.Owner", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
