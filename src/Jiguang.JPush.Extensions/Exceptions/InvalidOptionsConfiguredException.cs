using System;
using Jiguang.JPush.DependencyInjection.Options;

namespace Jiguang.JPush.DependencyInjection.Exceptions
{
    /// <summary>
    /// The configuration of <see cref="JPushOptions" /> is invalid
    /// </summary>
    public class InvalidOptionsConfiguredException : Exception
    {
        /// <summary>
        /// The configuration of <see cref="JPushOptions" /> is invalid
        /// </summary>
        /// <param name="message">Exception message</param>
        public InvalidOptionsConfiguredException(string message)
            : base(message)
        { }
    }
}