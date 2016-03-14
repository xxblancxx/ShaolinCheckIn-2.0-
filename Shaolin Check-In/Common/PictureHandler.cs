using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Media.Capture;
using Windows.Storage;

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
            camUI.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.VerySmallQvga;
            StorageFile sf = await camUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
            return sf;
        }



    }
}
