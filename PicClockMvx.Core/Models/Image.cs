namespace PicClockMvx.Core.Models
{
    public class Image
    {
        public int ID { get; set; }
        public string ClockImageName { get; set; }
        public string ProfileImageName { get; set; }
        public int ClockPositionX { get; set; }
        public int ClockPositionY { get; set; }
        public bool IsVisible { get; set; }

    }
}
