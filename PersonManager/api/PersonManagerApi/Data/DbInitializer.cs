using PersonManagerApi.Models;

namespace PersonManagerApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            _ = context.Database.EnsureCreated();

            if (context.CourseTypes.Any())
            {
                return; // DB has been seeded
            }

            CourseType[] courseTypes = new CourseType[]
            {
                new CourseType{TypeName="Online", TypeDescription="Online course", IsDeleted=false},
                new CourseType{TypeName="Offline", TypeDescription="Offline course", IsDeleted=false}
            };
            foreach (CourseType ct in courseTypes)
            {
                _ = context.CourseTypes.Add(ct);
            }
            _ = context.SaveChanges();

            Course[] courses = new Course[]
            {
                new Course{CourseNumber="C001", CourseName="Math", CourseDescription="Math course", Cost=500, Capacity=75, CourseTypeId=courseTypes.Single(ct => ct.TypeName == "Online").CourseTypeId},
                new Course{CourseNumber="C002", CourseName="Science", CourseDescription="Science course", Cost=700, Capacity=35, CourseTypeId=courseTypes.Single(ct => ct.TypeName == "Offline").CourseTypeId}
            };
            foreach (Course c in courses)
            {
                _ = context.Courses.Add(c);
            }
            _ = context.SaveChanges();

            GenderType[] genderTypes = new GenderType[]
            {
                new GenderType{Name="Male", DateCreated=DateTime.Now, IsDeleted=false},
                new GenderType{Name="Female", DateCreated=DateTime.Now, IsDeleted=false},
            };
            foreach (GenderType ct in genderTypes)
            {
                _ = context.GenderTypes.Add(ct);
            }
            _ = context.SaveChanges();
        }
    }
}
