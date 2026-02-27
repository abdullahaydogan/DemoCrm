using DemoCRM.Core.Extensions;
using DemoCRM.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Student.SearchStudent
{
    public class SearchStudentHandler : IRequestHandler<SearchStudentRequest, IQueryable<Core.Entity.Student>>
    {
        private readonly CrmContext _crmContext;

        public SearchStudentHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }
        public Task<IQueryable<Core.Entity.Student>> Handle(SearchStudentRequest request, CancellationToken cancellationToken)
        {
            var query = _crmContext.Students.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                var searchText = request.Name.NormalizeForSearch();
                query = query.Where(s => s.Name != null && s.Name.Contains(request.Name)).WhereNormalizeContains(s => s.Name, request.Name);
            }
            if (!string.IsNullOrWhiteSpace(request.Surname))
            {
                var searchText = request.Surname.NormalizeForSearch();
                query = query.Where(s => s.Surname != null && s.Surname.Contains(request.Surname)).WhereNormalizeContains(s => s.Surname, request.Surname);
            }
            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                var searchText = request.Email.NormalizeForSearch();
                query = query.Where(s => s.Email != null && s.Email.Contains(request.Email)).WhereNormalizeContains(s => s.Email, request.Email);
            }
            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                query = query.Where(s => s.PhoneNumber != null && s.PhoneNumber.Contains(request.PhoneNumber));
            }
            if (request.CourseIds != null && request.CourseIds.Any())
            {
                query = query.Where(s => s.Courses != null && s.Courses.Any(c => request.CourseIds.Contains(c.Id)));
            }
            return Task.FromResult(query);
        }
    }
}
