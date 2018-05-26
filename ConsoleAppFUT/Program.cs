using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateTeam;
using UltimateTeam.Toolkit;
using ConsoleAppFUT.Login;

namespace ConsoleAppFUT
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new FutClient();

            try
            {
                LoginManager.ConnectionAsync(client).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
           

            var creditsResponse = client.GetCreditsAsync().GetAwaiter().GetResult();
            Console.WriteLine($"Crediti: {creditsResponse.Credits}");

            var squadListResponse = client.GetSquadListAsync().GetAwaiter().GetResult();

            foreach (var squad in squadListResponse.Squad)
            {
                Console.WriteLine($"{squad.SquadName}");

                //squad.Id nella ricerca, non corrisponde a quello della lista
                //var squadDetailsResponse = client.GetSquadDetailsAsync(squad.Id).GetAwaiter().GetResult();
                //foreach (var squadPlayer in squadDetailsResponse.Players)
                //{
                //    Console.WriteLine($"{squadPlayer.ItemData.FirstName} {squadPlayer.ItemData.LastName}");
                //}

                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
