using System.Collections.ObjectModel;
using System.Linq;

namespace WpfTiles
{
    class MainWindowViewModel
    {
        public ObservableCollection<ColorInfo> Colors { get; }

        public MainWindowViewModel()
        {
            Colors = new ObservableCollection<ColorInfo>(ColorInfo.EnumerateAllColors().OrderBy(c => c.Name));
        }
    }
}
