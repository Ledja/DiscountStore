﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CartItemEditModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
