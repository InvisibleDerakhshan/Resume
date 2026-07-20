using Resume.DAL.Repositories.Interface;
using Resume.DAL.Repositories.Implementation;
using Resume.Business.Services.Interface;
using Resume.Business.Services.Implementation;
using Resume.Bussines.Services.Interfaces;
using Resume.Bussines.Services.Implementation;


namespace Resume.Web.Configuration
{
    public static class DiContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IAboutMeRepository, AboutMeRepository>();

            #endregion


            #region Services

            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IContactUsService,ContactUsService>();
            services.AddScoped<IAboutMeService,AboutMeService>();

            services.AddScoped<IEmailService,EmailService>();
            services.AddScoped<IViewRenderService,ViewRenderService>();

            #endregion
        }
    }
}
