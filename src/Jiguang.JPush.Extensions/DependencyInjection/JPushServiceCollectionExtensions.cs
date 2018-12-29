using Jiguang.JPush.DependencyInjection.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Jiguang.JPush.DependencyInjection
{
    /// <summary>
    /// 添加极光推送的DI扩展
    /// </summary>
    public static class JPushServiceCollectionExtensions
    {
        /// <summary>
        /// 添加极光推送
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        private static IJPushBuilder addJPush(this IServiceCollection services)
        {
            IOptionsProvider oProvider = new OptionsProvider();
            IJPushBuilder builder = new JPushBuilder(services, oProvider);

            builder.AddJPushClient();

            return builder;
        }

        /// <summary>
        /// 添加极光推送
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="setupAction">The setup action.</param>
        /// <returns></returns>
        public static IJPushBuilder AddJPush(this IServiceCollection services, Action<JPushOptions> setupAction)
        {
            services.Configure<JPushOptions>(setupAction);
            return services.addJPush();
        }

        /// <summary>
        /// 添加极光推送
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IJPushBuilder AddJPush(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JPushOptions>(configuration);
            return services.addJPush();
        }
    }
}