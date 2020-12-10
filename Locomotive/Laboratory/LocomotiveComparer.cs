using System.Collections.Generic;

namespace lab4
{
    class LocomotiveComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            if (x is ElLocomotive && y is ElLocomotive)
            {
                return ComparerElLocomotive((ElLocomotive)x, (ElLocomotive)y);
            }
            if (x is ElLocomotive && y is Locomotive)
            {
                return -1;
            }
            if (x is Locomotive && y is ElLocomotive)
            {
                return 1;
            }
            if (x is Locomotive && y is Locomotive)
            {
                return ComparerLocomotive((Locomotive)x, (Locomotive)y);
            }
            return 0;
        }
        private int ComparerLocomotive(Locomotive x, Locomotive y)
        {
            if (x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
            if (x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if (x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            return 0;
        }
        private int ComparerElLocomotive(ElLocomotive x, ElLocomotive y)
        {
            var res = ComparerLocomotive(x, y);
            if (res != 0)
            {
                return res;
            }
            if (x.DopColor != y.DopColor)
            {
                return x.DopColor.Name.CompareTo(y.DopColor.Name);
            }
            if (x.FirstHorn != y.FirstHorn)
            {
                return x.FirstHorn.CompareTo(y.FirstHorn);
            }
            if (x.SecondHorn != y.SecondHorn)
            {
                return x.SecondHorn.CompareTo(y.SecondHorn);
            }
            if (x.ThirdHorn != y.ThirdHorn)
            {
                return x.ThirdHorn.CompareTo(y.ThirdHorn);
            }
            if (x.UpperPipe != y.UpperPipe)
            {
                return x.UpperPipe.CompareTo(y.UpperPipe);
            }
            if (x.FrontBumper != y.FrontBumper)
            {
                return x.FrontBumper.CompareTo(y.FrontBumper);
            }
            if (x.BackLine != y.BackLine)
            {
                return x.BackLine.CompareTo(y.BackLine);
            }
            return 0;
        }
    }
}
