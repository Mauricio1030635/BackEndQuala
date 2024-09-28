using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quala.Core.Dto;
using Quala.Core.Models;
using Quala.Core.Repository;
using Quala.Services.Service;


namespace Quala.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    public class NuevaMonedaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NuevaMonedaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var moneda = await _unitOfWork.Monedas.GetAllAsync();
            var monedaDtos = _mapper.Map<IEnumerable<NuevaMonedaDto>>(moneda);
            return Ok(monedaDtos);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var moneda = await _unitOfWork.Monedas.GetByIdAsync(id);
            if (moneda == null) return NotFound();

            var monedaDto = _mapper.Map<NuevaMonedaDto>(moneda);
            return Ok(monedaDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NuevaMonedaCreateDto createDto)
        {
            var moneda = _mapper.Map<NuevaMoneda>(createDto);
            var newMoneda = await _unitOfWork.Monedas.CreateAsync(moneda);
            var monedaDto = _mapper.Map<NuevaMonedaDto>(newMoneda);
            return CreatedAtAction(nameof(GetById), new { id = monedaDto.IdMoneda }, monedaDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] NuevaMonedaUpdateDto updateDto)
        {
            var moneda = _mapper.Map<NuevaMoneda>(updateDto);
            var updatedMoneda = await _unitOfWork.Monedas.UpdateAsync(moneda);
            var monedaDto = _mapper.Map<NuevaMonedaDto>(updatedMoneda);
            return Ok(monedaDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Monedas.DeleteAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }


    }

}
