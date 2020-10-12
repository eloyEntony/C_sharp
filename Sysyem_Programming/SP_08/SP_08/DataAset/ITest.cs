using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_08.DataAset
{
    interface ITest
    {
        long GetPlayerInMS(int id);
        long GetPlayersTeamInMS(int teamId);
        long GetTeamsInSportInMS(int sportId);
    }
}
