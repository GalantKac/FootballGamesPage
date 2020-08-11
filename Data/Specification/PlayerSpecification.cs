using Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Data.Specification
{
    public class PlayerSpecification : BaseSpecification<Player>
    {
        public PlayerSpecification(int id) : base(item => item.Id == id) { }

        public PlayerSpecification(string name, string password): base(item=> item.Name == name && item.Password == password) { }
    }
}
