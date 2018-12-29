using Jiguang.JPush.DependencyInjection.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Jiguang.JPush.DependencyInjection
{
    /// <summary>
    /// Provide operations from <see cref="JPushOptions" />
    /// </summary>
    public interface IOptionsProvider
    {
        /// <summary>
        /// Get <see cref="JPushOptions" />
        /// </summary>
        /// <param name="services">an instance of <see cref="IServiceCollection" /></param>
        /// <returns>return <see cref="JPushOptions" /></returns>
        JPushOptions GetOptions(IServiceCollection services);
    }
}