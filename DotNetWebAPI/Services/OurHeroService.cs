using DotNetWebAPI.Model;

namespace DotNetWebAPI.Services
{
    public class OurHeroService : IOurHeroService
    {
        private readonly List<OurHero> _ourherosList;
        public OurHeroService()
        {
            _ourherosList = new List<OurHero>()
            {
                new OurHero()
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "Test1",
                    isActive = true,
                }
            };
        }
        public List<OurHero> GetAllHeros(bool? isActive)
        {
            return isActive == null ? _ourherosList : _ourherosList.Where(hero => hero.isActive == isActive).ToList();
        }
        public OurHero? GetHerosByID(int id)
        {
            return _ourherosList.FirstOrDefault(hero => hero.Id == id);
        }
        public OurHero AddOurHero(AddUpdateOurHero obj)
        {
            var addHero = new OurHero()
            {
                Id = _ourherosList.Max(hero => hero.Id) + 1,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                isActive = obj.isActive,
            };
            _ourherosList.Add(addHero);
            return addHero;
        }
        public OurHero? UpdateOurHero(int id, AddUpdateOurHero obj)
        {
            var ourHeroIndex = _ourherosList.FindIndex(index => index.Id == id);
            if (ourHeroIndex > 0)
            {
                var hero = _ourherosList[ourHeroIndex];
                hero.FirstName = obj.FirstName;
                hero.LastName = obj.LastName;
                hero.isActive = obj.isActive;
                _ourherosList[ourHeroIndex] = hero;
                return hero;
            }
            else
            {
                return null;
            }
        }
        public bool DeleteHerosByID(int id)
        {
            var ourHeroIndex = _ourherosList.FindIndex(index => index.Id == id);
            if (ourHeroIndex >= 0)
            {
                _ourherosList.RemoveAt(ourHeroIndex);
            }
            return ourHeroIndex >= 0;
        }
    }
}
