using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [CollectionDataContract]
    public class RoleList : List<Role>
    {
        public RoleList() : base() { }
        public RoleList(IEnumerable<Role> list) : base(list) { }
        public RoleList(IEnumerable<BaseEntity> list) : base(list.Cast<Role>().ToList()) { }
    }
}
