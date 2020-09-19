using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApi.Services;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : Controller
    {
        private ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {

            _companyService = companyService ?? throw new ArgumentNullException();
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanies() {
            var companies = await _companyService.GetCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet("{companyId}")]//api/companies/{companyId}
        public async Task<IActionResult> GetCompany(Guid companyId)
        {
            var exists= await _companyService.CompanyExistsAsync(companyId);
            if (!exists)
            {
                return NoContent();
            }
            var company = await _companyService.GetCompanyAsync(companyId);
      
            return Ok(company);
        }
    }
}
