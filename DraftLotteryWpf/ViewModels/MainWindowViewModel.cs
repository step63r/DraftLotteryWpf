using DraftLotteryWpf.Content.Services;
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
            // 初期化処理
            UsersDataStore.Initialize();
            SessionsDataStore.Initialize();
        }
    }
}
