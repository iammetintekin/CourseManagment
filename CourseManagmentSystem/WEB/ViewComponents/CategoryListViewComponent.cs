using App.Application.LoadServices;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.ViewComponents
{
    [ViewComponent(Name = "CategoryListViewComponent")]
    public class CategoryListViewComponent:ViewComponent
    {
        private readonly IServiceManager _serviceManager;
        public CategoryListViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;            
        }
        public IViewComponentResult Invoke()
        {
            var menuModel = new MenuModel();
            var categories = _serviceManager.CategoryService.List();
            foreach (var item in categories.Data)
            {
                menuModel.Items.Add(new MenuItem { ID = item.Id, Text = item.Name });
            }
            return View(menuModel);
        }
    }
}
