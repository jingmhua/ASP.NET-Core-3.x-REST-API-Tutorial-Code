using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MyApi.Services
{
    public class CompanyServiceImpl : ICompanyService
    {
        private readonly MyApiDBContext _context;
        public CompanyServiceImpl(MyApiDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddCompany(Company company)
        {
            if (company == null) throw new Exception();

            company.Id = Guid.NewGuid();
            foreach (var employee in company.Employees)
            {
                employee.Id = Guid.NewGuid();
            }
            _context.Companies.Add(company);
        }

        public void AddEmployee(Guid companyId, Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CompanyExistsAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<Guid> companyIds)
        {
            if (companyIds == null) {
                throw new Exception();
            }
            return  await _context.Companies.Where(x => companyIds.Contains(x.Id)).ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }


        public async Task<Company> GetCompanyAsync(Guid companyId)
        {
            if (companyId == null) { 
             throw new ArgumentNullException(nameof(companyId));
            }
            return await _context.Companies.FirstAsync(x => x.Id == companyId);
        }

        public Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public void UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
