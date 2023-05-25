using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProgramaProyecto.Models;
using Newtonsoft.Json;

namespace ProgramaProyecto.Controllers;

    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController()
        {
            _httpClient = new HttpClient();
        }

// nos conectamos a la API
    public IActionResult Index()
    {

    const string apiUrl = "https://rickandmortyapi.com/api/character";
    var client = new HttpClient();
    var response = client.GetAsync(apiUrl).Result;
    var content = response.Content.ReadAsStringAsync().Result;
    
    var data = JsonConvert.DeserializeObject<Root>(content);
    
    // para mostrar 9 personajes
    var personajes = new List<Result>();
    int contador = 0;
    foreach (var personaje in data.results)
    {
        personajes.Add(personaje);
        contador++;
        if (contador == 9)
        {
            break;
        }
    }

    return View(personajes);
    }

}   
