using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BLL.Model;
using University.DAL.Entityes;
using University.DAL.Repository;

namespace University.BLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGenericRepository<Student> repoStudent;
        private readonly IGenericRepository<Groups> repoGroup;
        private readonly IMapper mapper;
        public GroupService(IGenericRepository<Student> _repoStudent,
           IGenericRepository<Groups> _repoGroup, IMapper _mapper)
        {
            repoStudent = _repoStudent;
            repoGroup = _repoGroup;
            mapper = _mapper;
        }
        public void AddGroup(GroupsDTO group)
        {
            var addGroup = mapper.Map<Groups>(group);
            repoGroup.Create(addGroup);
        }

        public void DeleteGroup(GroupsDTO group)
        {
            var deleteGroup = mapper.Map<Groups>(group);
            repoGroup.Delete(deleteGroup);
        }

        public IEnumerable<GroupsDTO> GetGroup()
        {
            var group = repoGroup.GetAll();
            var modelGroup = mapper.Map<ICollection<GroupsDTO>>(group);
            return modelGroup;
        }

        public void UpdateGroup(GroupsDTO group)
        {
            throw new NotImplementedException();
        }
    }
}
