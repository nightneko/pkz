namespace pkz.Services
{
    public static class PackageManagerChecker
    {
        public static async Task<bool> IsInstalledAsync(string managerName)
        {
            // 디버그
            //if (managerName == "npm") return false;

            string output = managerName switch
            {
                "winget" => await ProcessRunner.RunAsync("winget", "--version"),
                "choco" => await ProcessRunner.RunAsync("choco", "--version"),
                "npm" => await ProcessRunner.RunAsync("npm", "--version"),
                _ => string.Empty
            };

            return !string.IsNullOrWhiteSpace(output);
        }
    }
}