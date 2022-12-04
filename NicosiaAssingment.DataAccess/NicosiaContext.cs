using Microsoft.EntityFrameworkCore;
using NicosiaAssingment.DataAccess.Models;
using System;
using System.Threading.Tasks;

namespace NicosiaAssingment.DataAccess;

public class NicosiaContext : DbContext, INicosiaContext
{
	public NicosiaContext(DbContextOptions<NicosiaContext> options) : base(options)
	{
	}

	public DbSet<Section> Sections { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<Message> Messages { get; set; }
	public DbSet<StudentEnrollment> StudentEnrollments { get; set; }

	public void Migrate()
	{
		Database.Migrate();
	}

	public void EnsureCreated()
	{
		Database.EnsureCreated();
	}

	public async Task SaveChangesAsync()
	{
		await base.SaveChangesAsync();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<AcademicPeriod>()
			.HasData(
				new AcademicPeriod
				{
					Id = 1,
					Name = "First semester 2022",
					StartDate = new DateTimeOffset(2022, 1, 1, 0, 0, 0, 0, new TimeSpan(0)),
					EndDate = new DateTimeOffset(2022, 6, 1, 23, 59, 59, 0, new TimeSpan(0)),
				},
				new AcademicPeriod
				{
					Id = 2,
					Name = "Second semester 2022",
					StartDate = new DateTimeOffset(2022, 6, 2, 0, 0, 0, 0, new TimeSpan(0)),
					EndDate = new DateTimeOffset(2022, 12, 31, 23, 59, 59, 0, new TimeSpan(0)),
				});

		modelBuilder.Entity<Course>()
			.HasData(
				new Course
				{
					Id = 1,
					Code = "Math-231",
					Title = "Calculus"
				},
				new Course
				{
					Id = 2,
					Code = "IT-888",
					Title = "Intoduction to Linux"
				},
				new Course
				{
					Id = 3,
					Code = "ENG-153",
					Title = "An Introduction to Literary Analysis"
				},
				new Course
				{
					Id = 4,
					Code = "ART-991",
					Title = "An Introduction to painting"
				});

		modelBuilder.Entity<Section>()
			.HasData(
				new Section
				{
					Id = 1,
					CourseId = 1,
					PeriodId = 1,
					SectionNumber = "Spring2022_1"
				},
				new Section
				{
					Id = 2,
					CourseId = 2,
					PeriodId = 1,
					SectionNumber = "Summer2022_1"
				},
				new Section
				{
					Id = 3,
					CourseId = 4,
					PeriodId = 2,
					SectionNumber = "Fall2022_1"
				},
				new Section
				{
					Id = 4,
					CourseId = 3,
					PeriodId = 2,
					SectionNumber = "Fall2022_2"
				});

		modelBuilder.Entity<User>()
			.HasData(
				new User
				{
					Id = 1,
					FirstName = "John",
					LastName = "Petrucci",
					Email = "john-petrucci@nicosia.com",
					Phone = "+1 999 999 99 99",
					Role = "Student",
					// sha256: qwe123
					PwdHash = "c60217d999b4f9d57a00826a6c0f05e0cdb7601e9d80805512d631177189b736"
				},
				new User
				{
					Id = 2,
					FirstName = "Max",
					LastName = "Well",
					Email = "max-well@nicosia.com",
					Phone = "+1 888 888 88 88",
					Role = "Student",
					// sha256: asd123
					PwdHash = "5c009a36dcda289141dd3558f65d573a1452f5401f7c8e7ce728773d489d2790"
				},
				new User
				{
					Id = 3,
					FirstName = "Brian",
					LastName = "Dough",
					Email = "brian-dough@nicosia.com",
					Phone = "+1 777 777 77 77",
					Role = "Student",
					// sha256: zxc123
					PwdHash = "e2714127da7a68b22a3214a6a10c3f58901254ff339be87dbb84687581e6ba0d"
				},
				new User
				{
					Id = 4,
					FirstName = "Satoshi",
					LastName = "Nakamoto",
					Email = "satoshi-nakamoto@nicosia.com",
					Phone = "+1 666 666 66 66",
					Role = "Lecturer",
					// sha256: bit123
					PwdHash = "301f402e5a2795f6b87a5eacd0be62fe8d0546a9d0f16f30fe5a0861125ea11d"
				},
				new User
				{
					Id = 5,
					FirstName = "John",
					LastName = "Lock",
					Email = "john-lock@nicosia.com",
					Phone = "+1 555 555 55 55",
					Role = "Lecturer",
					// sha256: loc123
					PwdHash = "0a4669a4ad54e010b0f574b691de1efdfcfee372e0048ab28ae04b202ca09ad5"
				});

		modelBuilder.Entity<SectionLecturer>()
			.HasData(
				new SectionLecturer
				{
					Id = 1,
					LecturerId = 4,
					LecturedSectionId = 2
				},
				new SectionLecturer
				{
					Id = 2,
					LecturerId = 5,
					LecturedSectionId = 1
				},
				new SectionLecturer
				{
					Id = 3,
					LecturerId = 4,
					LecturedSectionId = 3
				},
				new SectionLecturer
				{
					Id = 4,
					LecturerId = 5,
					LecturedSectionId = 4
				});

		modelBuilder.Entity<StudentEnrollment>()
			.HasData(
				new StudentEnrollment
				{
					Id = 1,
					StudentId = 1,
					EnrolledInId = 1
				},
				new StudentEnrollment
				{
					Id = 2,
					StudentId = 3,
					EnrolledInId = 2
				},
				new StudentEnrollment
				{
					Id = 3,
					StudentId = 2,
					EnrolledInId = 1
				},
				new StudentEnrollment
				{
					Id = 4,
					StudentId = 3,
					EnrolledInId = 1
				},
				new StudentEnrollment
				{
					Id = 5,
					StudentId = 3,
					EnrolledInId = 4
				},
				new StudentEnrollment
				{
					Id = 6,
					StudentId = 2,
					EnrolledInId = 4
				},
				new StudentEnrollment
				{
					Id = 7,
					StudentId = 1,
					EnrolledInId = 3
				});
		
		var assembly = GetType().Assembly;
		modelBuilder.ApplyConfigurationsFromAssembly(assembly);
	}
}
