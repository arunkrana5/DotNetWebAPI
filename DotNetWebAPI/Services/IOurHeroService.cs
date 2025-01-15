using DotNetWebAPI.Model;

namespace DotNetWebAPI.Services
{
    public interface IOurHeroService
    {
        List<OurHero> GetAllHeros(bool? IsActive);
        OurHero? GetHerosByID(int id);
        OurHero AddOurHero(AddUpdateOurHero obj);
        OurHero? UpdateOurHero(int id, AddUpdateOurHero obj);
        bool DeleteHerosByID(int id);
    }
}
