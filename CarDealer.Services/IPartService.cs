namespace CarDealer.Services
{
    using CarDealer.Services.Models;
    using System.Collections.Generic;

    public interface IPartService
    {
        IEnumerable<PartListingModel> All(int page = 1, int pageSize = 10);

        PartDetailsModel ById(int id);

        int Total();

        void Create(string name, decimal price, int quantity, int supplierId);

        void Delete(int id);

        void Edit(int id, decimal price, int quantity);

        IEnumerable<PartSelectModel> AllSelected();
    }
}
