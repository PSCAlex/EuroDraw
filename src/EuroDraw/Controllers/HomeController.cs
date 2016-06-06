﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EuroDraw.Models;

namespace EuroDraw.Controllers
{
    public class HomeController : Controller
    {
        private IDrawRepo _repo;

        public HomeController(IDrawRepo drawRepo)
        {
            _repo = drawRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Draw()
        {
            if (!_repo.IsDrawn())
            {
                var d = RunDraw();
                if (!d)
                {
                    return RedirectToAction("Error");
                }
            }

            var draw = new DrawViewModel
            {
                countries = _repo.GetCountryList(),
                people = _repo.GetPeopleList(),
                timeStamp = _repo.GetTimestamp()
            };

            return View(draw);
        }

        private bool RunDraw()
        {
            DateTime d = new DateTime(2016, 6, 6, 11, 25, 0);

            if (!_repo.IsDrawn() && DateTime.Now >= d)
            {
                var rnd = new Random();
                var people = new List<int>();
                var countries = new List<int>();
                for (var i = 1; i < 25; i++)
                {
                    people.Add(i);
                    countries.Add(i);
                }

                var shuffledPeople = people.OrderBy(x => rnd.Next());
                var shuffledCountries = countries.OrderBy(x => rnd.Next());

                _repo.NewDraw(shuffledPeople, shuffledCountries);

                return true;
            }else
            {
                return false;
            }
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult PracticeDraw()
        {
            return View();
        }
    }

}
