using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchPresenter.Core.Services
{
    public class MediaService
    {

        private string GetVideoDirectory()
        {
           return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Church Presenter", "Resources", "Media", "Videos");
        }

        private string GetImagesDirectory()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Church Presenter", "Resources", "Media", "Images");
        }

        private string GetThumbnailDirectory() 
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Church Presenter", "Resources", "Media", "Thumbnails");
        }

        public string GetDataDirectory()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Church Presenter", "Resources", "Data");
        }

        public bool CreateApplicationDataDirectories()
        {
            try
            {
                CreateDirectory(GetDataDirectory(),true);
                CreateDirectory(GetThumbnailDirectory(),true);
                CreateDirectory(GetImagesDirectory());
                CreateDirectory(GetVideoDirectory());

                return true;
            }
            catch (Exception)
            {
                return false;
            }
     

        }

        private void CreateDirectory(string name, bool hidden = false)
        {
            if (!Directory.Exists(name))
            {
                Directory.CreateDirectory(name);
            }

            DirectoryInfo dir = new DirectoryInfo(name);

            if (hidden)
                dir.Attributes |= FileAttributes.Hidden;
            else
                dir.Attributes &= ~FileAttributes.Hidden;
        }


        public string[] GetAllVideoFiles()
        {
            return Directory.GetFiles(GetVideoDirectory());
        }

        public string[] GetAllImageFiles()
        {
            return Directory.GetFiles(GetImagesDirectory());

        }
        public string[] GetAllVideoThumbnailFiles()
        {
            return Directory.GetFiles(GetThumbnailDirectory());
        }


        public void SaveImage()
        {
            //check file extensions

            throw new NotImplementedException();
        }


    }
}
