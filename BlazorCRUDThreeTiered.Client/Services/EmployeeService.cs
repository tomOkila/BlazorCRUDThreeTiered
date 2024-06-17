using BlazorCRUDThreeTiered.Business.DTOs;
using BlazorCRUDThreeTiered.Business.Entities;
using System.Net.Http.Json;

namespace BlazorCRUDThreeTiered.Client.Services
{
    public class EmployeeService(HttpClient httpClient) : IEmployeeService
    {
        public async Task<ServiceResponse> AddAsync(Employee employee)
        {
            var data = await httpClient.PostAsJsonAsync("api/employee", employee);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var data = await httpClient.DeleteAsync($"api/employee/{id}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<List<Employee>> GetAsync() => await httpClient.GetFromJsonAsync<List<Employee>>("api/employee");

        public async Task<Employee> GetByIdAsync(int id)
      => await httpClient.GetFromJsonAsync<Employee>($"api/employee/{id}");

        public async Task<ServiceResponse> UpdateAsync(Employee employee)
        {
            var data = await httpClient.PutAsJsonAsync("api/employee", employee);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }
    }
}
