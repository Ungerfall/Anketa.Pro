using System.Windows.Input;
using AnketaPro.Service;

namespace AnketaPro.ViewModel
{
    public class CreateFormViewModel : ViewModelBase, IDialogWindow
    {
        public CreateFormViewModel()
        {
            formType = FormType.Anketa;
            gradeRecordName = "Ведомость не прикреплена.";
            actionButtonName = "Создать";
        }

        private string formName;

        public string FormName
        {
            get { return formName; }
            set
            {
                formName = value;
                OnPropertyChanged();
            }
        }

        private FormType formType;

        public FormType FormType
        {
            get { return formType; }
            set
            {
                formType = value;
                OnPropertyChanged();
            }
        }

        private string actionButtonName;

        public string ActionButtonName
        {
            get { return actionButtonName; }
            set
            {
                actionButtonName = value;
                OnPropertyChanged();
            }
        }

        private bool? createFormResult;

        public bool? CreateFormResult
        {
            get { return createFormResult; }
            set
            {
                createFormResult = value;
                OnPropertyChanged();
            }
        }

        private string gradeRecordName;

        public string GradeRecordName
        {
            get { return gradeRecordName; }
            set
            {
                gradeRecordName = value;
                OnPropertyChanged();
            }
        }

        public IForm Form { get; set; }

        public IGradeRecordService GradeRecord { get; set; }

        private ICommand addGradeRecordCommand;

        public ICommand AddGradeRecordCommand
        {
            get { return addGradeRecordCommand; }
        }

        private bool? dialogResult;
        public bool? DialogResult
        {
            get { return dialogResult; }
            set
            {
                dialogResult = value;
                OnPropertyChanged();
            }
        }
    }
}