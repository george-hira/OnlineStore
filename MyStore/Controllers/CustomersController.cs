using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController: ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]

        public IEnumerable<CustomerModel> Get(string? text, int page=1) 
        {
            
            var allCustomers = customerService.GetCustomers(page, text);

            var modelsToReturn = new List<CustomerModel>();
            foreach (var customers in allCustomers)
            {
                modelsToReturn.Add(customers.ToCustomerModel());
            }
            return modelsToReturn;
        }

        [HttpGet("{id}")]
        public ActionResult <CustomerModel> GetByID(int id ) 
        {
            var customerFromDb = customerService.GetCustomer(id);
            if (customerFromDb == null)
            {
                return NotFound();
            }

            var model = new CustomerModel();
            model = customerFromDb.ToCustomerModel();

            return Ok(model);
        
        }

        [HttpPut("{id}")]
        public ActionResult<CustomerModel> Update(int id, CustomerModel model)
        {
            // verificam in DB mai intai sa vedem daca exista ceva cu ID-ul respectiv 
            // updatam 
            // returnam 404 

            var existingCustomer = customerService.GetCustomer(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingCustomer);

            var customerToUpdate = new Customer();
            customerToUpdate = model.ToCustomer();
            customerService.Update(customerToUpdate);

            return Ok(customerToUpdate.ToCustomerModel());
        }

        [HttpPost]
        public IActionResult Create(CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);    
            }

            if (customerService.IsDuplicate(model.Companyname)) 
            {
                ModelState.AddModelError("Customername", $"You can' have the duplicate items with the value {model.Companyname} on companyName");
                return Conflict(ModelState);
            }

            var customerToSave = new Customer();
            customerToSave = model.ToCustomer();

            customerService.InsertNew(customerToSave);
            model.Companyname = customerToSave.Companyname;

            return CreatedAtAction(nameof(GetByID), new { id = customerToSave.Companyname }, model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer= customerService.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }
            customerService.Remove(customer);

            return NoContent();
        }


        

    }
}
