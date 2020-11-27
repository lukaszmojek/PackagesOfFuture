using System;
using System.Windows;
using PackagesOfFuture.UI;
using Xunit;

namespace UI.Tests
{
    public class MainWindowTests
    {
        [Fact]
        public void MainWindow_is_created_without_errors()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                var mainWindow = new MainWindow();

                Assert.NotNull(mainWindow);
            });

        }
    }
}
