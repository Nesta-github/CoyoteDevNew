namespace WebNesta.Coyote.Geral.Domain.ViewModel
{
    public class ValidateViewModel
    {
        public ValidateViewModel(bool isValid, string message) { IsValid = IsValid; Message = message; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
