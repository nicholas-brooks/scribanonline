using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using scribanonline.Models;

namespace scribanonline.Controllers
{
    [ApiController]
    public class GenerateController(ILogger<GenerateController> logger) : ControllerBase
    {
        [Route("/generate")]
        [HttpPost]
        public ActionResult<GenerateOutput> Post(GenerateInput model)
        {
            return new GenerateOutput
            {
                Output = Generate(model.Model, model.Template)
            };
        }

        private string Generate(string model, string template)
        {
            return Generate((object?)JsonSerializer.Deserialize<JsonElement>(model) ?? new {}, template);
        }

        private string Generate(object model, string template)
        {
            try
            {
                return ScribanUtils.Render(template, new {model});
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error generating {Template} using {@Model}", template, model);
                throw;
            }
        }
    }
}