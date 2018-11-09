using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// API访问类
    /// </summary>
    public static class CommunicateBLL
    {
        /// <summary>
        /// 调用ManageCenter API
        /// </summary>
        /// <param name="apiUrl">请求api地址</param>
        /// <param name="paramDic">请求参数列表</param>
        /// <param name="dataCompress">数据是需要解压</param>
        /// <param name="isPost">提交方式</param>
        /// <returns>成功返回请求返回的数据，失败返回null</returns>
        //internal static ResultDataObject CallManageCenterServer(String apiUrl, Dictionary<String, Object> paramDic = null, DataCompress dataCompress = DataCompress.NotCompress, Boolean isPost = true)
        //{
        //    #region 操作日志记录

        //    #endregion

        //    //请求参数
        //    String reqStr = String.Empty;
        //    //请求返回数据
        //    String backStr = String.Empty;

        //    apiUrl = Path.Combine(WebConfig.ManageCenterUrl, apiUrl);

        //    try
        //    {
        //        reqStr = ConstructRequestData(paramDic, false);
        //        if (!isPost)
        //        {
        //            backStr = WebUtil.GetWebData(apiUrl, reqStr, dataCompress, null, 60 * 1000);
        //        }
        //        else
        //        {
        //            backStr = WebUtil.PostWebData(apiUrl, reqStr, dataCompress, null, 60 * 1000);
        //        }

        //        if (String.IsNullOrEmpty(backStr))
        //        {
        //            throw new Exception("ManageCenter返回NULL");
        //        }

        //        var result = JsonUtil.Deserialize<Model.ReturnObject>(backStr);

        //        if (result.Code != (Int32)ResultStatus.Success)
        //        {
        //            throw new Exception($"ManageCenter返回错误,错误代码:{result.Code},错误信息{result.Message}");
        //        }

        //        return result;

        //    }
        //    catch (Exception ex)
        //    {
        //        LogUtil.Write(String.Format("{0}请求Api出错,Url:{1}{0}reqData:{2}{0}stackTrace:{0}{3}{0}Message:{0}{4}{0}", Environment.NewLine, apiUrl, reqStr, ex.StackTrace, ex.Message), LogType.Error);
        //        throw new Exception($"{apiUrl}:{ex.Message}");
        //    }
        //}

    }
}
