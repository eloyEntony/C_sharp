using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BLL.Model;
using University.DAL;
using University.DAL.Repository;

namespace University.BLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGenericRepository<Groups> repoG;
        private readonly IMapper mapper;

        public GroupService(IGenericRepository<Groups> _repoG,  IMapper _mapper)
        {
            repoG = _repoG;
            mapper = _mapper;
        }
        public void AddGroup(GroupDTO group)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupDTO> GetGroups()
        {
            var groups = repoG.GetAll();

            var model = mapper.Map<ICollection<GroupDTO>>(groups);
            return model;
        }
    }
}
