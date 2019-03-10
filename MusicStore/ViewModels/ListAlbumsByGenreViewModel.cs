using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.ViewModels
{
    public class ListAlbumsByGenreViewModel
    {
        public List<Genre> Genres { get; set; }
        public List<Album> Albums { get; set; }
    }
}
