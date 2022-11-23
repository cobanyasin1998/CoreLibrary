namespace CoreLibrary.Web.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {

        private readonly MyDbContext _context;
        protected ILogger<T> Logger => _logger ?? (_logger = HttpContext.RequestServices.GetService<ILogger<T>>());

    }
}
