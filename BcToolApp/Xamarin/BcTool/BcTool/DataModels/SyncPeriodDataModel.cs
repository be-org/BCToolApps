using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BcTool.DataModels
{
	/// <summary>
	/// 掲示板同期期間用データモデル
	/// </summary>
	public class SyncPeriodDataModel
	{
		private string _syncPeriod;
		/// <summary>
		/// 掲示板同期期間
		/// </summary>
		public string SyncPeriod
		{
			get
			{
				return _syncPeriod;
			}
			set
			{
				_syncPeriod = value;
			}
		}
	}
}
