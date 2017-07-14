using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExercises
{
    public class Tile
    {
        public Tile(Vector2 vector2)
        {
            this.Vector2 = vector2;
            this.AreaType = AreaTypeFactory.GetRandomAreaType();
        }

        public Vector2 Vector2 { get; }

        public AreaType AreaType { get; set; }
    }
}
