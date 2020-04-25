using fromsPeople.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace fromsPeople.ViewModel
{
    internal class Presenter : ViewModelBase
    {
        private humanDataManipulator modelManager = new humanDataManipulator();

        private void refresh()
        {
            People = modelManager.getPeople();
            Index = -1;
            Name = null;
            Surname = null;
            Age = 25;
            modelManager.saveToFile();
        }

        public Presenter()
        {
            modelManager.loadFromFile();
            refresh();
        }

        private string _name = null;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                onPropertyChanged(nameof(Name));
            }
        }
        private string _surname = null;
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                onPropertyChanged(nameof(Surname));
            }
        }

        private int _age = 25;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                onPropertyChanged(nameof(Age));
            }
        }

        private string[] _people;
        public string[] People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
                onPropertyChanged(nameof(People));
            }
        }

        private ICommand _addHuman = null;

        public ICommand AddHuman
        {
            get
            {
                if (_addHuman == null)
                {
                    _addHuman = new RelayCommand(
                        x =>
                        {
                            modelManager.AddHuman(Name, Surname, Age);
                            refresh();
                        },
                        x =>
                        {
                            bool tmp = true;
                            if ((Name == null) || (Name == "") || (Name.Contains(" ")) || (Surname == null) || (Surname == "") || (Surname.Contains(" ")))
                            {
                                tmp = false;
                            }
                            return tmp;
                        }
                        );
                }

                return _addHuman;
            }
        }

        private int _index = -1;
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                if (_index != -1)
                {
                    Name = modelManager.getName(_index);
                    Surname = modelManager.getSurname(_index);
                    Age = modelManager.getAge(_index);
                }
                onPropertyChanged(nameof(Index));
            }
        }
        private ICommand _editHuman = null;
        public ICommand EditHuman
        {
            get
            {
                if (_editHuman == null)
                {
                    _editHuman = new RelayCommand(
                        x =>
                        {
                            modelManager.editHuman(Index, Name, Surname, Age);
                            refresh();
                        },
                        x =>
                        {
                            if (Index != -1)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        );
                }
                return _editHuman;
            }
        }

        private ICommand _deleteHuman = null;
        public ICommand DeleteHuman
        {
            get
            {
                if (_deleteHuman == null)
                {
                    _deleteHuman = new RelayCommand(
                        x =>
                        {
                            modelManager.deleteHuman(Index);
                            refresh();
                        },
                        x =>
                        {
                            if (Index != -1)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        );
                }
                return _deleteHuman;
            }
        }


        private ICommand _btnTest = null;
        public ICommand BtnTest
        {
            get
            {
                if (_btnTest == null)
                {
                    _btnTest = new RelayCommand(
                        x =>
                        {
                            Index = 1;
                        },
                        x =>
                        {
                            if (Index == 1)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        );
                }
                return _btnTest;
            }
        }
    }
}
