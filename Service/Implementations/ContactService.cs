using HCL.Api.Models;
using HCL.Api.Repository.Interfaces;
using HCL.Api.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HCL.Api.Service.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await this.contactRepository.GetContacts();
        }
    }
}
