using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly CompaniesService _compServ;
        private readonly JobsService _jobsServ;

        public CompaniesController(CompaniesService compServ, JobsService jobsServ)
        {
            _compServ = compServ;
            _jobsServ = jobsServ;
        }

        [HttpGet]
        public ActionResult<List<Company>> Get()
        {
            try
            {
                List<Company> companies = _compServ.Get();
                return Ok(companies);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Company> Get(int id)
        {
            try
            {
                Company company = _compServ.Get(id);
                return Ok(company);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{companyId}/contractors")]
        public ActionResult<List<CompanyContractorContractorViewModel>> GetContractors(int companyId)
        {
            try
            {
                List<CompanyContractorContractorViewModel> contractors = _jobsServ.GetContractors(companyId);
                return Ok(contractors);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Company> Create([FromBody] Company company)
        {
            try
            {
                Company newCompany = _compServ.Create(company);
                return Created($"/api/companies/{newCompany.Id}", newCompany);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]

        public ActionResult<Company> Edit([FromBody] Company company, int id)
        {
            try
            {
                company.Id = id;
                Company editCompany = _compServ.Edit(company);
                return Ok(editCompany);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Company> Delete(int id)
        {
            try
            {
                _compServ.Delete(id);
                return Ok("Deleted Contractor");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}