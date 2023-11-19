using App.Shared.ReturnObjects;
using WEB.Models.Common;

namespace WEB.Models.Basket
{
    public class BasketViewModel
    {
        public Result Result;
        public SelectCourseDto Basket; 
        public BasketViewModel(Result result=null, SelectCourseDto basket=null)
        {
            Result = result;
            Basket = basket;
        }
    }
}
