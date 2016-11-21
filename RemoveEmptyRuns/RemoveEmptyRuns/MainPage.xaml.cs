using System.ComponentModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RemoveEmptyRuns
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private string _MyProperty;
        public string MyProperty
        {
            get { return _MyProperty; }
            set
            {
                _MyProperty = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MyProperty)));
            }
        }


        public MainPage()
        {
            this.InitializeComponent();
            LoadAsync();
        }

        private async Task LoadAsync()
        {
            await Task.Delay(2000);
            MyProperty = "Some text";
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
