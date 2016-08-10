using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AcademySample.Models;

namespace AcademySample.Migrations
{
    [DbContext(typeof(ComputerDbContext))]
    [Migration("20160810074343_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("AcademySample.Models.ComputerDetails", b =>
                {
                    b.Property<string>("Name");

                    b.Property<string>("IpAddress");

                    b.Property<int>("Memory");

                    b.Property<string>("User");

                    b.HasKey("Name");

                    b.ToTable("ComputerDetails");
                });

            modelBuilder.Entity("AcademySample.Models.UsageData", b =>
                {
                    b.Property<Guid>("UsageDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AvailableDiskSpace");

                    b.Property<string>("ComputerName");

                    b.Property<int>("CpuUsage");

                    b.Property<int>("MemoryUsage");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("UsageDataId");

                    b.HasIndex("ComputerName");

                    b.ToTable("UsageData");
                });

            modelBuilder.Entity("AcademySample.Models.UsageData", b =>
                {
                    b.HasOne("AcademySample.Models.ComputerDetails", "ComputerDetails")
                        .WithMany("UsageData")
                        .HasForeignKey("ComputerName");
                });
        }
    }
}
