using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.Events.Redo.Interface;
using Sandbox.Events.Redo.Concrete;

namespace Library.Test.Sandbox_Tests.Events.Redo
{
    [TestClass]
    public class EventRedoTest
    {
        [TestMethod]
        public void TestEventRedo()
        {
            ILever lever = new Lever();
            IDoor tdoor = new Door(lever);

            Assert.IsTrue(tdoor.IsOpen == false);
            lever.Pull();
            Assert.IsTrue(tdoor.IsOpen == true);
            lever.Pull();
            Assert.IsTrue(tdoor.IsOpen == true);
            lever.Push();
            Assert.IsTrue(tdoor.IsOpen == false);
        }
    }
}