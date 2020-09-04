using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Group.Model
{
    class Class1
    {
        public class Content
        {
            public string description { get; set; }
            public string url { get; set; }
        }

        public class Root
        {
            public int id { get; set; }
            public string date { get; set; }
            public string title { get; set; }
            public string image { get; set; }
            public Content content { get; set; }
        }
    }
}
