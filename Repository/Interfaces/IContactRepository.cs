using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCL.Api.Models;

namespace HCL.Api.Repository.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContacts();
    }
}
