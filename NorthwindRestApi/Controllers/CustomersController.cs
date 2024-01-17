using Microsoft.AspNetCore.Http;
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
            var asiakas = db.Customers.Find(id);
            if(asiakas != null)
            {
                return Ok(asiakas);
            }
            else
            {
                return BadRequest($"Asiakasta id:llä {id} ei löydy.");
            }
        }
    }
}
