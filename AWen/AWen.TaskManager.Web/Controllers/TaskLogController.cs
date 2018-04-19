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
        public ActionResult List(int page, int limit, string search)
        {
            var totaldata = _TaskLogService.GetModelList(" where IsDelete=0 and TaskName Like '%" + search + "%'", null);
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

        [HttpPost]
        public ActionResult Delete(string idList)
        {
            var result = new ResponseResult();
            try
            {
                var idArray = idList.Split(',');
                foreach (var id in idArray)
                {
                    var model = _TaskLogService.GetModel(int.Parse(id));
                    model.IsDelete = 1;
                    _TaskLogService.Update(model);
                }
                result.success = true;
                result.message = "操作成功";
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return Json(result);
        }
	}
}