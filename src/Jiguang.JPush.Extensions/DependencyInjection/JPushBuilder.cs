using Jiguang.JPush.DependencyInjection.Exceptions;
using Jiguang.JPush.DependencyInjection.Options;
using Jiguang.JPush.DependencyInjection.Utility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Jiguang.JPush.DependencyInjection
{
    /// <summary>
    /// JPush配置
    /// </summary>
    public class JPushBuilder : IJPushBuilder
    {
        private readonly IServiceCollection _services;
        private readonly IOptionsProvider _optionsProvider;

        public JPushBuilder(IServiceCollection services, IOptionsProvider optionsProvider)
        {
            _services = services;
            _optionsProvider = optionsProvider;
        }

        /// <summary>
        /// 添加JPush客户端
        /// </summary>
        public void AddJPushClient()
        {
            var options = _optionsProvider.GetOptions(_services);

            if (options == null)
            {
                throw new NoOptionsConfiguredException($"{nameof(JPushOptions)} didn't configured.");
            }

            if (!DataAnnotationsValidator.TryValidate(options, out ICollection<ValidationResult> results))
            {
                var errMsg = results
                    .Select(r => r.ErrorMessage)
                    .Aggregate((current, next) => $"{current}, {next}");

                throw new InvalidOptionsConfiguredException($"Invalid {nameof(JPushOptions)} configuration, details: {errMsg}");
            }

            _services.AddTransient<JPushClient, JPushClient>(p => new JPushClient(options.AppKey, options.MasterSecret));
        }
    }
}