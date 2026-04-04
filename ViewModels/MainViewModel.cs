using CommunityToolkit.Mvvm.ComponentModel;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using pkz.Models;
using pkz.Services;

namespace pkz.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        // 사이드바에서 선택된 패키지 매니저 데이터
        [ObservableProperty]
        private PackageManagerInfo? _selectedManagerInfo;

        // 컨텐츠 영역에 표시될 ViewModel
        [ObservableProperty]
        private ObservableObject? _currentViewModel;

        public ObservableCollection<PackageManagerInfo> Managers { get; } = new()
        {
            new PackageManagerInfo { Name = "winget", IconKind = PackIconKind.MicrosoftWindows, UpdateCount = 0, IsInstalled = false },
            new PackageManagerInfo { Name = "choco",  IconKind = PackIconKind.Package,          UpdateCount = 0, IsInstalled = false },
            new PackageManagerInfo { Name = "npm",    IconKind = PackIconKind.Npm,              UpdateCount = 0, IsInstalled = false }
        };

        public MainViewModel()
        {
            // 반환값 안쓴다고
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            foreach (var manager in Managers) 
            {
                manager.IsInstalled = await PackageManagerChecker.IsInstalledAsync(manager.Name);
            }
        }

        partial void OnSelectedManagerInfoChanged(PackageManagerInfo? value)
        {
            CurrentViewModel = value?.Name switch
            {
                "winget" => value.IsInstalled ? new WingetViewModel() : new InstallGuideViewModel("winget"),
                "choco" => value.IsInstalled ? new ChocoViewModel() : new InstallGuideViewModel("choco"),
                "npm" => value.IsInstalled ? new NpmViewModel() : new InstallGuideViewModel("npm"),
                _ => null
            };
        }
    }
}
