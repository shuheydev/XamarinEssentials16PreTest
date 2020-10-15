using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinEssentials16PreTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediaPickerPage : ContentPage
    {
        public MediaPickerPage()
        {
            InitializeComponent();

            TakePhotoCommand = new Command(async () =>
             {
                 await TakePhotoAsync();
             });

            CaptureVideoCommand = new Command(async () =>
            {
                await CaptureVideoAsync();
            });

            PickPhotoCommand = new Command(async () =>
            {
                await PickPhotoAsync();
            });

            PickVideoCommand = new Command(async () =>
              {
                  await PickVideoAsync();
              });

            this.BindingContext = this;
        }

        public ICommand TakePhotoCommand { get; private set; }

        public ICommand CaptureVideoCommand { get; private set; }

        public ICommand PickPhotoCommand { get; private set; }

        public ICommand PickVideoCommand { get; private set; }

        #region CaptureVideo
        async Task CaptureVideoAsync()
        {
            try
            {
                var video = await MediaPicker.CaptureVideoAsync();
                await LoadVideoAsync(video);
            }
            catch (Exception ex)
            {

            }
        }

        async Task LoadVideoAsync(FileResult video)
        {
            //canceled
            if (video == null)
            {
                VideoPath = null;
                return;
            }

            //save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, video.FileName);
            using (var stream = await video.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            VideoPath = newFile;
        }
        private string _videoPath;
        public string VideoPath
        {
            get
            {
                return _videoPath;
            }
            set
            {
                _videoPath = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region TakePhoto
        async Task TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadPhotoAsync(photo);
            }
            catch (Exception ex)
            {

            }
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            //canceled
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }

            //save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            PhotoPath = newFile;
        }

        private string _photoPath;
        public string PhotoPath
        {
            get
            {
                return _photoPath;
            }
            set
            {
                _photoPath = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region PickVideo
        async Task PickVideoAsync()
        {
            var video = await MediaPicker.PickVideoAsync();
            await LoadVideoAsync(video);
        }
        #endregion

        #region PickPhoto
        async Task PickPhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                await LoadPhotoAsync(photo);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}