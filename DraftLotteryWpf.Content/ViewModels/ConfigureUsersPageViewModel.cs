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
    public class ConfigureUsersPageViewModel : BindableBase
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
        /// 新規作成コマンド
        /// </summary>
        public DelegateCommand CreateNewCommand { get; private set; }
        /// <summary>
        /// 更新コマンド
        /// </summary>
        public DelegateCommand UpdateCommand { get; private set; }
        /// <summary>
        /// 戻るコマンド
        /// </summary>
        public DelegateCommand GoBackCommand { get; private set; }

        private User _selectedUser;
        /// <summary>
        /// 選択されたユーザー
        /// </summary>
        public User SelectedUser
        {
            get { return _selectedUser; }
            set { SetProperty(ref _selectedUser, value); }
        }

        private bool _isChanged = false;
        /// <summary>
        /// 変更フラグ
        /// </summary>
        public bool IsChanged
        {
            get { return _isChanged; }
            set { SetProperty(ref _isChanged, value); }
        }
        #endregion

        /// <summary>
        /// ユーザー一覧
        /// </summary>
        public ObservableCollection<User> Users { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="eventAggregator"></param>
        public ConfigureUsersPageViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            // インタフェースを受け取る
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            // コマンドを定義
            CreateNewCommand = new DelegateCommand(ExecuteCreateNewCommand);
            UpdateCommand = new DelegateCommand(ExecuteUpdateCommand, CanExecuteUpdateCommand);
            GoBackCommand = new DelegateCommand(ExecuteGoBackCommand);

            foreach (var user in UsersDataStore.GetUsers())
            {
                Users.Add(user);
            }
        }

        /// <summary>
        /// 新規作成を実行する
        /// </summary>
        public void ExecuteCreateNewCommand()
        {
            SelectedUser = new User();
        }

        /// <summary>
        /// 更新を実行する
        /// </summary>
        public void ExecuteUpdateCommand()
        {
            if (UsersDataStore.GetUser(SelectedUser.Guid) is null)
            {
                UsersDataStore.UpdateUser(SelectedUser);
            }
            else
            {
                UsersDataStore.AddUser(SelectedUser);
            }
            SelectedUser = new User();
        }

        /// <summary>
        /// 更新が実行可能かどうかを判定する
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteUpdateCommand()
        {
            return SelectedUser != null && !string.IsNullOrEmpty(SelectedUser.Name);
        }

        /// <summary>
        /// 戻る
        /// </summary>
        public void ExecuteGoBackCommand()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(TopPage));
        }
    }
}
