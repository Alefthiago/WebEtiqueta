using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace WebApplicationWebPack.Components
{
    public class Webpack : ViewComponent
    {
        private readonly ICompositeViewEngine _viewEngine;

        public Webpack(ICompositeViewEngine viewEngine)
        {
            _viewEngine = viewEngine;
        }

        public IViewComponentResult Invoke(int tipo)
        {
            // Obtém os nomes do controller e action atuais
            string controllerName = ViewContext.RouteData.Values["controller"]?.ToString() ?? string.Empty;
            string actionName = ViewContext.RouteData.Values["action"]?.ToString() ?? string.Empty;
            string viewPath;

            // Define o caminho da view com base no tipo
            switch (tipo)
            {
                case 1:
                    viewPath = "/Views/Shared/Components/Webpack/Index.cshtml";
                    break;
                case 2:
                    viewPath = $"/Views/Shared/Components/Webpack/{controllerName}/Index.cshtml";
                    break;
                case 3:
                    viewPath = $"/Views/Shared/Components/Webpack/{controllerName}/{actionName}/Index.cshtml";
                    break;
                default:
                    return Content("Tipo inválido.");
            }

            // Verifica se a view existe
            var viewResult = _viewEngine.GetView(null, viewPath, false);

            if (!viewResult.Success)
            {
                // Retorna um conteúdo vazio se a view não for encontrada
                return Content("");
            }

            // Retorna a view encontrada
            return View(viewPath);
        }
    }
}