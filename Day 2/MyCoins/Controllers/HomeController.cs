﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyCoins.Models;

namespace MyCoins.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(new CoinsData().Coins);
    }

    [HttpGet]
    public IActionResult Edit(Coin c)
    {
        return View(c);
    }

    [HttpPost]
    public IActionResult Save(Coin c)
    {
        return View("Edit",c);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
