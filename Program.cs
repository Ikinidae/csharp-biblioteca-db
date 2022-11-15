using System.Data;
using System.Data.SqlClient;

string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";

SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione);


try
{
    connessioneSql.Open();

    crud.ricercaPrestito("pippo", connessioneSql);

    Console.WriteLine("Scrivi il titolo del documento da cercare: ");
    string userInputDocumento = Console.ReadLine();

    int documento_id = crud.ricercaDocumento(userInputDocumento, connessioneSql);

    Console.WriteLine("Vuoi prenotare il documento? [si/no]");
    string userInput = Console.ReadLine();

    if (userInput == "si")
    {
        Console.WriteLine("Inserire nome utente");
        string userNome = Console.ReadLine();
        Console.WriteLine("Inserire data inizio prestito");
        string dataInizio = Console.ReadLine();
        Console.WriteLine("Inserire data fine prestito");
        string dataFine = Console.ReadLine();
        crud.creaPrestito(userNome, dataInizio, dataFine, documento_id, connessioneSql);
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);

}
finally
{
    connessioneSql.Close();
}

return;

//INSERT
//string insertQuery = "INSERT INTO documenti (titolo, anno, codice, settore, scaffale, stato, autore, tipo_documento, pagine, durata)" +
//    "VALUES (@titolo, @anno, @codice, @settore, @scaffale, @stato, @autore, @tipo_documento, @pagine, @durata)";

//SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);

//insertCommand.Parameters.Add(new SqlParameter("@titolo", "La solitudine dei numeri primi"));
//insertCommand.Parameters.Add(new SqlParameter("@anno", "2008"));
//insertCommand.Parameters.Add(new SqlParameter("@codice", 9788804577027));
//insertCommand.Parameters.Add(new SqlParameter("@settore", "Romanzo"));
//insertCommand.Parameters.Add(new SqlParameter("@scaffale", 126));
//insertCommand.Parameters.Add(new SqlParameter("@stato", 1));
//insertCommand.Parameters.Add(new SqlParameter("@autore", "Paolo Giordano"));
//insertCommand.Parameters.Add(new SqlParameter("@tipo_documento", "libro"));
//insertCommand.Parameters.Add(new SqlParameter("@pagine", 304));
//insertCommand.Parameters.Add(new SqlParameter("@durata", 120));

//Documento libro1 = new Documento("Il silenzio degli innocenti", "1932", "Thriller", false, 24, "Paolo Giordano", "2350192573246", 334, 0, "libro");

//insertCommand.Parameters.Add(new SqlParameter("@titolo", libro1.Titolo));
//insertCommand.Parameters.Add(new SqlParameter("@anno", libro1.Anno));
//insertCommand.Parameters.Add(new SqlParameter("@codice", libro1.Codice));
//insertCommand.Parameters.Add(new SqlParameter("@settore", libro1.Settore));
//insertCommand.Parameters.Add(new SqlParameter("@scaffale", libro1.Scaffale));
//insertCommand.Parameters.Add(new SqlParameter("@stato", libro1.Stato));
//insertCommand.Parameters.Add(new SqlParameter("@autore", libro1.Autore));
//insertCommand.Parameters.Add(new SqlParameter("@tipo_documento", libro1.Tipo));
//insertCommand.Parameters.Add(new SqlParameter("@pagine", libro1.Pagine));
//insertCommand.Parameters.Add(new SqlParameter("@durata", libro1.Durata));


//int affectedRows = insertCommand.ExecuteNonQuery();

//UPDATE
//string updateQuery = "UPDATE documenti SET scaffale=@scaffale WHERE id=@id;";

//SqlCommand updateCommand = new SqlCommand(updateQuery, connessioneSql);

//updateCommand.Parameters.Add(new SqlParameter("@scaffale", 26));
//updateCommand.Parameters.Add(new SqlParameter("@id", 2));

//int updateRows = updateCommand.ExecuteNonQuery();

//DELETE
//string deleteQuery = "DELETE documenti WHERE id=@id;";
//SqlCommand deleteCommand = new SqlCommand(deleteQuery, connessioneSql);
//deleteCommand.Parameters.Add(new SqlParameter("@id", 1));
//int updateRows = deleteCommand.ExecuteNonQuery();