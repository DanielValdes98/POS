using POS.Domain.Entities;
using POS.Infrastucture.Commons.Bases.Request;
using POS.Infrastucture.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastucture.Persistences.Interfaces
{
    public interface IProviderRepository
    {
        Task<BaseEntityResponse<Provider>> ListProviders(BaseFiltersRequest filters);
    }
}
