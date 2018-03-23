using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Friend
    {
        public Friend()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String SurName { get; set; }
        public String Email { get; set; }
        public int Phone { get; set; }
        public DateTime Birthday { get; set; }
    }
}
