using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Controllers
{
    [Area(areaName:"Admin")]
    public class AdminBaseController:Controller
    {
        protected string SuccessMessage = "SuccessMessage";
        protected string ErrorsMessage = "ErrorSuccessMessage";

    }
}
