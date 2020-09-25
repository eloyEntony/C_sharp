using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BLL.Model;

namespace University.BLL.Services
{
    public interface IGroupService
    {
        IEnumerable<GroupDTO> GetGroups();
        void AddGroup(GroupDTO group);
    }
}
