using AsyncAwaitBestPractices.MVVM;
using ServiceResult;
using SuaveKeys.SnapReader.Uwp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Graphics.Capture;
using Windows.UI.Xaml;

namespace SuaveKeys.SnapReader.Uwp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly ISuaveKeysService _suaveKeysService;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SuaveKeysSignInCommand { get; set; }
        public ICommand ToggleStartCommand { get; set; }
        public bool IsListening { get; set; }
        public Visibility SuaveKeysSignInVisibility { get; set; }
        public string CommandLog { get; set; }
        public string Error { get; set; }
        public MainPageViewModel()
        {
            _suaveKeysService = App.Current?.Container?.Resolve<ISuaveKeysService>();
            CommandLog = "";
            SuaveKeysSignInCommand = new AsyncCommand(async () =>
            {
                var signInResult = await _suaveKeysService.StartSignInAsync();
                SuaveKeysSignInVisibility = signInResult?.ResultType == ResultType.Ok ? Visibility.Visible : Visibility.Collapsed;
            });
            ToggleStartCommand = new AsyncCommand(async () =>
            {
                if (!GraphicsCaptureSession.IsSupported())
                {
                    Error = "This device does not support the capture requirements";
                    return;
                }
                // The GraphicsCapturePicker follows the same pattern the
                // file pickers do.
                var picker = new GraphicsCapturePicker();
                GraphicsCaptureItem item = await picker.PickSingleItemAsync();

                // The item may be null if the user dismissed the
                // control without making a selection or hit Cancel.
                if (item != null)
                {
                    // We'll define this method later in the document.
                    //StartCaptureInternal(item);
                    // TODO: start capturing frames and running through some sort of qr reader
                }
            });
        }
    }
}
