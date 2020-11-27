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
using Infrastructure;
using Logic;
using Microsoft.Extensions.DependencyInjection;

namespace PackagesOfFuture.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UnitOfWork unitOfWork { get; }

        public MainWindow()
        {
            InitializeComponent();
            Startup.ConfigureServices();
            var serviceProvider = Startup.GetServiceProviderInstance();
            unitOfWork = serviceProvider.GetService<UnitOfWork>();
        }
    }
}
