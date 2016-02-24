//// --------------------------------------------------------------------------------------------------------------------
//// <copyright file="CascadeConvention.cs" company="Level B Ltd">
////   (c) Level B Ltd 2014
//// </copyright>
//// --------------------------------------------------------------------------------------------------------------------

//namespace Roboworld.Recipes.WebApi.Conventions
//{
//    using System.Linq;
//    using System.Reflection;

//    using FluentNHibernate.Conventions;
//    using FluentNHibernate.Conventions.Instances;

//    using NHibernate.Engine;

//    /// <summary>
//    /// A NHibernate automatic mapping convention that deals with cascading on navigation properties
//    /// </summary>
//    public class CascadeConvention : AttributeDrivenConventionBase, IHasManyConvention, IReferenceConvention, IHasManyToManyConvention
//    {
//        /// <summary>
//        /// Apply this convention's settings to a specific instance (property) for a One-To-Many relationship
//        /// </summary>
//        /// <param name="instance">Fluent interface for configuring conventions on this property</param>
//        public void Apply(IOneToManyCollectionInstance instance)
//        {
//            var attr = GetAttributeOn<CascadeAttribute>(instance.Member);

//            if (attr != null)
//            {
//                SetCascade(instance.Cascade, attr);
//            }
//        }

//        /// <summary>
//        /// Apply this convention's settings to a specific instance (property) for a Many-To-One relationship
//        /// </summary>
//        /// <param name="instance">Fluent interface for configuring conventions on this property</param>
//        public void Apply(IManyToOneInstance instance)
//        {
//            var attr = GetAttributeOn<CascadeAttribute>(instance.Property.MemberInfo);

//            if (attr != null)
//            {
//                SetCascade(instance.Cascade, attr);
//            }
//        }

//        /// <summary>
//        /// Apply this convention's settings to a specific instance (property) for a Many-To-Many relationship
//        /// </summary>
//        /// <param name="instance">Fluent interface for configuring conventions on this property</param>
//        public void Apply(IManyToManyCollectionInstance instance)
//        {
//            var attr = GetAttributeOn<CascadeAttribute>(instance.Member);

//            if (attr != null)
//            {
//                SetCascade(instance.Cascade, attr);
//            }
//        }

//        /// <summary>
//        /// Apply a cascading attribute to an instance
//        /// </summary>
//        /// <param name="instanceCascade">The instance to modify</param>
//        /// <param name="attribute">The attribute that defines how we should cascade this property</param>
//        private static void SetCascade(ICascadeInstance instanceCascade, CascadeAttribute attribute)
//        {
//            switch (attribute.Style)
//            {
//                case CascadeStyle.None:
//                    instanceCascade.None();
//                    break;
//                case CascadeStyle.All:
//                    instanceCascade.All();
//                    break;
//                case CascadeStyle.CreateOnly:
//                    instanceCascade.SaveUpdate();
//                    break;
//                case CascadeStyle.DeleteOnly:
//                    instanceCascade.Delete();
//                    break;
//            }
//        }
//    }

//    public abstract class AttributeDrivenConventionBase
//    {
//        /// <summary>
//        /// Find a <see cref="CascadeAttribute"/> if it exists on the provided member
//        /// </summary>
//        /// <param name="memberInfo">The member to check for a property</param>
//        /// <returns>An unambiguous cascade attribute, or null</returns>
//        protected static T GetAttributeOn<T>(MemberInfo memberInfo) where T : class
//        {
//            var attrs = memberInfo.GetCustomAttributes(typeof(T), false);

//            if (attrs.Length == 1)
//            {
//                return attrs.Single() as T;
//            }

//            return null;
//        }
//    }
//}