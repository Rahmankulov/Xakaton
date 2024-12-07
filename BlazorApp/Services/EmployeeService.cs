using BlazorApp.Database;
using BlazorApp.Models;
using System.Data.Entity;

namespace BlazorApp.Services
{
    public class EmployeeService
    {
        private readonly AgroContext _context;

        public EmployeeService(AgroContext context)
        {
            _context = context;
        }

        public Task<List<Employee>> GetAllEmployeesAsync()
        {
            return Task.FromResult(_context.Employees.ToList());
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
