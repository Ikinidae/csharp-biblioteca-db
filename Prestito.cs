public class Prestito
{
    public string Nome { get; set; }
    public string NomeUtente { get; set; }
    public string InizioPrestito { get; set; }
    public string FinePrestito { get; set; }
    public int Documento_Id { get; set; }

    public Prestito(string nome, string nomeUtente, string inizioPrestito, string finePrestito, int documento_Id)
    {
        Nome = nome;
        NomeUtente = nomeUtente;
        InizioPrestito = inizioPrestito;
        FinePrestito = finePrestito;
        Documento_Id = documento_Id;
    }
}