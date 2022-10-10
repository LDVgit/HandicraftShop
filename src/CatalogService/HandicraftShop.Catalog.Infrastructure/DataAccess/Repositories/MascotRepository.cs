namespace HandicraftShop.Catalog.Infrastructure.DataAccess.Repositories;

using Domain.Entities;
using Domain.Interfaces.Entities;

/// <summary>
/// EfCore implementation IMascotRepository
/// </summary>
public class MascotRepository : IMascotRepository
{
    private readonly CatalogContext _context;

    public MascotRepository(CatalogContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public IEnumerable<Mascot> GetAllAsync()
    {
        return new List<Mascot>();
    }
}