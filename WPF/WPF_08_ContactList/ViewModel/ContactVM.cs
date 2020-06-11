using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF_08_ContactList.Model;
using WPF_08_ContactList.ViewModel.Command;

namespace WPF_08_ContactList.ViewModel
{
    public class ContactVM : INotifyPropertyChanged
    {
        private Contact contact;
        private Contact selectedContact;
        private Contact tmpContact;
        bool visibleEdit = false;
        bool visibleCreate = true;
        string[] themesArr = { "light", "dark" };
        string[] langArr = { "en", "ua" };
        int indexT = 0;
        int indexL = 1;

        public Contact TmpContact
        {
            get => tmpContact;
            set { tmpContact = value; OnNotify(); }
        }
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public Contact Contact
        {
            get => contact;
            set
            {
                contact = value;
                OnNotify();
            }
        }
        public Contact SelectContact
        {
            get => selectedContact;
            set
            {
                selectedContact = value;
                OnNotify();
            }
        }
        public bool VisibleEdit
        {
            get => visibleEdit;
            set
            {
                visibleEdit = value;
                OnNotify();
            }
        }
        public bool VisibleCreated
        {
            get => visibleCreate;
            set
            {
                visibleCreate = value;
                OnNotify();
            }
        }
        public AddCommand AddCommand { get; set; }
        public DeleteCommand DeleteCommand { get; set; }
        public EditCommand EditCommand { get; set; }
        public SaveCommand SaveCommand { get; set; }
        public CloseCommand CloseCommand { get; set; }
        public ClearCommand ClearCommand { get; set; }
        public ChangeLang ChangeLang { get; set; }
        public ChangeThemes ChangeThemes { get; set; }
        public ContactVM()
        {
            AddCommand = new AddCommand(this);
            DeleteCommand = new DeleteCommand(this);
            EditCommand = new EditCommand(this);
            SaveCommand = new SaveCommand(this);
            CloseCommand = new CloseCommand(this);
            ClearCommand = new ClearCommand(this);
            ChangeLang = new ChangeLang(this);
            ChangeThemes = new ChangeThemes(this);
            Contact = new Contact();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void AddToList()
        {
            Contacts.Add(new Contact { Name = contact.Name, Surname = contact.Surname, Number = contact.Number });
            Clear();
        }

        public void Clear()
        {
            Contact = null;
            Contact = new Contact();
        }

        public void Edit(Button button)
        {
            //TmpContact = new Contact { Name = SelectContact.Name, Surname = SelectContact.Surname, Number = SelectContact.Number };
            //Contact = new Contact();
            //ChangeVisible();
            if ((Contact)button.DataContext != null)
                TmpContact = new Contact { Name =((Contact)button.DataContext).Name, Surname = ((Contact)button.DataContext).Surname, Number = ((Contact)button.DataContext).Number };

            //Contact = new Contact();
            ChangeVisible();
        }

        public void Delete(Button button)
        {
            Contacts.Remove((Contact)button.DataContext);
        }

        public void Save()
        {
            for (int i = 0; i < Contacts.Count; i++)
            {
                if (SelectContact == Contacts[i])
                    Contacts[i] = TmpContact;
            }
            Contact = new Contact();
            ChangeVisible();
        }

        public void Close()
        {
            TmpContact = null;
            //Contact = new Contact();
            ChangeVisible();
        }

        private void ChangeVisible()
        {
            VisibleEdit = !VisibleEdit;
            VisibleCreated = !VisibleCreated;
        }
       
        public void ChangeTheme(MenuItem menuItem)
        {
            indexT = Convert.ToInt32(menuItem.Tag);

            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("Themes/" + themesArr[indexT] + ".xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
            Application.Current.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri("Properties/" + langArr[indexL] + ".xaml", UriKind.Relative)));

        }
        
        public void ChengeLang(MenuItem menuItem)
        {
            indexL = Convert.ToInt32(menuItem.Tag);

            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("Properties/" + langArr[indexL] + ".xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
            Application.Current.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri("Themes/" + themesArr[indexT] + ".xaml", UriKind.Relative)));
        }
    }
}
