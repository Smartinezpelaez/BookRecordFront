using BookRecord.WEB.DTOs;
using BookRecord.WEB.Models;
using Newtonsoft.Json;

namespace BookRecord.WEB.Services;

public class LibrosServices
{
    private readonly HttpClient httpClient;

    public LibrosServices(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<LibroDTO>> GetBook()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://localhost:7010/api/Libro/GetAll");
        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine(json);
        var libroResponse = JsonConvert.DeserializeObject<LibroResponseDTO>(json);
        return libroResponse.data;
    }

    public async Task<LibroDTO> InsertBook(LibroDTO libro)
    {
        var libroJson = JsonConvert.SerializeObject(libro);
        var content = new StringContent(libroJson, System.Text.Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("https://localhost:7010/api/Libro/InsertAsync", content);

        if (response.IsSuccessStatusCode)
        {
            // Si la respuesta es exitosa, obtenemos el contenido y lo deserializamos a una lista de prestamos.
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var libroResponse = JsonConvert.DeserializeObject<LibroDTO>(jsonResponse);
            return libroResponse ;
            
        }
        else
        {
            throw new Exception($"Error en la llamada HTTP: {response.StatusCode} - {response.ReasonPhrase}");
        }
    }

}

