﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.FooterAddressDtos
{
    public class ResultFooterAddressDto
    {
        public int footerAddressID { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
