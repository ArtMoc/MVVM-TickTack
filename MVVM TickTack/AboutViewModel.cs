using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MVVM_TickTack
{
    class AboutViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string _aboutText;
        BitmapSource _bitmapImageSource;

        public string AboutText
        {
            get { return _aboutText; }
        }
        public BitmapSource BitmapImageSource
        {
            get { return _bitmapImageSource; }
        }
        public AboutViewModel()
        {
            _aboutText = "Данная програма создавалась с целью изучить MVVM на WPF";
            _bitmapImageSource = new BitmapImage(new Uri("d:\\1\\cat.jpg"));
            Notify("AboutText");
            Notify("BitmapImageSource");
        }
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
