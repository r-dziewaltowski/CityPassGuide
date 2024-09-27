﻿// <auto-generated />
using System;
using CityPassGuide.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityPassGuide.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240926233107_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("AttractionCityCard", b =>
                {
                    b.Property<int>("AttractionsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityCardsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AttractionsId", "CityCardsId");

                    b.HasIndex("CityCardsId");

                    b.ToTable("AttractionCityCard");

                    b.HasData(
                        new
                        {
                            AttractionsId = 1,
                            CityCardsId = 1
                        },
                        new
                        {
                            AttractionsId = 2,
                            CityCardsId = 1
                        },
                        new
                        {
                            AttractionsId = 3,
                            CityCardsId = 1
                        },
                        new
                        {
                            AttractionsId = 4,
                            CityCardsId = 2
                        },
                        new
                        {
                            AttractionsId = 5,
                            CityCardsId = 2
                        },
                        new
                        {
                            AttractionsId = 7,
                            CityCardsId = 3
                        },
                        new
                        {
                            AttractionsId = 8,
                            CityCardsId = 3
                        },
                        new
                        {
                            AttractionsId = 9,
                            CityCardsId = 3
                        });
                });

            modelBuilder.Entity("CityPassGuide.Core.CityCardAggregate.Attraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId", "Name")
                        .IsUnique();

                    b.ToTable("Attractions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "London Eye",
                            Price = 40m
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Name = "Tate Gallery",
                            Price = 30m
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            Name = "Tower of London",
                            Price = 35m
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            Name = "Louvre Museum",
                            Price = 50m
                        },
                        new
                        {
                            Id = 5,
                            CityId = 2,
                            Name = "Eiffel Tower",
                            Price = 60m
                        },
                        new
                        {
                            Id = 6,
                            CityId = 2,
                            Name = "Arc de Triomphe",
                            Price = 35m
                        },
                        new
                        {
                            Id = 7,
                            CityId = 3,
                            Name = "Wawel Castle",
                            Price = 30m
                        },
                        new
                        {
                            Id = 8,
                            CityId = 3,
                            Name = "Sukiennice",
                            Price = 25m
                        },
                        new
                        {
                            Id = 9,
                            CityId = 3,
                            Name = "Mariacki Church",
                            Price = 20m
                        });
                });

            modelBuilder.Entity("CityPassGuide.Core.CityCardAggregate.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("DailyTransportCost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId", "Name")
                        .IsUnique();

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            DailyTransportCost = 25m,
                            Name = "London"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            DailyTransportCost = 30m,
                            Name = "Paris"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 3,
                            DailyTransportCost = 20m,
                            Name = "Krakow"
                        });
                });

            modelBuilder.Entity("CityPassGuide.Core.CityCardAggregate.CityCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CoversTransport")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DurationInDays")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId", "Name")
                        .IsUnique();

                    b.ToTable("CityCards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            CoversTransport = false,
                            DurationInDays = 5,
                            Name = "London Card"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 2,
                            CoversTransport = true,
                            DurationInDays = 3,
                            Name = "Paris Card"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 3,
                            CoversTransport = true,
                            DurationInDays = 2,
                            Name = "Krakow Card"
                        });
                });

            modelBuilder.Entity("CityPassGuide.Core.CityCardAggregate.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "United Kingdom"
                        },
                        new
                        {
                            Id = 2,
                            Name = "France"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Poland"
                        });
                });

            modelBuilder.Entity("CityPassGuide.Core.ContributorAggregate.Contributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Contributors");
                });

            modelBuilder.Entity("AttractionCityCard", b =>
                {
                    b.HasOne("CityPassGuide.Core.CityCardAggregate.Attraction", null)
                        .WithMany()
                        .HasForeignKey("AttractionsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CityPassGuide.Core.CityCardAggregate.CityCard", null)
                        .WithMany()
                        .HasForeignKey("CityCardsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CityPassGuide.Core.CityCardAggregate.Attraction", b =>
                {
                    b.HasOne("CityPassGuide.Core.CityCardAggregate.City", null)
                        .WithMany("Attractions")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CityPassGuide.Core.CityCardAggregate.City", b =>
                {
                    b.HasOne("CityPassGuide.Core.CityCardAggregate.Country", null)
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CityPassGuide.Core.CityCardAggregate.CityCard", b =>
                {
                    b.HasOne("CityPassGuide.Core.CityCardAggregate.City", null)
                        .WithMany("CityCards")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CityPassGuide.Core.CityCardAggregate.DateRange", "ValidityPeriod", b1 =>
                        {
                            b1.Property<int>("CityCardId")
                                .HasColumnType("INTEGER");

                            b1.Property<DateOnly>("EndDate")
                                .HasColumnType("TEXT");

                            b1.Property<DateOnly>("StartDate")
                                .HasColumnType("TEXT");

                            b1.HasKey("CityCardId");

                            b1.ToTable("CityCards");

                            b1.WithOwner()
                                .HasForeignKey("CityCardId");

                            b1.HasData(
                                new
                                {
                                    CityCardId = 1,
                                    EndDate = new DateOnly(9999, 12, 31),
                                    StartDate = new DateOnly(2024, 1, 1)
                                },
                                new
                                {
                                    CityCardId = 2,
                                    EndDate = new DateOnly(9999, 12, 31),
                                    StartDate = new DateOnly(2024, 1, 1)
                                },
                                new
                                {
                                    CityCardId = 3,
                                    EndDate = new DateOnly(2024, 12, 31),
                                    StartDate = new DateOnly(2024, 1, 1)
                                });
                        });

                    b.Navigation("ValidityPeriod")
                        .IsRequired();
                });

            modelBuilder.Entity("CityPassGuide.Core.ContributorAggregate.Contributor", b =>
                {
                    b.OwnsOne("CityPassGuide.Core.ContributorAggregate.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<int>("ContributorId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("CountryCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Extension")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("ContributorId");

                            b1.ToTable("Contributors");

                            b1.WithOwner()
                                .HasForeignKey("ContributorId");
                        });

                    b.Navigation("PhoneNumber");
                });

            modelBuilder.Entity("CityPassGuide.Core.CityCardAggregate.City", b =>
                {
                    b.Navigation("Attractions");

                    b.Navigation("CityCards");
                });

            modelBuilder.Entity("CityPassGuide.Core.CityCardAggregate.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}