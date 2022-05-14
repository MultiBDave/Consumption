using Consumption_Meter.Model;

namespace Consumption_Meter.Data.Interface
{
    public interface IElementData
    {
        Task<List<Modul>> GetModuls();
        Task<List<Modul>> GetDefaultModuls();
        Task<List<Modul>> GetNonDefaultModuls();
        Task InsertModul(Modul modul);
        Task UpdateModul(Modul modul);
        Task DeleteModul(Modul modul);
        Task<Modul> GetModulById(Modul modul);
    }
}