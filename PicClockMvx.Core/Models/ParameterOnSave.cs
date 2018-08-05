using System;
namespace PicClockMvx.Core.Models
{
    public class ParameterOnSave
    {
		public string ImageName { get; set; }
		public Action<bool> CallBack { get; set; }
    }
}
