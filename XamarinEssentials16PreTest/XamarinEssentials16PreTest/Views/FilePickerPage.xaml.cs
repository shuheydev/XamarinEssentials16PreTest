using System;
using System.Collections.Generic;
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
    public partial class FilePickerPage : ContentPage
    {
        public FilePickerPage()
        {
            InitializeComponent();

            PickSingleFileCommand = new Command(async () =>
              {
                  await PickSingleFileAsync();
              });

            PickMultipleFilesCommand = new Command(async () =>
              {
                  await PickMultipleFilesAsync();
              });

            this.BindingContext = this;
        }

        #region PickMultipleFiles
        async Task PickMultipleFilesAsync()
        {
            try
            {
                var files = await FilePicker.PickMultipleAsync();
                LoadFiles(files);
            }
            catch (Exception ex)
            {

            }
        }

        void LoadFiles(IEnumerable<FileResult> files)
        {
            Files = files.Select(f => f.FullPath);
        }

        private IEnumerable<string> _files;
        public IEnumerable<string> Files
        {
            get
            {
                return _files;
            }
            set
            {
                _files = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region PickSingleFile
        async Task PickSingleFileAsync()
        {
            try
            {
                var file = await FilePicker.PickAsync();
                LoadFile(file);
            }
            catch (Exception ex)
            {

            }
        }

        void LoadFile(FileResult file)
        {
            FilePath = file.FullPath;
        }

        private string _filePath;
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public ICommand PickSingleFileCommand { get; private set; }

        public ICommand PickMultipleFilesCommand { get; private set; }
    }
}