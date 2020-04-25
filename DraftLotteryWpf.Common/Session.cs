using System;
using System.Collections.Generic;

namespace DraftLotteryWpf.Common
{
    /// <summary>
    /// セッション情報
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Guid
        /// </summary>
        public string Guid { get; private set; }
        /// <summary>
        /// 作成日付
        /// </summary>
        public DateTime CreateDate { get; private set; }
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 結果
        /// </summary>
        public List<User> Result { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Session()
        {
            Guid = System.Guid.NewGuid().ToString();
            CreateDate = DateTime.Now;
        }
    }
}
