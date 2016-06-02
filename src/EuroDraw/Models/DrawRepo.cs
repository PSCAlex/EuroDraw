using EuroDraw.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EuroDraw.Models
{
    public interface IDrawRepo
    {
        void NewDraw(IEnumerable<int> peopleList, IEnumerable<int> countryList);
        IEnumerable<int> GetPeopleList();
        IEnumerable<int> GetCountryList();
        string GetTimestamp();
        bool IsDrawn();

    }
    public class DrawRepo : IDrawRepo
    {
        private ApplicationDbContext _context;

        public DrawRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void NewDraw(IEnumerable<int> peopleList,IEnumerable<int> countryList)
        {
            var draw = new DrawModel {
                people = JsonConvert.SerializeObject(peopleList),
                countries = JsonConvert.SerializeObject(countryList),
                timeStamp = DateTime.Now
            };

            _context.Add(draw);
            _context.SaveChanges();
        }

        public IEnumerable<int> GetPeopleList()
        {
            return JsonConvert.DeserializeObject<IEnumerable<int>>(_context.Draw.FirstOrDefault().people);
        }

        public IEnumerable<int> GetCountryList()
        {
            return JsonConvert.DeserializeObject<IEnumerable<int>>(_context.Draw.FirstOrDefault().countries);
        }

        public string GetTimestamp()
        {
            return _context.Draw.FirstOrDefault().timeStamp.TimeOfDay.ToString();
        }

        public bool IsDrawn()
        {
            return _context.Draw.Any();
        }
    }
}
