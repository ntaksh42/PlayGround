using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDesignPattern.Objects
{
    internal sealed class Mario : CharaBase
    {
        public Mario(Point point) : base(point, Color.Red)
        {
        }
    }
}
