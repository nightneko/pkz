using CommunityToolkit.Mvvm.ComponentModel;
using MaterialDesignThemes.Wpf;

namespace pkz.Models
{
    public partial class PackageManagerInfo : ObservableObject
    {
        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        private PackIconKind _iconKind;

        [ObservableProperty]
        private int _updateCount;

        [ObservableProperty]
        private bool _isInstalled;
    }
}
