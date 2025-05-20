using System.Collections.Generic;
using System.Net.Mail;

namespace GMT_Sfe
{
  public class Correo
  {
    public string Usuario { get; set; }

    public string Contrasena { get; set; }

    public string Email { get; set; }

    public string Servidor { get; set; }

    public List<string> LstEnviarA { get; set; }

    public List<string> LstCopiarA { get; set; }

    public List<Attachment> LstAdjuntos { get; set; }

    public string Asunto { get; set; }

    public string Mensaje { get; set; }
  }
}
