using WebFlix.Models;
using static WebFlix.Models.MovieCatalogue;

namespace WebFlixClient
{
    public class Program
    {
        static void Main()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5041/");

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            GetAllMovies(client).Wait();
            
            MovieCatalogue entry = new MovieCatalogue() { MovieId = 5, Title = "Batman", Genre = Genres.action, Certification = Certifications._15, Rating = 9, ReleaseDate = "2022" };

           

        }
        //test comment
        private static async Task GetAllMovies(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("api/Movie");
            if (response.IsSuccessStatusCode)
            {

                var allMovies = await response.Content.ReadAsAsync<IEnumerable<MovieCatalogue>>();
                foreach (var movieCatalogue in allMovies)
                {
                    Console.WriteLine(movieCatalogue);
                }


            }
        }




        
    }
        
    }
