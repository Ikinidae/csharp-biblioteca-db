public class Documento
{
    //properties
    public string Titolo { get; set; }
    public string Anno { get; set; }
    public string Settore { get; set; }
    public bool Stato { get; set; }
    public int Scaffale { get; set; }
    public string Autore { get; set; }
    public string Codice { get; set; }
    public int Durata { get; set; }
    public int Pagine { get; set; }
    public string Tipo { get; set; }

    //costruttore
    public Documento(string titolo, string anno, string settore, bool stato, int scaffale, string autore, string codice, int durata, int pagine, string tipo)
    {
        Titolo = titolo;
        Anno = anno;
        Settore = settore;
        Stato = stato;
        Scaffale = scaffale;
        Autore = autore;
        Codice = codice;
        Durata = durata;
        Pagine = pagine;
        Tipo = tipo;
    }
}