using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.ViewModels
{
    public class ListAlbumsViewModel
    {
        public List<Album> Albums { get; set; }
        public SelectList Genres { get; set; }
        public SelectList Artists { get; set; }

        public int GenreID { get; set; }
        public int ArtistID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }
    }
}
