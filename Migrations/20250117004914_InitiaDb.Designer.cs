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
    [Migration("20250117004914_InitiaDb")]
    partial class InitiaDb
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

                    b.Property<int>("UserId")
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
                            ImagePath = "images/exe2.png",
                            Name = "Agachamento Terra",
                            UserId = 3,
                            VideoPath = "videos/execucao.mp4"
                        },
                        new
                        {
                            Id = 2,
                            Day = 5,
                            Description = "Sente-se em um banco e incline-se levemente, mantendo o peito erguido. Flexione o braço para levantar o halter até o ombro, pause por um segundo no topo e estenda lentamente o braço para retornar à posição inicial.",
                            ImagePath = "images/exe.png",
                            Name = "Rosca Concentrada",
                            UserId = 4,
                            VideoPath = "videos/execucao.mp4"
                        },
                        new
                        {
                            Id = 3,
                            Day = 1,
                            Description = "Deite-se em um banco plano, segure a barra com uma pegada média e abaixe-a até tocar levemente o peito. Empurre a barra para cima até que os braços estejam completamente estendidos.",
                            ImagePath = "images/exe3.png",
                            Name = "Supino Reto",
                            UserId = 3,
                            VideoPath = "videos/execucao.mp4"
                        },
                        new
                        {
                            Id = 4,
                            Day = 3,
                            Description = "Sente-se no aparelho de puxada e segure a barra com uma pegada ampla. Puxe a barra em direção ao peito enquanto mantém a coluna reta, contraindo os músculos das costas. Retorne à posição inicial de forma controlada.",
                            ImagePath = "images/exe4.png",
                            Name = "Puxada Aberta",
                            UserId = 3,
                            VideoPath = "videos/execucao.mp4"
                        },
                        new
                        {
                            Id = 5,
                            Day = 5,
                            Description = "Fique em pé com os pés na largura dos ombros, segure a barra com uma pegada mista e mantenha a coluna reta. Levante a barra do chão até a altura do quadril, mantendo o controle, e abaixe-a lentamente.",
                            ImagePath = "images/exe5.png",
                            Name = "Levantamento Terra",
                            UserId = 4,
                            VideoPath = "videos/execucao.mp4"
                        });
                });

            modelBuilder.Entity("olympo_webapi.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Breaks")
                        .HasColumnType("double precision");

                    b.Property<int>("ExerciseId")
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Breaks = 60.0,
                            ExerciseId = 1,
                            Repetitions = 10,
                            Series = 3,
                            Time = 5.0
                        },
                        new
                        {
                            Id = 2,
                            Breaks = 45.0,
                            ExerciseId = 2,
                            Repetitions = 12,
                            Series = 4,
                            Time = 6.0
                        },
                        new
                        {
                            Id = 3,
                            Breaks = 90.0,
                            ExerciseId = 3,
                            Repetitions = 8,
                            Series = 5,
                            Time = 7.5
                        },
                        new
                        {
                            Id = 4,
                            Breaks = 30.0,
                            ExerciseId = 4,
                            Repetitions = 15,
                            Series = 3,
                            Time = 4.5
                        },
                        new
                        {
                            Id = 5,
                            Breaks = 120.0,
                            ExerciseId = 5,
                            Repetitions = 6,
                            Series = 6,
                            Time = 10.0
                        });
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

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CPF = "123.456.789-01",
                            Email = "adm@gmail.com",
                            ImagePath = "defaultphoto.jpg",
                            Name = "Admin",
                            Password = "AQAAAAIAAYagAAAAELQiroQuBETEzbi+6watlapd/T/HDs7+tUXMfvVsQ5iJkkqstVyohnQCC1EgZQzYPg==",
                            Type = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            CPF = "987.654.321-09",
                            Email = "jose@gmail.com",
                            ImagePath = "defaultphoto.jpg",
                            Name = "José",
                            Password = "AQAAAAIAAYagAAAAEEWvxgDNSyImvHes32BvugcsZMfM+OmMp/HbVaX7is7cvjJ+xHvpbl+ZK93fOZzuGg==",
                            Type = "Professor"
                        },
                        new
                        {
                            Id = 3,
                            CPF = "123.456.789-01",
                            Email = "maria@gmail.com",
                            ImagePath = "defaultphoto.jpg",
                            Name = "Maria",
                            Password = "AQAAAAIAAYagAAAAEMxiwgUpT1xx1qQFQ6dzIk4QzB/jneys0wwDwWgFKJtSDB8u0EHMhqQcg00KdToSrQ==",
                            Type = "Aluno"
                        },
                        new
                        {
                            Id = 4,
                            CPF = "123.456.789-01",
                            Email = "joao@gmail.com",
                            ImagePath = "defaultphoto.jpg",
                            Name = "João",
                            Password = "AQAAAAIAAYagAAAAEEZms7z0OZCi6JI27Z9/3aMYZn5UL9u7VYCFAzAEx63BNjNm+SdzvnSxJegF9e1fBQ==",
                            Type = "Aluno"
                        });
                });

            modelBuilder.Entity("olympo_webapi.Models.Exercise", b =>
                {
                    b.HasOne("olympo_webapi.Models.User", "User")
                        .WithMany("Exercise")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("olympo_webapi.Models.Session", b =>
                {
                    b.HasOne("olympo_webapi.Models.Exercise", "Exercise")
                        .WithMany("Sessions")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
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
