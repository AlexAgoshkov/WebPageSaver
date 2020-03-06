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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebSaver.Services;

namespace WebSaver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IFileService _fileService;
        private readonly IWebService _webService;
        public MainWindow()
        {
            InitializeComponent();
            _fileService = new FileTextService();
            _webService = new WebService();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Save
            if (!string.IsNullOrWhiteSpace(_webPage.Text))
            {
                var result = await _webService.GetAsync(_webPage.Text);
                await _fileService.SaveAsync(result);
            }
        }
    }
}
