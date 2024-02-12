using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Interfaces;
using POS.Infrastucture.Commons.Bases.Request;

namespace POS.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderApplication _providerApplication;

        public ProviderController(IProviderApplication providerApplication)
        {
            _providerApplication = providerApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListProviders([FromBody] BaseFiltersRequest filters) // Se envian todos los filtros por el body
        {
            var response = await _providerApplication.ListProviders(filters);
            return Ok(response);
        }
    }
}
