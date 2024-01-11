using Synel.Domain.Entities;

namespace Synel.Application.Abstractions
{
    public interface IEmployeeRepository
    {
        public ValueTask<Employee> InsertAsync(Employee employee);
    }
}
