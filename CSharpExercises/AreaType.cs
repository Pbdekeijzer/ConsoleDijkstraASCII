using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExercises
{
    public interface AreaType
    {
        string AreaName { get; }
        double AreaWeight { get; }
        string AreaCodeForPrinting { get; }
    }

    public class Forest : AreaType
    {
        public Forest()
        {
            AreaName = "Forest";
            AreaWeight = 50;
            AreaCodeForPrinting = "F";
        }

        public string AreaName { get; }
        public double AreaWeight { get; }
        public string AreaCodeForPrinting { get; }
    }

    public class Road : AreaType
    {
        public Road()
        {
            AreaName = "Road";
            AreaWeight = 1;
            AreaCodeForPrinting = "R";
        }

        public string AreaName { get; }
        public double AreaWeight { get; }
        public string AreaCodeForPrinting { get; }
    }

    public class Ocean : AreaType
    {
        public Ocean()
        {
            AreaName = "Ocean";
            AreaWeight = 40000;
            AreaCodeForPrinting = "O";
        }

        public string AreaName { get; }
        public double AreaWeight { get; }
        public string AreaCodeForPrinting { get; }
    }

    public class Desert : AreaType
    {
        public Desert()
        {
            AreaName = "Desert";
            AreaWeight = 200;
            AreaCodeForPrinting = "D";
        }

        public string AreaName { get; }
        public double AreaWeight { get; }
        public string AreaCodeForPrinting { get; }
    }

    public class Mountain : AreaType
    {
        public Mountain()
        {
            AreaName = "Mountain";
            AreaWeight = 10000;
            AreaCodeForPrinting = "M";
        }

        public string AreaName { get; }
        public double AreaWeight { get; }
        public string AreaCodeForPrinting { get; }
    }

    public class Jungle : AreaType
    {
        public Jungle()
        {
            AreaName = "Jungle";
            AreaWeight = 100000;
            AreaCodeForPrinting = "J";
        }

        public string AreaName { get; }
        public double AreaWeight { get; }
        public string AreaCodeForPrinting { get; }
    }

    public class UnpassableTerrain : AreaType
    {
        public UnpassableTerrain()
        {
            AreaName = "UnpassableTerrain";
            AreaWeight = double.PositiveInfinity;
            AreaCodeForPrinting = "U";
        }

        public string AreaName { get; }
        public double AreaWeight { get; }
        public string AreaCodeForPrinting { get; }
    }
}
