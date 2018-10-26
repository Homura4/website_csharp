using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website
{
    /// <summary>
    /// 菜单条目(子菜单模型)
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        /// <summary>
        /// 菜单显示名称
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Text { get; set; }

        /// <summary>
        /// 菜单所属控制器
        /// </summary>
        [JsonProperty(PropertyName = "controller")]
        public string Controller { get; set; }

        /// <summary>
        /// 菜单所属方法
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        /// <summary>
        /// 子操作方法 search ,data
        /// </summary>
        public string ChildAction { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        [JsonProperty(PropertyName = "values")]
        public IEnumerable<MenuItem> Items { get; set; }

        /// <summary>
        /// 当前菜单
        /// </summary>
        /// <value>The parent.</value>
        [JsonIgnore]
        public MenuItem Parent { get; set; }

        /// <summary>
        /// 菜单标签图标
        /// </summary>
        public string CSSClass { get; set; }

        [JsonIgnore]
        public string Path
        {
            get
            {
                if (Parent != null)
                {
                    return Parent.Path + "&gt" + this.Text;
                }
                return this.Text;
            }
        }

        public string LinkPath(Func<MenuItem, string> expr)
        {
            var result = "";
            if (Parent != null)
            {
                result += Parent.LinkPath(expr) + "&gt";
            }

            return result + expr(this);
        }
    }
}