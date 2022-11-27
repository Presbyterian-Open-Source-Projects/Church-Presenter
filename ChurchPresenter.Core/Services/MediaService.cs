using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchPresenter.Core.Services
{
    public static class MediaService
    {

        private static string GetVideoDirectory()
        {
           return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Church Presenter", "Resources", "Media", "Videos");
        }

        private static string GetImagesDirectory()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Church Presenter", "Resources", "Media", "Images");
        }

        private static string GetThumbnailDirectory() 
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Church Presenter", "Resources", "Media", "Thumbnails");
        }

        private static string GetDbDataDirectory()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Church Presenter", "Resources", "Data");
        }

        public static bool CreateApplicationDataDirectories()
        {
            try
            {
                CreateDirectory(GetDbDataDirectory(),true);
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

        private static void CreateDirectory(string name, bool hidden = false)
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


        public static string[] GetAllVideoFiles()
        {
            return Directory.GetFiles(GetVideoDirectory());
        }

        public static string[] GetAllImageFiles()
        {
            return Directory.GetFiles(GetImagesDirectory());

        }
        public static string[] GetAllVideoThumbnailFiles()
        {
            return Directory.GetFiles(GetThumbnailDirectory());
        }

        public static string GetDbPath()
        {
            return Path.Combine( GetDbDataDirectory(), "data.lyrics");
        }

        public static void SaveImage()
        {
            //check file extensions copy files

            throw new NotImplementedException();
        }


    }
}
