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
        //private ApplicationDbContext _context;

        public DrawRepo(/*ApplicationDbContext context*/)
        {
            //_context = context;
        }

        public void NewDraw(IEnumerable<int> peopleList,IEnumerable<int> countryList)
        {
            /*
            var draw = new DrawModel {
                people = JsonConvert.SerializeObject(peopleList),
                countries = JsonConvert.SerializeObject(countryList),
                timeStamp = DateTime.Now
            };

            _context.Add(draw);
            _context.SaveChanges();
            */
        }

        public IEnumerable<int> GetPeopleList()
        {
            //return JsonConvert.DeserializeObject<IEnumerable<int>>(_context.Draw.FirstOrDefault().people);
            return new List<int> (){ 6, 18, 3, 11, 7, 23, 5, 24, 1, 9, 2, 12, 4, 13, 15, 19, 10, 21, 16, 17, 22, 20, 14, 8};
        }

        public IEnumerable<int> GetCountryList()
        {
            //return JsonConvert.DeserializeObject<IEnumerable<int>>(_context.Draw.FirstOrDefault().countries);
            return new List<int>() { 3, 15, 11, 23, 7, 13, 14, 20, 19, 5, 8, 17, 6, 12, 1, 18, 24, 16, 21, 9, 22, 2, 4, 10 };
        }

        public string GetTimestamp()
        {
            //return _context.Draw.FirstOrDefault().timeStamp.TimeOfDay.ToString();
            return "2016-06-09 20:30:02.2317966";
        }

        public bool IsDrawn()
        {
            //return _context.Draw.Any();
            return true;
        }
    }
}
