using System;
namespace PicClockMvx.Core.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Home { get; set; }
        public string Message { get; set; }
		private string compareTo;
		public string CompareTo
		{
			get { return compareTo; }
			set { compareTo = "やっさんを[" + value + "]にたとえると"; }
		}
		public string WouldBe { get; set; }
		private string nicname;
		public string Nickname
		{
			get => nicname;
			set => nicname = "by " + value;
		}
    }
}
