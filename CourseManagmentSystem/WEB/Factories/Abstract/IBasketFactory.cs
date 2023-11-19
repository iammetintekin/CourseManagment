using App.Shared.ReturnObjects;
using WEB.Models.Basket;
using WEB.Models.Common;

namespace WEB.Factories.Abstract
{
    public interface IBasketFactory
    {
        BasketViewModel Prepare(Result result=null);
    }
}
