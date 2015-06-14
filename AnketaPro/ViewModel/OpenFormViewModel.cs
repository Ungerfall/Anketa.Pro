using System.Collections.Generic;
using AnketaPro.Model;
using AnketaPro.Service;
using AnketaProDB;

namespace AnketaPro.ViewModel
{
    public class OpenFormViewModel : ViewModelBase, IDialogWindow
    {
        public OpenFormViewModel()
        {
            selectedOpenFormType = OpenFormType.MyForms;
            client = new QuickFormsDbClient();
        }

        private IQuickFormsDbClient client;

        private OpenFormType selectedOpenFormType;

        public OpenFormType SelectedOpenFormType
        {
            get { return selectedOpenFormType; }
            set
            {
                selectedOpenFormType = value;
                if (selectedOpenFormType == OpenFormType.MyForms)
                {
                    
                }
                OnPropertyChanged();
            }
        }

        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private List<FormInfo> availableForms;

        public List<FormInfo> AvailableForms
        {
            get { return availableForms; }
            set
            {
                availableForms = value;
                OnPropertyChanged();
            }
        }

        private FormInfo selectedForm;

        public FormInfo SelectedForm
        {
            get { return selectedForm; }
            set
            {
                selectedForm = value;
                OnPropertyChanged();
            }
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