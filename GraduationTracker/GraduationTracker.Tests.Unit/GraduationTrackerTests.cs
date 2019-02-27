using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        Diploma[] _diploma;
        Student[] _students;
        Student _studentZeroAvg;
        Requirement[] _requirements;
        GraduationTracker _tracker;
        GraduationTracker _moqTracker;

        [TestInitialize]
        public void Setup()
        {
            {
                _tracker = new GraduationTracker(new RepositoryWrapper(), new StandingFactory());
                _diploma = MockData.GetDiplomas();
                _students = MockData.GetStudents();
                _studentZeroAvg = MockData.GetStudentsWithZeroAverage();
                _requirements = MockData.GetRequirements();

                Mock<IStandingFactory> standingFactory = new Mock<IStandingFactory>();
                Mock<IGradResult> gradResult = new Mock<IGradResult>();

               
                gradResult.Setup(x => x.GetResult()).Returns(Tuple.Create(true, STANDING.SumaCumLaude));
                standingFactory.Setup(x => x.CreateStanding(It.IsAny<int>())).Returns(gradResult.Object);

                Mock<IRepository> repository = new Mock<IRepository>();
                repository.Setup(x => x.GetRequirements()).Returns(_requirements);

                _moqTracker = new GraduationTracker(repository.Object, standingFactory.Object);
            }
        }

        [TestMethod]
        public void TestHasGraduatedUsingMockObjects()
        {
            // Arrange 
            var diploma = _diploma.FirstOrDefault();
            Student student = _students.FirstOrDefault();
            var expected = Tuple.Create(true, STANDING.SumaCumLaude);

            // Act 
            var actual = _moqTracker.HasGraduated(diploma, student);

            // Assert 
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestHasCredits()
        {
            // Arrange 
            var diploma = _diploma.FirstOrDefault();
            var students = _students;
            var graduated = new List<Tuple<bool, STANDING>>();
           
            var expectedGraduatedCount = 3;
            var expectedNotGraduatedCount = 1;

            // Act
            foreach (var student in students)
            {
                graduated.Add(_tracker.HasGraduated(diploma, student));
            }

            var studentsGraduated = graduated.Where(t => t.Item1 == true).Count();
            var studentsNotGraduated = graduated.Where(t => t.Item1 == false).Count();

            // Assert
            Assert.IsFalse(graduated.All(t => t.Item1 == true));
            Assert.IsTrue(graduated.Any(t => t.Item1 == true));
            Assert.AreEqual(expectedGraduatedCount, studentsGraduated);
            Assert.AreEqual(expectedNotGraduatedCount, studentsNotGraduated);
            Assert.IsTrue(graduated.Any(t => t.Item2 == STANDING.Average));
            Assert.IsTrue(graduated.Any(t => t.Item2 == STANDING.MagnaCumLaude));
            Assert.IsTrue(graduated.Any(t => t.Item2 == STANDING.SumaCumLaude));
            Assert.IsTrue(graduated.Any(t => t.Item2 == STANDING.Remedial));

        }

        [TestMethod]
        public void TestStudentWithZeroAverageshouldNotGraduate()
        {
            // Arrange
            var diploma = _diploma.FirstOrDefault();
            Student student = _studentZeroAvg;

            // Act
            var graduated = _tracker.HasGraduated(diploma, student);

            // Assert
            Assert.IsTrue(graduated.Item1 == false);
            Assert.IsTrue(graduated.Item2 == STANDING.None);
        }


    }
}
