using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rutasegura
{
    public partial class MainPage : ContentPage
    {
        private string Url = "http://192.168.100.116/rutasegura/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<perfilusuario> post;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ObtenerDatos();
        }

        private async void ObtenerDatos()
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<perfilusuario> listaPost = JsonConvert.DeserializeObject<List<perfilusuario>>(contenido);
            post = new ObservableCollection<perfilusuario>(listaPost);
            listaperfilusuario.ItemsSource = post;
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<perfilusuario> listaPost = JsonConvert.DeserializeObject<List<perfilusuario>>(contenido);
            post = new ObservableCollection<perfilusuario>(listaPost);
            listaperfilusuario.ItemsSource = post;
        }
    }
}
