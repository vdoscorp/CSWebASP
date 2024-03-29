﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoinWeb.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.OutputCaching;
using System.Diagnostics;

namespace CoinWeb.Controllers
{
    public class CoinController : Controller
    {
        private readonly ApplicationContext _context;
        private IMemoryCache cache;

        public CoinController(ApplicationContext context, IMemoryCache cache)
        {
            _context = context;
            this.cache = cache;
        }

        // GET: Coin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coins.ToListAsync());
        }

        // GET: Coin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coin coin;
            if (!cache.TryGetValue(id, out coin))
            {
                coin = await _context.Coins
                .FirstOrDefaultAsync(m => m.Id == id);
                if (coin == null)
                {
                    return NotFound();
                }
                cache.Set(coin.Id, coin,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1)));
            }
            else
                Console.WriteLine($"Coin {coin.Id} get from cache");

            return View(coin);
        }

        // GET: Coin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year,Comment,Country,Metal,Face,Denomination")] Coin coin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coin);
        }

        // GET: Coin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coin = await _context.Coins.FindAsync(id);
            if (coin == null)
            {
                return NotFound();
            }
            return View(coin);
        }

        // POST: Coin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Year,Comment,Country,Metal,Face,Denomination")] Coin coin)
        {
            if (id != coin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoinExists(coin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(coin);
        }

        // GET: Coin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coin = await _context.Coins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coin == null)
            {
                return NotFound();
            }

            return View(coin);
        }

        // POST: Coin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coin = await _context.Coins.FindAsync(id);
            if (coin != null)
            {
                _context.Coins.Remove(coin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoinExists(int id)
        {
            return _context.Coins.Any(e => e.Id == id);
        }
    }
}
