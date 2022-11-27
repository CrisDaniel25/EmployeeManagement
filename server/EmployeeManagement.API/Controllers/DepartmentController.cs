using EmployeeManagement.API.Controllers.Base;
using EmployeeManagement.Domain.Interfaces.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EmployeeManagement.API.Dtos.Employees;
using EmployeeManagement.Domain.Entities.Employees;

namespace EmployeeManagement.API.Controllers
{
    //Autorized default
    //Default route "api/[controller]" 
    public class DepartmentController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var record = await _unitOfWork.Department.GetAll();
                return Ok(record);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var record = await _unitOfWork.Department.GetById(id);
                return Ok(record);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartmentDto payload)
        {
            try
            {
                var entity = _mapper.Map<Department>(payload);
                await _unitOfWork.Department.Add(entity);
                return CreatedAtAction(nameof(Get), new { id = payload.ID }, payload);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DepartmentDto payload)
        {
            payload.ID = id;

            try
            {
                var entity = _mapper.Map<Department>(payload);
                await _unitOfWork.Department.Update(entity);
                return NoContent();
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Department record = new Department { ID = id };
                await _unitOfWork.Department.Delete(record);
                return NoContent();
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }
    }
}
