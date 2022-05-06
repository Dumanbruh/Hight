using HightBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Estabilishment> Estabilishments { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EstabilishmentImage> EstabilishmentImages { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<EstabilishmentType> estabilishmentTypes { get; set; }

        public DbSet<Comment> comments { get; set; }

        public DbSet<usersFavourites> usersFavourites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Estabilishment>()
                .HasData(
                    new Estabilishment { 
                        estabilishmentId = 1,
                        name = "Wyndham Garden Astana",
                        description = "Отель Wyndham Garden Astana расположен в городе Астана, в 5 минутах ходьбы от торгового центра MEGA Silk Way и места проведения международной выставки «Астана ЭКСПО-2017». К услугам гостей бесплатный Wi-Fi, фитнес-центр, спа-центр и конференц-залы. На территории открыты ресторан и бар. Номера оформлены в современном стиле. В распоряжении гостей кровать размера «king-size», письменный стол, телевизор с плоским экраном, сейф, гладильные принадлежности, высокотехнологичная система климат-контроля и бесплатные принадлежности для чая/кофе. Ванная комната отделана мрамором. В числе удобств круглосуточная стойка регистрации, банкомат, камера хранения багажа и бизнес-центр. Предоставляются услуги химчистки. В отеле можно поиграть в бильярд и бесплатно взять напрокат велосипед. Поездка от отеля Wyndham Garden Astana до монумента Байтерек займет 15 минут, а до международного аэропорта Нурсултан Назарбаев — 7 минут.",
                        website = "http://wyndhamgardenastana.com/ru/",
                        location = "https://goo.gl/maps/BzA7ke8LvRHbEK5t7",
                        reviewNum = 0,
                        overallRating = 0,
                        locationRating = 0,
                        serviceRating = 0,
                        price_qualityRating = 0
                    }
                );

            modelBuilder.Entity<Event>()
                .HasData(
                    new Event { 
                        eventID = 1,
                        title = "Example",
                        time = DateTime.Today,
                        price = 0,
                        location = null,
                        eventImage = null,
                        estabilishmentID = 1
                    },

                    new Event
                    {
                        eventID = 2,
                        title = "Example2",
                        time = DateTime.Today,
                        price = 0,
                        location = null,
                        eventImage = null,
                        estabilishmentID = 1
                    },

                    new Event
                    {
                        eventID = 3,
                        title = "Example3",
                        time = DateTime.Today,
                        price = 0,
                        location = null,
                        eventImage = null,
                        estabilishmentID = 1
                    }

                );
        }

    }
}
