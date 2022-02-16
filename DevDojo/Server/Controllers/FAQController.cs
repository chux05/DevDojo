using DevDojo.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDojo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FAQController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Coronaviruses are a large family of viruses which may cause illness in animals or humans. In humans, several coronaviruses are known to cause respiratory infections ranging from the common cold to more severe diseases such as Middle East Respiratory Syndrome (MERS) and Severe Acute Respiratory Syndrome (SARS). The most recently discovered coronavirus causes coronavirus disease COVID-19",""
            , "COVID-19 is the infectious disease caused by the most recently discovered coronavirus. This new virus and disease were unknown before the outbreak began in Wuhan, China, in December 2019. COVID-19 is now a pandemic affecting many countries globally.",
            "The most common symptoms of COVID-19 are fever, dry cough, and tiredness. Other symptoms that are less common and may affect some patients include aches and pains, nasal congestion, headache, conjunctivitis, sore throat, diarrhoea, loss of taste or smell or a rash on skin or discoloration of fingers or toes. These symptoms are usually mild and begin gradually. Some people become infected but only have very mild symptoms.",
        };

        private static readonly string[] Questions = new[]
        {
            "What is a coronavirus?", "What is COVID-19?", "What are the symptoms of COVID-19?", "What should I do if I have COVID-19 symptoms and when should I seek medical care?"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public FAQController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<FAQ> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 8).Select(index => new FAQ
            {
                Question = Questions[rng.Next(Questions.Length)],
                Answer = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();
        }
    }
}
