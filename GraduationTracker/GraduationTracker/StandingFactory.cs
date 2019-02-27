namespace GraduationTracker
{
    public class StandingFactory : IStandingFactory
    {
        public IGradResult CreateStanding(int average)
        {
            if (average == 0)
                return new None();
            if (average < 50)
                return new Remedial();
            else if (average < 80)
                return new Average();
            else if (average < 95)
                return new MagnaCumLaude();
            else
                return new SumaCumLaude();
        }
    }
}