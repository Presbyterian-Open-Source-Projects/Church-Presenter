using ChurchPresenter.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church_Presenter.ViewModels
{
    internal partial class SongsPageViewModel : ObservableObject
    {
        private static List<Song> _songs;

        public static List<Song> Songs { get => _songs; set => _songs = value; }
    }
}
