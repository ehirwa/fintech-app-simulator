using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountService.Application.DTOs;
using AccountService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<AccountDto>> Create(AccountDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AccountDto>> GetById(Guid id)
        {
            var account = await _service.GetAsync(id);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountDto>>> Search([FromQuery]string ownerName = "")
        {
            var result = await _service.SearchAsync(ownerName);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, AccountDto dto)
        {
            if (id != dto.Id) return BadRequest();
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
