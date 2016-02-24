// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringTypeConvention.cs" company="Level B Ltd">
//   (c) Level B Ltd 2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Recipes.WebApi.Conventions
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Reflection;

    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public abstract class AttributeDrivenConventionBase
    {
        /// <summary>
        /// Find a <see cref="CascadeAttribute"/> if it exists on the provided member
        /// </summary>
        /// <param name="memberInfo">The member to check for a property</param>
        /// <returns>An unambiguous cascade attribute, or null</returns>
        protected static T GetAttributeOn<T>(MemberInfo memberInfo) where T : class
        {
            var attrs = memberInfo.GetCustomAttributes(typeof(T), false);

            if (attrs.Length == 1)
            {
                return attrs.Single() as T;
            }

            return null;
        }
    }

    public class StringTypeConvention : AttributeDrivenConventionBase, IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            var sqlType = GetAttributeOn<ColumnAttribute>(instance.Property.MemberInfo);

            if (sqlType != null)
            {
                switch ((sqlType.TypeName ?? string.Empty).ToLower())
                {
                    case "text":
                    case "ntext":
                    case "varchar(max)":
                    case "varchar[max]":
                    case "nvarchar(max)":
                    case "nvarchar[max]":
                        instance.CustomSqlType(sqlType.TypeName);

                        // This is more than 4000, and magically this allows any length!  Magical!
                        instance.Length(4001);
                        return;
                }
            }

            var stringLength = GetAttributeOn<StringLengthAttribute>(instance.Property.MemberInfo);

            if (stringLength != null)
            {
                instance.Length(stringLength.MaximumLength);
            }
        }
    }
}