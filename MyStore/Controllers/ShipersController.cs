using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyStore.Data;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;
using System.Security.Cryptography.Xml;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipersController : ControllerBase
    {

        private readonly IShipperService shipperService;

        public ShipersController( IShipperService shipperService)
        {
            
            this.shipperService = shipperService;
        }

        [HttpGet]

        public IEnumerable <ShipperModel> Get(string? text, int page=1)
        {
            // implementam paginarea 
            // adaugam un filtru 

            var allShippers = shipperService.GetShippers(page, text);

            var modelsToReturn = new List<ShipperModel>();
            foreach ( var shipper in allShippers)
            {
                modelsToReturn.Add(shipper.ToShiperModel());
            }
            return modelsToReturn;
        }

        [HttpGet("{id}")]

        public ActionResult <ShipperModel> GetShippersById(int id) 
        {
            var shipperFromDb = shipperService.GetShipper(id);

            if (shipperFromDb == null)
            {
                return NotFound();
            }
            var model = new ShipperModel();
            model = shipperFromDb.ToShiperModel();
            return Ok(model);
        }

        //[HttpGet]

        //public IEnumerable<Shipper> OrderedList()
        //{
        //    var orderdList = context.Shippers.OrderBy(x => x.Companyname).ToList();
        //    return orderdList;
        //}


        [HttpPost]

        public IActionResult Create( ShipperModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (shipperService.IsDuplicate(model.Companyname))
            {
                ModelState.AddModelError("Companyname", $"You can't have the duplicate items with the value{model.Companyname} on companyName");
                return Conflict(ModelState);
            }
            var shipperToSave = new Shipper();
            shipperToSave = model.ToShipper();

            shipperService.InsertNew( shipperToSave );

            model.Shipperid = shipperToSave.Shipperid;


            return CreatedAtAction(nameof(GetShippersById), new { id = shipperToSave.Shipperid }, model);
        }

        [HttpPut ("/{id:maxlength(10)?}")]

        public ActionResult<ShipperModel> Update(int id, ShipperModel model)
        {

            var existingShipper = shipperService.GetShipper(id);
            if (existingShipper == null)
            {
                return NotFound();
            }
            TryUpdateModelAsync(existingShipper);

            var shipperToUpdate = new Shipper();
            shipperToUpdate = model.ToShipper();
            shipperService.Update( shipperToUpdate );

            return Ok(shipperToUpdate.ToShiperModel());
        }

        [HttpDelete("{id}")]

        public IActionResult WhatEverIWant(int id)
        {
            var shipperToDelete = shipperService.GetShipper(id);

            if (shipperToDelete == null)
            {
                return NotFound();
            }

            shipperService.Remove(shipperToDelete );

            return NoContent();
        }








    }
}
