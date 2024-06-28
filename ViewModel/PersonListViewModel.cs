using model;
using MVVMtest.ViewModel.command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMtest.ViewModel
{
    public class PersonListViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _searchText;
        private ObservableCollection<Person> _resultList;
        private PersonData personData;
        #endregion

        #region Properties

        public ObservableCollection<Person> PersonList { get; private set; }

        // 查询关键字
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        // 查询结果
        public ObservableCollection<Person> ResultList
        {
            get { return _resultList; }
            set
            {
                _resultList = value;
                RaisePropertyChanged("ResultList");
            }
        }

        public ICommand QueryCommand
        {
            get { return new QueryCommand(Searching, CanSearching); }
        }

        public ICommand Addperson
        {
            get { return new QueryCommand(Add,CanSearching); }
        }

        #endregion

        #region Construction
        public PersonListViewModel(PersonData personData)
        {
            this.personData = personData;
            PersonList = personData.GetPersons();
            _resultList = PersonList;
        }

        #endregion

        #region Command Handler
        public void Searching()
        {
            ObservableCollection<Person> personList = null;
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                ResultList = personData.GetPersons();
            }
            else
            {
                personList = new ObservableCollection<Person>(personData.GetPersons().Where(p => p.Name.Contains(SearchText)));

                if (personList != null)
                {
                    ResultList = personList;
                }
            }
        }

        public void Add()
        {
            personData.AddPerson(new Person() { Name = "张三", Age = 33 });
        }

        public bool CanSearching()
        {
            return true;
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods
        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
