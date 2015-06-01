using System.Collections.Generic;
using AnketaPro.Forms.Common;
using AnketaProDB;

namespace AnketaPro.Forms.OpenForm
{
    public class OpenFormViewModel : ViewModelBase
    {
        public OpenFormViewModel()
        {
            selectedOpenFormType = OpenFormType.MyForms;
            client = new ApClient();
        }

        private ApClient client;

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
    }
}