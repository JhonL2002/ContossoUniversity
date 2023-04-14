using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            if(context.Students.Any())
            {
                return; //Db has been seeded
            }
            var students = new Student[]
            {
                new Student {FirstName="John",LastName="Castaño",EnrollmentDate=DateTime.Parse("2023-05-01")},
                new Student {FirstName="Claudia",LastName="Suarez",EnrollmentDate=DateTime.Parse("2018-06-10")},
                new Student {FirstName="Ronalito",LastName="Ronalin",EnrollmentDate=DateTime.Parse("2020-04-03")}
            };
            context.Students.AddRange(students);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseId=1050,Title="Object Ortiented Programming",Credits=3},
                new Course{CourseId=4033,Title="Integral Calculos",Credits=3},
                new Course{CourseId=1060,Title="Introduction to JavaScript",Credits=3},
                new Course{CourseId=2030,Title="System Analysys",Credits=3},
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentId=1,CourseId=1050,Grade=Grade.A},
                new Enrollment{StudentId=1,CourseId=4033,Grade=Grade.C},
                new Enrollment{StudentId=2,CourseId=1060,Grade=Grade.B},
                new Enrollment{StudentId=2,CourseId=2030,Grade=Grade.C},
                new Enrollment{StudentId=3,CourseId=1060,Grade=Grade.A},
                new Enrollment{StudentId=3,CourseId=1050,Grade=Grade.B}
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
