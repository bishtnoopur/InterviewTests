using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {

        private IRepository _repository;
        private IStandingFactory _standingFactory;

        public GraduationTracker(IRepository repository, IStandingFactory standingFactory)
        {
            _repository = repository;
            _standingFactory = standingFactory;
        }

        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            var studentDiplomaCourses = FilterCoursesByDiplomaRequirements(student.Courses, diploma);

            var average = studentDiplomaCourses.Sum(c => c.Mark) / student.Courses.Length;
            var credits = studentDiplomaCourses.Sum(c => c.Credits);
            return _standingFactory
                        .CreateStanding(average)
                        .GetResult();
        }

        private IEnumerable<DiplomaCourse> FilterCoursesByDiplomaRequirements(Course[] courses, Diploma diploma)
        {
            var diplomaRequirements = GetDiplomaRequirementsByCourse(diploma);

            var diplomaCourses = courses
                            .Join(diplomaRequirements,
                            c => c.Id,
                            r => r.CourseId, (c, r) => new DiplomaCourse
                            {
                                Id = c.Id,
                                Mark = c.Mark,
                                Credits = (r.MinimumMark < c.Mark) ? r.Credits : 0
                            });


            return diplomaCourses;
        }

        private IEnumerable<DiplomaRequirement> GetDiplomaRequirementsByCourse(Diploma diploma)
        {
            return _repository.GetRequirements()
                          .Where(r => diploma.Requirements.Contains(r.Id))
                          .SelectMany(r => r.Courses,
                          (r, courseId) => new DiplomaRequirement
                          {
                              CourseId = courseId,
                              MinimumMark = r.MinimumMark,
                              Credits = r.Credits
                          })
                          .ToList();
        }
    }
}
