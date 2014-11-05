using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynamic.Extension.Test.Domain
{
    public class Worker
        : DynamicBinder
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Salary { get; set; }
    }
}
