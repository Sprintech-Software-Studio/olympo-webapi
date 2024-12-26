﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using olympo_webapi.Infrastructure;

#nullable disable

namespace olympo_webapi.Migrations
{
    [DbContext(typeof(ConnectionContext))]
    [Migration("20241226214418_InitialDb")]
    partial class InitialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("olympo_webapi.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Day")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("VideoPath")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Day = 5,
                            Description = "Use uma pegada pronada, com as palmas das mãos voltadas para o corpo, para segurar a barra. Mantenha os joelhos flexionados na posição de agachamento, a coluna ereta e alinhada, e as pernas abertas com os pés apontados para fora.",
                            ImagePath = "",
                            Name = "Agachamento Terra",
                            VideoPath = ""
                        },
                        new
                        {
                            Id = 2,
                            Day = 5,
                            Description = "Sente-se em um banco e incline-se levemente, mantendo o peito erguido. Flexione o braço para levantar o halter até o ombro, pause por um segundo no topo e estenda lentamente o braço para retornar à posição inicial.",
                            ImagePath = "",
                            Name = "Rosca Concentrada",
                            VideoPath = ""
                        });
                });

            modelBuilder.Entity("olympo_webapi.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<int>("Repetitions")
                        .HasColumnType("integer");

                    b.Property<int>("Series")
                        .HasColumnType("integer");

                    b.Property<double>("Time")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("olympo_webapi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CPF = "123.456.789-01",
                            Email = "adm@gmail.com",
                            Name = "Admin",
                            Password = "password",
                            PhotoPath = "defaultphoto.jpg"
                        });
                });

            modelBuilder.Entity("olympo_webapi.Models.Exercise", b =>
                {
                    b.HasOne("olympo_webapi.Models.User", null)
                        .WithMany("Exercise")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("olympo_webapi.Models.Session", b =>
                {
                    b.HasOne("olympo_webapi.Models.Exercise", null)
                        .WithMany("Sessions")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("olympo_webapi.Models.Exercise", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("olympo_webapi.Models.User", b =>
                {
                    b.Navigation("Exercise");
                });
#pragma warning restore 612, 618
        }
    }
}
