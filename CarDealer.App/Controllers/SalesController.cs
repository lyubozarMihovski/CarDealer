namespace CarDealer.App.Controllers
{
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;

    public class SalesController : Controller
    {
        private readonly ISaleService sales;

        public SalesController(ISaleService sales)
        {
            this.sales = sales;
        }
        [Route("sales")]
        public IActionResult All()
        {
            return this.View(this.sales.All());
        }
        [Route("sales/{id}")]
        public IActionResult SaleById(int id)
        {
            return this.View(this.sales.SaleById(id));
        }
        [Route("sales/discounted")]
        public IActionResult Discounted()
        {
            return this.View(this.sales.Discounted());
        }
        [Route("sales/discounted/{percent}")]
        public IActionResult DiscountedByPercent(double percent)
        {
            return this.View(this.sales.DiscountedByPercent(percent));
        }
    }
}
