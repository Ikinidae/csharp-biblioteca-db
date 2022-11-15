using System.Data.SqlClient;

string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";

SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione);


try
{
    connessioneSql.Open();
    string insertQuery = "INSERT INTO documenti (titolo, anno, codice, settore, scaffale, stato, autore, tipo_documento, pagine, durata)" +
        "VALUES (@titolo, @anno, @codice, @settore, @scaffale, @stato, @autore, @tipo_documento, @pagine, @durata)";

    SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);

    insertCommand.Parameters.Add(new SqlParameter("@titolo", "La solitudine dei numeri primi"));
    insertCommand.Parameters.Add(new SqlParameter("@anno", "2008"));
    insertCommand.Parameters.Add(new SqlParameter("@codice", 9788804577027));
    insertCommand.Parameters.Add(new SqlParameter("@settore", "Romanzo"));
    insertCommand.Parameters.Add(new SqlParameter("@scaffale", 126));
    insertCommand.Parameters.Add(new SqlParameter("@stato", 1));
    insertCommand.Parameters.Add(new SqlParameter("@autore", "Paolo Giordano"));
    insertCommand.Parameters.Add(new SqlParameter("@tipo_documento", "libro"));
    insertCommand.Parameters.Add(new SqlParameter("@pagine", 304));
    insertCommand.Parameters.Add(new SqlParameter("@durata", 120));

    int affectedRows = insertCommand.ExecuteNonQuery();

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