using Prism.Mvvm;

namespace DraftLotteryWpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "DraftLotteryWpf";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
