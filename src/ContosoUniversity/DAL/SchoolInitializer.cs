using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ContosoUniversity.Models;

namespace ContosoUniversity.DAL
{
	public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
	{
		protected override void Seed(SchoolContext context)
		{
			var carson = new Student { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01") };
			var meredith = new Student { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01") };
			var arturo = new Student { FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01") };
			var gytis = new Student { FirstMidName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01") };
			var yan = new Student { FirstMidName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("2002-09-01") };
			var peggy = new Student { FirstMidName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2001-09-01") };
			var laura = new Student { FirstMidName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2003-09-01") };
			var nino = new Student { FirstMidName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-09-01") };

			var students = new List<Student> { carson, meredith, arturo, gytis, yan, peggy, laura, nino };

			students.ForEach(s => context.Students.Add(s));
			context.SaveChanges();

			var chemistry = new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 };
			var microeconomics = new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 };
			var macroeconomics = new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 };
			var calculus = new Course { CourseID = 1045, Title = "Calculus", Credits = 4 };
			var trigonometry = new Course { CourseID = 3141, Title = "Trigonometry", Credits = 4 };
			var composition = new Course { CourseID = 2021, Title = "Composition", Credits = 3 };
			var literature = new Course { CourseID = 2042, Title = "Literature", Credits = 4 };

			var chemistryDept = new Department { Name = "Chemistry", Budget = 1000, StartDate = DateTime.Parse("2000-01-01"), Courses = new List<Course> { chemistry } };
			var economyDept = new Department { Name = "Economy", Budget = 1000, StartDate = DateTime.Parse("2000-01-01"), Courses = new List<Course> { microeconomics, macroeconomics } };
			var mathematicsDept = new Department { Name = "Mathematics", Budget = 1000, StartDate = DateTime.Parse("2000-01-01"), Courses = new List<Course> { calculus, trigonometry } };
			var literatureDept = new Department { Name = "Literature", Budget = 1000, StartDate = DateTime.Parse("2000-01-01"), Courses = new List<Course> { composition, literature } };

			var departments = new List<Department>{chemistryDept, economyDept, mathematicsDept, literatureDept};

			departments.ForEach(s => context.Departments.Add(s));
			context.SaveChanges();

			var enrollments = new List<Enrollment>
			{
			new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
			new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
			new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
			new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
			new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.A},
			new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.A},
			new Enrollment{StudentID=3,CourseID=1050},
			new Enrollment{StudentID=4,CourseID=1050,},
			new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
			new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
			new Enrollment{StudentID=6,CourseID=1045},
			new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
			};
			enrollments.ForEach(s => context.Enrollments.Add(s));
			context.SaveChanges();
		}
	}
}