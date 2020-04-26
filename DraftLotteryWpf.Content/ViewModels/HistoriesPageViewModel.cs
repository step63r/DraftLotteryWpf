using DraftLotteryWpf.Common;
using DraftLotteryWpf.Content.Services;
using DraftLotteryWpf.Content.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace DraftLotteryWpf.Content.ViewModels
{
    public class HistoriesPageViewModel : BindableBase, IRegionMemberLifetime
    {
        #region インタフェース
        /// <summary>
        /// RegionManager
        /// </summary>
        private readonly IRegionManager _regionManager;
        /// <summary>
        /// EventAggregator
        /// </summary>
        private readonly IEventAggregator _eventAggregator;
        #endregion

        #region コマンド・プロパティ
        /// <summary>
        /// 戻るコマンド
        /// </summary>
        public DelegateCommand GoBackCommand { get; private set; }

        /// <summary>
        /// セッション情報一覧
        /// </summary>
        public ObservableCollection<Session> Sessions { get; set; } = new ObservableCollection<Session>();

        private Session _selectedSession;
        /// <summary>
        /// 選択されたセッション
        /// </summary>
        public Session SelectedSession
        {
            get { return _selectedSession; }
            set { SetProperty(ref _selectedSession, value); }
        }

        /// <summary>
        /// インスタンスを使い回すか
        /// </summary>
        public bool KeepAlive { get; } = false;
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="eventAggregator"></param>
        public HistoriesPageViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            // インタフェースを受け取る
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            // コマンドを定義
            GoBackCommand = new DelegateCommand(ExecuteGoBackCommand);

            Sessions = SessionsDataStore.GetSessions();
        }

        /// <summary>
        /// 戻る
        /// </summary>
        private void ExecuteGoBackCommand()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(TopPage));
        }
    }
}
