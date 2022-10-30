using SimpleHttp;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CTEDSDigitalMenu.Controllers
{
    public class HttpServerController
    {
        private readonly MenuController menuController;

        public HttpServerController(MenuController menuController)
        {
            this.menuController = menuController;
            Route.Add("/", (req, res, props) =>
            {
                res.AsText(RenderEntries());
            });

            Route.Add("/entradas", (req, res, props) =>
            {
                res.AsText(RenderEntries());
            });

            Route.Add("/principal", (req, res, props) =>
            {
                res.AsText(RenderMain());
            });

            Route.Add("/sobremesas", (req, res, props) =>
            {
                res.AsText(RenderDesserts());
            });

            Route.Add("/bebidas", (req, res, props) =>
            {
                res.AsText(RenderDrinks());
            });

            Route.Add("/Assets/{file}", (rq, rp, args) =>
            {
                string filepath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string newPath = Path.GetFullPath(Path.Combine(filepath, @"..\..\..\Assets\" + args["file"]));
                rp.ContentType = "image/" + args["file"].Split(".")[1];
                rp.AsFile(rq, newPath);
            });

            Task.Run(() =>
            {
                HttpServer.ListenAsync(
                    2035,
                    CancellationToken.None,
                    Route.OnHttpRequestAsync
                ).Wait();
            });
        }

        private string RenderEntries()
        {
            string htmlResponse = "<ul class=\"nav nav-pills nav-fill\" style=\"margin: 3px;\">" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link active\" href=\"\\entradas\">Entradas</a>" +
                    "</li>" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link\" href=\"\\principal\">Prato principal</a>" +
                    "</li>" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link\" href=\"\\sobremesas\">Sobremesas</a>" +
                    "</li>" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link\" href=\"\\bebidas\">Bebidas</a>" +
                    "</li>" +
                "</ul>";
            foreach (Models.MenuItem Item in menuController.GetMenuItemsPerType("Entrada"))
            {
                htmlResponse += "<div class=\"card\" style=\"margin: 4px;\">" +
                    $"<div class=\"card-header\" style=\"text-align: center;\">{WebUtility.HtmlEncode(Item.Name)}</div>" +
                    "<div class=\"card-body\" style=\"display: flex; align-items: center;\">" +
                        $"<img src=\"{Item.PhotoPath}\" style=\"width: 40%; max-height: 400px;\">" +
                        $"<div style=\"margin: 0 auto; text-align: center; justify-content: center;\">{WebUtility.HtmlEncode(Item.Description)}</div>" +
                    "</div>" +
                    "<div class=\"card-footer\" style=\"text-align: center\">" +
                        $"R$ {Item.Price}" +
                    "</div>" +
                "</div>";
            }
            return AddHTMLHeadAndFooter(htmlResponse);
        }
        private string RenderMain()
        {
            string htmlResponse = "<ul class=\"nav nav-pills nav-fill\" style=\"margin: 3px;\">" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link\" href=\"\\entradas\">Entradas</a>" +
                    "</li>" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link active\" href=\"\\principal\">Prato principal</a>" +
                    "</li>" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link\" href=\"\\sobremesas\">Sobremesas</a>" +
                    "</li>" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link\" href=\"\\bebidas\">Bebidas</a>" +
                    "</li>" +
                "</ul>";
            foreach (Models.MenuItem Item in menuController.GetMenuItemsPerType("Principal"))
            {
                htmlResponse += "<div class=\"card\" style=\"margin: 4px;\">" +
                    $"<div class=\"card-header\" style=\"text-align: center;\">{WebUtility.HtmlEncode(Item.Name)}</div>" +
                    "<div class=\"card-body\" style=\"display: flex; align-items: center;\">" +
                        $"<img src=\"{Item.PhotoPath}\" style=\"width: 40%; max-height: 400px;\">" +
                        $"<div style=\"margin: 0 auto; text-align: center; justify-content: center;\">{WebUtility.HtmlEncode(Item.Description)}</div>" +
                    "</div>" +
                    "<div class=\"card-footer\" style=\"text-align: center\">" +
                        $"R$ {Item.Price}" +
                    "</div>" +
                "</div>";
            }
            return AddHTMLHeadAndFooter(htmlResponse);
        }
        private string RenderDesserts()
        {
            string htmlResponse = "<ul class=\"nav nav-pills nav-fill\" style=\"margin: 3px;\">" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link\" href=\"\\entradas\">Entradas</a>" +
                    "</li>" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link\" href=\"\\principal\">Prato principal</a>" +
                    "</li>" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link active\" href=\"\\sobremesas\">Sobremesas</a>" +
                    "</li>" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link\" href=\"\\bebidas\">Bebidas</a>" +
                    "</li>" +
                "</ul>";
            foreach (Models.MenuItem Item in menuController.GetMenuItemsPerType("Sobremesa"))
            {
                htmlResponse += "<div class=\"card\" style=\"margin: 4px;\">" +
                    $"<div class=\"card-header\" style=\"text-align: center;\">{WebUtility.HtmlEncode(Item.Name)}</div>" +
                    "<div class=\"card-body\" style=\"display: flex; align-items: center;\">" +
                        $"<img src=\"{Item.PhotoPath}\" style=\"width: 40%; max-height: 400px;\">" +
                        $"<div style=\"margin: 0 auto; text-align: center; justify-content: center;\">{WebUtility.HtmlEncode(Item.Description)}</div>" +
                    "</div>" +
                    "<div class=\"card-footer\" style=\"text-align: center\">" +
                        $"R$ {Item.Price}" +
                    "</div>" +
                "</div>";
            }
            return AddHTMLHeadAndFooter(htmlResponse);
        }
        private string RenderDrinks()
        {
            string htmlResponse = "<ul class=\"nav nav-pills nav-fill\" style=\"margin: 3px;\">" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link\" href=\"\\entradas\">Entradas</a>" +
                    "</li>" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link\" href=\"\\principal\">Prato principal</a>" +
                    "</li>" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link\" href=\"\\sobremesas\">Sobremesas</a>" +
                    "</li>" +
                    "<li class=\"nav-item\">" +
                        "<a class=\"nav-link active\" href=\"\\bebidas\">Bebidas</a>" +
                    "</li>" +
                "</ul>";
            foreach (Models.MenuItem Item in menuController.GetMenuItemsPerType("Bebida"))
            {
                htmlResponse += "<div class=\"card\" style=\"margin: 4px;\">" +
                    $"<div class=\"card-header\" style=\"text-align: center;\">{WebUtility.HtmlEncode(Item.Name)}</div>" +
                    "<div class=\"card-body\" style=\"display: flex; align-items: center;\">" +
                        $"<img src=\"{Item.PhotoPath}\" style=\"width: 40%; max-height: 400px;\">" +
                        $"<div style=\"margin: 0 auto; text-align: center; justify-content: center;\">{WebUtility.HtmlEncode(Item.Description)}</div>" +
                    "</div>" +
                    "<div class=\"card-footer\" style=\"text-align: center\">" +
                        $"R$ {Item.Price}" +
                    "</div>" +
                "</div>";
            }
            return AddHTMLHeadAndFooter(htmlResponse);
        }

        private string AddHTMLHeadAndFooter(string HTMLbody)
        {
            string htmlResponse = "<!DOCTYPE html>" +
                "<html><head>" +
                "<title>CTEDS Menu Digital</title>" +
                "<meta name=\"viewport\" content=\"width=device-width, height=device-height, initial-scale=1, shrink-to-fit=no\">\r\n\t<meta http-equiv=\"Content-Type\" content=\"text/html\" charset=\"utf-8\">\r\n\t<meta http-equiv=\"Content-Language\" content=\"pt-br\">" +
                "<link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC\" crossorigin=\"anonymous\">" +
                "<script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js\" integrity=\"sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF\" crossorigin=\"anonymous\"></script>" +
                "</head><body>";

            htmlResponse += HTMLbody;

            htmlResponse += "</body></html>";

            return htmlResponse;
        }
    }
}
