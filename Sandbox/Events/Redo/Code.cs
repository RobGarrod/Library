using Sandbox.Events.Redo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Events.Redo.Interface
{
    public interface IPushable
    {
        void Push();

        event EventHandler Pushed;
    }

    public interface IPullable
    {
        void Pull();

        event EventHandler Pulled;
    }

    public interface ILever : IPushable, IPullable
    {
        bool IsLeverPulled { get; }
    }

    public interface IOpenable
    {
        void Open(object sender, EventArgs e);
    }

    public interface ICloseable
    {
        void Close(object sender, EventArgs e);
    }

    public interface IDoor : IOpenable, ICloseable
    {
        bool IsOpen { get; }
    }
}

namespace Sandbox.Events.Redo.Concrete
{
    public class Door : IDoor
    {
        public bool IsOpen { get; private set; }

        public Door(ILever lever)
        {
            lever.Pulled += Open;
            lever.Pushed += Close;
        }

        public void Close(object sender, EventArgs e)
        {
            IsOpen = false;
        }

        public void Open(object sender, EventArgs e)
        {
            IsOpen = true;
        }
    }

    public class Lever : ILever
    {
        public bool IsLeverPulled { get; private set; }

        public event EventHandler Pulled;

        public event EventHandler Pushed;

        public void Pull()
        {
            Pulled?.Invoke(this, EventArgs.Empty);
        }

        public void Push()
        {
            Pushed?.Invoke(this, EventArgs.Empty);
        }
    }
}