using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace website
{
    /// <summary>
    /// 菜单类
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="html">扩展htmlhelper方法</param>
        /// <param name="menuItems">当前获取到的用户菜单集合</param>
        /// <param name="menuUrl">actionName,controllerName,URL</param>
        /// <param name="collapseAll">是否收缩菜单(未实现,没有展开需求,预留字段,思路为动态判断然后写入class)</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString CreateMenu(this HtmlHelper html, IEnumerable<MenuItem> menuItems, Func<String, String, String> menuUrl, Boolean collapseAll = false)
        {
            string menuHtml = string.Empty;

            menuHtml = RecursionMenuList(html, menuItems, menuUrl, collapseAll);

            return MvcHtmlString.Create(menuHtml);
        }

        /// <summary>
        /// 菜单生成
        /// </summary>
        public static string RecursionMenuList(HtmlHelper html, IEnumerable<MenuItem> menuItems, Func<String, String, String> menuUrl, Boolean collapseAll)
        {
            string menuHtml = string.Empty;

            // 菜单分组
            foreach (var menu in menuItems)
            {
                var div = new TagBuilder("div");
                div.AddCssClass("menu_section");

                var h3 = new TagBuilder("h3");
                h3.InnerHtml = menu.Text;

                if (menu.Items.Any())
                {
                    var ul = new TagBuilder("ul");
                    ul.AddCssClass("nav side-menu");

                    // 分组下的菜单
                    foreach (var childItem in menu.Items)
                    {
                        var li = new TagBuilder("li");

                        // 菜单名称和图标
                        var a = new TagBuilder("a");

                        var i = new TagBuilder("i");
                        i.AddCssClass("fa " + childItem.CSSClass);

                        var span = new TagBuilder("span");
                        span.AddCssClass("fa fa-chevron-down");

                        a.InnerHtml = i.ToString() + childItem.Text + span.ToString();

                        // 子菜单
                        if (childItem.Items.Any())
                        {
                            // 递归子菜单
                            li.InnerHtml = a.ToString() + ChildMeun(childItem.Items, menuUrl);
                        }
                        else
                        {
                            li.InnerHtml = a.ToString();
                        }
                        
                        ul.InnerHtml += li.ToString();
                    }

                    div.InnerHtml = h3 + ul.ToString();
                }
                else
                {
                    div.InnerHtml = h3.ToString();
                }

                menuHtml += div.ToString();
            }

            return menuHtml;
        }


        /// <summary>
        /// 子菜单递归
        /// </summary>
        /// <returns>System.String.</returns>
        public static string ChildMeun(IEnumerable<MenuItem> childItem , Func<String, String, String> menuUrl)
        {
            var ul = new TagBuilder("ul");
            ul.AddCssClass("nav child_menu");

            foreach (var itemLi in childItem)
            {
                var li = new TagBuilder("li");

                var a = new TagBuilder("a");

                if (itemLi.Items.Any())
                {
                    var span = new TagBuilder("span");
                    span.AddCssClass("fa fa-chevron-down");

                    a.InnerHtml = itemLi.Text + span.ToString();

                    li.InnerHtml = a.ToString() + ChildMeun(itemLi.Items , menuUrl);
                }
                else
                {
                    a.InnerHtml = itemLi.Text;
                    a.Attributes["href"] = menuUrl(itemLi.Action, itemLi.Controller);

                    li.InnerHtml = a.ToString();
                }

                ul.InnerHtml += li.ToString();
            }

            return ul.ToString();
        }
    }
}