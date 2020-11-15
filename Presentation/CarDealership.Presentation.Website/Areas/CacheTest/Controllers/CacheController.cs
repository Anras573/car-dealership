using CarDealership.Domain.Caching;
using CarDealership.Presentation.Website.Areas.CacheTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace CarDealership.Presentation.Website.Areas.CacheTest.Controllers
{
    [Area("CacheTest")]
    public class CacheController : Controller
    {
        private const string CacheKey = "Controller:Test";
        private readonly IMultiLayerCache _cache;
        private readonly IMemoryCache _memoryCache;

        public CacheController(IMultiLayerCache cache, IMemoryCache memoryCache)
        {
            _cache = cache;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index()
        {
            var value = DateTime.UtcNow;
            await _cache.GetOrAddAsync(CacheKey, () =>  new CacheTestViewModel() { Time = value.ToLongTimeString() });
            return View();
        }

        public async Task<IActionResult> MultiLayer()
        {
            var model = await _cache.GetAsync<CacheTestViewModel>(CacheKey);
            return View(model);
        }

        public async Task<IActionResult> Distributed()
        {
            _memoryCache.Remove(CacheKey);
            var model = await _cache.GetAsync<CacheTestViewModel>(CacheKey);
            return View(model);
        }
    }
}
