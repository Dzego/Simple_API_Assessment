using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicationRepository _applicantRepository;

        public ApplicantController(IApplicationRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        [HttpGet]
        public IEnumerable<Applicant> GetAllApplicants()
        {
            return _applicantRepository.GetAllApplicants();
        }

        [HttpGet("{id}")]
        public ActionResult<Applicant> GetApplicantById(int id)
        {
            var applicant = _applicantRepository.GetApplicantById(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return applicant;
        }

        [HttpPost]
        public ActionResult<Applicant> AddApplicant(Applicant applicant)
        {
            _applicantRepository.AddApplicant(applicant);
            return CreatedAtAction(nameof(GetApplicantById), new { id = applicant.ApplicantId }, applicant);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateApplicant(int id, Applicant applicant)
        {
            if (id != applicant.ApplicantId)
            {
                return BadRequest();
            }

            _applicantRepository.UpdateApplicant(applicant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteApplicant(int id)
        {
            _applicantRepository.DeleteApplicant(id);
            return NoContent();
        }
    }
}
