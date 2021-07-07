using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.OleDb;

namespace ViewModel
{
    public class ChangeEntity
    {
        private BaseEntity entity;
        private readonly CreateSQL create;

        public delegate void CreateSQL(BaseEntity entity, OleDbCommand cmd);

        public ChangeEntity(BaseEntity entity, CreateSQL create)
        {
            this.entity = entity;
            this.create = create;
        }

        public BaseEntity Entity
        {
            get
            {
                return entity;
            }
            set
            {
                entity = value;
            }
        }
        public CreateSQL Create
        {
            get
            {
                return create;
            }
        }
    }
}
