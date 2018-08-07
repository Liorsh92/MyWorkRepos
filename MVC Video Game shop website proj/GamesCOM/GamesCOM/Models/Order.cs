﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesCOM.Models
{
    public class Order
    {

        [Key]
        public int id { get; set; }

        public string userName { get; set; }

        public int sum { get; set; }
    }

}