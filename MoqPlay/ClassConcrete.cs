using System;
using System.Collections.Generic;
using System.Text;

namespace MoqPlay
{
    public class ClassConcrete
    {
        public virtual int A(int num)  // virtual keyword needed for mocking.
        {
            if (num == 1)
                return 10;
            if (num == 2)
                return 15;

            return 0;
        }

        public virtual int B()
        {
            return 20;
        }

        public int C()
        {
            return 30;
        }
    }
}
