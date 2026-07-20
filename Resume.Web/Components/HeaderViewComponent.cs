using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;

namespace Resume.Web.Components
{
    public class HeaderViewComponent :ViewComponent
    {
        #region Fields

        private readonly IAboutMeService _aboutMeService;



        #endregion


        #region Constructor

        public HeaderViewComponent(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }
        #endregion


        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _aboutMeService.GetClientSideInfoAsync();
            return View("Header");
        }

        #endregion

    }
}
