using System.Collections.Generic;
using AnketaPro.Forms.Common;

namespace AnketaPro.Forms.OpenForm
{
    public class OpenFormViewModel : ViewModelBase
    {
        public OpenFormViewModel()
        {
            selectedOpenFormType = OpenFormType.MyForms;
        }

        private OpenFormType selectedOpenFormType;

        public OpenFormType SelectedOpenFormType
        {
            get { return selectedOpenFormType; }
            set
            {
                selectedOpenFormType = value;
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