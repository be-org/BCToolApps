using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BcTool.DataModels
{
    public class UserDataModel
    {
        #region
        /// <summary>
        /// ユーザー名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// メールアドレス
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// パスワード
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 所属グループ
        /// </summary>
        public string Group { get; set; }

        #endregion
    }
}
