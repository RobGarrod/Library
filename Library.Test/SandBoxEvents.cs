using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Core;
using Library.Core.Factories;
using Library.DAL;
using Sandbox;
using System.Diagnostics;
using System.Collections.Generic;
using Sandbox.Events;
using Sandbox.IoC;
using Unity;

namespace Library.Test
{
    [TestClass]
    public class IoCTest
    {
        //http://www.tutorialsteacher.com/ioc/register-and-resolve-in-unity-container

        [TestMethod]
        public void IoCCarTest()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICar, BMW>();

            Driver driver = container.Resolve<Driver>();
            driver.RunCar();
        }
    }

    [TestClass]
    public class Events
    {
        private void ReportToConsole(object sender, EventArgs e)
        {
            Debug.WriteLine("ReportToConsole was called");
        }

        [TestMethod]
        public void TestLonghandEvent()
        {
            ClickHandler handler = ReportToConsole;

            LongHandEventRaiser raiser = new LongHandEventRaiser();
            raiser.OnClick();

            raiser.Click += handler;
            raiser.OnClick();

            raiser.Click += handler;
            raiser.OnClick();

            raiser.Click -= handler;
            raiser.Click -= handler;
            raiser.OnClick();
        }

        [TestMethod]
        public void TestShorthandEvent()
        {
            ClickHandler handler = ReportToConsole;

            ShorthandEventRaiser raiser = new ShorthandEventRaiser();
            raiser.OnClick();

            raiser.Click += handler;
            raiser.OnClick();

            raiser.Click += handler;
            raiser.OnClick();

            raiser.Click -= handler;
            raiser.Click -= handler;
            raiser.OnClick();
        }

        [TestMethod]
        public void TestRoom()
        {
            Room _room = new Room();
            Assert.IsTrue(_room.Light.On == false);
            _room.LightSwitch.Flip();
            Assert.IsTrue(_room.Light.On == true);
        }

        [TestMethod]
        public void TestRoom2()
        {
            Room2 _room = new Room2();
            Assert.IsTrue(_room.Light.On == false);
            _room.LightSwitch.Flip();
            Assert.IsTrue(_room.Light.On == true);
        }
    }

    [TestClass]
    public class DelegatesAndGenerics
    {
        [TestMethod]
        public void SquareList()
        {
            NumberWang testWang = new NumberWang();
            Assert.IsTrue(testWang.SquareList(new List<int>() { 1, 2, 3 })[0] == 1);
            Assert.IsTrue(testWang.SquareList(new List<int>() { 1, 2, 3 })[1] == 4);
            Assert.IsTrue(testWang.SquareList(new List<int>() { 1, 2, 3 })[2] == 9);
        }

        [TestMethod]
        public void SquareRootList()
        {
            NumberWang testWang = new NumberWang();
            testWang.SquareRootList(new List<int>() { 1, 2, 3 });
        }
    }
}