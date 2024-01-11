using CsvHelper.Configuration;
using CsvHelper;
using Synel.Application.Abstractions;
using Synel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synel.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async ValueTask<Employee> CreateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.InsertAsync(employee);
            return employee;
        }

        public async ValueTask<string> ImportFile(string filePath)
        {
        

            try
            { 
                using (var csv = new CsvReader(new StreamReader(filePath), new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.Context.RegisterClassMap<EmployeeMap>();
                    var records = csv.GetRecords<Employee>().ToList();

                    foreach (var record in records) 
                    {
                        await _employeeRepository.InsertAsync(record);
                        
                    }

                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return "Added";
        }
    }
}
