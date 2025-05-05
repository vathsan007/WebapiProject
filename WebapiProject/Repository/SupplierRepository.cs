using Microsoft.EntityFrameworkCore;
using WebapiProject.Models;

namespace WebapiProject.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext db;

        public SupplierRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddSupplier(Supplier supplier)

        {

            if (supplier == null)

            {

                throw new System.Exception("Supplier cannot be null.");

            }

            db.Database.ExecuteSqlRaw(

                "EXEC AddSupplier @Id ={0},@Name = {1}, @Phone = {2}, @Email = {3}", supplier.SupplierId,

                supplier.SupplierName, supplier.Phone, supplier.Email

            );

        }


        public void UpdateSupplier(Supplier supplier)
        {
            var existingSupplier = db.Suppliers.FirstOrDefault(s => s.SupplierId == supplier.SupplierId);
            if (existingSupplier == null)
            {
                throw new System.Exception("Supplier not found.");
            }

            db.Database.ExecuteSqlRaw(
                "EXEC UpdateSupplier @SupplierId = {0}, @Name = {1}, @Phone = {2}, @Email = {3}",
                supplier.SupplierId, supplier.SupplierName, supplier.Phone, supplier.Email
            );
        }

        public void DeleteSupplier(int supplierId)
        {
            var supplier = db.Suppliers.FirstOrDefault(s => s.SupplierId == supplierId);
            if (supplier == null)
            {
                throw new System.Exception("Supplier not found.");
            }

            db.Database.ExecuteSqlRaw(
                "EXEC DeleteSupplier @SupplierId = {0}",
                supplierId
            );
        }

        public List<Supplier> GetAllSuppliers()
        {
            var suppliers = db.Suppliers.ToList();
            if (suppliers == null || !suppliers.Any())
            {
                throw new System.Exception("No suppliers found.");
            }

            return suppliers;
        }

        public Supplier GetSupplierById(int supplierId)
        {
            var supplier = db.Suppliers.FirstOrDefault(s => s.SupplierId == supplierId);
            if (supplier == null)
            {
                throw new System.Exception("Supplier not found.");
            }

            return supplier;
        }
    }
}