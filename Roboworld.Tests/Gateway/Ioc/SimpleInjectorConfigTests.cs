// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleInjectorConfigTests.cs" company="Matthew Longworth">
//   (c) Matthew Longworth 2016
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Roboworld.Tests.Gateway.Ioc
{
    using System.Web.Http;

    using NUnit.Framework;

    using Roboworld.Gateway.WebApi;

    [TestFixture]
    public class SimpleInjectorConfigTests 
    {
        [Test, Ignore("Needs some extra work for finding the controllers")]
        public void Register_WhenRegistered_ThenAllConfigurationIsValid()
        {
            var httpConfiguration = new HttpConfiguration();
            SimpleInjectorConfig.Register(httpConfiguration);
        }
    }
}