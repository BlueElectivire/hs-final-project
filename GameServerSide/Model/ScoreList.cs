using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [CollectionDataContract]
    public class ScoreList : List<Score>
    {
        public ScoreList() : base() { }
        public ScoreList(IEnumerable<Score> list) : base(list) { }
        public ScoreList(IEnumerable<BaseEntity> list) : base(list.Cast<Score>().ToList()) { }
    }
}
