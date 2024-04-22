using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DataContextDcContext _context;

        public ApplicationRepository(DataContextDcContext context)
        {
            _context = context;
        }

        public IEnumerable<Applicant> GetAllApplicants()
        {
            return _context.Applicants.ToList();
        }

        public Applicant GetApplicantById(int id)
        {
            return _context.Applicants.FirstOrDefault(a => a.ApplicantId == id);
        }

        public void AddApplicant(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            _context.SaveChanges();
        }

        public void UpdateApplicant(Applicant applicant)
        {
            _context.Applicants.Update(applicant);
            _context.SaveChanges();
        }

        public void DeleteApplicant(int id)
        {
            var applicant = _context.Applicants.Find(id);
            if (applicant != null)
            {
                _context.Applicants.Remove(applicant);
                _context.SaveChanges();
            }
        }
    }
}
