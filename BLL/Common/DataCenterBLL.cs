using BLL.DataBLL;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 数据中心逻辑处理类
    /// </summary>
    //public static class DataCenterBLL
    //{
    //    #region 属性定义

    //    /// <summary>
    //    /// 刷新信息的时间间隔，单位（分钟）
    //    /// </summary>
    //    private static Int32 mRefreshInfoInterval => WebConfig.RefreshInfoInterval;

    //    /// <summary>
    //    /// 锁
    //    /// </summary>
    //    private static readonly object lockUtilObj = new object();

    //    #endregion

    //    #region 初始化数据

    //    /// <summary>
    //    /// 启动数据中心
    //    /// </summary>
    //    public static void Start()
    //    {
    //        //启动一个新线程用于刷新数据
    //        Thread t = new Thread(Refresh) { IsBackground = false };
    //        t.Start();
    //    }

    //    /// <summary>
    //    /// 刷新数据
    //    /// </summary>
    //    private static void Refresh()
    //    {
    //        while (true)
    //        {
    //            Init();

    //            //休眠指定的时间
    //            Thread.Sleep(1000 * 60 * mRefreshInfoInterval);
    //        }
    //    }

    //    /// <summary>
    //    /// 初始化数据
    //    /// </summary>
    //    public static void Init()
    //    {
    //        try
    //        {
    //            //ManageCenter数据初始化
    //            ManageCenterBLL .Init(DataCenter.Instance);

    //            lock (lockUtilObj)
    //            {
    //                // 加载gameserver的model数据
    //                DataCenter.Instance.ResourceTypeList = GameServerBaseBLL.GetList<ResourceType>();
    //                DataCenter.Instance.SubResourcetypeList = GameServerBaseBLL.GetList<SubResourceType>();
    //                DataCenter.Instance.ModuleSubConfigList = GameServerBaseBLL.GetList<ModuleSubConfig>();
    //                DataCenter.Instance.GoodsModelList = GameServerBaseBLL.GetList<GoodsModel>();
    //                DataCenter.Instance.HeroModelList = GameServerBaseBLL.GetList<HeroModel>();
    //                DataCenter.Instance.EquipModelList = GameServerBaseBLL.GetList<EquipModel>();
    //                DataCenter.Instance.HeadModelList = GameServerBaseBLL.GetList<HeadModel>();
    //                DataCenter.Instance.GoodsDjqModelList = GameServerBaseBLL.GetList<GoodsDjqModel>();
    //                DataCenter.Instance.MonthCardTypeList = GameServerBaseBLL.GetList<MonthCardType>();
    //                DataCenter.Instance.CityImageModelList = GameServerBaseBLL.GetList<CityImageModel>();
    //                DataCenter.Instance.HeadImageFrameModelList = GameServerBaseBLL.GetList<HeadImageFrameModel>();
    //                DataCenter.Instance.BookModelList = GameServerBaseBLL.GetList<BookModel>();
    //                DataCenter.Instance.MountsSkinModelList = GameServerBaseBLL.GetList<MountsSkinModel>();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            LogUtil.Write($"刷新DataCenter出现错误,ex：{ex}！", LogType.Error);
    //        }

    //        //记录日志
    //        LogUtil.Write("刷新DataCenter成功！", LogType.Info);
    //    }

    //    #endregion
    //}
}
