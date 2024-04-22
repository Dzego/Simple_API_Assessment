using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    public class SkillRepository
    {
        private readonly DataContextDcContext _context;

        public SkillRepository(DataContextDcContext context)
        {
            _context = context;
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return _context.Skills.ToList();
        }

        public Skill GetSkillById(int id)
        {
            return _context.Skills.FirstOrDefault(s => s.Id == id);
        }

        public void AddSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
        }

        public void UpdateSkill(Skill skill)
        {
            _context.Skills.Update(skill);
            _context.SaveChanges();
        }

        public void DeleteSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                _context.SaveChanges();
            }
        }
    }
}
