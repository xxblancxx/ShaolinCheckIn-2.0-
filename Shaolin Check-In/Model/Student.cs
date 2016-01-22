using Shaolin_Check_In.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Shaolin_Check_In.Model
{
    class Student
    {
        private BitmapImage _profilePicture;


        public string Name { get; set; }
        public int Id { get; set; }

        public int Team { get; set; }

        public byte[] Image { get; set; }
        public bool IsActive { get; set; }

        public BitmapImage ProfilePicture
        {
            get
            {
                if (Image != null)
                {
                    return ConvertImg();
                }
                if (Image == null)
                {
                    return new BitmapImage(new Uri("ms-appx:///Assets/NoAvatar.png"));
                }
                return null;
            }
            private set { _profilePicture = value; }
        }

        public Student(string name, int team)
        {
            Name = name;
            IsActive = true;
            Team = team;
        }

        public BitmapImage ConvertImg()
        {
            var handler = new ImageConversionHandler();
            return handler.Convert(Image);
        }
    }
}
