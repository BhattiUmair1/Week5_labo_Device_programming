using Oefening1.NewFolder;
using Oefening1.NewFolder1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Oefening1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            testModels();
        }

        private async void testModels()
        {
            Debug.WriteLine("test");
            //Haal alle boards op en toon de naam
            List<TrelloBoard> boards = await TrelloRepository.GetTrelloBoardsAsync();
            foreach (var item in boards)
            {
                Debug.WriteLine("Name: " + item.Name);
            }
        }
    }
}
