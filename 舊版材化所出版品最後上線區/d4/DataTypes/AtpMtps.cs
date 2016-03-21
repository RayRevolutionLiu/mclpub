using System;
using System.Data;
using System.Data.SqlClient;
using MRLPub.d4.Configurations;

namespace MRLPub.d4.DataTypes
{
	#region 應用產業類別、材料特性的單筆資料類別
	/// <summary>
	/// 應用產業類別、材料特性的單筆資料類別
	/// </summary>
	public class AMEntry
	{
		#region Private Member
		private string _contno;
		private int _cls1id;
		private int _cls2id;
		private int _cls3id;
		#endregion

		#region Properties
		public string ContNo
		{
			get{return _contno;}
			set{_contno=value;}
		}

		public int Cls1Id
		{
			get{return _cls1id;}
			set{_cls1id=value;}
		}

		public int Cls2Id
		{
			get{return _cls2id;}
			set{_cls2id=value;}
		}

		public int Cls3Id
		{
			get{return _cls3id;}
			set{_cls3id=value;}
		}
		#endregion

		#region Constructor
		public AMEntry()
		{
		}

		public AMEntry(string contno, int cls1id, int cls2id, int cls3id)
		{
			if (contno == null || contno.Trim()  == "" || contno.Length != 6)
			{
				throw new Exception("新生資料的合約編號不可為null、空字串，或者長度不符");
			}

//			if (cls1id == null)
//			{
//				throw new Exception("類別碼cls1id不可為null");
//			}
//
//			if (cls2id == null)
//			{
//				throw new Exception("類別碼cls2id不可為null");
//			}
//
//			if (cls3id == null)
//			{
//				throw new Exception("類別碼cls3id不可為null");
//			}

			_contno = contno;
			_cls1id = cls1id;
			_cls2id = cls2id;
			_cls3id = cls3id;
		}
		#endregion

	}
	#endregion

	/// <summary>
	/// Summary description for AtpMtps.
	/// </summary>
	public class AtpMtps
	{
		public AtpMtps()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region 取得材料特性或應用產業LV1
		public DataSet GetClass1()
		{
			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);

			string strCmd = "SELECT * FROM c4_class1";

			SqlDataAdapter myCommand = new SqlDataAdapter(strCmd, myConnection);
			
			DataSet ds = new DataSet();

			myCommand.Fill(ds);

			return ds;
		}
		#endregion

		#region 取得材料特性或應用產業LV2
		public DataSet GetClass2(int cls1id)
		{
//			if (cls1id == null)
//			{
//				throw new Exception("第一層代碼不得為null");
//			}

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);

			string strCmd = "SELECT * FROM c4_class2 WHERE cls2_cls1id=" + cls1id.ToString();

			SqlDataAdapter myCommand = new SqlDataAdapter(strCmd, myConnection);
			
			DataSet ds = new DataSet();

			myCommand.Fill(ds);

			return ds;
		}
		#endregion

		#region 取得材料特性或應用產業LV3
		public DataSet GetClass3(int cls1id, int cls2id)
		{
//			if (cls1id == null)
//			{
//				throw new Exception("第一層代碼不得為null");
//			}
//
//			if (cls2id == null)
//			{
//				throw new Exception("第二層代碼不得為null");
//			}
			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);

			string strCmd = "SELECT cls3_cls1id, cls3_cls2id, cls3_cls3id, cls3_cname, "+
				"CASE WHEN LEN(cls3_cls1id)=1 THEN '0'+CONVERT(CHAR(1), cls3_cls1id) ELSE CONVERT(CHAR(2), cls3_cls1id) END + " +
				"CASE WHEN LEN(cls3_cls2id)=1 THEN '0'+CONVERT(CHAR(1), cls3_cls2id) ELSE CONVERT(CHAR(2), cls3_cls2id) END + " +
				"CASE WHEN LEN(cls3_cls3id)=1 THEN '0'+CONVERT(CHAR(1), cls3_cls3id) ELSE CONVERT(CHAR(2), cls3_cls3id) END AS cls3_cls123id "+
				"FROM c4_class3 WHERE cls3_cls1id=" + cls1id.ToString() + " AND cls3_cls2id=" + cls2id.ToString();

			SqlDataAdapter myCommand = new SqlDataAdapter(strCmd, myConnection);
			
			DataSet ds = new DataSet();

			myCommand.Fill(ds);

			return ds;
		}
		#endregion

		/*						*/
		/*		 CLASSES		*/
		/*						*/

		#region 取得合約資料的應用產業類別及材料特性
		/// <summary>
		/// 取得合約資料的應用產業類別及材料特性
		/// </summary>
		/// <param name="contno">合約編號</param>
		/// <returns>合約資料的應用產業類別及材料特性</returns>
		public DataSet GetAtpMtps(string contno)
		{
			if (contno == "")
				throw new Exception("合約編號不可為空白");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);

			string strCmd = "SELECT cls_contno, cls_cls1id, cls_cls2id, cls_cls3id, "+
				"CASE WHEN LEN(cls_cls1id)=1 THEN '0'+CONVERT(CHAR(1), cls_cls1id) ELSE CONVERT(CHAR(2), cls_cls1id) END + " +
				"CASE WHEN LEN(cls_cls2id)=1 THEN '0'+CONVERT(CHAR(1), cls_cls2id) ELSE CONVERT(CHAR(2), cls_cls2id) END + " +
				"CASE WHEN LEN(cls_cls3id)=1 THEN '0'+CONVERT(CHAR(1), cls_cls3id) ELSE CONVERT(CHAR(2), cls_cls3id) END AS cls_cls123id "+
				"FROM c4_classes WHERE cls_contno='" + contno + "'";

			SqlDataAdapter myCommand = new SqlDataAdapter(strCmd, myConnection);
			
			DataSet ds = new DataSet();

			myCommand.Fill(ds);

			return ds;
		}
		#endregion

		#region 儲存合約資料的應用產業類別及材料特性
		/// <summary>
		/// 
		/// </summary>
		/// <param name="contno">合約編號</param>
		/// <param name="objs">AMentry[]應用產業類別及材料特性資料</param>
		/// <returns>儲存是否成功</returns>
		public bool SaveAtpMtps(string contno, object[] objs)
		{
			if (contno == "")
				throw new Exception("合約編號不可為空白");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);

			myConnection.Open();

			SqlCommand myCommand = new SqlCommand();
			myCommand.Connection = myConnection;

			SqlTransaction myTrans = myConnection.BeginTransaction();
			myCommand.Transaction = myTrans;

			bool success = false;

			try
			{
				//先全部砍掉...
				myCommand.CommandText = "DELETE FROM c4_classes WHERE cls_contno='" + contno + "'";
				myCommand.ExecuteNonQuery();

				//再一個一個新增...
				for(int i=0; i<objs.Length; i++)
				{
					myCommand.CommandText = "INSERT INTO c4_classes VALUES ('" + contno + "', " + ((AMEntry)objs.GetValue(i)).Cls1Id.ToString() + ", " + ((AMEntry)objs.GetValue(i)).Cls2Id.ToString() + ", " + ((AMEntry)objs.GetValue(i)).Cls3Id.ToString() + ")";
					myCommand.ExecuteNonQuery();
				}

				myTrans.Commit();
				success = true;
			}
			catch(SqlException ex)
			{
				myTrans.Rollback();
				success = false;
				//throw new Exception("儲存資料時發生錯誤" + ex.Message);
			}
			myConnection.Close();

			return success;
		}
		#endregion
	}
}
