using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _contractorsServ;

        public ContractorsController(ContractorsService contractorsServ)
        {
            _contractorsServ = contractorsServ;
        }
        [HttpGet]
        public ActionResult<List<Contractor>> Get()
        {
            try
            {
                List<Contractor> contractor = _contractorsServ.Get();
                return Ok(contractor);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Contractor> Get(int id)
        {
            try
            {
                Contractor contractor = _contractorsServ.Get(id);
                return Ok(contractor);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Contractor> Create([FromBody] Contractor contractor)
        {
            try
            {
                Contractor newContractor = _contractorsServ.Create(contractor);
                return Created($"/api/contractors/{newContractor.Id}", newContractor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]

        public ActionResult<Contractor> Edit([FromBody] Contractor contractor, int id)
        {
            try
            {
                contractor.Id = id;
                Contractor editContractor = _contractorsServ.Edit(contractor);
                return Ok(editContractor);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Contractor> Delete(int id)
        {
            try
            {
                _contractorsServ.Delete(id);
                return Ok("Deleted Contractor");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}