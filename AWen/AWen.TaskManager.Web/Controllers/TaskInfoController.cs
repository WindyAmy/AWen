using AWen.TaskManager.Core.BLL;
using AWen.TaskManager.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWen.TaskManager.Web.Controllers
{
    public class TaskInfoController : BaseController
    {
        private TaskInfoService _TaskInfoService;

        public TaskInfoController()
        {
            _TaskInfoService = new TaskInfoService();
        }

        [HttpGet]
        public ActionResult List()
        {
            var data = _TaskInfoService.GetModelList("", null);
            var result = new ResponseResult() { success = true, message = "数据获取成功", data = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /TaskInfo/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Info()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(TB_TM_TaskInfo Info)
        {
            var result = new ResponseResult();
            //Info.BackgroundJobId = System.Guid.NewGuid();
            result.success = _TaskInfoService.Add(Info);
            return Json(result);
        }
        [HttpGet]
        public ActionResult InfoData(int id)
        {
            var result = new ResponseResult();
            result.data = _TaskInfoService.GetModel(id);
            result.success = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}