using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PicClockMvx.Core.Models
{
    public class ProfileHolder
    {
        private SystemIO io;
        //private JArray profileJarray;
		private JObject profileJobject;
        public Profile Profile { get; set; }
        //public int ProfileLength { get; private set; }
        public static ProfileHolder Current { get; } = new ProfileHolder()
        {
            io = new SystemIO("Profile.json")
        };
		public List<Profile> ProfileList { get; private set; } = new List<Profile>();

        public void Load()
        {
            io.LoadString();
            //profileJarray = JArray.Parse(io.String);
            //ProfileLength = profileJarray.Count;
			try
			{
				profileJobject = JObject.Parse(io.String);
			}
			catch(Exception e)
			{
				throw e;
			}

			try
			{
				ProfileList = profileJobject["Profile"].ToObject<List<Profile>>();	
			}
			catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.ToString());
				throw e;
			}
        }

        public void SetProfile()
        {
			//var stringProfile = profileJarray[ImageHolder.Current.Index].ToString();
            //Profile = JsonConvert.DeserializeObject<Profile>(stringProfile);
			Profile = ProfileList[ImageHolder.Current.Index];
        }
    }
}
