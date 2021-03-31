using HCL.Api.Dapper;
using HCL.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCL.Api.Models;

namespace HCL.Api.Repository.Implemenations
{
    public class ContactRepository: IContactRepository
    {
        public IDatabase database;

        public ContactRepository(IDatabase database)
        {
            this.database = database;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {

            var result = await this.database.ExecuteList<Contact>("[Employee].[uspGetContacts]");
            return await Task.FromResult(result);
        }
    }
}
