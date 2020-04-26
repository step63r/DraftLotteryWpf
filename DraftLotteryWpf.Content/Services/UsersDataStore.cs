using DraftLotteryWpf.Common;
using System.Collections.ObjectModel;
using System.Linq;

namespace DraftLotteryWpf.Content.Services
{
    /// <summary>
    /// ユーザー情報管理クラス
    /// </summary>
    public static class UsersDataStore
    {
        /// <summary>
        /// ユーザー情報
        /// </summary>
        private static ObservableCollection<User> _users;

        /// <summary>
        /// ファイルパス
        /// </summary>
        private static readonly string _filePath = string.Format(@"{0}\{1}", Path.BaseDir, Path.UsersFileName);

        /// <summary>
        /// 初期化処理
        /// </summary>
        public static void Initialize()
        {
            CreateFileIfNotExists();
            _users = XmlConverter.DeSerialize<ObservableCollection<User>>(_filePath);
            if (_users == null)
            {
                _users = new ObservableCollection<User>();
                XmlConverter.Serialize(_users, _filePath);
            }
        }

        /// <summary>
        /// ユーザー情報一覧を取得する
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<User> GetUsers()
        {
            return _users;
        }

        /// <summary>
        /// ユーザー情報をGUIDで取得する
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static User GetUser(string guid)
        {
            return _users.Where(item => item.Guid == guid).FirstOrDefault();
        }

        /// <summary>
        /// ユーザーを追加する
        /// </summary>
        /// <param name="user"></param>
        public static void AddUser(User user)
        {
            _users.Add(user);
            XmlConverter.Serialize(_users, _filePath);
        }

        /// <summary>
        /// ユーザーを変更する
        /// </summary>
        /// <param name="user"></param>
        public static void UpdateUser(User user)
        {
            var targetUser = _users.Where(item => item.Guid == user.Guid).FirstOrDefault();
            targetUser = user;
            XmlConverter.Serialize(_users, _filePath);
        }

        /// <summary>
        /// ユーザーを削除する
        /// </summary>
        /// <param name="user"></param>
        public static void RemoveUser(User user)
        {
            var targetUser = _users.Where(item => item.Guid == user.Guid).FirstOrDefault();
            _users.Remove(targetUser);
            XmlConverter.Serialize(_users, _filePath);
        }

        /// <summary>
        /// ユーザー情報を全て削除する
        /// </summary>
        public static void Clear()
        {
            _users.Clear();
            XmlConverter.Serialize(_users, _filePath);
        }

        /// <summary>
        /// ファイルがない場合作成する
        /// </summary>
        private static void CreateFileIfNotExists()
        {
            // ディレクトリ取得
            string dirInfo = System.IO.Path.GetDirectoryName(_filePath);
            System.IO.Directory.CreateDirectory(dirInfo);

            // ファイルが存在しなければ作る
            if (!System.IO.File.Exists(_filePath))
            {
                _users = new ObservableCollection<User>();
                XmlConverter.Serialize(_users, _filePath);
            }
        }
    }
}
