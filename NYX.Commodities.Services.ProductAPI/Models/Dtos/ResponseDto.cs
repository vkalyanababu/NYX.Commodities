namespace NYX.Commodities.Services.ProductAPI.Models.Dtos
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSucess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
