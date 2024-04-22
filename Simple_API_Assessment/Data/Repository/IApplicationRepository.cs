using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    public interface IApplicationRepository
    {
        IEnumerable<Applicant> GetAllApplicants();
        Applicant GetApplicantById(int id);
        void AddApplicant(Applicant applicant);
        void UpdateApplicant(Applicant applicant);
        void DeleteApplicant(int id);
    }
}
