using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFMVVM.Infostructure.Commands;
using WPFMVVM.ViewModels.Base;

namespace WPFMVVM.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Заголовок окна
        private string _Title = "TestW";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        #region Commands

        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new RelayCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute); 
        }
    }
}
