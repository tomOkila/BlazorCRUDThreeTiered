using BlazorCRUDThreeTiered.Business.Entities;
using BlazorCRUDThreeTiered.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUDThreeTiered.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartment department) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await department.GetAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await department.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Department departmentDto)
        {
            var result = await department.AddAsync(departmentDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Department departmentDto)
        {
            var result = await department.UpdateAsync(departmentDto);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await department.DeleteAsync(id);
            return Ok(result);
        }
    }
}
