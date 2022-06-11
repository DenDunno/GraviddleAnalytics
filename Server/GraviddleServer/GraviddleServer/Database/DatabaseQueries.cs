using System.Globalization;

public class DatabaseQueries
{
    public string InsertCommand(DataForAnalytics dataForAnalytics)
    {
        return $@"INSERT INTO Analytics VALUES ('{dataForAnalytics.DeviceId}', 
                                                '{dataForAnalytics.Name}', 
                                                {dataForAnalytics.Age}, 
                                                {dataForAnalytics.Level}, 
                                                {dataForAnalytics.TimeForLevel.ToString(CultureInfo.InvariantCulture)}, 
                                                1, 
                                                {dataForAnalytics.Stars});";
    }

    public string GetRecord(DataForAnalytics dataForAnalytics)
    {
        return $@"SELECT * FROM Analytics WHERE DeviceId = '{dataForAnalytics.DeviceId}' AND
                                                LevelId = {dataForAnalytics.Level} AND
                                                Stars = {dataForAnalytics.Stars};";
    }

    public string UpdateRecord(DataForAnalytics dataForAnalytics, int attempts)
    {
        return $@"UPDATE Analytics SET TimeForLevelSum = {dataForAnalytics.TimeForLevel.ToString(CultureInfo.InvariantCulture)}, Attempts = {attempts} 
                                   WHERE DeviceId = '{dataForAnalytics.DeviceId}' AND
                                         LevelId = {dataForAnalytics.Level} AND
                                         Stars = {dataForAnalytics.Stars};";
    }
}