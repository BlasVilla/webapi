using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AcademySample.Models;

namespace AcademySample.Migrations
{
    [DbContext(typeof(ComputerDbContext))]
    [Migration("20160809120601_Initial")]
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
        }
    }
}
