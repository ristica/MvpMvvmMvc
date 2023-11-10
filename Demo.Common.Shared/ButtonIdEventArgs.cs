using System;

namespace Demo.Common.Shared
{
    public class ButtonIdEventArgs : EventArgs
    {
        public int ButtonId { get; private set; }

        public ButtonIdEventArgs(int buttonId)
        {
            this.ButtonId = buttonId;
        }
    }
}
