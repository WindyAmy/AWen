/********************************************************************
 * 命名空间: AWen.TaskManager.Web.Controllers

 * 文件名称: BaseController

 * 文件作者: AWen

 * 创建时间: 2018/4/18 10:45:21
=====================================================================
 * 功能说明:
---------------------------------------------------------------------
 * 其他说明:
*********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using AWen.TaskManager.Web;

namespace AWen.TaskManager.Web.Controllers
{
    public class BaseController : Controller
    {
        #region JsonResult

        public new JsonResult Json(object data)
        {
            return new NewtonJsonResult(data, new JsonSerializerSettings() { DateFormatString = "yyyy-MM-dd HH:mm:ss" });
        }

        public new JsonResult Json(object data, JsonRequestBehavior behavior)
        {
            return new NewtonJsonResult(data, behavior, new JsonSerializerSettings() { DateFormatString = "yyyy-MM-dd HH:mm:ss" });
        }

        public JsonResult Json(object data, JsonRequestBehavior behavior, string DateFormatString)
        {
            return new NewtonJsonResult(data, behavior, new JsonSerializerSettings() { DateFormatString = DateFormatString });
        }

        public new JsonResult Json(object data, string DateFormatString)
        {
            return new NewtonJsonResult(data, new JsonSerializerSettings() { DateFormatString = DateFormatString });
        }

        #endregion
	}
}