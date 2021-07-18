using System.Web;
using System.Web.Mvc;

namespace DO_AN_APS_DOC_NET_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
