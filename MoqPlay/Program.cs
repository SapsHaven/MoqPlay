using System;
using System.Diagnostics;

namespace MoqPlay
{
    public class Program
    {
        private readonly IClassInterface _cci;
        private readonly ClassConcrete _cc;

        public Program(IClassInterface cci, ClassConcrete cc)
        {
            _cci = cci;
            _cc = cc;
        }

        public void GetDoit(ref IClassInterface cci, ref ClassConcrete cc)
        {
            cci = _cci;
            cc = _cc;
        }

        static void Main()
        {
            // Two concrete classes.  One from an interface, the other 'standalone'.
            ClassConcreteFromInterface cci = new ClassConcreteFromInterface();
            ClassConcrete cc = new ClassConcrete();

            // Inject the two classes into Program using a constructor.
            var program = new Program(cci, cc);

            // Do it.  Use method A for both classes.
            program.Doit();
        }

        public void Doit()
        {
            int i = _cci.A();
            Console.WriteLine("ClassConcreteFromInterface A: " + i);

            i = _cc.A(1);
            Console.WriteLine("ClassConcrete A: " + i);

            i = _cc.A(2);
            Console.WriteLine("ClassConcrete A: " + i);

            i = _cc.B();
            Console.WriteLine("ClassConcrete B: " + i);
        }

        // Return the sum of the A methods.
        public int DoitSum()
        {
            int t = _cci.A() + _cc.A(1);
            return t;
        }

        // Return the sum of the A methods.
        public void DoitSumTask()
        {
            Console.WriteLine(_cci.A() + "   " + _cc.A(1) + "   " + _cc.A(1) + "   " + _cc.A(1));
        }
    }
}
