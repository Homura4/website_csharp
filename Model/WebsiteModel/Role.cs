// ***********************************************************************
// Assembly         : Model
// Author           : yangyang
// Created          : 11-01-2018
//
// Last Modified By : yangyang
// Last Modified On : 11-01-2018
// ***********************************************************************
// <copyright file="Role.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Model
{
    using Common;

    /// <summary>
    /// 角色
    /// </summary>
    [DataBaseTable("role")]
    public sealed class Role
    {
        #region 属性

        /// <summary>
        /// 角色Id
        /// </summary>
        [PrimaryKey]
        public Int32 ID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public String RolesName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// 角色具有的权限
        /// </summary>
        public String Page { get; set; }

        #endregion
    }
}
