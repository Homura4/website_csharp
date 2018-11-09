// ***********************************************************************
// Assembly         : Model
// Author           : yangyang
// Created          : 11-02-2018
//
// Last Modified By : yangyang
// Last Modified On : 11-02-2018
// ***********************************************************************
// <copyright file="ReturnObject.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary>回调函数对象类</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// gameserver回调通用返回
    /// </summary>
    public class CallbackServerCommonResponse
    {
        /// <summary>
        /// 数据
        /// </summary>
        public String Data { get; set; }
    }

    /// <summary>
    /// gameServer API返回对象
    /// </summary>
    public class ResultDataObject
    {
        /// <summary>
        /// 结果状态枚举（enum）
        /// </summary>
        public Int32 ResultStatus { get; set; }

        /// <summary>
        /// 状态枚举名称
        /// </summary>
        public String ResultStatusName { get; set; }

        /// <summary>
        /// 返回值数据
        /// </summary>
        public CallbackServerCommonResponse Value { get; set; }
    }

    /// <summary>
    /// manageCenter Api返回对象
    /// </summary>
    public class ReturnObject
    {
        /// <summary>
        /// 返回的状态值；0：成功；非0：失败（根据实际情况进行定义）
        /// </summary>
        public Int32 Code { get; set; }

        /// <summary>
        /// 返回的描述信息；
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public Object Data { get; set; }
    }

    /// <summary>
    /// chatServer API返回对象
    /// </summary>
    public class ChatResultDataObject
    {
        /// <summary>
        /// 结果枚举
        /// </summary>
        public Int32 Code { get; set; }

        /// <summary>
        /// 结果状态枚举（enum）
        /// </summary>
        public Int32 ResultCodeStatus { get; set; }

        /// <summary>
        /// 返回的描述信息；
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public Object Data { get; set; }
    }
}
