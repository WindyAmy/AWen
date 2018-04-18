/******************************************************************** 
 * 命名空间: AWen.TaskManager.Web.App_Code

 * 文件名称: NewtonJsonResult

 * 文件作者: Young
 
 * 创建时间: 2018/4/18 14:02:00
=====================================================================
 * 功能说明: 
--------------------------------------------------------------------- 
 * 其他说明:
*********************************************************************/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AWen.TaskManager.Web
{
    public class NewtonJsonResult : JsonResult
    {
        public JsonSerializerSettings JsonSerializerSettings { get; set; }
        public NewtonJsonResult()
        {
            this.JsonRequestBehavior = JsonRequestBehavior.DenyGet;
        }
        public NewtonJsonResult(object obj)
        {
            this.JsonRequestBehavior = JsonRequestBehavior.DenyGet;
            this.Data = obj;
        }
        public NewtonJsonResult(object obj, JsonSerializerSettings jsonSerializerSettings)
        {
            this.JsonRequestBehavior = JsonRequestBehavior.DenyGet;
            this.Data = obj;
            this.JsonSerializerSettings = jsonSerializerSettings;
        }

        public NewtonJsonResult(object obj, JsonRequestBehavior behavior, JsonSerializerSettings jsonSerializerSettings)
        {
            this.JsonRequestBehavior = behavior;
            this.Data = obj;
            this.JsonSerializerSettings = jsonSerializerSettings;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if ((this.JsonRequestBehavior == JsonRequestBehavior.DenyGet) && (string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("该方法当前不允许使用Get");
            }
            HttpResponseBase response = context.HttpContext.Response;
            if (!string.IsNullOrEmpty(this.ContentType))
            {
                response.ContentType = this.ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }
            if (this.Data != null)
            {
                string strJson = JsonConvert.SerializeObject(this.Data, JsonSerializerSettings);
                response.Write(strJson);
                response.End();
            }
        }
    }
}
