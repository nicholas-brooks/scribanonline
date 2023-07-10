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
            return Generate((object?) JsonConvert.DeserializeObject<ExpandoObject>(model) ?? new {}, template);
        }

        private string Generate(object model, string template)
        {
            logger.LogDebug("Generating for {template} using {@model}", template, model);
            try
            {
                return ScribanUtils.Render(template, new {model});
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error generating {template} using {@model}", template, model);
                throw;
            }
        }
    }
}