using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Devices.Enumeration;    // Used to enumerate cameras on the device
using Windows.Devices.Sensors;        // Orientation sensor is used to rotate the camera preview
using Windows.Graphics.Display;       // Used to determine the display orientation
using Windows.Graphics.Imaging;       // Used for encoding captured images
using Windows.Media;                  // Provides SystemMediaTransportControls
using Windows.Media.MediaProperties;  // Used for photo and video encoding
using Windows.Storage.FileProperties; // Used for image file encoding
using Windows.Storage.Streams;        // General file I/O
using Windows.System.Display;         // Used to keep the screen awake during preview and capture
using Windows.UI.Core;





namespace Shaolin_Check_In.Common
{
    class PictureHandler
    {

        private MediaCapture _mediaCapture;
        private bool _isInitialized;
        private bool _isPreviewing;
        private bool _isRecording;

        public static async Task<StorageFile> PictureTime()
        {
            CameraCaptureUI camUI = new CameraCaptureUI();
            camUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            camUI.PhotoSettings.CroppedAspectRatio = new Size(1, 1);
            camUI.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.SmallVga;
            StorageFile sf = await camUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (sf == null)
            {
                // User cancelled photo capture
                return null;
            }
            else
            {
                return sf;
            }
        }


    }
}
