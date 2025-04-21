using StockControl.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Application.Interfaces
{
    public interface IProductMovementService
    {
        /// <summary>
        /// Adds a new product movement to the system.
        /// </summary>
        /// <param name="productMovement">The product movement to add.</param>
        void AddProductMovement(ProductMovementDTO productMovement);
    }
}
