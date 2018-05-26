using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateTeam.Toolkit;
using UltimateTeam.Toolkit.Constants;
using UltimateTeam.Toolkit.Models;
using UltimateTeam.Toolkit.Services;

namespace ConsoleAppFUT.Login
{
    public static class LoginManager
    {
        public static async Task ConnectionAsync(FutClient client)
        {
            var loginDetails = new LoginDetails("", "", "", Platform.XboxOne, AppVersion.WebApp);
            ITwoFactorCodeProvider provider = new FutAuth();
            var loginResponse = await client.LoginAsync(loginDetails, provider);
        }

        private class FutAuth : ITwoFactorCodeProvider
        {
            public TaskCompletionSource<string> taskResult = new TaskCompletionSource<string>();
            public Task<string> GetTwoFactorCodeAsync(AuthenticationType authType)
            {
                Console.WriteLine($"{ DateTime.Now } Enter OTP ({ authType }):");
                taskResult.SetResult(Console.ReadLine());
                return taskResult.Task;
            }
        }
    }
}
