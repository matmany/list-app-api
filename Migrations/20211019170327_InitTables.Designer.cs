﻿// <auto-generated />
using System;
using ListApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ListApi.Migrations
{
    [DbContext(typeof(ListApiContext))]
    [Migration("20211019170327_InitTables")]
    partial class InitTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-rc.2.21480.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ListApi.Models.Artefact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("ListID")
                        .HasColumnType("integer")
                        .HasColumnName("list_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("notes");

                    b.Property<int?>("Score")
                        .HasColumnType("integer")
                        .HasColumnName("score");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.Property<string>("UrlImg")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url_img");

                    b.Property<int>("UserID")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("ID")
                        .HasName("pk_artefacts");

                    b.HasIndex("ListID")
                        .HasDatabaseName("ix_artefacts_list_id");

                    b.HasIndex("UserID")
                        .HasDatabaseName("ix_artefacts_user_id");

                    b.ToTable("artefacts", (string)null);
                });

            modelBuilder.Entity("ListApi.Models.ArtefactTag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("ArtefactId")
                        .HasColumnType("integer")
                        .HasColumnName("artefact_id");

                    b.Property<int>("TagId")
                        .HasColumnType("integer")
                        .HasColumnName("tag_id");

                    b.HasKey("ID")
                        .HasName("pk_artefact_tags");

                    b.HasIndex("ArtefactId")
                        .HasDatabaseName("ix_artefact_tags_artefact_id");

                    b.HasIndex("TagId")
                        .HasDatabaseName("ix_artefact_tags_tag_id");

                    b.ToTable("artefact_tags", (string)null);
                });

            modelBuilder.Entity("ListApi.Models.List", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<int>("ListGroupID")
                        .HasColumnType("integer")
                        .HasColumnName("list_group_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.Property<int>("UserID")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<bool>("active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.HasKey("ID")
                        .HasName("pk_lists");

                    b.HasIndex("ListGroupID")
                        .HasDatabaseName("ix_lists_list_group_id");

                    b.HasIndex("UserID")
                        .HasDatabaseName("ix_lists_user_id");

                    b.ToTable("lists", (string)null);
                });

            modelBuilder.Entity("ListApi.Models.ListGroup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.Property<int>("UserID")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<bool>("active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.HasKey("ID")
                        .HasName("pk_list_groups");

                    b.HasIndex("UserID")
                        .HasDatabaseName("ix_list_groups_user_id");

                    b.ToTable("list_groups", (string)null);
                });

            modelBuilder.Entity("ListApi.Models.Tag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_tags");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_tags_user_id");

                    b.ToTable("tags", (string)null);
                });

            modelBuilder.Entity("ListApi.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<int>("TotalItens")
                        .HasColumnType("integer")
                        .HasColumnName("total_itens");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.Property<bool>("active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.HasKey("ID")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ListApi.Models.Artefact", b =>
                {
                    b.HasOne("ListApi.Models.List", "List")
                        .WithMany()
                        .HasForeignKey("ListID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_artefacts_lists_list_id");

                    b.HasOne("ListApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_artefacts_users_user_id");

                    b.Navigation("List");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ListApi.Models.ArtefactTag", b =>
                {
                    b.HasOne("ListApi.Models.Artefact", "Artefact")
                        .WithMany("ArtefactTags")
                        .HasForeignKey("ArtefactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_artefact_tags_artefacts_artefact_id");

                    b.HasOne("ListApi.Models.Tag", "Tag")
                        .WithMany("ArtefactTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_artefact_tags_tags_tag_id");

                    b.Navigation("Artefact");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("ListApi.Models.List", b =>
                {
                    b.HasOne("ListApi.Models.ListGroup", "ListGroup")
                        .WithMany("Lists")
                        .HasForeignKey("ListGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_lists_list_groups_list_group_id");

                    b.HasOne("ListApi.Models.User", "User")
                        .WithMany("List")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_lists_users_user_id");

                    b.Navigation("ListGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ListApi.Models.ListGroup", b =>
                {
                    b.HasOne("ListApi.Models.User", "User")
                        .WithMany("ListGroups")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_list_groups_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ListApi.Models.Tag", b =>
                {
                    b.HasOne("ListApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tags_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ListApi.Models.Artefact", b =>
                {
                    b.Navigation("ArtefactTags");
                });

            modelBuilder.Entity("ListApi.Models.ListGroup", b =>
                {
                    b.Navigation("Lists");
                });

            modelBuilder.Entity("ListApi.Models.Tag", b =>
                {
                    b.Navigation("ArtefactTags");
                });

            modelBuilder.Entity("ListApi.Models.User", b =>
                {
                    b.Navigation("List");

                    b.Navigation("ListGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
