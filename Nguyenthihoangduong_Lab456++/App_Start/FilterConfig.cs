using System.Web;
using System.Web.Mvc;

namespace Nguyenthihoangduong_Lab456__
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
