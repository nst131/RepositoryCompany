using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MariGold.OpenXHTML;
using UI.BaseModels;
using UI.Models.EmployeeUI.Dto;

namespace UI.Controllers
{
    [Route("[controller]")]
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment environment;

        public FileController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<byte[]> GetBytesListOfEmployee([FromBody] ICollection<ResponseGetEmployeeDtoUI> model)
        {
            var pathDocx = Path.Combine(this.environment.ContentRootPath, nameof(File) + FileExtensions.docx);

            if (System.IO.File.Exists(pathDocx))
                System.IO.File.Delete(pathDocx);

            var pathHtml = Path.Combine(Directory.GetCurrentDirectory(), nameof(File) + FileExtensions.html);

            if (System.IO.File.Exists(pathHtml))
                System.IO.File.Delete(pathHtml);

            await using (var file = new FileStream(pathHtml, FileMode.OpenOrCreate))
            {
                await using (var writer = new StreamWriter(file, Encoding.UTF8))
                {
                    await writer.WriteAsync(await this.RenderViewAsync<ICollection<ResponseGetEmployeeDtoUI>>("GetEmployess", model));
                }
            }

            using (var reader = new StreamReader(pathHtml))
            {
                var text = await reader.ReadToEndAsync();

                using (var stream = new MemoryStream())
                {
                    var doc = new WordDocument(stream);
                    doc.Process(new HtmlParser(text));
                    doc.Save();

                    return stream.ToArray();
                }
            }
        }
    }

    public static class ControllerExtensions
    {
        public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.ActionDescriptor.ActionName;
            }

            controller.ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;

                if (viewEngine is null)
                    throw new NullReferenceException("ViewEngine is not find");

                var viewResult = viewEngine.FindView(controller.ControllerContext, viewName, !partial);

                if (!viewResult.Success)
                    throw new ArgumentException("Cann't convert View to Html");


                var viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }
    }
}
