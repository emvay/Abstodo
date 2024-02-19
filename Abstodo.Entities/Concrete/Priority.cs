using Abstodo.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstodo.Entities.Concrete
{

        public enum PriorityEnum
        {
            Low = 1,
            Medium = 2,
            High = 3,
            Critical = 4
        }

        public class Priority
        {
            public int ID { get; set; }
            public PriorityEnum Name { get; set; }
        }
}
