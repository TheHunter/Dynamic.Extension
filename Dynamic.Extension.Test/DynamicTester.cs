using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dynamic.Extension.Test.Domain;
using Xunit;

namespace Dynamic.Extension.Test
{
    public class DynamicTester
    {
        [Fact]
        public void AddNewMembersWithProp()
        {
            dynamic instance = new Worker
                {
                    Id = 5,
                    Name = "MyName",
                    Salary = 12000
                };

            instance.SalaryByYear = instance.Salary * 12;
            instance.Surname = "MySurname";

            Assert.NotNull(instance.Surname);
            Assert.Equal(instance.SalaryByYear, instance.Salary * 12);
        }


        [Fact]
        public void AddNewMembersWithNaming()
        {
            dynamic instance = new Worker
            {
                Id = 5,
                Name = "MyName",
                Salary = 12000
            };

            instance.SalaryByYear = instance.Salary * 12;
            instance.Surname = "MySurname";

            Assert.Equal(instance.Surname, instance["Surname"]);
            Assert.Equal(instance.SalaryByYear, instance["SalaryByYear"]);
        }
    }
}
