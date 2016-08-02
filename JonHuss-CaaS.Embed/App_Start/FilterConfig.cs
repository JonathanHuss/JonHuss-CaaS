using System.Web;
using System.Web.Mvc;

namespace JonHuss_CaaS.Embed
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
