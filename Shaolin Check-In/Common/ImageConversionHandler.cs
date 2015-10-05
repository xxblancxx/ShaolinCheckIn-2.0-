using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Shaolin_Check_In.Common
{
    class ImageConversionHandler
    {

        public BitmapImage Convert(byte[] data)
        {
            using (InMemoryRandomAccessStream raStream =
                new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(raStream))
                {
                    // Write the bytes to the stream
                  writer.WriteBytes(data);

                    // Store the bytes to the MemoryStream
                    writer.StoreAsync();

                    // Not necessary, but do it anyway
                    writer.FlushAsync();

                    // Detach from the Memory stream so we don't close it
                    writer.DetachStream();
                }

                raStream.Seek(0);

                BitmapImage bitMapImage = new BitmapImage();
                bitMapImage.SetSource(raStream);

                return bitMapImage;
            }
        }
    }
}
