using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Core.Entities
{
    public class Person
    {
        public int ID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string Discriminator { get; set; }
    }
}
