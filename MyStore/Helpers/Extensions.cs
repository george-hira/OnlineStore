using Microsoft.AspNetCore.Localization;
using Microsoft.Identity.Client;
using MyStore.Domain;
using MyStore.Models;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace MyStore.Helpers
{
    public static class Extensions
    {
        public static int CountWords(this string paragraph)
        {
            var words = paragraph.Split(' ');
            return words.Length;
        }

        public static CategoryModel ToCategoryModel(this Category domainObject)
        {
            var model = new CategoryModel();

            model.Categoryid = domainObject.Categoryid;
            model.Categoryname = domainObject.Categoryname;
            model.Description = domainObject.Description;
            return model;
        }

        public static Category ToCategory(this CategoryModel domainObject)
        {
            var category = new Category();

            category.Categoryid = domainObject.Categoryid;
            category.Categoryname = domainObject.Categoryname;
            category.Description = domainObject.Description;
            return category;
        }

        public static ShipperModel ToShiperModel( this Shipper domainObject)
        {

            var model = new ShipperModel();
            model.Shipperid = domainObject.Shipperid;
            model.Companyname = domainObject.Companyname;
            model.Phone = domainObject.Phone;
            return model;
        }

        public static Shipper ToShipper(this ShipperModel domainObject)
        {
            var shipper = new Shipper();

            shipper.Shipperid = domainObject.Shipperid;
            shipper.Companyname = domainObject.Companyname;
            shipper.Phone = domainObject.Phone;
            return shipper;
        }

        public static Supplier ToSupplier (this SupplierModel domainObject)
        {
            var supplier = new Supplier();
            supplier.Supplierid = domainObject.Supplierid;
            supplier.Companyname = domainObject.Companyname;
            supplier.Contactname = domainObject.Contactname;    
            supplier.Contacttitle = domainObject.Contacttitle;
            supplier.Address = domainObject.Address;
            supplier.City = domainObject.City;
            supplier.Region = domainObject.Region;
            supplier.Postalcode = domainObject.Postalcode;
            supplier.Country = domainObject.Country;
            supplier.Phone = domainObject.Phone;
            supplier.Fax= domainObject.Fax;
            return supplier;

        }

        public static SupplierModel ToSupplierModel (this Supplier domainObject)
        {
            var model = new SupplierModel ();
            model.Supplierid = domainObject.Supplierid;
            model.Companyname = domainObject.Companyname;
            model.Contactname = domainObject.Contactname;
            model.Contacttitle = domainObject.Contacttitle;
            model.Address = domainObject.Address;
            model.City = domainObject.City;

            
            
            model.Country = domainObject.Country;
            model.Phone = domainObject.Phone;
            

            return model;

        }

        public static Customer ToCustomer(this CustomerModel domainObject)
        {
            var customer = new Customer();
            customer.Custid = domainObject.Custid;
            customer.Companyname =  domainObject.Companyname;
            customer.Contactname = domainObject.Contactname;
            customer.Contacttitle = domainObject.Contacttitle;
            customer.Address = domainObject.Address;
            customer.City = domainObject.City;
            customer.Postalcode = domainObject.Postalcode;
            customer.Country = domainObject.Country;
            customer.Phone = domainObject.Phone;

            return customer;

        }

        public static CustomerModel ToCustomerModel(this Customer domainObject) 
        {
            var model = new CustomerModel();
            model.Custid= domainObject.Custid;
            model.Companyname = domainObject.Companyname;
            model.Contactname = domainObject.Contactname;
            model.Contacttitle = domainObject.Contacttitle;
            model.Address = domainObject.Address;
            model.City = domainObject.City;
            model.Postalcode= domainObject.Postalcode;
            model.Country = domainObject.Country;
            model.Phone = domainObject.Phone;

            return model;


        }

        public static EmployeeModel ToEmployeeModel(this Employee domainObject)
        {
            var model = new EmployeeModel();

            model.Firstname = domainObject.Firstname;
            model.Lastname = domainObject.Lastname;
            model.Birthdate = domainObject.Birthdate;
            model.Hiredate = domainObject.Hiredate;
            model.Address = domainObject.Address;
            model.City = domainObject.City;
            return model;
        }

        public static Employee ToEmployee(this EmployeeModel domainObject)
        {
            var model = new Employee();

            model.Firstname = domainObject.Firstname;
            model.Lastname = domainObject.Lastname;
            model.Birthdate = domainObject.Birthdate;
            model.Hiredate = domainObject.Hiredate;
            model.Address = domainObject.Address;
            model.City = domainObject.City;
            return model;
        }
    }
}