using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Events
{
    #region Pluralsight Example

    public delegate void ClickHandler(object sender, EventArgs e);

    public class LongHandEventRaiser
    {
        private ClickHandler currentHandler = null;

        public void OnClick()
        {
            ClickHandler tmp = currentHandler;
            if (tmp != null)
                tmp.Invoke(this, EventArgs.Empty);
        }

        public event ClickHandler Click
        {
            add { currentHandler += value; }
            remove { currentHandler -= value; }
        }
    }

    public class ShorthandEventRaiser
    {
        public void OnClick()
        {
            ClickHandler tmp = Click;
            if (tmp != null)
                tmp.Invoke(this, EventArgs.Empty);
        }

        public event ClickHandler Click;
    }

    #endregion Pluralsight Example

    #region My room with different switches example

    public interface ISwitch
    {
        void Flip();
    }

    public interface ISwitchableEquipment
    {
        bool On { get; }

        void SwitchFlipped();
    }

    public interface ILight : ISwitchableEquipment
    {
    }

    public class Switch : ISwitch
    {
        public delegate void eventRaiser();

        public event eventRaiser OnSwitchFlip;

        public void Flip()
        {
            if (OnSwitchFlip != null)
                OnSwitchFlip();
        }
    }

    public class Light : ILight
    {
        private bool _on;

        public bool On
        {
            get
            {
                return _on;
            }
        }

        public Light()
        {
            _on = false;
        }

        public void SwitchFlipped()
        {
            _on = !_on;
        }
    }

    public class Room
    {
        private Switch _lightSwitch = new Switch();
        private Light _light = new Light();

        public Switch LightSwitch
        {
            get
            {
                return _lightSwitch;
            }
        }

        public Light Light
        {
            get
            {
                return _light;
            }
        }

        public Room()
        {
            _lightSwitch.OnSwitchFlip += _light.SwitchFlipped;
        }
    }

    #endregion My room with different switches example

    #region My try using interfaces as well

    public interface ISwitch2
    {
        void Flip();

        event EventHandler SwitchFlipped;
    }

    public interface ISwitchableEquipment2
    {
        bool On { get; }

        void SwitchFlipped(object sender, EventArgs e);
    }

    public interface ILight2 : ISwitchableEquipment2
    {
    }

    public class Switch2 : ISwitch2
    {
        public event EventHandler SwitchFlipped;

        public void Flip()
        {
            if (SwitchFlipped == null)
                return;

            SwitchFlipped(this, EventArgs.Empty);
        }
    }

    public class Light2 : ILight2
    {
        private bool _on;

        public bool On
        {
            get
            {
                return _on;
            }
        }

        public Light2()
        {
            _on = false;
        }

        public void SwitchFlipped(object sender, EventArgs e)
        {
            _on = !_on;
        }
    }

    public class Room2
    {
        private ISwitch2 _lightSwitch2 = new Switch2();
        private ILight2 _light = new Light2();

        public Room2()
        {
            _lightSwitch2.SwitchFlipped += _light.SwitchFlipped;
        }

        public ILight2 Light
        {
            get
            {
                return _light;
            }
        }

        public ISwitch2 LightSwitch
        {
            get
            {
                return _lightSwitch2;
            }
        }
    }

    #endregion My try using interfaces as well
}