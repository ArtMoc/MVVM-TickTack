using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_TickTack
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<string> _buttonsText;
        TickTackTorModel model;
        public ViewModel()
        {
            model = new TickTackTorModel();
            _buttonsText = new ObservableCollection<string>()
            {
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " "};
        }
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<string> ButtonText
        {
            get { return _buttonsText; }
            set
            {
                _buttonsText = value;
                Notify("ButtonText");
            }
        }

        public ICommand AboutClick
        {
            get
            {
                return new ButtonCommand(new Action<object>
                    ((parameter) =>
                    {
                        About form = new About();
                        form.ShowDialog();

                    }));
            }
        }

        public ICommand NewGame
        {
            get
            {
                return new ButtonCommand(new Action<object>
              ((parameter) =>
              {
                  model = new TickTackTorModel();
                  ButtonText = new ObservableCollection<string>()
                  {

                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " "};
              }));
            }
        }

        public ICommand ButtonClick
        {
            get
            {
                return new ButtonCommand(new Action<object>((parameter) =>
               {
                   int index = Convert.ToInt32(parameter.ToString());
                   ButtonText[index] = model.PlayerTurn(index);
                   if (model.CheckWinner() != null)
                   {
                       MessageBox.Show(model.CheckWinner());
                   }
               }));
            }
        }
    }

}