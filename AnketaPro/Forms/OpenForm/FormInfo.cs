using AnketaPro.Forms.Common;

namespace AnketaPro.Forms.OpenForm
{
    public class FormInfo : ViewModelBase
    {
        private string name;

        [DbColumn("form_name")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string id;

        [DbColumn("form_id")]
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private string type;

        [DbColumn("form_type")]
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }
    }
}