using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace contracted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _jobsServ;

        public JobsController(JobsService jobsServ)
        {
            _jobsServ = jobsServ;
        }

        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job newJob)
        {
            try
            {
                return Ok(_jobsServ.Create(newJob));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _jobsServ.Delete(id);
                return Ok("Deleted Job");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}