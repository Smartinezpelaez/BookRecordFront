using BookRecord.WEB.DTOs;
using BookRecord.WEB.Models;
using Newtonsoft.Json;
using System.Data.Common;

namespace BookRecord.WEB.Services;

public class AutoresService
{
    private readonly HttpClient httpClient;
    private readonly BookRecordContext context;

    public AutoresService(HttpClient httpClient, BookRecordContext context)
    {
        this.httpClient = httpClient;
        this.context = context;
    }

    

    /// <summary>
    /// Metodo para obtener todos los Autores
    /// </summary>
    /// <returns></returns>
    public async Task<List<AutorDTO>> GetAuthors()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://localhost:7010/api/Autor/GetAll");
        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine(json);
        var autorResponse = JsonConvert.DeserializeObject<AutorResponseDTO>(json);
        return autorResponse.data;
    }

    /// <summary>
    /// Creamos un nuevo autor 
    /// </summary>
    /// <param name="autor"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<AutorDTO> InsertAuthor(AutorDTO autor)
    {
        var autorJson = JsonConvert.SerializeObject(autor);
        var content = new StringContent(autorJson, System.Text.Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("https://localhost:7010/api/Autor/InsertAsync", content);

        if (response.IsSuccessStatusCode)
        {
            // Si la respuesta es exitosa, obtenemos el contenido y lo deserializamos a una lista de prestamos.
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var autorResponse = JsonConvert.DeserializeObject<AutorDTO>(jsonResponse);
            return autorResponse;

        }
        else
        {
            throw new Exception($"Error en la llamada HTTP: {response.StatusCode} - {response.ReasonPhrase}");
        }
    }

    /// <summary>
    /// Actualiza un usuario
    /// </summary>
    /// <param name="authorId"></param>
    /// <param name="autor"></param>
    /// <returns></returns>
    public async Task<AutorDTO> UpdateAuthor(int authorId, AutorDTO autor)
    {
        var autorJson = JsonConvert.SerializeObject(autor);
        var content = new StringContent(autorJson, System.Text.Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync($"https://localhost:7010/api/Autor/Update/{authorId}", content);

        return await HandleResponse<AutorDTO>(response);
    }

    /// <summary>
    /// Elimina el usuario
    /// </summary>
    /// <param name="authorId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<bool> DeleteAuthor(int authorId)
    {
        var response = await httpClient.DeleteAsync($"https://localhost:7010/api/Autor/DeleteAsync/{authorId}");

        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            throw new Exception($"Error en la llamada HTTP: {response.StatusCode} - {response.ReasonPhrase}");
        }
    }

    public async Task<AutorDTO> GetAuthorById(int authorId)
    {
        var response = await httpClient.GetAsync($"https://localhost:7010/api/Autor/GetById/{authorId}");

        return await HandleResponse<AutorDTO>(response);
    }

    private async Task<T> HandleResponse<T>(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResponse);
            return result;
        }
        else
        {
            throw new Exception($"Error en la llamada HTTP: {response.StatusCode} - {response.ReasonPhrase}");
        }
    }
}
