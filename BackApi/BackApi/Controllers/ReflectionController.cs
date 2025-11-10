using BussinesLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackApi.Controllers
{
    [Route("api/importers")]
    [ApiController]
    public class ReflectionController : ControllerBase
    {
        private readonly ImporterLogic _importerLogic;
        public ReflectionController(ImporterLogic importerLogic)
        {
            _importerLogic = importerLogic;
        }

        [HttpGet]
        public IActionResult ImportersName()
        {
            var avaibleImporters = _importerLogic.GetAllImporters().ToArray();
            if (avaibleImporters == null)
            {
                return Ok(new string[0]);
            }
            else
            {
                return Ok(avaibleImporters.Select(a => a));
            }
        }
    }
}
