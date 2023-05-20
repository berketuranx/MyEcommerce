using MyEcommerce.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.Entity.Interface
{
    public interface IEntity<T>
    {
        public int Id { get; set; }
        public T MasterId { get; set; }
        //Created
        public DateTime CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedAdUsername { get; set; }
        public string CreatedIpAddress { get; set; }


        //Updated
        public DateTime UpdatedDate { get; set; }
        public string UpdatedComputerName { get; set; }
        public string UpdatedAdUsername { get; set; }
        public string UpdatedIpAddress { get; set; }

        public bool IsActive { get; set; }
        public Status Status { get; set; }//
    }
}
