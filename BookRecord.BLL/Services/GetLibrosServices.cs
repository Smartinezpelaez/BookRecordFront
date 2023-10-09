using BookRecord.BLL.DTOs;
using Newtonsoft.Json;

namespace BookRecord.BLL.Services;

public class GetLibrosServices
{
    private readonly HttpClient httpClient;

    public GetLibrosServices(HttpClient httpClient)
    {
        httpClient = new HttpClient();
    }

    public async Task<List<LibroDTO>> GetLibro()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("http://localhost/BookRecordAPI/api/Autor/GetAll");
        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine(json);
        var libroResponse = JsonConvert.DeserializeObject<LibroResponseDTO>(json);
        return libroResponse.LibroDTOs;

    }
}
