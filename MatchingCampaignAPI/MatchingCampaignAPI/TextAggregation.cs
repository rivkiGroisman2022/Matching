namespace MatchingCampaignAPI
{
    public class TextAggregation : IAggregations
    {
        const string MyPath = "DataAggregation.txt";
        public void Aggregate(string text)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(MyPath, true))
                {
                    writer.WriteLineAsync(text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
