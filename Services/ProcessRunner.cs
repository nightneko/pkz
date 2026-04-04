using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace pkz.Services
{
    public static class ProcessRunner
    {
        public static async Task<string> RunAsync(string command, string arguments)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/c {command} {arguments}",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };
                process.Start();
                string output = await process.StandardOutput.ReadToEndAsync();
                await process.WaitForExitAsync();

                return output;
            } 
            catch
            {
                return string.Empty;
            }
        }
    }
}
