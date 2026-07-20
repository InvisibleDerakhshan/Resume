namespace Resume.Business.Services.Interface;

public interface IViewRenderService
{
    Task<string> RenderToStringAsync(string viewName, object model);
}