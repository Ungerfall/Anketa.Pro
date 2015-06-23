using System;
using System.Windows.Input;
using AnketaPro.Service;
using AnketaPro.View;

namespace AnketaPro.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService dialogService;

        public MainWindowViewModel() : this(ServiceLocator.Resolve<IDialogService>())
        {
        }

        private MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            CreateFormCommand = new RelayCommand(CreateForm);
            OpenFormCommand = new RelayCommand(OpenForm);
            CloseFormCommand = new RelayCommand(CloseForm, IsFormActive);
            SaveFormCommand = new RelayCommand(SaveForm, CanSaveForm);
            PrintFormCommand = new RelayCommand(PrintForm, IsFormActive);
            GetWebFormCommand = new RelayCommand(GetWebForm, IsFormActive);
            SolveFormCommand = new RelayCommand(SolveForm, IsFormActive);
            OpenGradeRecordCommand = new RelayCommand(OpenGradeRecord, IsFormActive);
            SignInCommand = new RelayCommand(SignIn, CanSignIn);
            SignUpCommand = new RelayCommand(SignUp, CanSignUp);
            LogoutCommand = new RelayCommand(Logout, CanLogout);
            ShowAboutCommand = new RelayCommand(ShowAbout);
            AddElementCommand = new RelayCommand(AddElement, CanAddElement);
            DeleteElementCommand = new RelayCommand(DeleteElement, CanDeleteElement);
            UpElementCommand = new RelayCommand(UpElement, CanUpElement);
            DownElementCommand = new RelayCommand(DownElement, CanDownElement);
            UndoElementCommand = new RelayCommand(UndoElement, CanUndoElement);
            RedoElementCommand = new RelayCommand(RedoElement, CanRedoElement);

        }


        public ICommand CreateFormCommand { get; private set; }
        public ICommand OpenFormCommand { get; private set; }
        public ICommand CloseFormCommand { get; private set; }
        public ICommand SaveFormCommand { get; private set; }
        public ICommand PrintFormCommand { get; private set; }
        public ICommand GetWebFormCommand { get; private set; }
        public ICommand SolveFormCommand { get; private set; }
        public ICommand OpenGradeRecordCommand { get; private set; }
        public ICommand SignInCommand { get; private set; }
        public ICommand SignUpCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }
        public ICommand ShowAboutCommand { get; private set; }
        public ICommand AddElementCommand { get; private set; }
        public ICommand DeleteElementCommand { get; private set; }
        public ICommand UpElementCommand { get; private set; }
        public ICommand DownElementCommand { get; private set; }
        public ICommand UndoElementCommand { get; private set; }
        public ICommand RedoElementCommand { get; private set; }

        #region Command methods

        private bool CanRedoElement(object arg)
        {
            throw new NotImplementedException();
        }

        private void RedoElement(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanUndoElement(object arg)
        {
            throw new NotImplementedException();
        }

        private void UndoElement(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanDownElement(object arg)
        {
            throw new NotImplementedException();
        }

        private void DownElement(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanUpElement(object arg)
        {
            throw new NotImplementedException();
        }

        private void UpElement(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanDeleteElement(object arg)
        {
            throw new NotImplementedException();
        }

        private void DeleteElement(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanAddElement(object arg)
        {
            throw new NotImplementedException();
        }

        private void AddElement(object obj)
        {
            throw new NotImplementedException();
        }

        private void ShowAbout(object obj)
        {
            throw new NotImplementedException();
        }

        private void Logout(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanLogout(object arg)
        {
            throw new NotImplementedException();
        }

        private void SignUp(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanSignUp(object arg)
        {
            throw new NotImplementedException();
        }

        private void SignIn(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanSignIn(object arg)
        {
            throw new NotImplementedException();
        }

        private void OpenGradeRecord(object obj)
        {
            throw new NotImplementedException();
        }

        private void SolveForm(object obj)
        {
            throw new NotImplementedException();
        }

        private void GetWebForm(object obj)
        {
            throw new NotImplementedException();
        }

        private bool IsFormActive(object arg)
        {
            return true;
        }

        private void CloseForm(object obj)
        {
            throw new NotImplementedException();
        }

        private void OpenForm(object obj)
        {
            var openFormViewModel = new OpenFormViewModel();
            var dialogResult = dialogService.ShowDialog<OpenFormWindow>(this, openFormViewModel);
        }

        private void CreateForm(object o)
        {
            var createFormViewModel = new CreateFormViewModel();
            var dialogResult = dialogService.ShowDialog<CreateFormWindow>(this, createFormViewModel);
        }

        private void PrintForm(object obj)
        {
            throw new NotImplementedException();
        }

        private void SaveForm(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanSaveForm(object arg)
        {
            return true;
        }

        #endregion
    }
}