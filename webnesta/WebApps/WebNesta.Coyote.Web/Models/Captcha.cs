namespace WebNesta.Coyote.Web.Models
{
    public class Captcha
    {
        public Captcha(string characterSet, int codeLength)
        {
            CharacterSet = characterSet;
            CodeLength = codeLength;
        }
    
        public string CharacterSet { get; set; } //= ;
        public int CodeLength { get; set; }// = 5;

    }
}
