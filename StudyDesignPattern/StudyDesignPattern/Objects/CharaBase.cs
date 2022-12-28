using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPattern.Objects
{
    internal class CharaBase
    {
        public int CallCnt { get; set; } = 0;

        public Point Pos { get; set; }
        public Color Color { get; }

        public CharaBase(Point point, Color color)
        {
            Pos = point;
            Color = color;
        }
    }
}
