using System;

namespace GraduationTracker
{
    public interface IGradResult
    {
        Tuple<bool, STANDING> GetResult();
    }

    public class Average : IGradResult
    {
        private STANDING _standing;
        public Average()
        {
            _standing = STANDING.Average;
        }
        public Tuple<bool, STANDING> GetResult()
        {
            return new Tuple<bool, STANDING>(true, _standing);
        }
    }

    public class SumaCumLaude : IGradResult
    {
        private STANDING _standing;
        public SumaCumLaude()
        {
            _standing = STANDING.SumaCumLaude;
        }
        public Tuple<bool, STANDING> GetResult()
        {
            return new Tuple<bool, STANDING>(true, _standing);
        }
    }

    public class MagnaCumLaude : IGradResult
    {
        private STANDING _standing;
        public MagnaCumLaude()
        {
            _standing = STANDING.MagnaCumLaude;
        }
        public Tuple<bool, STANDING> GetResult()
        {
            return new Tuple<bool, STANDING>(true, _standing);
        }
    }

    public class Remedial : IGradResult
    {
        private STANDING _standing;
        public Remedial()
        {
            _standing = STANDING.Remedial;
        }
        public Tuple<bool, STANDING> GetResult()
        {
            return new Tuple<bool, STANDING>(false, _standing);
        }
    }

    public class None : IGradResult
    {
        private STANDING _standing;
        public None()
        {
            _standing = STANDING.None;
        }
        public Tuple<bool, STANDING> GetResult()
        {
            return new Tuple<bool, STANDING>(false, _standing);
        }
    }
}