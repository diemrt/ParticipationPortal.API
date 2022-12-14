// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParticipationPortal.Infrastructure;

#nullable disable

namespace ParticipationPortal.API.Migrations
{
    [DbContext(typeof(ParticipationPortalContext))]
    [Migration("20221018161006_InitalCreate")]
    partial class InitalCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.IncomingEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ActualDate")
                        .HasColumnType("datetime")
                        .HasColumnName("actual_date");

                    b.Property<bool>("IsCovered")
                        .HasColumnType("bit")
                        .HasColumnName("is_covered");

                    b.Property<Guid>("WeeklyEventId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("weekly_event_id");

                    b.HasKey("Id");

                    b.HasIndex("WeeklyEventId");

                    b.ToTable("incoming_event", "dbo");
                });

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.IncomingEventUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IncomingEventId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("incoming_event_id");

                    b.Property<bool>("IsParticipating")
                        .HasColumnType("bit")
                        .HasColumnName("is_participating");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("IncomingEventId");

                    b.HasIndex("UserId");

                    b.ToTable("incoming_event_user", "dbo");
                });

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IconName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("icon_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("role", "dbo");
                });

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("email");

                    b.Property<string>("FirebaseUserId")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("firebase_user_id");

                    b.Property<DateTime>("InsertDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("insert_date")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("name");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("user", "dbo");
                });

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.WeeklyEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int")
                        .HasColumnName("day_of_week");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("weekly_event", "dbo");
                });

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.WeeklyEventRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<Guid>("WeeklyEventId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("weekly_event_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("WeeklyEventId");

                    b.ToTable("weekly_event_role", "dbo");
                });

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.IncomingEvent", b =>
                {
                    b.HasOne("ParticipationPortal.Domain.Entities.v1.WeeklyEvent", "WeeklyEvent")
                        .WithMany("IncomingEvents")
                        .HasForeignKey("WeeklyEventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("WeeklyEvent");
                });

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.IncomingEventUser", b =>
                {
                    b.HasOne("ParticipationPortal.Domain.Entities.v1.IncomingEvent", "IncomingEvent")
                        .WithMany("IncomingEventUsers")
                        .HasForeignKey("IncomingEventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ParticipationPortal.Domain.Entities.v1.User", "User")
                        .WithMany("IncomingEventUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("IncomingEvent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.User", b =>
                {
                    b.HasOne("ParticipationPortal.Domain.Entities.v1.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.WeeklyEventRole", b =>
                {
                    b.HasOne("ParticipationPortal.Domain.Entities.v1.Role", "Role")
                        .WithMany("IncomingEventRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ParticipationPortal.Domain.Entities.v1.WeeklyEvent", "WeeklyEvent")
                        .WithMany("WeeklyEventRoles")
                        .HasForeignKey("WeeklyEventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("WeeklyEvent");
                });

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.IncomingEvent", b =>
                {
                    b.Navigation("IncomingEventUsers");
                });

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.Role", b =>
                {
                    b.Navigation("IncomingEventRoles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.User", b =>
                {
                    b.Navigation("IncomingEventUsers");
                });

            modelBuilder.Entity("ParticipationPortal.Domain.Entities.v1.WeeklyEvent", b =>
                {
                    b.Navigation("IncomingEvents");

                    b.Navigation("WeeklyEventRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
