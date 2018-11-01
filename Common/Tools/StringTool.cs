using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 字符串工具
    /// </summary>
    public static class StringTool
    {
        /// <summary>
        /// 是否为日期+时间型字符串
        /// </summary>
        /// <param name="strSource">字符串</param>
        /// <returns></returns>
        public static bool IsDateTime(string strSource)
        {
            return Regex.IsMatch(strSource, @"\d{4}/\d{1,2}/\d{1,2} \d{1,2}:\d{1,2}:\d{1,2}");
        }

        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="strSource">字符串</param>
        /// <returns></returns>
        public static bool IsIp(string strSource)
        {
            return Regex.IsMatch(strSource, @"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");
        }

        /// <summary>
        /// 获取唯一的字符串
        /// </summary>
        /// <returns></returns>
        public static String UniqueString()
        {
            return (DateTime.Now.ToString() + Guid.NewGuid().ToString()).Replace(" ", "").Replace(":", "").Replace("-", "").Replace("/", "");
        }
    }
}
