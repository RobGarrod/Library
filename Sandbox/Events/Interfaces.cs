using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Events
{
    public interface IPressable
    {
        void Press();

        event EventHandler Pressed;
    }

    public interface IButton : IPressable
    {
        ButtonFunction Function { get; }
    }

    public interface IRemoteControl
    {
        IList<IButton> Buttons { get; }
    }

    public interface ITelevision
    {
        int Volume { get; set; }
        int Channel { get; set; }
        bool IsOn { get; set; }

        void PowerCycle(object sender, EventArgs e);

        void VolumeUp(object sender, EventArgs e);

        void VolumeDown(object sender, EventArgs e);

        void ChannelUp(object sender, EventArgs e);

        void ChannelDown(object sender, EventArgs e);
    }
}