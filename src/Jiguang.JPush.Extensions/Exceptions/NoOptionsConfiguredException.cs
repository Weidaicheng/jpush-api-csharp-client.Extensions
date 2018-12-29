using System;
using Jiguang.JPush.DependencyInjection.Options;

namespace Jiguang.JPush.DependencyInjection.Exceptions
{
    /// <summary>
    /// There's no <see cref="JPushOptions" /> could be found exception
    /// </summary>
    public class NoOptionsConfiguredException : Exception
    {
        /// <summary>
        /// There's no <see cref="JPushOptions" /> could be found exception
        /// </summary>
        /// <param name="message">Exception message</param>
        public NoOptionsConfiguredException(string message)
            : base(message)
        { }
    }
}