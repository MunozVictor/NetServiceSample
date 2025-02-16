namespace WineCorp.Dom
{
    public interface IParcelsRepository
    {
        Task<Dictionary<string, float>> GetTotalParcelAreaByGrapeAsync();
        Task<Dictionary<string, float>> GetTotalParcelAreaByManagerAsync();
        Task<Dictionary<string, List<string>>> GetParcelVineyardsNamesWithManagersAsync();
    }
}
