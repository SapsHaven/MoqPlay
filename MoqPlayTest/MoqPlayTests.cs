using Moq;
using MoqPlay;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MoqExtension;

namespace MoqPlayTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Create a mock for the class created via interface, and use the
            // real concrete class.  Use the mock to override A to return 53.

            var mockClassConcreteFromInterface = new Mock<IClassInterface>();
            mockClassConcreteFromInterface.Setup(f => f.A()).Returns(53);

            var cc = new ClassConcrete();

            var sut = new Program(mockClassConcreteFromInterface.Object, cc);

            sut.Doit();

            Assert.IsTrue(sut.DoitSum() == (53 + 10));
        }

        [Test]
        public void Test2()
        {
            // Create a mock for the class created via interface, and for the
            // real concrete class.  Use the mocks to override A to return 53
            // and 19.

            var mockClassConcreteFromInterface = new Mock<IClassInterface>();
            mockClassConcreteFromInterface.Setup(f => f.A()).Returns(53);

            var mockClassConcrete = new Mock<ClassConcrete>();
            mockClassConcrete.Setup(f => f.A(1)).Returns(18);
            mockClassConcrete.Setup(f => f.A(2)).Returns(19);
            mockClassConcrete.Setup(f => f.B()).Returns(2);

            var sut = new Program(mockClassConcreteFromInterface.Object, mockClassConcrete.Object);

            //sut.Doit();
            int total = sut.DoitSum();

            Assert.IsTrue(total == (53 + 18));
        }

        [Test]
        public void Test3()
        {
            // Create a mock for the class created via interface, and for the
            // real concrete class.  Use the mocks to override A to return 53
            // and 19.

            var mockClassConcreteFromInterface = new Mock<IClassInterface>();
            mockClassConcreteFromInterface.Setup(f => f.A()).Returns(53);

            var mockClassConcrete = new Mock<ClassConcrete>();
            //mockClassConcrete.Setup(f => f.A(1)).Returns(11111);
            //mockClassConcrete.Setup(f => f.A(1)).Returns(22222);

            mockClassConcrete.Setup(f => f.A(1)).Returns(new Queue<int>(new[] { 43, 431, 432, 8, 88, 888 }).Dequeue);

            mockClassConcrete.Setup(f => f.A(2)).Returns(19);
            mockClassConcrete.Setup(f => f.B()).Returns(2);

            Program sut = new Program(mockClassConcreteFromInterface.Object, mockClassConcrete.Object);
            Task dt = new Task(() => sut.DoitSumTask());

            dt.Start();
            Thread.Sleep(1000);
            dt.Wait();

            Console.WriteLine("back...");

            //mockClassConcrete.Setup(f => f.A(1)).Returns(new Queue<int>(new[] { 143, 1431, 1432 }).Dequeue);
            //mockClassConcrete.Setup(f => f.A(1)).ReturnsInOrder(9, 99, 999);
            sut.DoitSumTask();

        }
    }
}