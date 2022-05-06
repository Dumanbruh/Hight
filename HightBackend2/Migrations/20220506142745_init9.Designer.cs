﻿// <auto-generated />
using System;
using HightBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HightBackend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220506142745_init9")]
    partial class init9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("HightBackend.Models.Comment", b =>
                {
                    b.Property<int>("commentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("comment")
                        .HasColumnType("text");

                    b.Property<int>("estabilishmentID")
                        .HasColumnType("integer");

                    b.Property<float?>("locationRating")
                        .HasColumnType("real");

                    b.Property<float?>("overallRating")
                        .HasColumnType("real");

                    b.Property<float?>("price_qualityRating")
                        .HasColumnType("real");

                    b.Property<DateTime>("publishedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float?>("serviceRating")
                        .HasColumnType("real");

                    b.Property<int>("userID")
                        .HasColumnType("integer");

                    b.HasKey("commentID");

                    b.HasIndex("estabilishmentID");

                    b.HasIndex("userID");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("HightBackend.Models.Estabilishment", b =>
                {
                    b.Property<int>("estabilishmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("location")
                        .HasColumnType("text");

                    b.Property<float?>("locationRating")
                        .HasColumnType("real");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float?>("overallRating")
                        .HasColumnType("real");

                    b.Property<float?>("price_qualityRating")
                        .HasColumnType("real");

                    b.Property<float?>("reviewNum")
                        .HasColumnType("real");

                    b.Property<float?>("serviceRating")
                        .HasColumnType("real");

                    b.Property<int?>("typeID")
                        .HasColumnType("integer");

                    b.Property<string>("website")
                        .HasColumnType("text");

                    b.HasKey("estabilishmentId");

                    b.HasIndex("typeID");

                    b.ToTable("Estabilishments");

                    b.HasData(
                        new
                        {
                            estabilishmentId = 1,
                            description = "Отель Wyndham Garden Astana расположен в городе Астана, в 5 минутах ходьбы от торгового центра MEGA Silk Way и места проведения международной выставки «Астана ЭКСПО-2017». К услугам гостей бесплатный Wi-Fi, фитнес-центр, спа-центр и конференц-залы. На территории открыты ресторан и бар. Номера оформлены в современном стиле. В распоряжении гостей кровать размера «king-size», письменный стол, телевизор с плоским экраном, сейф, гладильные принадлежности, высокотехнологичная система климат-контроля и бесплатные принадлежности для чая/кофе. Ванная комната отделана мрамором. В числе удобств круглосуточная стойка регистрации, банкомат, камера хранения багажа и бизнес-центр. Предоставляются услуги химчистки. В отеле можно поиграть в бильярд и бесплатно взять напрокат велосипед. Поездка от отеля Wyndham Garden Astana до монумента Байтерек займет 15 минут, а до международного аэропорта Нурсултан Назарбаев — 7 минут.",
                            location = "https://goo.gl/maps/BzA7ke8LvRHbEK5t7",
                            locationRating = 0f,
                            name = "Wyndham Garden Astana",
                            overallRating = 0f,
                            price_qualityRating = 0f,
                            reviewNum = 0f,
                            serviceRating = 0f,
                            website = "http://wyndhamgardenastana.com/ru/"
                        });
                });

            modelBuilder.Entity("HightBackend.Models.EstabilishmentImage", b =>
                {
                    b.Property<int>("imageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("estabilishmentID")
                        .HasColumnType("integer");

                    b.HasKey("imageID");

                    b.HasIndex("estabilishmentID");

                    b.ToTable("EstabilishmentImages");
                });

            modelBuilder.Entity("HightBackend.Models.EstabilishmentType", b =>
                {
                    b.Property<int>("typeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("typeName")
                        .HasColumnType("text");

                    b.HasKey("typeID");

                    b.ToTable("estabilishmentTypes");
                });

            modelBuilder.Entity("HightBackend.Models.Event", b =>
                {
                    b.Property<int>("eventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<int>("estabilishmentID")
                        .HasColumnType("integer");

                    b.Property<string>("eventImage")
                        .HasColumnType("text");

                    b.Property<string>("location")
                        .HasColumnType("text");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("eventID");

                    b.HasIndex("estabilishmentID");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            eventID = 1,
                            estabilishmentID = 1,
                            price = 0f,
                            time = new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Local),
                            title = "Example"
                        },
                        new
                        {
                            eventID = 2,
                            estabilishmentID = 1,
                            price = 0f,
                            time = new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Local),
                            title = "Example2"
                        },
                        new
                        {
                            eventID = 3,
                            estabilishmentID = 1,
                            price = 0f,
                            time = new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Local),
                            title = "Example3"
                        });
                });

            modelBuilder.Entity("HightBackend.Models.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.HasKey("userID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HightBackend.Models.usersFavourites", b =>
                {
                    b.Property<int>("favID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("estabilishmentID")
                        .HasColumnType("integer");

                    b.Property<int>("userID")
                        .HasColumnType("integer");

                    b.HasKey("favID");

                    b.HasIndex("estabilishmentID");

                    b.HasIndex("userID");

                    b.ToTable("usersFavourites");
                });

            modelBuilder.Entity("HightBackend.Models.Comment", b =>
                {
                    b.HasOne("HightBackend.Models.Estabilishment", "estabilishment")
                        .WithMany("comments")
                        .HasForeignKey("estabilishmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HightBackend.Models.User", "user")
                        .WithMany("comments")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estabilishment");

                    b.Navigation("user");
                });

            modelBuilder.Entity("HightBackend.Models.Estabilishment", b =>
                {
                    b.HasOne("HightBackend.Models.EstabilishmentType", "type")
                        .WithMany()
                        .HasForeignKey("typeID");

                    b.Navigation("type");
                });

            modelBuilder.Entity("HightBackend.Models.EstabilishmentImage", b =>
                {
                    b.HasOne("HightBackend.Models.Estabilishment", "Estabilishment")
                        .WithMany("estabilishmentImage")
                        .HasForeignKey("estabilishmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estabilishment");
                });

            modelBuilder.Entity("HightBackend.Models.Event", b =>
                {
                    b.HasOne("HightBackend.Models.Estabilishment", "estabilishment")
                        .WithMany("events")
                        .HasForeignKey("estabilishmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estabilishment");
                });

            modelBuilder.Entity("HightBackend.Models.usersFavourites", b =>
                {
                    b.HasOne("HightBackend.Models.Estabilishment", "estabilishment")
                        .WithMany()
                        .HasForeignKey("estabilishmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HightBackend.Models.User", "user")
                        .WithMany("favourites")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estabilishment");

                    b.Navigation("user");
                });

            modelBuilder.Entity("HightBackend.Models.Estabilishment", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("estabilishmentImage");

                    b.Navigation("events");
                });

            modelBuilder.Entity("HightBackend.Models.User", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("favourites");
                });
#pragma warning restore 612, 618
        }
    }
}
