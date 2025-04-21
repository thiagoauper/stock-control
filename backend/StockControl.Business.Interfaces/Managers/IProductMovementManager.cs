using StockControl.Domain.Entities;

namespace StockControl.Business.Interfaces.Managers
{
    public interface IProductMovementManager
    {
        int AddProductMovement(ProductMovement productMovement);
    }
}
