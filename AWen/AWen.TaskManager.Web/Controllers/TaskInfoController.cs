using AWen.TaskManager.Core.BLL;
using AWen.TaskManager.Core.Model;
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
            var data = _TaskInfoService.GetModelList(" where IsDelete=0 ", null);
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

        public ActionResult Info(int id)
        {
            var model = _TaskInfoService.GetModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddPost(TB_TM_TaskInfo Info)
        {
            var result = new ResponseResult();
            //Info.BackgroundJobId = System.Guid.NewGuid();
            result.success = _TaskInfoService.Add(Info);
            return Json(result);
        }

        [HttpPost]
        public ActionResult UpateState(int id, int state)
        {
            var result = new ResponseResult();
            var model = _TaskInfoService.GetModel(id);
            model.State = state;
            result.success = _TaskInfoService.Update(model);
            result.message = result.success == true ? "操作成功" : "操作失败";
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