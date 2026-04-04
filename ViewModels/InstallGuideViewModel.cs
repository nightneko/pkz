using CommunityToolkit.Mvvm.ComponentModel;

namespace pkz.ViewModels
{
    public partial class InstallGuideViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _managerName;

        public InstallGuideViewModel(string managerName)
        {
            _managerName = managerName;
        }
    }
}