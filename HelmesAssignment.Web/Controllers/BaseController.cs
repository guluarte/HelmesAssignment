using System.Web.Mvc;

namespace HelmesAssignment.Web.Controllers
{
    public class BaseController : Controller
    {
        public string GetCurrentSessionId => System.Web.HttpContext.Current.Session.SessionID;

        public BaseController()
        {

        }
    }
}