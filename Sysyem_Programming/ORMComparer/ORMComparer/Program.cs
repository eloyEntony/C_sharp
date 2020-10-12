using Dapper;
using ORMComparer.DataAccess;
using ORMComparer.Helpers;
using ORMComparer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMComparer
{
    class Program
    {
        static int countS = 0;
        static int countT = 0;
        static int countP = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter sport count : ");
            countS = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter sport count : ");
            countT = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter sport count : ");
            countP = int.Parse(Console.ReadLine());

            List<Sport> sports = Generator.GenerateSport(countS);
            List<Team> teams = new List<Team>();
            List<Player> players = new List<Player>();

            foreach (var item in sports)
            {
                var tmp = Generator.GenerateTeams(item.Id, countT);
                teams.AddRange(tmp);

                foreach (var item1 in tmp)
                {
                    var tmp1 = Generator.GeneratePlayers(item1.Id, countP);
                    players.AddRange(tmp1);
                }
            }

            Database.Reset();
            Database.Load(players, teams, sports);


            var allTests = new List<TestResult>();
            allTests.AddRange(new[]{
                              StartProcess(Framework.EntityFramework, new EF()),
                              StartProcess(Framework.AdoNet, new ADO()),
                              StartProcess(Framework.Dapper, new Dapper_())
            });
            ShowResults(allTests);
        }
        private static void ShowResults(List<TestResult> allTests)
        {
            foreach (var item in allTests)
            {
                Console.WriteLine("_____________{0}______________\n",
                    Enum.GetName(typeof(Framework),
                    item.Framework));
                Console.WriteLine("{0,-15}, {1,15}{2,15}",
                                  "PlayerById", "PlayersInTeam", "TeamsInSport");
                Console.WriteLine("{0,-15}, {1,15}{2,15}",
                                    item.PlayerMs, item.SportMs, item.TeamMs);
            }
        }
        private static TestResult StartProcess(Framework framework, ITest test)
        {
            var result = new TestResult { Framework = framework };
            for (int i = 0; i < countP; i++)
                result.PlayerMs += test.GetPlayerInMS(i);
            result.PlayerMs /= countP;
            for (int i = 0; i < countT; i++)
                result.TeamMs += test.GetPlayersTeamInMS(i);
            result.TeamMs /= countT;
            for (int i = 0; i < countS; i++)
                result.SportMs += test.GetTeamsInSportInMS(i);
            result.SportMs /= countS;
            return result;
        }


    }
}
