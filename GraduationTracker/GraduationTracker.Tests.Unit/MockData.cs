namespace GraduationTracker.Tests.Unit
{
    public class MockData
    {
        public static Diploma[] GetDiplomas()
        {
            return new[]{
                new Diploma {
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[] { 100, 102, 103, 104 }
                }
            };
        }

        public static Student[] GetStudents()
        {
            return new[]
            {
                new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physical Education", Mark=95 }
                   }
               },
                new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physical Education", Mark=80 }
                   }
               },
                new Student
                {
                    Id = 3,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=50 },
                        new Course{Id = 2, Name = "Science", Mark=50 },
                        new Course{Id = 3, Name = "Literature", Mark=50 },
                        new Course{Id = 4, Name = "Physical Education", Mark=50 }
                    }
                },
                new Student
                {
                    Id = 4,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=40 },
                        new Course{Id = 2, Name = "Science", Mark=40 },
                        new Course{Id = 3, Name = "Literature", Mark=40 },
                        new Course{Id = 4, Name = "Physical Education", Mark=40 }
                    }
                }
            };
        }

        public static Requirement[] GetRequirements()
        {
            return new[]
            {
                    new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new int[]{1}, Credits=1 },
                    new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new int[]{2}, Credits=1 },
                    new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new int[]{3}, Credits=1},
                    new Requirement{Id = 104, Name = "Physical Education", MinimumMark=50, Courses = new int[]{4}, Credits=1 }
                };
        }

        public static Student GetStudentsWithZeroAverage()
        {
            return new Student
            {
                Id = 1,
                Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=0 },
                        new Course{Id = 2, Name = "Science", Mark=0 },
                        new Course{Id = 3, Name = "Literature", Mark=0 },
                        new Course{Id = 4, Name = "Physical Education", Mark=0 }
                    }
            };
        }
    }
}