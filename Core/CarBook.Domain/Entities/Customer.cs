﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int CustomerName { get; set; }
        public int CustomerSurname { get; set; }
        public int CustomerMail { get; set; }
        public List<RentACarProcess> RentACarProcesses { get; set; }
    }
}
