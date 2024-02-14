using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Application.DTOs.Provider.Request;
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

        [HttpGet("{providerId:int}")]
        public async Task<IActionResult> ProviderById(int providerId)
        {
            var response = await _providerApplication.ProviderById(providerId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterProvider([FromBody] ProviderRequestDTO requestDTO)
        {
            var response = await _providerApplication.RegisterProvider(requestDTO);
            return Ok(response);
        }

        [HttpPut("Edit/{providerId:int}")]
        public async Task<IActionResult> EditProvider(int providerId, [FromBody] ProviderRequestDTO requestDTO)
        {
            var response = await _providerApplication.EditProvider(providerId, requestDTO);
            return Ok(response);
        }

        [HttpPut("Remove/{providerId:int}")]
        public async Task<IActionResult> RemoveProvider(int providerId)
        {
            var response = await _providerApplication.RemoveProvider(providerId);   
            return Ok(response);
        }
    }
}
