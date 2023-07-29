namespace MatchingCampaignAPI
{
    public abstract  class Aggregations : IAggregations
    {
        //static Aggregations aggregations;
        public abstract void Aggregate(string text);
    }

}
