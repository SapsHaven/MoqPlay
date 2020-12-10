using System;
using System.Collections.Generic;
using System.Text;

namespace MoqPlay
{
    class ClassConcreteFromInterface : IClassInterface
    {
        public int A()
        {
            return 1;
        }

        public int B()
        {
            return 2;
        }

        public int C()
        {
            return 3;
        }
    }
}
