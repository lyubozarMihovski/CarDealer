using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Services
{
    public interface ISaleService
    {
        IEnumerable<SalesModel> All();

        SalesModel SaleById(int id);

        IEnumerable<SalesModel> Discounted();

        IEnumerable<SalesModel> DiscountedByPercent(double percent);
    }
}
