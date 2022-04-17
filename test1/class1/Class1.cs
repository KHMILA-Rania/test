using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test1.class1
{
   
    
        public class Customer : IEntityWithId
        {
            public int ID { get; set; }
            public string NAME { get; set; }
            public string DESCRIPTION { get; set; }
        }

    public interface IEntityWithId
    {
        int ID { get; set; }
    }
}