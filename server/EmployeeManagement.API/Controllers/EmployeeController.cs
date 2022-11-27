using AutoMapper;
using EmployeeManagement.API.Controllers.Base;
using EmployeeManagement.API.Dtos.Employees;
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    //Autorized default
    //Default route "api/[controller]" 
    public class EmployeeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var record = await _unitOfWork.Employee.GetAll();
                return Ok(record);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var record = _unitOfWork.Employee.GetEmployee(id);
                return Ok(record);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDto payload)
        {
            try
            {
                var entity = _mapper.Map<Employee>(payload);
                await _unitOfWork.Employee.Add(entity);
                return CreatedAtAction(nameof(Get), new { id = payload.ID }, payload);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDto payload)
        {
            payload.ID = id;

            try
            {
                var entity = _mapper.Map<Employee>(payload);
                await _unitOfWork.Employee.Update(entity);
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
                Employee record = new Employee { ID = id };
                await _unitOfWork.Employee.Delete(record);
                return NoContent();
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }
    }
}
