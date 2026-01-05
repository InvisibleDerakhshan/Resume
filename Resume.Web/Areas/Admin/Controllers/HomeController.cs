using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Resume.Web.Areas.Admin.Controllers
{
 
    public class HomeController : AdminBaseController
    {
        #region Actions 
        public IActionResult Index()
        {
            return View();
        }
        #endregion
    }
}
