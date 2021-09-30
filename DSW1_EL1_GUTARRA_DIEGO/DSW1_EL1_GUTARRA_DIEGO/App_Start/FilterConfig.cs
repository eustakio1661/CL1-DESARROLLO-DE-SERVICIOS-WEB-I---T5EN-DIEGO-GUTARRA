using System.Web;
using System.Web.Mvc;

namespace DSW1_EL1_GUTARRA_DIEGO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
