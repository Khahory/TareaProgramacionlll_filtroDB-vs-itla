using System.Web;
using System.Web.Mvc;

namespace TareaProgramacionlll_filtroDB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
