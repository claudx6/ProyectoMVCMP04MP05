using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProgramaProyecto.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProgramaProyecto.Controllers
{
    public class EpisodeController : Controller
    {
        private readonly HttpClient _httpClient;

        public EpisodeController()
        {
            _httpClient = new HttpClient();
        }

// nos conectamos a la API
        public IActionResult Index()
        {
            const string apiUrl = "https://rickandmortyapi.com/api/episode";
            var client = new HttpClient();
            var response = client.GetAsync(apiUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            var data = JsonConvert.DeserializeObject<EpisodeRoot>(content);
            
            // se muestran todos los episodios que aparecen en la API
            var episodes = data.Results;

            return View(episodes);
        }
    }
}
