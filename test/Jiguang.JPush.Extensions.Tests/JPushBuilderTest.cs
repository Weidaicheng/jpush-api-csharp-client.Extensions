using Jiguang.JPush.DependencyInjection;
using Jiguang.JPush.DependencyInjection.Exceptions;
using Jiguang.JPush.DependencyInjection.Options;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;

namespace Jiguang.JPush.Extensions.Tests
{
    public class JPushBuilderTest
    {
        private IServiceCollection services;

        [SetUp]
        public void SetUp()
        {
            services = new ServiceCollection();
        }

        [TearDown]
        public void TearDown()
        {
            services = null;
        }

        [Test]
        public void AddJPushClient_OptionsConfiguredAsNull_ThrowsException()
        {
            var oProvider = Substitute.For<IOptionsProvider>();
            oProvider.GetOptions(services).Returns(call => null);

            var builder = new JPushBuilder(services, oProvider);

            Assert.Throws<NoOptionsConfiguredException>(() =>
            {
                builder.AddJPushClient();
            });
        }

        [Test]
        public void AddJPushClient_OptionsConfiguredAppKeyAndMasterSecretAsNull_ThrowsException()
        {
            var oProvider = Substitute.For<IOptionsProvider>();
            oProvider.GetOptions(services).Returns(call => new JPushOptions()
            {
                AppKey = null,
                MasterSecret = null
            });

            var builder = new JPushBuilder(services, oProvider);

            Assert.Throws<InvalidOptionsConfiguredException>(() =>
            {
                builder.AddJPushClient();
            });
        }

        [Test]
        public void AddJPushClient_OptionsConfiguredAppKeyAndMasterSecretAsEmptyString_ThrowsException()
        {
            var oProvider =Substitute.For<IOptionsProvider>();
            oProvider.GetOptions(services).Returns(call => new JPushOptions()
            {
                AppKey = string.Empty,
                MasterSecret = string.Empty
            });

            var builder = new JPushBuilder(services, oProvider);

            Assert.Throws<InvalidOptionsConfiguredException>(() =>
            {
                builder.AddJPushClient();
            });
        }
    }
}