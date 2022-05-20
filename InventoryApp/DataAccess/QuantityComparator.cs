﻿using InventoryApp.DataAccess.Interfaces;
using InventoryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApp.DataAccess
{
    public class QuantityComparator : IObjectComparator<Product>
    {
        private const int SOURCE_IS_SMALLER = -1;
        private const int SOURCE_IS_GREATER = 1;

        public int Compare(Product source, Product destination)
        {
            return source.Quantity <= destination.Quantity ? SOURCE_IS_SMALLER : SOURCE_IS_GREATER;
        }


    }
}
