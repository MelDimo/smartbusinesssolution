using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sbs.dll
{
    public partial class DTO
    {
        /// <summary>
        /// Использую в модуле обновления заведений
        /// </summary>
        public class Branch
        {
            public int id { get; set; }
            public string Name { get; set; }
            public string IpAddr { get; set; }
        }
    }
}
