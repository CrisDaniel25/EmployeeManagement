using AutoMapper;
using EmployeeManagement.API.Controllers.Base;
using EmployeeManagement.API.Dtos.Employees;
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Interfaces.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    //Autorized default
    //Default route "api/[controller]" 
    public class PositionController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PositionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var record = _unitOfWork.Position.GetPositions();
                return Ok(record);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpGet("department/{id}")]
        public async Task<IActionResult> GetByDepartment(int id)
        {
            try
            {
                var record = await _unitOfWork.Position.Find(x => x.DepartmentID == id);
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
                var record = await _unitOfWork.Position.GetById(id);
                return Ok(record);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PositionDto payload)
        {
            try
            {
                var entity = _mapper.Map<Position>(payload);
                await _unitOfWork.Position.Add(entity);
                return CreatedAtAction(nameof(Get), new { id = payload.ID }, payload);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PositionDto payload)
        {
            payload.ID = id;

            try
            {
                var entity = _mapper.Map<Position>(payload);
                await _unitOfWork.Position.Update(entity);
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
                Position record = new Position { ID = id };
                await _unitOfWork.Position.Delete(record);
                return NoContent();
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }
    }
}
