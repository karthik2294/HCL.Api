using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCL.Api.Models;
using System.Net;
using Microsoft.Extensions.Logging;
using HCL.Api.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HCL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ContactController : Controller
    {

        private readonly IContactService contactService;
        private readonly IConfiguration Configuration;

        public ContactController(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
            //TODO Move the initialization to IOC controller unity or autofac
            this.contactService = new Service.Implementations.ContactService(new Repository.Implemenations.ContactRepository(new Dapper.Database(this.Configuration)));
        }


        // GET: api/<ContactController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Contact>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Contact> contacts = await this.contactService.GetContacts();
            return (IActionResult)this.Ok(contacts);
        }

    }
}
