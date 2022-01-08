using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace INF11207_TP3_Jeu_de_Pokemons.Views
{
    /// <summary>
    /// Logique d'interaction pour DeckWin.xaml
    /// </summary>
    public partial class DeckWin : Window
    {
        public DeckWin(Models.Invitation player)
        {
            InitializeComponent();
            DataContext = new ViewModels.DeckModelView(this, player);

        }
    }
}
