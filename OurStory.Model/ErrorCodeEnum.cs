using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OurStory.Model
{
    /// <summary>
    /// 操作状态码
    /// </summary>
    public enum ErrorCodeEnum
    {
        /// <summary>
        /// 操作失败
        /// </summary>
        [Description("操作失败")]
        Failed = -1001,

        /// <summary>
        /// 操作成功
        /// </summary>
        [Description("操作成功")]
        Success = 1001,

        /// <summary>
        /// 网络异常
        /// </summary>
        [Description("网络异常")]
        Error_NetWork = 1002,

        /// <summary>
        /// 序列化错误
        /// </summary>
        [Description("序列化错误")]
        Error_Serialization = 1003,

        /// <summary>
        /// 程序异常
        /// </summary>
        [Description("程序异常")]
        Error_Program = 1004,

        /// <summary>
        /// 没有找到数据
        /// </summary>
        [Description("没有找到数据")]
        Error_NoData = 1005,

        /// <summary>
        /// 数据库的数据错误
        /// </summary>
        [Description("数据库的数据错误")]
        Error_SqlData = 1006,

        /// <summary>
        /// 系统缓存错误
        /// </summary>
        [Description("设置系统缓存错误")]
        Error_SetCache = 1007,

        /// <summary>
        /// 反序列化错误
        /// </summary>
        [Description("反序列化错误")]
        Error_Deserialization = 1008,

        /// <summary>
        /// 无效的链接
        /// </summary>
        [Description("无效的链接")]
        Error_URL = 1009,

        /// <summary>
        /// 数据状态不正确
        /// </summary>
        [Description("数据状态不正确")]
        Error_Data_State = 1100,

        /// <summary>
        /// 参数错误
        /// </summary>
        [Description("传入参数错误")]
        Parameter_Missing = 1201,


        #region 授权错误
        /// <summary>
        /// 用户已失效, 请重新登录
        /// </summary>
        [Description("用户已失效, 请重新登录")]
        Error_Token_Invalid = 1301,

        /// <summary>
        /// 参数ClientID错误
        /// </summary>
        [Description("参数ClientID错误")]
        Error_Token_ClientID = 1302,

        /// <summary>
        /// assessToken已过期,请刷新或者重新登录
        /// </summary>
        [Description("assessToken已过期,请刷新或者重新登录")]
        Error_Token_Timeout = 1303,

        /// <summary>
        /// 网关请求服务超时
        /// </summary>
        [Description("网关请求服务超时")]
        Error_Service_Timeout = 1304,
        /// <summary>
        /// 网关请求服务超时
        /// </summary>
        [Description("登录错误次数")]
        Error_Login_Number = 1305,
        /// <summary>
        /// 单位时间内请求超过次数
        /// </summary>
        [Description("单位时间内请求超过次数")]
        Error_Request_Number = 1306,
        #endregion

        #region 权限验证
        /// <summary>
        /// 没有权限，请设置用户角色权限
        /// </summary>
        [Description("没有权限，请设置用户角色权限")]
        Error_NoPermission = 1401
        #endregion
    }
}
