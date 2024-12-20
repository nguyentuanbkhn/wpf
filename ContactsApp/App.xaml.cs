using System;
using System.Windows;

namespace ContactsApp
{
    public partial class App : Application
    {
        public App()
        {
            // Đăng ký sự kiện để xử lý các exceptions chưa được xử lý
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        // Phương thức xử lý exception toàn cục
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            // Hiển thị thông báo lỗi trong MessageBox
            MessageBox.Show($"An unexpected error occurred: {e.Exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            // Ngừng sự kiện mặc định để ngừng ứng dụng thoát
            e.Handled = true;
        }
    }
}