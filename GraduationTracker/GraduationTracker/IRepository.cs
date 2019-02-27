using System.Collections.Generic;

namespace GraduationTracker
{
    public interface IRepository
    {
        IEnumerable<Requirement> GetRequirements();
        Student GetStudent(int id);
        Requirement GetRequirement(int id);
    }
}