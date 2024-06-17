using BlazorCRUDThreeTiered.Business.DTOs;
using BlazorCRUDThreeTiered.Business.Entities;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorCRUDThreeTiered.Client.Services
{
    public class DepartmentService(HttpClient httpClient) : IDepartmentService
    {
        public async Task<ServiceResponse> AddAsync(Department department)
        {
            var data = await httpClient.PostAsJsonAsync("api/department", department);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var data = await httpClient.DeleteAsync($"api/department/{id}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<List<Department>> GetAsync() => await httpClient.GetFromJsonAsync<List<Department>>("api/department");

        public async Task<Department> GetByIdAsync(int id)
     => await httpClient.GetFromJsonAsync<Department>($"api/department/{id}");

        public async Task<ServiceResponse> UpdateAsync(Department department)
        {
            var data = await httpClient.PutAsJsonAsync("api/department", department);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }
    }
}
