﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.22");

            modelBuilder.Entity("API.Entities.Bike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BikeModel")
                        .HasColumnType("TEXT");

                    b.Property<string>("BikeNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EnginePower")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bikes");
                });

            modelBuilder.Entity("API.Entities.Rider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmirateId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonalNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Riders");
                });

            modelBuilder.Entity("API.Entities.RiderBikeAssociation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BikeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RiderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BikeId")
                        .IsUnique();

                    b.HasIndex("RiderId")
                        .IsUnique();

                    b.ToTable("RiderBikeAssociations");
                });

            modelBuilder.Entity("API.Entities.RiderBikeAssociation", b =>
                {
                    b.HasOne("API.Entities.Bike", "Bike")
                        .WithOne("RiderBikeAssociation")
                        .HasForeignKey("API.Entities.RiderBikeAssociation", "BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Rider", "Rider")
                        .WithOne("RiderBikeAssociation")
                        .HasForeignKey("API.Entities.RiderBikeAssociation", "RiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bike");

                    b.Navigation("Rider");
                });

            modelBuilder.Entity("API.Entities.Bike", b =>
                {
                    b.Navigation("RiderBikeAssociation");
                });

            modelBuilder.Entity("API.Entities.Rider", b =>
                {
                    b.Navigation("RiderBikeAssociation");
                });
#pragma warning restore 612, 618
        }
    }
}
