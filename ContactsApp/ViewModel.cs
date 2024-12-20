using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ContactsApp
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _age;
        private string _phone;
        private string _address;
        private string _note;

        // ObservableCollection để lưu các Contact
        public ObservableCollection<Contact> Contacts { get; set; }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ContactViewModel()
        {
            Contacts = new ObservableCollection<Contact>();

            // Tạo RelayCommand cho các hành động
            AddCommand = new RelayCommand(AddContact);
            EditCommand = new RelayCommand(EditContact, CanEditOrDelete);
            DeleteCommand = new RelayCommand(DeleteContact, CanEditOrDelete);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        public string Note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value;
                    OnPropertyChanged(nameof(Note));
                }
            }
        }

        public Contact SelectedContact { get; set; }

        private void AddContact()
        {
            var newContact = new Contact
            {
                Name = Name,
                Age = Age,
                Phone = Phone,
                Address = Address,
                Note = Note,
                CreatedDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            Contacts.Add(newContact);
            ClearFields();
        }

        private void EditContact()
        {
            if (SelectedContact != null)
            {
                SelectedContact.Name = Name;
                SelectedContact.Age = Age;
                SelectedContact.Phone = Phone;
                SelectedContact.Address = Address;
                SelectedContact.Note = Note;
            }
        }

        private void DeleteContact()
        {
            if (SelectedContact != null)
            {
                Contacts.Remove(SelectedContact);
                ClearFields();
            }
        }

        private bool CanEditOrDelete()
        {
            return SelectedContact != null;
        }

        private void ClearFields()
        {
            Name = string.Empty;
            Age = string.Empty;
            Phone = string.Empty;
            Address = string.Empty;
            Note = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}