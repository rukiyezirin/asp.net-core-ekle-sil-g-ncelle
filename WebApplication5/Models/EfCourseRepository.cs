using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class EfCourseRepository : ICourseRepository
    {
        private DataContext context;
        public EfCourseRepository(DataContext _context)
        {
            context = _context;
                
        }
        

        public IQueryable<Course> Courses => context.Courses;

       

        public void CreateCourse(Course newCourse)
        {
            context.Courses.Add(newCourse);
            context.SaveChanges();
        }

        public void DeleteCourse(int courseid)
        {
            var entity = context.Courses.Find(courseid);
            context.Courses.Remove(entity);
            context.SaveChanges();
        }

        public Course GetById(int courseid)
        {
            return context.Courses.Find(courseid);
        }

        public IEnumerable<Course> GetCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesByActive(bool isActive)
        {
            return context.Courses.Where(i => i.isActive == true).ToList();
        }

        public void UpdateCourse(Course updatedCourse)
        {
            var entity = context.Courses.Find(updatedCourse.id);
            if (entity != null)
            {
                entity.Name = updatedCourse.Name;
                entity.Description = updatedCourse.Description;
                entity.Price = updatedCourse.Price;
                entity.isActive = updatedCourse.isActive;

                context.SaveChanges();
            }
        }
    }
}
