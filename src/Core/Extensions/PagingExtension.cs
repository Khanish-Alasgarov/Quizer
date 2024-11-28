using Models.Common.Paging;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
namespace Core.Extensions;

public static partial class Extension
{
    public static IPaginate ToPaginate(this
        IQueryable<dynamic> query,
        PaginateRequest paginateRequest
        )
    {
        query = query.WhereIt(paginateRequest.Filters);

        var response = new Paginate(paginateRequest.Page, paginateRequest.Size, query.Count());

        if (paginateRequest.Page < 1)
        {
            response.Items = Enumerable.Empty<dynamic>();
            return response;
        }
        response.Items = query.SelectIt(paginateRequest?.Fields)
            .Skip((response.Page - 1) * response.Size).Take(response.Size).ToDynamicList();
        return response;
    }

    private static IQueryable<dynamic> WhereIt(this IQueryable<dynamic> query, PaginateFilter[] filters)
    {
        if (filters == null || filters.Length < 1)
            return query;

        var sb = new StringBuilder();
        for (int i = 0; i < filters.Length; i++)
        {
            var filter = filters[i];

            switch (filter.Operator)
            {
                case "contains" when typeof(string).IsAssignableFrom(filter.Value.GetType()):
                case "like" when typeof(string).IsAssignableFrom(filter.Value.GetType()):
                    sb.Append($"{filter.FieldName}.Contains(\"{filter.Value}\")");
                    break;

                case "start" when typeof(string).IsAssignableFrom(filter.Value.GetType()):
                case ">=" when typeof(string).IsAssignableFrom(filter.Value.GetType()):
                case ">" when typeof(string).IsAssignableFrom(filter.Value.GetType()):
                    sb.Append($"{filter.FieldName}.StartsWith(\"{filter.Value}\")");
                    break;

                case "equals" when typeof(string).IsAssignableFrom(filter.Value.GetType()):
                case "=" when typeof(string).IsAssignableFrom(filter.Value.GetType()):
                    sb.Append($"{filter.FieldName} == \"{filter.Value}\" ");
                    break;



                case "end" when typeof(string).IsAssignableFrom(filter.Value.GetType()):
                case "<=" when typeof(string).IsAssignableFrom(filter.Value.GetType()):
                case "<" when typeof(string).IsAssignableFrom(filter.Value.GetType()):
                    sb.Append($"{filter.FieldName}.EndsWith(\"{filter.Value}\")");
                    break;

                default:
                    sb.Append($"{filter.FieldName} {filter.Operator} \"{filter.Value}\" ");
                    break;


            }

            if (i < filters.Length - 1)
                sb.Append(" and ");
        }
        return query.Where(sb.ToString());
    }
    private static IQueryable<dynamic> SelectIt(this IQueryable<dynamic> query, string[] fields)
    {
        if (fields == null || fields.Length < 1)
            return query;


        return query.Select($"new({string.Join(", ", fields)})") as IQueryable<dynamic>;


    }
}
