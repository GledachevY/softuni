namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager manager;
        [SetUp]
        public void Setup()
        {
            robot = new Robot("Test", 10);
            manager = new RobotManager(10);
        }
        [Test]
        public void WhenRobotIsCreatedPropertiesShouldBSet()
        {
            Assert.AreEqual("Test", robot.Name);
            Assert.AreEqual(10, robot.Battery);
            Assert.AreEqual(10, robot.MaximumBattery);
        }
        [Test]
        public void WhenRobotManagerIsCreatedCapacityShouldBeSet()
        {
            Assert.AreEqual(10, manager.Capacity);
        }
        [Test]
        public void WhenRobotManagerCapacityIsNegativeExSholdBeThrow()
        {
            Assert.Throws<ArgumentException>(()=>
            {
                RobotManager roboManager = new RobotManager(-5);
            });
        }

        [Test]
        public void WhenRobotManagerISCreateCountBe0()
        {
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void WhenAddSameRobotExceprSholudBeThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robot);
                manager.Add(robot);

            });
        }

        [Test]
        public void WhenAddMoreRobotsThanCapacityExceprShouldBeThrow()
        {
            Robot nasko = new Robot("naskoo", 500);
            RobotManager robokop = new RobotManager(1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robokop.Add(robot);
                robokop.Add(nasko);

            });
        }
        [Test]
        public void WhenAddWithCorrectDataShouldWork()
        {
            manager.Add(robot);
            Assert.AreEqual(1, manager.Count);
            manager.Add(new Robot("asdasasdasd", 2));
            Assert.AreEqual(2, manager.Count);
        }

        [Test]
        public void WhenRemoveNotExistExcShouldBeThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Remove("Nqq me");
            });
        }
        [Test]
        public void WhenRemoveCorrectShouldWorkCorrect()
        {
            manager.Add(new Robot("Ima me", 10));
            manager.Remove("Ima me");
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void WhenWorkNoExistRobotExceptShouldBeThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("nqq me", " ", 10);
            });
        }
        [Test]
        public void WhenChargeRobotBattShuldGetmaximmu()
        {
            manager.Add(robot);
                manager.Work(robot.Name, "jov", 5);
                manager.Charge(robot.Name);
                Assert.AreEqual(robot.Battery, 10);
           
        }

    }
}
