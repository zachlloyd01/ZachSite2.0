﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZachSite2._0.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}