using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace Core.Extensions;

public static partial class Extension
{
    public static bool IsEditable(this PropertyInfo propertyInfo)
    {
        if (propertyInfo == null || !propertyInfo.CanWrite)
            return false;

        if (propertyInfo.PropertyType == typeof(string))
            return true;


        if (propertyInfo.PropertyType.IsClass || typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
            return false;

        return true;
    }

    public static EntityEntry<TEntity> SetValue<TEntity, TProperty>(this EntityEntry<TEntity> entry,
        Expression<Func<TEntity, TProperty>> expression, TProperty value)
        where TEntity : class 
    {
        entry.Property(expression).IsModified = true;
        entry.Property(expression).CurrentValue = value;
        return entry;
    }
}
