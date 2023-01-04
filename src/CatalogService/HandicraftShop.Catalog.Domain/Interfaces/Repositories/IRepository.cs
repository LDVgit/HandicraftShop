namespace HandicraftShop.Catalog.Domain.Interfaces.Repositories;

using Domain.Entities;

/// <summary>
/// Mascot data access - repository
/// </summary>
public interface IRepository <T> where T : EntityId<Guid>
{
    
}