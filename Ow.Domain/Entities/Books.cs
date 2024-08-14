using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Ow.Domain.Entities
{
    public class Books : Entity<Guid>
    {
        public Books() { }
        public Books(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; set; } 
        public string Description { get; set; }
    }
}
