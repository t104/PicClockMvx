using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PicClockMvx.Core.Models
{
    public class ImageHolder
    {
        private JObject imageJobject;
        private SystemIO io;
        private Random random;
        public int Index { get; private set; }
        public Image Image { get; set; }
        public List<Image> ImageList { get; private set; } = new List<Image>();
		public List<Image> BonusImage { get; private set; } = new List<Image>();
        public static ImageHolder Current { get; } = new ImageHolder()
        {
            io = new SystemIO("Image.json", "SavedImage.json"),
            Index = 0,
            random = new Random()
        };


        public async Task LoadAsync()
        {
            await io.LoadAsync();
            imageJobject = JObject.Parse(io.String);
            ImageList = imageJobject["ProfileImage"].ToObject<List<Image>>();
            try {
                BonusImage = imageJobject["Bonus"].ToObject<List<Image>>();
            }
            catch(Exception e){
                throw e;
            }
        }

        public async Task InitializeAlbum()
        {
            io.LoadString();
            imageJobject = JObject.Parse(io.String);
            ImageList = imageJobject["ProfileImage"].ToObject<List<Image>>();
            await io.SaveAsync(io.String);
        }

        public void SetImage()
        {
            Image = ImageList[Current.Index];
        }

        public void NewImage()
        {
            var n = Current.ImageList.Count;
			Index = (Index + random.Next(1, n-1)) %n;
        }

		public void OverwriteImage()
        {
            ImageList[Current.Image.ID] = Current.Image;
			imageJobject["ProfileImage"] = JArray.FromObject(ImageList);
            string stringToSave = imageJobject.ToString();
            var save = io.SaveAsync(stringToSave);
        }
    }
}
