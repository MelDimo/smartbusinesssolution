using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sbs.dll
{
    /// <summary>
    /// Использую в модуле обновления заведений
    /// </summary>
    public partial class DTO_Updater
    {
        public class Branch
        {
            public string id { get; set; }
            public string name { get; set; }
            public string ip { get; set; }
            public string srvName { get; set; }
            public string dbName { get; set; }
            /// <summary>
            /// 0 - не обработан; 1 - в процессе обработки; 2 - обработан;
            /// </summary>
            public int updateStatus { get; set; }

            public string getPath()
            {
                return string.Format(@"[{0}\{1}].[{2}].[dbo]", ip, srvName, dbName);
            }
        }

        public class Category
        {
            public string name;
            public string script;

            public override string ToString()
            {
                return name;
            }

        }
    }
}
