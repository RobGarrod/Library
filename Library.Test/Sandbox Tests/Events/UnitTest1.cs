using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.Events;
using System.Collections.Generic;

namespace Library.Test.Sandbox_Tests.Events
{
    [TestClass]
    public class EventTests
    {
        [TestClass]
        public class TelevisonEventsTests
        {
            [TestMethod]
            public void TestPowerButton()
            {
                IRemoteControl Remote = new RemoteControl();
                ITelevision TV = new Television(Remote);

                Assert.IsTrue(TV.IsOn == false);
                (Remote.Buttons as List<IButton>).Find(x => x.Function == ButtonFunction.Power).Press();
                Assert.IsTrue(TV.IsOn == true);
                (Remote.Buttons as List<IButton>).Find(x => x.Function == ButtonFunction.Power).Press();
                Assert.IsTrue(TV.IsOn == false);
            }

            [TestMethod]
            public void TestVolumeButtonWhenOn()
            {
                IRemoteControl Remote = new RemoteControl();
                ITelevision TV = new Television(Remote);

                (Remote.Buttons as List<IButton>).Find(x => x.Function == ButtonFunction.Power).Press();

                int startingVolume = TV.Volume;

                (Remote.Buttons as List<IButton>).Find(x => x.Function == ButtonFunction.VolumeUp).Press();
                (Remote.Buttons as List<IButton>).Find(x => x.Function == ButtonFunction.VolumeUp).Press();

                Assert.IsTrue(startingVolume < TV.Volume);
                Assert.IsTrue(TV.Volume == startingVolume + 2);

                (Remote.Buttons as List<IButton>).Find(x => x.Function == ButtonFunction.VolumeDown).Press();
                (Remote.Buttons as List<IButton>).Find(x => x.Function == ButtonFunction.VolumeDown).Press();

                Assert.IsTrue(startingVolume == TV.Volume);
            }

            [TestMethod]
            public void TestVolumeButtonWhenOff()
            {
                IRemoteControl Remote = new RemoteControl();
                ITelevision TV = new Television(Remote);

                int startingVolume = TV.Volume;

                (Remote.Buttons as List<IButton>).Find(x => x.Function == ButtonFunction.VolumeUp).Press();
                (Remote.Buttons as List<IButton>).Find(x => x.Function == ButtonFunction.VolumeUp).Press();

                Assert.IsTrue(startingVolume == TV.Volume);

                (Remote.Buttons as List<IButton>).Find(x => x.Function == ButtonFunction.VolumeDown).Press();
                (Remote.Buttons as List<IButton>).Find(x => x.Function == ButtonFunction.VolumeDown).Press();

                Assert.IsTrue(startingVolume == TV.Volume);
            }
        }
    }
}