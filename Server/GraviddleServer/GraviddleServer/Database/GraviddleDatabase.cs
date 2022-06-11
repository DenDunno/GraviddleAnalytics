using System.Data;
using System.Data.SqlClient;

public class GraviddleDatabase
{
    private readonly SqlConnection _sqlConnection = new(@"Data Source=DENISBONDAR\SQLEXPRESS01;Initial Catalog=GraviddleAnalytics; Integrated Security=True");
    private readonly DatabaseQueries _databaseQueries = new();

    public void Open()
    {
        _sqlConnection.Open();
    }

    public void Insert(DataForAnalytics dataForAnalytics)
    {
        GetCommand(_databaseQueries.InsertCommand(dataForAnalytics)).ExecuteNonQuery();
    }

    public bool RecordExists(DataForAnalytics dataForAnalytics)
    {
        return  GetCommand(_databaseQueries.GetRecord(dataForAnalytics)).ExecuteScalar() != null;
    }

    public void UpdateTime(DataForAnalytics dataForAnalytics)
    {
        SqlDataReader reader = GetCommand(_databaseQueries.GetRecord(dataForAnalytics)).ExecuteReader()!;
        reader.Read();
        
        int attempts = (int)reader["Attempts"] + 1;
        dataForAnalytics.TimeForLevel += Convert.ToSingle(reader["TimeForLevelSum"]);
        reader.Close();

        string a = _databaseQueries.UpdateRecord(dataForAnalytics, attempts);
        
        GetCommand(a).ExecuteNonQuery();
    }

    private SqlCommand GetCommand(string query)
    {
        return new SqlCommand(query, _sqlConnection);
    }
}