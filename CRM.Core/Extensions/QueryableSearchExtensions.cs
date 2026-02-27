using System.Linq.Expressions;

namespace DemoCRM.Core.Extensions
{
    public static class QueryableSearchExtensions
    {
        public static IQueryable<T> WhereNormalizeContains<T>(this IQueryable<T> query, Expression<Func<T, string?>> selector, string? searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return query;

            var normalizedSearch = searchText.NormalizeForSearch();
            var parameter = selector.Parameters[0];

            var notNull = Expression.NotEqual(selector.Body, Expression.Constant(null, typeof(string)));

            var toUpper = Expression.Call(selector.Body, typeof(string).GetMethod(nameof(string.ToUpper), Type.EmptyTypes)!);

            var contains = Expression.Call(toUpper, typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })!, Expression.Constant(normalizedSearch));
            var body = Expression.AndAlso(notNull, contains);
            var predicate = Expression.Lambda<Func<T, bool>>(body, parameter);
            return query.Where(predicate);
        }
    }
}
