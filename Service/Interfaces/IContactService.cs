using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCL.Api.Models;
namespace HCL.Api.Service.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContacts();
    }
}
