using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ContactsApp
{
    public partial class Page2 : Page
    {
        private string _name;
        private string _age;
        private string _phone;
        private string _address;
        private string _note;

        public Page2(ObservableCollection<Contact> contacts)
        {
            InitializeComponent();

            // Nhận danh sách liên hệ từ Page1
            ContactsListView.ItemsSource = contacts;
        }

        // Xử lý sự kiện quay lại Page 1
        private void NavigateToPage1(object sender, RoutedEventArgs e)
        {
            // Điều hướng quay lại Page 1
            this.NavigationService.Navigate(new Page1());
        }
    }
}