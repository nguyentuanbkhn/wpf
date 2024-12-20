using System.Windows;
using System.Windows.Controls;

namespace ContactsApp
{
    public partial class Page1 : Page
    {
        public ContactViewModel ViewModel { get; set; }
        private Contact _selectedContact;

        public Page1()
        {
            InitializeComponent();
            ViewModel = new ContactViewModel();
            this.DataContext = ViewModel;
        }

        // Sự kiện khi nhấn nút "Add Contact"
        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            // Thêm một liên hệ mới vào ObservableCollection
            var newContact = new Contact
            {
                Name = ViewModel.Name,
                Age = ViewModel.Age,
                Phone = ViewModel.Phone,
                Address = ViewModel.Address,
                Note = ViewModel.Note,
                CreatedDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            ViewModel.Contacts.Add(newContact);

            // Sau khi thêm, làm sạch các trường nhập liệu trong ViewModel
            ViewModel.Name = string.Empty;
            ViewModel.Age = string.Empty;
            ViewModel.Phone = string.Empty;
            ViewModel.Address = string.Empty;
            ViewModel.Note = string.Empty;
        }

        // Sự kiện khi nhấn nút "Edit Contact"
        private void EditContactButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedContact != null)
            {
                // Cập nhật các thuộc tính của Contact
                _selectedContact.Name = ViewModel.Name;
                _selectedContact.Age = ViewModel.Age;
                _selectedContact.Phone = ViewModel.Phone;
                _selectedContact.Address = ViewModel.Address;
                _selectedContact.Note = ViewModel.Note;

                // Cập nhật lại DataGrid
                ContactsDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a contact to edit.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Sự kiện khi nhấn nút "Delete Contact"
        private void DeleteContactButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedContact != null)
            {
                // Xóa liên hệ được chọn
                ViewModel.Contacts.Remove(_selectedContact);
                ClearTextFields();  // Làm sạch các trường nhập liệu
            }
            else
            {
                MessageBox.Show("Please select a contact to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Sự kiện khi nhấn nút "Go to Page 2"
        private void NavigateToPage2(object sender, RoutedEventArgs e)
        {
            // Truyền danh sách các liên hệ từ Page1 sang Page2
            this.NavigationService.Navigate(new Page2(ViewModel.Contacts));
        }

        // Cập nhật khi người dùng chọn một dòng trong DataGrid
        private void ContactsDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ContactsDataGrid.SelectedItem != null)
            {
                _selectedContact = ContactsDataGrid.SelectedItem as Contact;

                // Hiển thị dữ liệu của dòng đã chọn vào các TextBox
                ViewModel.Name = _selectedContact.Name;
                ViewModel.Age = _selectedContact.Age;
                ViewModel.Phone = _selectedContact.Phone;
                ViewModel.Address = _selectedContact.Address;
                ViewModel.Note = _selectedContact.Note;
            }
        }

        // Phương thức để làm sạch các trường nhập liệu
        private void ClearTextFields()
        {
            ViewModel.Name = string.Empty;
            ViewModel.Age = string.Empty;
            ViewModel.Phone = string.Empty;
            ViewModel.Address = string.Empty;
            ViewModel.Note = string.Empty;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    // Model cho Contact
    public class Contact
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string CreatedDate { get; set; }
    }
}