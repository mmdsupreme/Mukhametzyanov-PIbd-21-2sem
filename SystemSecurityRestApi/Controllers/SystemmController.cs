using SystemSecurityService.BindingModels;
using SystemSecurityService.Interfaces;
using System;
using System.Web.Http;

namespace NewRestApi.Controllers
{
    public class SystemmController : ApiController
    {
        private readonly ISystemm _service;

        public SystemmController(ISystemm service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(SystemmBindModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(SystemmBindModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(SystemmBindModel model)
        {
            _service.DelElement(model.ID);
        }
    }
}
