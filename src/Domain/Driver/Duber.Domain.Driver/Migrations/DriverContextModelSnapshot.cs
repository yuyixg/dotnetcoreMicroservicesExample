﻿// <auto-generated />
using Duber.Domain.Driver.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Duber.Domain.Driver.Migrations
{
    [DbContext(typeof(DriverContext))]
    partial class DriverContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("Relational:Sequence:Driver.driverseq", "'driverseq', 'Driver', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:Driver.vehicleseq", "'vehicleseq', 'Driver', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Duber.Domain.Driver.Model.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "driverseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "Driver")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("Rating");

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.ToTable("Drivers","Driver");
                });

            modelBuilder.Entity("Duber.Domain.Driver.Model.DriverStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("DriverStatuses","Driver");
                });

            modelBuilder.Entity("Duber.Domain.Driver.Model.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "vehicleseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "Driver")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<bool>("Active");

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int>("DriverId");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<string>("Plate")
                        .IsRequired();

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("TypeId");

                    b.ToTable("Vehicles","Driver");
                });

            modelBuilder.Entity("Duber.Domain.Driver.Model.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes","Driver");
                });

            modelBuilder.Entity("Duber.Domain.Driver.Model.Driver", b =>
                {
                    b.HasOne("Duber.Domain.Driver.Model.DriverStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Duber.Domain.Driver.Model.Vehicle", b =>
                {
                    b.HasOne("Duber.Domain.Driver.Model.Driver")
                        .WithMany("Vehicles")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Duber.Domain.Driver.Model.VehicleType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
