using System.Web;
using System.Web.Mvc;

namespace WjbuGangVer2_WebNC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
