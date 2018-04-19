using AWen.TaskManager.Core.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWen.TaskManager.Web.Controllers
{
    public class TaskLogController : BaseController
    {
        private TaskLogService _TaskLogService;

        public TaskLogController()
        {
            _TaskLogService = new TaskLogService();
        }

        [HttpGet]
        public ActionResult List(int page,int limit)
        {
            var totaldata = _TaskLogService.GetModelList(" where IsDelete=0 ", null);
            var data = _TaskLogService.GetListPage(page, limit, " where IsDelete=0 ", "TaskLogId desc", null);
            var result = new ResponseResult() { success = true,count=totaldata.Count(), message = "数据获取成功", data = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /TaskInfo/
        public ActionResult Index()
        {
            return View();
        }
	}
}