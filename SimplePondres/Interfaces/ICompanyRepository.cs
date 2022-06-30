using Microsoft.AspNetCore.Mvc;
using SimplePondres.Models;

namespace SimplePondres.Interfaces
{
    public interface ICompanyRepository
    {
        /// <summary>
        /// Abstract method to get all companies.
        /// </summary>
        /// <returns>A list of companies.</returns>
        Task<ActionResult<IEnumerable<Company>>> GetCompanysAsync();

        /// <summary>
        /// Abstract method to get a company by Id.
        /// </summary>
        /// <param name="id">The id of the company.</param>
        /// <returns>The company object.</returns>
        Task<ActionResult<Company>> GetCompanyAsync(int id);

        /// <summary>
        /// Abstract method to add a new company.
        /// </summary>
        /// <param name="company">Company type</param>
        /// <returns>The new company object.</returns>
        Task<ActionResult<Company>> PostCompanyAsync(Company company);
    }
}
