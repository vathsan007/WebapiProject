using WebapiProject.Models;

namespace WebapiProject.Repository
{
    public interface ISupplierRepository
    {
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(int supplierId);
        List<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(int supplierId);


    }
}
