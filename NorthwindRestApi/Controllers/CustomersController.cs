﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindRestApi.Models;

namespace NorthwindRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        northwindContext db = new northwindContext();

        [HttpGet]
        
        public ActionResult GetAllCustomers()
        {
            try
            {
                var asiakkaat = db.Customers.ToList();
                return Ok(asiakkaat);
            }
            catch (Exception ex)
            {
                return BadRequest("Tapahtui virhe. Lue lisää" + ex.InnerException);
            }
        }


        [HttpGet("{id}")]

        public ActionResult GetOneCustomersById(string id)
        {
            try
            {
                var asiakas = db.Customers.Find(id);
                if (asiakas != null)
                {
                    return Ok(asiakas);
                }
                else
                {
                    return NotFound($"Asiakasta id:llä {id} ei löydy.");
                }
            }
            catch(Exception e)
            {
                return BadRequest("Tapahtui virhe. Lue lisää" + e);
            }
        }




        [HttpPost]

        public ActionResult AddNew([FromBody] Customer cust)
        {
            try
            {
                db.Customers.Add(cust);
                db.SaveChanges();
                return Ok($"Lisättiin uusi asiakas {cust.CompanyName} from {cust.City}");
            }
            catch (Exception e)
            {
                return BadRequest("Tapahtui virhe. Lue lisää: " + e.InnerException);
            }
        }


        [HttpDelete]


        public ActionResult Delete(string id)
        {
            try
            {
                var asiakas = db.Customers.Find(id);    

                if (asiakas != null)
                {
                    db.Customers.Remove(asiakas);
                    db.SaveChanges();
                    return Ok("Asiakas " + asiakas.CompanyName + " poistettiin.");

                }
                return NotFound("Asiakasta id:llä " + id + " ei löytynyt.");
            }
            catch (Exception e) 
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}
