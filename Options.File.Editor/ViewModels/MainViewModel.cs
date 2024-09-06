using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Options.File.Editor.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public static string PackageVersion => GetPackageVersion();

        private static string GetPackageVersion()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var version = assembly?.GetName().Version?.ToString();
            return version ?? "Error getting version number.";
        }

        public ObservableCollection<string> FirstListItems { get; } = new ObservableCollection<string>
        {
            "Item 1",
            "Item 2",
            "Item 3"
        };

        private string _selectedFirstItem;
        public string SelectedFirstItem
        {
            get => _selectedFirstItem;
            set
            {
                if (_selectedFirstItem != value)
                {
                    _selectedFirstItem = value;
                    OnPropertyChanged();
                    UpdateSecondListItems();
                }
            }
        }

        public ObservableCollection<string> SecondListItems { get; } = new ObservableCollection<string>();

        private void UpdateSecondListItems()
        {
            SecondListItems.Clear();
            if (SelectedFirstItem == "Item 1")
            {
                SecondListItems.Add("Subitem A");
                SecondListItems.Add("Subitem B");
                SecondListItems.Add("Subitem C");
            }
            else if (SelectedFirstItem == "Item 2")
            {
                SecondListItems.Add("Subitem D");
                SecondListItems.Add("Subitem E");
                SecondListItems.Add("Subitem F");
            }
            // Add more conditions as needed
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}