using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 读取webconfig
    /// </summary>
    public class WebConfig
    {
        /// <summary>
        /// 刷新中心数据时间间隔
        /// </summary>
        public static Int32 RefreshInfoInterval
        {
            get
            {
                var temp = ConfigurationManager.AppSettings["RefreshInfoInterval"];
                if (temp == null)
                {
                    throw new Exception("刷新中心数据时间间隔没有配置");
                }

                return Convert.ToInt32(temp);
            }
        }

        /// <summary>
        /// 允许访问的ip(用;隔开)
        /// </summary>
        public static String[] AllowIps
        {
            get
            {
                var temp = ConfigurationManager.AppSettings["AllowIps"];
                if (temp == null)
                {
                    throw new Exception("AllowIps允许访问的ip没有配置");
                }

                return temp.Split(';');
            }
        }

        /// <summary>
        /// 管理服务器数据库连接
        /// </summary>
        public static String ConnString
        {
            get
            {
                var temp = ConfigurationManager.ConnectionStrings["ConnString"];
                if (temp == null)
                {
                    throw new Exception("GameManageConnString数据库连接没有配置");
                }

                return ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            }
        }

        /// <summary>
        /// check方法
        /// </summary>
        public static void Check()
        {
            object temp;
            temp = RefreshInfoInterval;
            temp = AllowIps;
            temp = ConnString;
        }
    }
}
