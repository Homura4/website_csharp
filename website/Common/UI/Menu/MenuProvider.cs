using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace website
{
    /// <summary>
    /// 菜单提供者
    /// </summary>
    public class MenuProvider
    {
        #region 声明字段

        /// <summary>
        /// 菜单列表
        /// </summary>
        private static Dictionary<String, MenuItem> menusDic = new Dictionary<String, MenuItem>();

        /// <summary>
        /// 菜单缓存时间(分钟)
        /// </summary>
        private static int menuCacheTime = 60;

        #endregion

        #region 方法

        /// <summary>
        /// 获取当前登录用户菜单
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<MenuItem> GetMenuFromCurrentLoginUser()
        {
            IEnumerable<MenuItem> menus = new List<MenuItem>();

            // 需要验证用户登录
            // 需要判断是否是超级用户
            // 根据用户id来获取菜单

            menus = GetMenu();

            return menus;
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<MenuItem> GetMenu()
        {
            String menuPath = HttpContext.Current.Server.MapPath("~/App_Data/Menu.xml");
            IEnumerable<MenuItem> menuItems = new List<MenuItem>();
            // 缓存的键
            String cacheName = "UI.Menu";

            // 缓存判断
            if (MemoryCacheManager.IsSet(cacheName))
            {
                menuItems = MemoryCacheManager.Get<IEnumerable<MenuItem>>(cacheName);
            }
            else
            {
                try
                {
                    XElement menuElement = XElement.Load(menuPath);
                    menusDic = new Dictionary<String, MenuItem>();
                    menuItems = RecursionMenu(menuElement);
                }
                catch (Exception)
                {
                }

                if (menuItems.Any())
                {
                    MemoryCacheManager.Set(cacheName, menuItems,menuCacheTime);
                }
            }

            return menuItems;
        }

        /// <summary>
        /// 递归菜单XML
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="menuElement"></param>
        /// <returns></returns>
        private static IEnumerable<MenuItem> RecursionMenu(XElement menuElement, MenuItem parent = null)
        {
            List<MenuItem> listMenuItem = new List<MenuItem>();
            var menus = menuElement.Elements("MenuItem");
            MenuItem item = new MenuItem();
            foreach (var p in menus)
            {
                item = new MenuItem();
                item.ID = p.Attribute("ID")?.Value.Trim();
                item.Text = p.Attribute("Text")?.Value.Trim();
                item.Controller = p.Attribute("Controller")?.Value.Trim();
                item.Action = p.Attribute("Action")?.Value.Trim();
                if (p.Attribute("ChildAction") != null)
                {
                    item.ChildAction = p.Attribute("ChildAction")?.Value.Trim();
                }

                item.Items = RecursionMenu(p, item);
                if (p.Attribute("CSSClass") != null)
                {
                    item.CSSClass = p.Attribute("CSSClass")?.Value.Trim();
                }
                item.Parent = parent;
                listMenuItem.Add(item);
                if (!menusDic.ContainsKey(item.ID))
                {
                    menusDic.Add(item.ID, item);
                }
            }

            return listMenuItem;
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<String, MenuItem> GetMenuDic()
        {
            if (menusDic.Count == 0)
            {
                GetMenu();
            }

            return menusDic;
        }

        #endregion

    }
}