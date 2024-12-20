using System.Windows;

namespace ContactsApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Đặt vị trí của cửa sổ vào giữa màn hình
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Điều hướng đến Page1 khi ứng dụng khởi động
            MainFrame.Navigate(new Page1());
        }
    }
}