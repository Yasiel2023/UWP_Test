using Services;
using Services.DTOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App_Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<ProductDto> Products;
        public MainPage()
        { 
            InitializeAsync();
            Products= new List<ProductDto>();
           
            this.InitializeComponent();
       
        }

        private async void InitializeAsync()
        {
            Products = await Api.GetProductsAsync();
            GridView1.ItemsSource = null;
            GridView1.ItemsSource = Products;
            //ListView1.Foreground = new SolidColorBrush(Colors.Orange);
            //string[] skills = { "Java", "C#", "PHP", "JQuery" };
            //ListView1.ItemsSource = skills;
            //image.Source = new BitmapImage(new Uri("https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg", UriKind.Absolute));
        }


        private void listviewEvent(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            
            string selected=listView.SelectedItem as string;
            MessageDialog dialog = new MessageDialog("Selected:" + selected);
            dialog.ShowAsync();
        }

        private void ListView1_Loaded(object sender, RoutedEventArgs e)
        { 
            ListView listView = sender as ListView;
            
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var product = (ProductDto)e.ClickedItem;
            DetailProductPage detailPage = new DetailProductPage(product);
            // Crea una nueva ventana emergente (ContentDialog) y muestra la página DetailProductPage dentro de ella
            var dialog = new ContentDialog
            {
                Title = "Detalles del producto",
                Content = detailPage,
                CloseButtonText = "Cerrar"
            };

            // Muestra la ventana emergente
            dialog.ShowAsync();
        }
    }
}
