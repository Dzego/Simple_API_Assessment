using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillRepository _skillRepository;

        public SkillsController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [HttpGet]
        public IEnumerable<Skill> GetAllSkills()
        {
            return _skillRepository.GetAllSkills();
        }

        [HttpGet("{id}")]
        public ActionResult<Skill> GetSkillById(int id)
        {
            var skill = _skillRepository.GetSkillById(id);
            if (skill == null)
            {
                return NotFound();
            }
            return skill;
        }

        [HttpPost]
        public ActionResult<Skill> AddSkill(Skill skill)
        {
            _skillRepository.AddSkill(skill);
            return CreatedAtAction(nameof(GetSkillById), new { id = skill.Id }, skill);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSkill(int id, Skill skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            _skillRepository.UpdateSkill(skill);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSkill(int id)
        {
            _skillRepository.DeleteSkill(id);
            return NoContent();
        }
    }
}
