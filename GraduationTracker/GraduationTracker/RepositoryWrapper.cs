using System.Collections.Generic;

namespace GraduationTracker
{
    public class RepositoryWrapper : IRepository
    {
        public Requirement GetRequirement(int id)
        {
            return Repository.GetRequirement(id);
        }
 
        public Student GetStudent(int id)
        {
            return Repository.GetStudent(id);
        }

        IEnumerable<Requirement> IRepository.GetRequirements()
        {
            return Repository.GetRequirements();
        }
    }
}