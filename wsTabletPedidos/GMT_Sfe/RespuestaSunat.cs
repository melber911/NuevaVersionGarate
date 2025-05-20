namespace GMT_Sfe
{
  public class RespuestaSunat
  {
    public string Codigo { get; set; }

    public string Mensaje { get; set; }

    public string Ticket { get; set; }

    public string DigestValue { get; set; }

    public string SignatureValue { get; set; }

    public string RutaXML { get; set; }

    public string RutaCDR { get; set; }

    public string RutaPDF { get; set; }

    public Estado Estado { get; set; }
  }
}
