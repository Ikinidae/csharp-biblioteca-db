using System.Data.SqlClient;

string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";

SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione);


try
{
    connessioneSql.Open();
    

    

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

public void Prestito()
{
    Console.WriteLine("Vuoi cercare un libro o un dvd? [libro/dvd] ");
    string userInput = Console.ReadLine();

    if (userInput == "libro")
    {
        Console.WriteLine("Scrivi il codice o il titolo del libro da cercare: ");
        string userInputLibro = Console.ReadLine();

        foreach (Libro libro in Libri)
        {
            if (userInputLibro == libro.Titolo || userInputLibro == libro.Isbn)
            {
                if (libro.Stato == true)
                {
                    Console.WriteLine("il libro ricercato è disponibile");
                    EffettuaPrestito(userInputLibro);
                    break;
                }
                else
                {
                    Console.WriteLine("il libro non è disponibile");
                }
            }
        }

    }
    else if (userInput == "dvd")
    {
        Console.WriteLine("Scrivi il codice o il titolo del dvd da cercare: ");
        string userInputDvd = Console.ReadLine();

        foreach (Dvd dvd in Dvd)
        {
            if (userInputDvd == dvd.Titolo || userInputDvd == dvd.Codice)
            {
                if (dvd.Stato == true)
                {
                    Console.WriteLine("il dvd ricercato è disponibile");
                    EffettuaPrestito(userInputDvd);
                    break;
                }
                else
                {
                    Console.WriteLine("il dvd ricercato non è disponibile");
                }
            }
        }
    }
    else
    {
        Console.WriteLine("inserisci un valore corretto");
        Prestito();
    }
}


public class crud
{
    public void creaPrestito (string nome_utente, string data_inizio, string data_fine, int documento_id, SqlConnection connessioneSql)
    {
        string insertQuery = "INSERT INTO prestiti (codice_prestito, nome_utente, data_inizio, data_fine, documento_id)" +
        "VALUES (@codice_prestito, @nome_utente, @data_inizio, @data_fine, @documento_id)";

        SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);

        Random rnd = new Random();
        insertCommand.Parameters.Add(new SqlParameter("@codice_prestito", rnd.Next(0,1001)));
        insertCommand.Parameters.Add(new SqlParameter("@nome_utente", nome_utente));
        insertCommand.Parameters.Add(new SqlParameter("@data_inizio", data_inizio));
        insertCommand.Parameters.Add(new SqlParameter("@data_fine", data_fine));
        insertCommand.Parameters.Add(new SqlParameter("@documento_id", documento_id));

        int insertRows = insertCommand.ExecuteNonQuery();
    }
}

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