namespace BookRecord.WEB.Endpoints;

public class ApiEndpoints
{
    public static class Libro
    {
        public static string BaseUrl { get; } = "http://localhost/BookRecordAPI/api/Libro/";
        public static string GetAll { get; } = "GetAll";
        public static string InsertAsync { get; } = "InsertAsync";
    }

    public static class Autor
    {
        public static string BaseUrl { get; } = "http://localhost/BookRecordAPI/api/Autor/";
        public static string GetAll { get; } = "GetAll";
        public static string InsertAsync { get; } = "InsertAsync";
        public static string Update { get; } = "Update";
        public static string DeleteAsync { get; } = "DeleteAsync";
        public static string GetById { get; } = "GetById";
    }
}
