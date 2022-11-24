namespace WebNesta.Coyote.Geral.Domain.ViewModel
{
    public class ValidateViewModel
    {
        public ValidateViewModel(bool isValid, string message) { IsValid = isValid; Message = message; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
