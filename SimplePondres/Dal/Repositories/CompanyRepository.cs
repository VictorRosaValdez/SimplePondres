using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplePondres.Interfaces;
using SimplePondres.Models;

namespace SimplePondres.Dal.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        // Fields

        // Variable for the DbContext.
        private readonly SimplePondresDbContext _context;

        /// <summary>
        /// Constructor for the CompanyRepository.
        /// </summary>
        /// <param name="context"></param>
        public CompanyRepository(SimplePondresDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a company by Id
        /// </summary>
        /// <param name="id">Id of the company</param>
        /// <returns>A company object</returns>
        public async Task<ActionResult<Company>> GetCompanyAsync(int id)
        {
           
            var company = await _context.Company.FindAsync(id);

            return company;
        }

        /// <summary>
        /// Get all companies
        /// </summary>
        /// <returns>A list of companies</returns>
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanysAsync()
        {
            var company = await _context.Company.ToListAsync();

            return company;
        }

        /// <summary>
        /// Adds a new company object to the database.
        /// </summary>
        /// <param name="company">Company object</param>
        /// <returns>The new company object</returns>
        public async Task<ActionResult<Company>> PostCompanyAsync(Company company)
        {
            _context.Company.Add(company);
            await _context.SaveChangesAsync();

            return company;
        }
    }
}
