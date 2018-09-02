﻿// <auto-generated />
using System;
using AuthenticationService.Domain.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuthenticationService.Migrations
{
    [DbContext(typeof(AuthenticationServiceDbContext))]
    partial class AuthenticationServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CrossCutting.Authentication.Models.ApplicationUserModel", b =>
                {
                    b.Property<Guid>("ApplicationUserGuid")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthenticationModelGuid");

                    b.HasKey("ApplicationUserGuid");

                    b.HasIndex("AuthenticationModelGuid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CrossCutting.Authentication.Models.AuthenticationModel", b =>
                {
                    b.Property<Guid>("AuthenticationGuid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Salt");

                    b.Property<string>("UserIdentification");

                    b.HasKey("AuthenticationGuid");

                    b.ToTable("AuthenticationCredentials");
                });

            modelBuilder.Entity("CrossCutting.Authentication.Models.ApplicationUserModel", b =>
                {
                    b.HasOne("CrossCutting.Authentication.Models.AuthenticationModel", "AuthenticationModel")
                        .WithMany()
                        .HasForeignKey("AuthenticationModelGuid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}