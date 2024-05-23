using Domain;
using Infrastructure.Data;

namespace Application.Repositories;

public class CommonRrepository : ICommonRepository
{
    private readonly DataContext _context;

    public CommonRrepository(DataContext context)
    {
        _context = context;
    }

    public List<Allergie> GetAllAllergies()
    {
        return _context.Allergies.ToList();
    }

    public List<Disease> GetAllDieases()
    {
        return _context.Diseases.ToList();
    }

    public List<NCD> GetAllNCDs()
    {
        return _context.NCDs.ToList();
    }
}