using Microsoft.AspNetCore.Mvc;
using PokemonCatcher.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json; // Import this namespace for ReadFromJsonAsync

namespace PokemonCatcher.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public PokemonController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Call the PokeAPI to get a list of all Pokemon
                string baseUrl = "https://pokeapi.co/api/v2/pokemon?limit=1000"; // Increase limit for all Pokemon
                var client = _clientFactory.CreateClient();

                HttpResponseMessage response = await client.GetAsync(baseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var pokemonListResponse = await response.Content.ReadFromJsonAsync<PokemonListResponse>();
                    return View(pokemonListResponse.Results);
                }
                else
                {
                    // Handle unsuccessful response for Pokemon list request
                    ModelState.AddModelError("", "Failed to fetch Pokemon list from PokeAPI");
                }
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that might occur
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
            }

            return View();
        }

        public async Task<IActionResult> Details(string name)
        {
            try
            {
                // Call the PokeAPI to get details for the specific Pokemon
                string pokemonUrl = $"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}";
                var client = _clientFactory.CreateClient();

                HttpResponseMessage response = await client.GetAsync(pokemonUrl);

                if (response.IsSuccessStatusCode)
                {
                    var pokemon = await response.Content.ReadFromJsonAsync<Pokemon>();
                    return View(pokemon);
                }
                else
                {
                    // Handle unsuccessful response for Pokemon details request
                    ModelState.AddModelError("", $"Failed to fetch details for Pokemon {name}");
                }
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that might occur
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
            }

            return RedirectToAction("Index");
        }
    }
}
