using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.ViewModels;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreContext _context;

        public StoreController(StoreContext context)
        {
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> ListGenres()
        {
            return View(await _context.Genres.OrderBy(g => g.Name).ToListAsync());
        }

        public async Task<IActionResult> ListAlbums(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genres = from g in _context.Genres.Include(g => g.Albums).Where(g => g.GenreID == id)
                         select g;

            var albums = from a in _context.Albums.Where(a => a.GenreID == id).OrderBy(a => a.Title)
                         select a;

            var listAlbumsByGenreViewModel = new ListAlbumsByGenreViewModel();

            listAlbumsByGenreViewModel.Genres = await genres.ToListAsync();

            listAlbumsByGenreViewModel.Albums = await albums.ToListAsync();

            return View(listAlbumsByGenreViewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
    }
}