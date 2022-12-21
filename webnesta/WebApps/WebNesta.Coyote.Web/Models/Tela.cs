using System.ComponentModel;

namespace WebNesta.Coyote.Web.Models
{
    public enum ObjectLabel
    {
        //FRM - FORM 
        //BTN - BOTAO
        //CHK - CHECKBOX
        //EDT - EDIÇÃO

        [Description("frmLogin")]
        Login = 0,
        [Description("Documento")]
        Documento = 1,
        [Description("Home")]
        Home = 2, 
        [Description("Componente")]
        Componente = 3,
    } 
    
    public enum ControllerTutorialName
    {
        //FRM - FORM 
        //BTN - BOTAO
        //CHK - CHECKBOX
        //EDT - EDIÇÃO

        [Description("Login")]
        Login = 0,
    }
}
