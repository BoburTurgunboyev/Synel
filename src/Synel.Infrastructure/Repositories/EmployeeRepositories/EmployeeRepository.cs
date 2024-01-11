using Synel.Application.Abstractions;
using Synel.Domain.Entities;
using Synel.Infrastructure.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synel.Infrastructure.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async ValueTask<Employee> InsertAsync(Employee employee)
        {
            var entityEntry = await _appDbContext.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }
    }
}
