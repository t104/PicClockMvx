using System;
using MvvmCross.Plugins.Messenger;

namespace PicClockMvx.Core.Models
{
    public class MyMessage
        : MvxMessage
    {
        public MyMessage(object sender) : base(sender)
        {
        }
    }
}
