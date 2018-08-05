using System;
using System.IO;
using System.Reflection;
using PCLStorage;
using System.Threading.Tasks;

namespace PicClockMvx.Core.Models
{
    public class SystemIO
    {
        string fileName;
        string savedFileName;
        public string String { get; set; }
        //Constructors
        public SystemIO(string name)
        {
            fileName = name;
        }
        public SystemIO(string name, string savedName)
        {
            fileName = name;
            savedFileName = savedName;
        }

        public void LoadString()
        {
            var assembly = typeof(SystemIO).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("PicClockMvx.Core." + fileName);
            using (var reader = new StreamReader(stream))
            {
                String = reader.ReadToEnd();
            }
        }

        public async Task LoadAsync()
        {
            var rootFolder = FileSystem.Current.LocalStorage;
            var fileResult = await rootFolder.CheckExistsAsync(savedFileName);
            if (fileResult == ExistenceCheckResult.FileExists)
            {
                var file = await rootFolder.CreateFileAsync(savedFileName,
                                                            CreationCollisionOption.OpenIfExists);
                String = await file.ReadAllTextAsync();
            }
            else
            {
                LoadString();
            }
        }
        public async Task SaveAsync(string jsonString)
        {
            var rootFolder = FileSystem.Current.LocalStorage;
            var file = await rootFolder.CreateFileAsync(savedFileName,
                                                        CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(jsonString);
        }

    }
}
