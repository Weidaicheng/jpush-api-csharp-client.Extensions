using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jiguang.JPush.DependencyInjection.Options
{
    /// <summary>
    /// JPush配置
    /// </summary>
    public class JPushOptions
    {
        /// <summary>
        /// App Key
        /// </summary>
        [Required(ErrorMessage = "App Key is required")]
        public string AppKey { get; set; }

        /// <summary>
        /// Master Secret
        /// </summary>
        [Required(ErrorMessage = "Master Secret is required")]
        public string MasterSecret { get; set; }
    }
}