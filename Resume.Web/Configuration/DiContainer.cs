using Resume.DAL.Repositories.Interface;
using Resume.DAL.Repositories.Implementation;
using Resume.Business.Services.Interface;
using Resume.Business.Services.Implementation;


namespace Resume.Web.Configuration
{
    public static class DiContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion


            #region Services

            services.AddScoped<IUserService,UserService>();

            #endregion
        }
    }
}
