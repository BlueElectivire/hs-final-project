using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    public class Score : BaseEntity
    {
        private User user;
        private int level;
        private Role role;
        private int points;

        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }
        public Role Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
            }
        }
        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }
    }
}
