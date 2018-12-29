using Jiguang.JPush.DependencyInjection.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Jiguang.JPush.DependencyInjection
{
    /// <summary>
    /// Provide operations from <see cref="JPushOptions" />
    /// </summary>
    public class OptionsProvider : IOptionsProvider
    {
        /// <summary>
        /// Get <see cref="JPushOptions" />
        /// </summary>
        /// <param name="services">an instance of <see cref="IServiceCollection" /></param>
        /// <returns>return <see cref="JPushOptions" /></returns>
        public JPushOptions GetOptions(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider(); // get an instance of IServiceProvider
            var options = provider.GetRequiredService<IOptions<JPushOptions>>()?.Value; // resolve an instance of JPushOptions

            return options;
        }
    }
}