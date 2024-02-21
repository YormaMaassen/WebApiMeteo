using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiMeteo.Db;
using WebApiMeteo.Model;
using WebApiMeteo.Repository.Interfaces;

namespace WebApiMeteo.Repository
{
    public class VilleRepository : IVilleRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public VilleRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Ville> GetAsync(int id)
        {
            return  _mapper.Map<Ville>(await _context.Villes.FindAsync(id));
        }

        public async Task<IEnumerable<Ville>> GetAllAsync()
        {
            return _mapper.Map<IList<Ville>>(await _context.Villes.ToListAsync());
        }

        public async Task CreateAsync(Ville ville)
        {
            _context.Villes.Add(_mapper.Map<Entities.Ville>(ville));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ville ville)
        {
            _context.Villes.Update(_mapper.Map<Entities.Ville>(ville));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ville = await _context.Villes.FindAsync(id);
            if (ville != null)
            {
                _context.Villes.Remove(ville);
                await _context.SaveChangesAsync();
            }
        }
    }
}
