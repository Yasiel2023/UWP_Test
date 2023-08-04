using Services.DTOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App_Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailProductPage : Page
    {
        private ProductDto _product;
        public DetailProductPage(ProductDto product)
        {
            _product = product;
            this.InitializeComponent();
            ImgProduct.Source = new BitmapImage(new Uri(product.Image, UriKind.Absolute));
            TextTittle.Text = product.Title;
            TextCategoria.Text = product.Category;
            TextPrecio.Text = "$"+product.Price.ToString();
            RichDescripcion.Text = product.Description;
        }
    }
}
