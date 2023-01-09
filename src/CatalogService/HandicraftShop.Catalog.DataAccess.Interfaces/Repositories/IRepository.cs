namespace HandicraftShop.Catalog.DataAccess.Interfaces.Repositories;

using HandicraftShop.Catalog.Domain.Entities;

/// <summary>
/// Mascot data access - repository
/// </summary>
public interface IRepository <T> where T : EntityId<Guid>
{
    
}