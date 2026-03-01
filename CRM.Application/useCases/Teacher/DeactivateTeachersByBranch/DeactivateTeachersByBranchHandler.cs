using DemoCRM.Persistance.Context;
using MediatR;

namespace DemoCRM.Application.useCases.Teacher.DeactivateTeachersByBranch
{
    public class DeactivateTeachersByBranchHandler : IRequestHandler<DeactivateTeachersByBranchRequest, DeactivateTeachersByBranchResponse>
    {
        private readonly CrmContext _crmContext;

        public DeactivateTeachersByBranchHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public async Task<DeactivateTeachersByBranchResponse> Handle(DeactivateTeachersByBranchRequest request, CancellationToken cancellationToken)
        {
            var activeTeachers = _crmContext.Teachers.Where(t => t.IsActive == true && t.Branch ==request.Branch).ToList();

            if(activeTeachers.Count == 0)
            {
                return new DeactivateTeachersByBranchResponse
                {
                    Branch = request.Branch,
                    DeactivatedTeacherCount = 0
                };
            }

            foreach ( var teacher in activeTeachers)
            {
                teacher.IsActive = false;
                teacher.UpdatedDate = DateTime.UtcNow;
            }

            await  _crmContext.SaveChangesAsync();
            return new DeactivateTeachersByBranchResponse
            {
                Branch = request.Branch,
                DeactivatedTeacherCount = activeTeachers.Count
            };


        }
    }
}
