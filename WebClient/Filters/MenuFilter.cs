using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Filters
{
    public class MenuFilter : ActionFilterAttribute
    {
        AppService app;
        public MenuFilter()
        {
            app = new AppService();
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            Controller controller = (Controller)context.Controller;

            controller.ViewBag.categories = app.Category.GetCategories();
            controller.ViewBag.selectcategories = new SelectList(app.Category.GetCategories(), "Id", "Name");
        }
    }
}
