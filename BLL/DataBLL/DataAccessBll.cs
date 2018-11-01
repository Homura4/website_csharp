// ***********************************************************************
// Assembly         : BLL
// Author           : yangyang
// Created          : 10-31-2018
//
// Last Modified By : yangyang
// Last Modified On : 11-01-2018
// ***********************************************************************
// <copyright file="DataAccessBll.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DataBLL
{
    using DAL;

    /// <summary>
    /// 数据访问
    /// </summary>
    public class DataAccessBll
    {
        /// <summary>
        /// 查询列表（只支持主键筛选）
        /// </summary>
        /// <param name="paramObj">参数</param>
        /// <returns>数据</returns>
        public static List<T> GetList<T>(T paramObj = null) where T : class
        {
            try
            {
                return DataAccessDal<T>.GetList(paramObj);
            }
            catch (Exception ex)
            {
                // 日志模块

                return new List<T>();
            }
        }

        /// <summary>
        /// 查询列表（只支持字符串与数字筛选）
        /// </summary>
        /// <param name="pageNo">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="paramObj">参数</param>
        /// <param name="isLike">是否使用like查询</param>
        /// <param name="filterStr">自定义筛选字段</param>
        /// <param name="orderStr">排序字符串</param>
        /// <returns>数据</returns>
        public static List<T> GetDefinedList<T>(T paramObj = null, Int32 pageNo = -1, Int32 pageSize = -1, Boolean isLike = false, String filterStr = "", String orderStr = "") where T : class
        {
            try
            {
                return DataAccessDal<T>.GetDefinedList(paramObj, pageNo, pageSize, isLike, filterStr, orderStr);
            }
            catch (Exception ex)
            {
                // 日志模块

                return new List<T>();
            }
        }

        /// <summary>
        /// 获得自定义筛选的数据量（只支持字符串与数字筛选,like）
        /// </summary>
        /// <param name="paramObj">参数</param>
        /// <param name="isLike">是否使用like查询</param>
        /// <param name="filterStr">自定义筛选字段</param>
        /// <returns>受影响的函数</returns>
        public static Int32 GetDefinedCount<T>(T paramObj = null, Boolean isLike = false, String filterStr = "") where T : class
        {
            try
            {
                return DataAccessDal<T>.GetDefinedCount(paramObj, isLike, filterStr);
            }
            catch (Exception ex)
            {
                // 日志模块

                return 0;
            }
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="paramObj">参数</param>
        /// <returns>受影响的函数</returns>
        public static Int32 Insert<T>(T paramObj, Boolean ifThrowException = false) where T : class
        {
            try
            {
                return DataAccessDal<T>.Insert(paramObj);
            }
            catch (Exception ex)
            {
                // 日志模块

                if (ifThrowException)
                {
                    throw ex;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="paramObj">参数</param>
        /// <returns>受影响的函数</returns>
        public static Int32 Update<T>(T paramObj, Boolean ifThrowException = false) where T : class
        {
            try
            {
                return DataAccessDal<T>.Update(paramObj);
            }
            catch (Exception ex)
            {
                // 日志模块

                if (ifThrowException)
                {
                    throw ex;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="paramObj">参数</param>
        /// <returns>受影响的函数</returns>
        public static Int32 Delete<T>(T paramObj) where T : class
        {
            try
            {
                return DataAccessDal<T>.Delete(paramObj);
            }
            catch (Exception ex)
            {
                // 日志模块

                return 0;
            }
        }
    }
}
