using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    public interface ISkillRepository
    {
        IEnumerable<Skill> GetAllSkills();
        Skill GetSkillById(int id);
        void AddSkill(Skill skill);
        void UpdateSkill(Skill skill);
        void DeleteSkill(int id);
    }
}
