using SaintMarysUniversity.Data;
using SaintMarysUniversity.Models;
using System;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{FirstName="Carson",LastName="Alexander",Anumber="A1",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Meredith",LastName="Alonso",Anumber="A2",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Arturo",LastName="Anand",Anumber="A3",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstName="Gytis",LastName="Barzdukas",Anumber="A4",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Yan",LastName="Li",Anumber="A5",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstName="Peggy",LastName="Justice",Anumber="A6",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstName="Laura",LastName="Norman",Anumber="A7",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstName="Nino",LastName="Olivetto",Anumber="A8",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="Chemistry",CourseNumber="1",CRN="CRN1",Credits=10},
            new Course{CourseID=4022,Title="Microeconomics",CourseNumber="2",CRN="CRN2",Credits=5},
            new Course{CourseID=4041,Title="Macroeconomics",CourseNumber="3",CRN="CRN3",Credits=15},
            new Course{CourseID=1045,Title="Calculus",CourseNumber="4",CRN="CRN4",Credits=15},
            new Course{CourseID=3141,Title="Trigonometry",CourseNumber="5",CRN="CRN5",Credits=10},
            new Course{CourseID=2021,Title="Composition",CourseNumber="6",CRN="CRN6",Credits=10},
            new Course{CourseID=2042,Title="Literature",CourseNumber="7",CRN="CRN7",Credits=10}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}