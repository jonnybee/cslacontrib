
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Configuration;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
namespace Northwind.CSLA.Library
{
	public delegate void CategoryInfoEvent(object sender);
	/// <summary>
	///	CategoryInfo Generated by MyGeneration using the CSLA Object Mapping template
	/// </summary>
	[Serializable()]
	[TypeConverter(typeof(CategoryInfoConverter))]
	public partial class CategoryInfo : ReadOnlyBase<CategoryInfo>, IDisposable
	{
		public event CategoryInfoEvent Changed;
		private void OnChange()
		{
			if (Changed != null) Changed(this);
		}
		#region Collection
		protected static List<CategoryInfo> _AllList = new List<CategoryInfo>();
		private static Dictionary<string, CategoryInfo> _AllByPrimaryKey = new Dictionary<string, CategoryInfo>();
		private static void ConvertListToDictionary()
		{
			List<CategoryInfo> remove = new List<CategoryInfo>();
			foreach (CategoryInfo tmp in _AllList)
			{
				_AllByPrimaryKey[tmp.CategoryID.ToString()]=tmp; // Primary Key
				remove.Add(tmp);
			}
			foreach (CategoryInfo tmp in remove)
				_AllList.Remove(tmp);
		}
		internal static void AddList(CategoryInfoList lst)
		{
			foreach (CategoryInfo item in lst) _AllList.Add(item);
		}
		public static CategoryInfo GetExistingByPrimaryKey(int categoryID)
		{
			ConvertListToDictionary();
			string key = categoryID.ToString();
			if (_AllByPrimaryKey.ContainsKey(key)) return _AllByPrimaryKey[key]; 
			return null;
		}
		#endregion
		#region Business Methods
		private string _ErrorMessage = string.Empty;
		public string ErrorMessage
		{
			get { return _ErrorMessage; }
		}
		protected Category _Editable;
		private IVEHasBrokenRules HasBrokenRules
		{
			get
			{
				IVEHasBrokenRules hasBrokenRules = null;
				if (_Editable != null)
					hasBrokenRules = _Editable.HasBrokenRules;
				return hasBrokenRules;
			}
		}
		private int _CategoryID;
		[System.ComponentModel.DataObjectField(true, true)]
		public int CategoryID
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _CategoryID;
			}
		}
		private string _CategoryName = string.Empty;
		public string CategoryName
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _CategoryName;
			}
		}
		private string _Description = string.Empty;
		public string Description
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _Description;
			}
		}
		private byte[] _Picture;
		public byte[] Picture
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _Picture;
			}
		}
		private int _CategoryProductCount = 0;
		/// <summary>
		/// Count of CategoryProducts for this Category
		/// </summary>
		public int CategoryProductCount
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _CategoryProductCount;
			}
		}
		private ProductInfoList _CategoryProducts = null;
		[TypeConverter(typeof(ProductInfoListConverter))]
		public ProductInfoList CategoryProducts
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_CategoryProductCount > 0 && _CategoryProducts == null)
					_CategoryProducts = ProductInfoList.GetByCategoryID(_CategoryID);
				return _CategoryProducts;
			}
		}
		// TODO: Replace base CategoryInfo.ToString function as necessary
		/// <summary>
		/// Overrides Base ToString
		/// </summary>
		/// <returns>A string representation of current CategoryInfo</returns>
		//public override string ToString()
		//{
		//  return base.ToString();
		//}
		// TODO: Check CategoryInfo.GetIdValue to assure that the ID returned is unique
		/// <summary>
		/// Overrides Base GetIdValue - Used internally by CSLA to determine equality
		/// </summary>
		/// <returns>A Unique ID for the current CategoryInfo</returns>
		protected override object GetIdValue()
		{
			return _CategoryID;
		}
		#endregion
		#region Factory Methods
		private CategoryInfo()
		{/* require use of factory methods */
			_AllList.Add(this);
		}
		public void Dispose()
		{
			_AllList.Remove(this);
			_AllByPrimaryKey.Remove(CategoryID.ToString());
		}
		public virtual Category Get()
		{
			return _Editable = Category.Get(_CategoryID);
		}
		public static void Refresh(Category tmp)
		{
			CategoryInfo tmpInfo = GetExistingByPrimaryKey(tmp.CategoryID);
			if (tmpInfo == null) return;
			tmpInfo.RefreshFields(tmp);
		}
		private void RefreshFields(Category tmp)
		{
			_CategoryName = tmp.CategoryName;
			_Description = tmp.Description;
			_Picture = tmp.Picture;
			_CategoryInfoExtension.Refresh(this);
			OnChange();// raise an event
		}
		public static CategoryInfo Get(int categoryID)
		{
			//if (!CanGetObject())
			//  throw new System.Security.SecurityException("User not authorized to view a Category");
			try
			{
				CategoryInfo tmp = GetExistingByPrimaryKey(categoryID);
				if (tmp == null)
				{
					tmp = DataPortal.Fetch<CategoryInfo>(new PKCriteria(categoryID));
					_AllList.Add(tmp);
				}
				if (tmp.ErrorMessage == "No Record Found") tmp = null;
				return tmp;
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on CategoryInfo.Get", ex);
			}
		}
		#endregion
		#region Data Access Portal
		internal CategoryInfo(SafeDataReader dr)
		{
			Database.LogInfo("CategoryInfo.Constructor", GetHashCode());
			try
			{
				ReadData(dr);
			}
			catch (Exception ex)
			{
				Database.LogException("CategoryInfo.Constructor", ex);
				throw new DbCslaException("CategoryInfo.Constructor", ex);
			}
		}
		[Serializable()]
		protected class PKCriteria
		{
			private int _CategoryID;
			public int CategoryID
			{ get { return _CategoryID; } }
			public PKCriteria(int categoryID)
			{
				_CategoryID = categoryID;
			}
		}
		private void ReadData(SafeDataReader dr)
		{
			Database.LogInfo("CategoryInfo.ReadData", GetHashCode());
			try
			{
				_CategoryID = dr.GetInt32("CategoryID");
				_CategoryName = dr.GetString("CategoryName");
				_Description = dr.GetString("Description");
				_Picture = (byte[])dr.GetValue("Picture");
				_CategoryProductCount = dr.GetInt32("ProductCount");
			}
			catch (Exception ex)
			{
				Database.LogException("CategoryInfo.ReadData", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("CategoryInfo.ReadData", ex);
			}
		}
		private void DataPortal_Fetch(PKCriteria criteria)
		{
			Database.LogInfo("CategoryInfo.DataPortal_Fetch", GetHashCode());
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					ApplicationContext.LocalContext["cn"] = cn;
					using (SqlCommand cm = cn.CreateCommand())
					{
						cm.CommandType = CommandType.StoredProcedure;
						cm.CommandText = "getCategory";
						cm.Parameters.AddWithValue("@CategoryID", criteria.CategoryID);
						using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
						{
							if (!dr.Read())
							{
								_ErrorMessage = "No Record Found";
								return;
							}
							ReadData(dr);
						}
					}
					// removing of item only needed for local data portal
					if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Client)
						ApplicationContext.LocalContext.Remove("cn");
				}
			}
			catch (Exception ex)
			{
				Database.LogException("CategoryInfo.DataPortal_Fetch", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("CategoryInfo.DataPortal_Fetch", ex);
			}
		}
		#endregion
		// Standard Refresh
		#region extension
		CategoryInfoExtension _CategoryInfoExtension = new CategoryInfoExtension();
		[Serializable()]
		partial class CategoryInfoExtension : extensionBase {}
		[Serializable()]
		class extensionBase
		{
			// Default Refresh
			public virtual void Refresh(CategoryInfo tmp) { }
		}
		#endregion
	} // Class
	#region Converter
	internal class CategoryInfoConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
		{
			if (destType == typeof(string) && value is CategoryInfo)
			{
				// Return the ToString value
				return ((CategoryInfo)value).ToString();
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
	#endregion
} // Namespace