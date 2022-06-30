using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimplePondres.DTOs.CompanyDTOs;
using SimplePondres.Interfaces;
using SimplePondres.Models;
using System.Net.Mime;

namespace SimplePondres.Controllers
{
    [ApiController]
    [Route("api/companies")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CompanyController : ControllerBase
    {
        // Fields 
        private readonly ICompanyRepository _company;

        private readonly IMapper _mapper;
        public CompanyController(ICompanyRepository company, IMapper mapper)
        {
            _company = company;
            _mapper = mapper;
        }

        // GET: api/companies
        /// <summary>
        /// Get all companies.
        /// </summary>
        /// <response code="200">Succesfully returns a company object.</response>
        /// <returns>A list of company objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyReadDTO>>> GetCompanys()
        {
            // Instance of the domainCompany objects.
            var domainCompany = await _company.GetCompanysAsync();

            // Map domainCompany with CompanyReadDTO
            var dtoCompany = _mapper.Map<List<CompanyReadDTO>>(domainCompany.Value);

            return dtoCompany;

        }

        // GET: api/companies/1
        /// <summary>
        /// Get a company by ID.
        /// </summary>
        /// <param name="id">Id of the company.</param>
        /// <returns>A company object.</returns>
        /// <response code="200">Succesfully returns a company object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyReadDTO>> GetCompany(int id)
        {
            // Instance of the product object.
            var domainCompany = await _company.GetCompanyAsync(id);

            // Map domainCompany to CompanyReadDTO
            var dtoCompany = _mapper.Map<CompanyReadDTO>(domainCompany.Value);

            if (dtoCompany == null)
            {
                return NotFound();
            }

            return dtoCompany;
        }

        // POST: api/companies
        /// <summary>
        /// Creates a new company object.
        /// </summary>
        /// <param name="order">A company object.</param>
        /// <returns>The new company object.</returns>
        /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<CompanyCreateDTO>> PostCompany(CompanyCreateDTO companyDto)
        {

            // Map CompanyCreateDTO to domain object
            var domainCompany = _mapper.Map<Company>(companyDto);

            // New company object
            await _company.PostCompanyAsync(domainCompany);

            // Get company id for new company object.
            int companyId = _company.PostCompanyAsync(domainCompany).Id;

            // Returning the new order.
            return CreatedAtAction("GetCompany", new { id = companyId }, companyDto);
        }
    }
}
