using MediatR;

namespace DemoCRM.Application.useCases.Teacher.DeactivateTeachersByBranch
{
    public class DeactivateTeachersByBranchRequest : IRequest<DeactivateTeachersByBranchResponse>
    {
        public string Branch { get; set; }
    }
}
