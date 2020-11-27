using System.Web;
using System.Web.Mvc;

namespace CI0126_ExamenFinal_B70866
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
