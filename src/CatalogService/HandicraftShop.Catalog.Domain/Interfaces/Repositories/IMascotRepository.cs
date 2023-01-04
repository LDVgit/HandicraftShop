namespace HandicraftShop.Catalog.Domain.Interfaces.Entities;

using Domain.Entities;

/// <summary>
/// Mascot data access - repository
/// </summary>
public interface IMascotRepository
{
    /// <summary>
    /// Get All Mascots
    /// </summary>
    /// <param name="ct">Cancellation Token</param>
    /// <returns> Mascots collection </returns>
    IEnumerable<Mascot> GetAllAsync();
}