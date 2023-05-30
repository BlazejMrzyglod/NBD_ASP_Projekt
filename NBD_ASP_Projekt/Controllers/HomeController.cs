﻿using Microsoft.AspNetCore.Mvc;
using NBD_ASP_Projekt.Models.Models;
using NBD_ASP_Projekt.Models.ViewModels;
using NBD_ASP_Projekt.Services;
using System.Diagnostics;

namespace NBD_ASP_Projekt.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ComputerContext db;

		public HomeController(ILogger<HomeController> logger, ComputerContext computerContext)
		{
			_logger = logger;
			db = computerContext;
		}

		public async Task<IActionResult> Index(ComputerFilter filter)
		{
			var computers = await db.GetComputers(filter.Year, filter.ComputerName);
			var model = new ComputerList { Computers = computers, Filter = filter };
			return View(model);
		}

		public IActionResult Create() => View();

		[HttpPost]
		public async Task<IActionResult> Create(Computers computer)

		{
			if (ModelState.IsValid)
			{
				await db.Create(computer);
				return RedirectToAction("Index");
			}
			return View(computer);
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
}