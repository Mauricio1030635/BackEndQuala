﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quala.Core.Dto;
using Quala.Core.Models;
using Quala.Core.Repository;

namespace Quala.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Admin")]
    public class NuevaEntidadController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NuevaEntidadController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entidad = await _unitOfWork.Entidades.GetAllEntidadAsync();
            var entidadDtos = _mapper.Map<IEnumerable<NuevaEntidadDto>>(entidad);
            return Ok(entidadDtos);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entidad = await _unitOfWork.Entidades.GetEntidadAsync(id);
            if (entidad == null) return NotFound();

            var entidadDto = _mapper.Map<NuevaEntidadDto>(entidad);
            return Ok(entidadDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NuevaEntidadCreateDto createDto)
        {
            var entidad = _mapper.Map<NuevaEntidad>(createDto);
            var newEntidad = await _unitOfWork.Entidades.CreateAsync(entidad);
            var entidadDto = _mapper.Map<NuevaEntidadDto>(newEntidad);
            return CreatedAtAction(nameof(GetById), new { id = entidadDto.Codigo }, entidadDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] NuevaEntidadUpdateDto updateDto)
        {
            var entidad = _mapper.Map<NuevaEntidad>(updateDto);
            var updatedEntidad = await _unitOfWork.Entidades.UpdateAsync(entidad);
            var entidadDto = _mapper.Map<NuevaEntidadDto>(updatedEntidad);
            return Ok(entidadDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Entidades.DeleteAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }

}
