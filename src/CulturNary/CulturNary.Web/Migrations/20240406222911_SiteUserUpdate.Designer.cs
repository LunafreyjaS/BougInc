﻿// <auto-generated />
using System;
using CulturNary.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CulturNary.Web.Migrations
{
    [DbContext(typeof(CulturNaryDbContext))]
    [Migration("20240406222911_SiteUserUpdate")]
    partial class SiteUserUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CulturNary.Web.Models.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Img")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("img");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("person_id");

                    b.Property<string>("Tags")
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("tags");

                    b.HasKey("Id")
                        .HasName("PK__Collecti__3213E83FFE9DF17F");

                    b.HasIndex("PersonId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("CulturNary.Web.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IdentityId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("identity_id");

                    b.HasKey("Id")
                        .HasName("PK__Person__3213E83F37E58F11");

                    b.HasIndex(new[] { "IdentityId" }, "UQ__Person__D51AF5F55669F3EA")
                        .IsUnique()
                        .HasFilter("[identity_id] IS NOT NULL");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("CulturNary.Web.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CollectionId")
                        .HasColumnType("int")
                        .HasColumnName("collection_id");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Img")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("img");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("person_id");

                    b.HasKey("Id")
                        .HasName("PK__Recipes__3213E83F83A3281A");

                    b.HasIndex("CollectionId");

                    b.HasIndex("PersonId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("CulturNary.Web.Models.Collection", b =>
                {
                    b.HasOne("CulturNary.Web.Models.Person", "Person")
                        .WithMany("Collections")
                        .HasForeignKey("PersonId")
                        .HasConstraintName("FK__Collectio__perso__5629CD9C");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CulturNary.Web.Models.Recipe", b =>
                {
                    b.HasOne("CulturNary.Web.Models.Collection", "Collection")
                        .WithMany("Recipes")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Recipes__collect__59063A47");

                    b.HasOne("CulturNary.Web.Models.Person", "Person")
                        .WithMany("Recipes")
                        .HasForeignKey("PersonId")
                        .HasConstraintName("FK__Recipes__person___59FA5E80");

                    b.Navigation("Collection");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CulturNary.Web.Models.Collection", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("CulturNary.Web.Models.Person", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
