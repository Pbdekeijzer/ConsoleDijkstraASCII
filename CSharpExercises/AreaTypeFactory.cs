using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExercises
{
    public abstract class AreaTypeFactory
    {
        public static AreaType GetRandomAreaType()
        {
            int typeInt = StaticRandom.Instance.Next(1, 8);

            switch (typeInt)
            {
                case 1:
                    return new Forest();
                case 2:
                    return new Ocean();
                case 3:
                    return new Road();
                case 4:
                    return new Desert();
                case 5:
                    return new Mountain();
                case 6:
                    return new Jungle();
                default:
                    return new UnpassableTerrain();
            }
        }

    }
}
