using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Events
{
    public enum ButtonFunction
    {
        Power,
        VolumeUp,
        VolumeDown,
        ChannelUp,
        ChannelDown
    }

    public class Button : IButton
    {
        private ButtonFunction _buttonFunction;

        public Button(ButtonFunction function)
        {
            _buttonFunction = function;
        }

        public ButtonFunction Function
        {
            get
            {
                return _buttonFunction;
            }
        }

        public event EventHandler Pressed;

        public void Press()
        {
            if (Pressed == null)
                return;

            Pressed(this, EventArgs.Empty);
        }
    }

    public class RemoteControl : IRemoteControl
    {
        private IList<IButton> _buttons;

        public IList<IButton> Buttons
        {
            get
            {
                return _buttons;
            }
        }

        public RemoteControl()
        {
            _buttons = new List<IButton>();

            foreach (ButtonFunction function in Enum.GetValues(typeof(ButtonFunction)))
            {
                _buttons.Add(new Button(function));
            }
        }
    }

    public class Television : ITelevision
    {
        private int _channel;
        private bool _isOn;
        private int _volume;

        public int Channel
        {
            get
            {
                return _channel;
            }

            set
            {
                _channel = value;
            }
        }

        public bool IsOn
        {
            get
            {
                return _isOn;
            }

            set
            {
                _isOn = value;
            }
        }

        public int Volume
        {
            get
            {
                return _volume;
            }

            set
            {
                _volume = value;
            }
        }

        public void ChannelDown(object sender, EventArgs e)
        {
            if (_isOn)
                _channel -= 1;
        }

        public void ChannelUp(object sender, EventArgs e)
        {
            if (_isOn)
                _channel += 1;
        }

        public void PowerCycle(object sender, EventArgs e)
        {
            _isOn = !_isOn;
        }

        public void VolumeDown(object sender, EventArgs e)
        {
            if (_isOn)
                _volume -= 1;
        }

        public void VolumeUp(object sender, EventArgs e)
        {
            if (_isOn)
                _volume += 1;
        }

        public Television(IRemoteControl remoteControl)
        {
            _isOn = false;

            foreach (IButton button in remoteControl.Buttons)
            {
                switch (button.Function)
                {
                    case ButtonFunction.Power:
                        button.Pressed += PowerCycle;
                        break;

                    case ButtonFunction.VolumeUp:
                        button.Pressed += VolumeUp;
                        break;

                    case ButtonFunction.VolumeDown:
                        button.Pressed += VolumeDown;
                        break;

                    case ButtonFunction.ChannelUp:
                        button.Pressed += ChannelUp;
                        break;

                    case ButtonFunction.ChannelDown:
                        button.Pressed += ChannelDown;
                        break;
                }
            }
        }
    }
}