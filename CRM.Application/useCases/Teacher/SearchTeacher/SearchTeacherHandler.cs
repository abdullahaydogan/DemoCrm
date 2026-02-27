using DemoCRM.Application.useCases.Student.GetAllStudentEntity;
using DemoCRM.Persistance.Context;
using MediatR;

namespace DemoCRM.Application.useCases.Teacher.SearchTeacher
{
    public class SearchTeacherHandler : IRequestHandler<SearchTeacherRequest, IQueryable<DemoCRM.Core.Entity.Teacher>>
    {
        private readonly CrmContext _crmContext;

        public SearchTeacherHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public Task<IQueryable<Core.Entity.Teacher>> Handle(SearchTeacherRequest request, CancellationToken cancellationToken)
        {
            var query = _crmContext.Teachers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(t => t.Name.Contains(request.Name));
            }
            if (!string.IsNullOrWhiteSpace(request.Surname))
            {
                query = query.Where(t => t.Surname.Contains(request.Surname));
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                query = query.Where(t => t.Email.Contains(request.Email));
            }

            if (!string.IsNullOrEmpty(request.ContactValue))
            {
                query = query.Where(t => t.ContactValue.Contains(request.ContactValue));
            }
            if (!string.IsNullOrEmpty(request.Branch))
            {
                query = query.Where(t => t.Branch.Contains(request.Branch));
            }
            if (request.IsActive.HasValue)
            {
                query = query.Where(t => t.IsActive == request.IsActive.Value);
            }

            return Task.FromResult(query);
        }
    }
}
