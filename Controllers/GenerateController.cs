using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using scribanonline.Models;

namespace scribanonline.Controllers
{
    [ApiController]
    public class GenerateController : ControllerBase
    {
        private readonly ILogger<GenerateController> logger;

        public GenerateController(ILogger<GenerateController> logger)
        {
            this.logger = logger;
        }

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
            return Generate(JsonConvert.DeserializeObject<ExpandoObject>(model), template);
        }

        private string Generate(object model, string template)
        {
            logger.LogInformation("Generating for {template} using {model}", template, model);
            return ScribanUtils.Render(template, new { model });
        }
    }
}