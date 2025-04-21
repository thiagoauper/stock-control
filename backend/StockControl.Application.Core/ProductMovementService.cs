using StockControl.Application.Interfaces;
using StockControl.Domain.DTOs;
using StockControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Application.Core
{
    internal class ProductMovementService : IProductMovementService
    {
        public void AddProductMovement(ProductMovementDTO productMovement)
        {
            if (!productMovement.IsValid())
            {
                throw new ArgumentException("Invalid product movement data.");
            }

            ProductMovement movement = productMovement.ToModel();

            //TODO: Persist product movement in the data base!!!
        }
    }
}
