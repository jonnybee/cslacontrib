
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Configuration;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using Csla.Validation;
namespace Northwind.CSLA.Library
{
	/// <summary>
	///	Territory Generated by MyGeneration using the CSLA Object Mapping template
	/// </summary>
	[Serializable()]
	[TypeConverter(typeof(TerritoryConverter))]
	public partial class Territory : BusinessBase<Territory>, IDisposable, IVEHasBrokenRules
	{
		#region Refresh
		private List<Territory> _RefreshTerritories = new List<Territory>();
		private List<TerritoryEmployeeTerritory> _RefreshTerritoryEmployeeTerritories = new List<TerritoryEmployeeTerritory>();
		private void AddToRefreshList(List<Territory> refreshTerritories, List<TerritoryEmployeeTerritory> refreshTerritoryEmployeeTerritories)
		{
			if (IsDirty)
				refreshTerritories.Add(this);
			if (_TerritoryEmployeeTerritories != null && _TerritoryEmployeeTerritories.IsDirty)
			{
				foreach (TerritoryEmployeeTerritory tmp in _TerritoryEmployeeTerritories)
				{
					if(tmp.IsDirty)refreshTerritoryEmployeeTerritories.Add(tmp);
				}
			}
		}
		private void BuildRefreshList()
		{
			_RefreshTerritories = new List<Territory>();
			_RefreshTerritoryEmployeeTerritories = new List<TerritoryEmployeeTerritory>();
			AddToRefreshList(_RefreshTerritories, _RefreshTerritoryEmployeeTerritories);
		}
		private void ProcessRefreshList()
		{
			foreach (Territory tmp in _RefreshTerritories)
			{
				TerritoryInfo.Refresh(tmp);
				if(tmp._MyRegion != null) RegionInfo.Refresh(tmp._MyRegion);
			}
			foreach (TerritoryEmployeeTerritory tmp in _RefreshTerritoryEmployeeTerritories)
			{
				EmployeeTerritoryInfo.Refresh(this, tmp);
			}
		}
		#endregion
		#region Collection
		protected static List<Territory> _AllList = new List<Territory>();
		private static Dictionary<string, Territory> _AllByPrimaryKey = new Dictionary<string, Territory>();
		private static void ConvertListToDictionary()
		{
			List<Territory> remove = new List<Territory>();
			foreach (Territory tmp in _AllList)
			{
				_AllByPrimaryKey[tmp.TerritoryID.ToString()]=tmp; // Primary Key
				remove.Add(tmp);
			}
			foreach (Territory tmp in remove)
				_AllList.Remove(tmp);
		}
		public static Territory GetExistingByPrimaryKey(string territoryID)
		{
			ConvertListToDictionary();
			string key = territoryID.ToString();
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
		private string _TerritoryID = string.Empty;
		[System.ComponentModel.DataObjectField(true, true)]
		public string TerritoryID
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _TerritoryID;
			}
		}
		private string _TerritoryDescription = string.Empty;
		public string TerritoryDescription
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _TerritoryDescription;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (_TerritoryDescription != value)
				{
					_TerritoryDescription = value;
					PropertyHasChanged();
				}
			}
		}
		private int _RegionID;
		public int RegionID
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_MyRegion != null) _RegionID = _MyRegion.RegionID;
				return _RegionID;
			}
		}
		private Region _MyRegion;
		public Region MyRegion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_MyRegion == null && _RegionID != 0) _MyRegion = Region.Get(_RegionID);
				return _MyRegion;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (_MyRegion != value)
				{
					_MyRegion = value;
					PropertyHasChanged();
				}
			}
		}
		private int _TerritoryEmployeeTerritoryCount = 0;
		/// <summary>
		/// Count of TerritoryEmployeeTerritories for this Territory
		/// </summary>
		public int TerritoryEmployeeTerritoryCount
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _TerritoryEmployeeTerritoryCount;
			}
		}
		private TerritoryEmployeeTerritories _TerritoryEmployeeTerritories = null;
		/// <summary>
		/// Related Field
		/// </summary>
		[TypeConverter(typeof(TerritoryEmployeeTerritoriesConverter))]
		public TerritoryEmployeeTerritories TerritoryEmployeeTerritories
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if(_TerritoryEmployeeTerritoryCount > 0 && _TerritoryEmployeeTerritories == null)
					_TerritoryEmployeeTerritories = TerritoryEmployeeTerritories.GetByTerritoryID(TerritoryID);
				else if(_TerritoryEmployeeTerritories == null)
					_TerritoryEmployeeTerritories = TerritoryEmployeeTerritories.New();
				return _TerritoryEmployeeTerritories;
			}
		}
		public override bool IsDirty
		{
			get { return base.IsDirty || (_TerritoryEmployeeTerritories == null? false : _TerritoryEmployeeTerritories.IsDirty) || (_MyRegion == null? false : _MyRegion.IsDirty); }
		}
		public override bool IsValid
		{
			get { return (IsNew && !IsDirty ? true : base.IsValid) && (_TerritoryEmployeeTerritories == null? true : _TerritoryEmployeeTerritories.IsValid) && (_MyRegion == null? true : _MyRegion.IsValid); }
		}
		// TODO: Replace base Territory.ToString function as necessary
		/// <summary>
		/// Overrides Base ToString
		/// </summary>
		/// <returns>A string representation of current Territory</returns>
		//public override string ToString()
		//{
		//  return base.ToString();
		//}
		// TODO: Check Territory.GetIdValue to assure that the ID returned is unique
		/// <summary>
		/// Overrides Base GetIdValue - Used internally by CSLA to determine equality
		/// </summary>
		/// <returns>A Unique ID for the current Territory</returns>
		protected override object GetIdValue()
		{
			return _TerritoryID;
		}
		#endregion
		#region ValidationRules
		[NonSerialized]
		private bool _CheckingBrokenRules=false;
		public IVEHasBrokenRules HasBrokenRules
		{
			get {
				if(_CheckingBrokenRules)return null;
				if ((IsDirty || !IsNew) && BrokenRulesCollection.Count > 0) return this;
				try
				{
					_CheckingBrokenRules=true;
					IVEHasBrokenRules hasBrokenRules = null;
				if (_TerritoryEmployeeTerritories != null && (hasBrokenRules = _TerritoryEmployeeTerritories.HasBrokenRules) != null) return hasBrokenRules;
				if (_MyRegion != null && (hasBrokenRules = _MyRegion.HasBrokenRules) != null) return hasBrokenRules;
					return hasBrokenRules;
				}
				finally
				{
					_CheckingBrokenRules=false;
				}
			}
		}
		public BrokenRulesCollection BrokenRules
		{
			get
			{
				IVEHasBrokenRules hasBrokenRules = HasBrokenRules;
				if (this.Equals(hasBrokenRules)) return BrokenRulesCollection;
				return (hasBrokenRules != null ? hasBrokenRules.BrokenRules : null);
			}
		}
		protected override void AddBusinessRules()
		{
			ValidationRules.AddRule(
				Csla.Validation.CommonRules.StringRequired, "TerritoryID");
			ValidationRules.AddRule(
				Csla.Validation.CommonRules.StringMaxLength,
				new Csla.Validation.CommonRules.MaxLengthRuleArgs("TerritoryID", 20));
			ValidationRules.AddRule(
				Csla.Validation.CommonRules.StringRequired, "TerritoryDescription");
			ValidationRules.AddRule(
				Csla.Validation.CommonRules.StringMaxLength,
				new Csla.Validation.CommonRules.MaxLengthRuleArgs("TerritoryDescription", 50));
			ValidationRules.AddRule<Territory>(MyRegionRequired, "MyRegion");
			//ValidationRules.AddDependantProperty("x", "y");
			_TerritoryExtension.AddValidationRules(ValidationRules);
			// TODO:  Add other validation rules
		}
		protected override void AddInstanceBusinessRules()
		{
			_TerritoryExtension.AddInstanceValidationRules(ValidationRules);
			// TODO:  Add other validation rules
		}
		private static bool MyRegionRequired(Territory target, Csla.Validation.RuleArgs e)
		{
			if (target._RegionID == 0 && target._MyRegion == null) // Required field missing
			{
				e.Description = "Required";
				return false;
			}
			return true;
		}
		// Sample data comparison validation rule
		//private bool StartDateGTEndDate(object target, Csla.Validation.RuleArgs e)
		//{
		//	if (_started > _ended)
		//	{
		//		e.Description = "Start date can't be after end date";
		//		return false;
		//	}
		//	else
		//		return true;
		//}
		#endregion
		#region Authorization Rules
		protected override void AddAuthorizationRules()
		{
			//TODO: Who can read/write which fields
			//AuthorizationRules.AllowRead(TerritoryID, "<Role(s)>");
			//AuthorizationRules.AllowRead(TerritoryDescription, "<Role(s)>");
			//AuthorizationRules.AllowRead(RegionID, "<Role(s)>");
			//AuthorizationRules.AllowWrite(TerritoryDescription, "<Role(s)>");
			//AuthorizationRules.AllowWrite(RegionID, "<Role(s)>");
			_TerritoryExtension.AddAuthorizationRules(AuthorizationRules);
		}
		protected override void AddInstanceAuthorizationRules()
		{
			//TODO: Who can read/write which fields
			_TerritoryExtension.AddInstanceAuthorizationRules(AuthorizationRules);
		}
		public static bool CanAddObject()
		{
			// TODO: Can Add Authorization
			//return Csla.ApplicationContext.User.IsInRole("ProjectManager");
			return true;
		}
		public static bool CanGetObject()
		{
			// TODO: CanGet Authorization
			return true;
		}
		public static bool CanDeleteObject()
		{
			// TODO: CanDelete Authorization
			//bool result = false;
			//if (Csla.ApplicationContext.User.IsInRole("ProjectManager"))result = true;
			//if (Csla.ApplicationContext.User.IsInRole("Administrator"))result = true;
			//return result;
			return true;
		}
		public static bool CanEditObject()
		{
			// TODO: CanEdit Authorization
			//return Csla.ApplicationContext.User.IsInRole("ProjectManager");
			return true;
		}
		#endregion
		#region Factory Methods
		public int CurrentEditLevel
		{ get { return EditLevel; } }
		protected Territory()
		{/* require use of factory methods */
			_AllList.Add(this);
		}
		public void Dispose()
		{
			_AllList.Remove(this);
			_AllByPrimaryKey.Remove(TerritoryID.ToString());
		}
		public static Territory New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Territory");
			try
			{
				return DataPortal.Create<Territory>();
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on Territory.New", ex);
			}
		}
		public static Territory New(string territoryID, string territoryDescription, Region myRegion)
		{
			Territory tmp = Territory.New();
			tmp._TerritoryID = territoryID;
			tmp.TerritoryDescription = territoryDescription;
			tmp.MyRegion = myRegion;
			return tmp;
		}
		public static Territory MakeTerritory(string territoryID, string territoryDescription, Region myRegion)
		{
			Territory tmp = Territory.New(territoryID, territoryDescription, myRegion);
			if (tmp.IsSavable)
				tmp = tmp.Save();
			else
			{
				Csla.Validation.BrokenRulesCollection brc = tmp.ValidationRules.GetBrokenRules();
				tmp._ErrorMessage = "Failed Validation:";
				foreach (Csla.Validation.BrokenRule br in brc)
				{
					tmp._ErrorMessage += "\r\n\tFailure: " + br.RuleName;
				}
			}
			return tmp;
		}
		public static Territory Get(string territoryID)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a Territory");
			try
			{
				Territory tmp = GetExistingByPrimaryKey(territoryID);
				if (tmp == null)
				{
					tmp = DataPortal.Fetch<Territory>(new PKCriteria(territoryID));
					_AllList.Add(tmp);
				}
				if (tmp.ErrorMessage == "No Record Found") tmp = null;
				return tmp;
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on Territory.Get", ex);
			}
		}
		public static Territory Get(SafeDataReader dr)
		{
			if (dr.Read()) return new Territory(dr);
			return null;
		}
		internal Territory(SafeDataReader dr)
		{
			ReadData(dr);
		}
		public static void Delete(string territoryID)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a Territory");
			try
			{
				DataPortal.Delete(new PKCriteria(territoryID));
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on Territory.Delete", ex);
			}
		}
		public override Territory Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a Territory");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Territory");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a Territory");
			try
			{
				BuildRefreshList();
				Territory territory = base.Save();
				_AllList.Add(territory);//Refresh the item in AllList
				ProcessRefreshList();
				return territory;
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on CSLA Save", ex);
			}
		}
		#endregion
		#region Data Access Portal
		[Serializable()]
		protected class PKCriteria
		{
			private string _TerritoryID;
			public string TerritoryID
			{ get { return _TerritoryID; } }
			public PKCriteria(string territoryID)
			{
				_TerritoryID = territoryID;
			}
		}
		// TODO: If Create needs to access DB - It should not be marked RunLocal
		[RunLocal()]
		private new void DataPortal_Create()
		{

			// Database Defaults

			// TODO: Add any defaults that are necessary
			ValidationRules.CheckRules();
		}
		private void ReadData(SafeDataReader dr)
		{
			Database.LogInfo("Territory.ReadData", GetHashCode());
			try
			{
				_TerritoryID = dr.GetString("TerritoryID");
				_TerritoryDescription = dr.GetString("TerritoryDescription");
				_RegionID = dr.GetInt32("RegionID");
				_TerritoryEmployeeTerritoryCount = dr.GetInt32("EmployeeTerritoryCount");
				MarkOld();
			}
			catch (Exception ex)
			{
				Database.LogException("Territory.ReadData", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("Territory.ReadData", ex);
			}
		}
		private void DataPortal_Fetch(PKCriteria criteria)
		{
			Database.LogInfo("Territory.DataPortal_Fetch", GetHashCode());
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					ApplicationContext.LocalContext["cn"] = cn;
					using (SqlCommand cm = cn.CreateCommand())
					{
						cm.CommandType = CommandType.StoredProcedure;
						cm.CommandText = "getTerritory";
						cm.Parameters.AddWithValue("@TerritoryID", criteria.TerritoryID);
						using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
						{
							if (!dr.Read())
							{
								_ErrorMessage = "No Record Found";
								return;
							}
							ReadData(dr);
							// load child objects
							dr.NextResult();
							_TerritoryEmployeeTerritories = TerritoryEmployeeTerritories.Get(dr);
						}
					}
					// removing of item only needed for local data portal
					if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Client)
						ApplicationContext.LocalContext.Remove("cn");
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Territory.DataPortal_Fetch", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("Territory.DataPortal_Fetch", ex);
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		protected override void DataPortal_Insert()
		{
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					ApplicationContext.LocalContext["cn"] = cn;
					SQLInsert();
					// removing of item only needed for local data portal
					if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Client)
						ApplicationContext.LocalContext.Remove("cn");
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Territory.DataPortal_Insert", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("Territory.DataPortal_Insert", ex);
			}
			finally
			{
				Database.LogInfo("Territory.DataPortal_Insert", GetHashCode());
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		internal void SQLInsert()
		{
			if (!this.IsDirty) return;
			try
			{
				if(_MyRegion != null) _MyRegion.Update();
				SqlConnection cn = (SqlConnection)ApplicationContext.LocalContext["cn"];
				using (SqlCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
					cm.CommandText = "addTerritory";
					// Input All Fields - Except Calculated Columns
					cm.Parameters.AddWithValue("@TerritoryID", _TerritoryID);
					cm.Parameters.AddWithValue("@TerritoryDescription", _TerritoryDescription);
					cm.Parameters.AddWithValue("@RegionID", RegionID);
					// Output Calculated Columns
					// TODO: Define any additional output parameters
					cm.ExecuteNonQuery();
					// Save all values being returned from the Procedure
				}
				MarkOld();
				// update child objects
				if (_TerritoryEmployeeTerritories != null) _TerritoryEmployeeTerritories.Update(this);
				Database.LogInfo("Territory.SQLInsert", GetHashCode());
			}
			catch (Exception ex)
			{
				Database.LogException("Territory.SQLInsert", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("Territory.SQLInsert", ex);
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		public static void Add(SqlConnection cn, string territoryID, string territoryDescription, Region myRegion)
		{
			Database.LogInfo("Territory.Add", 0);
			try
			{
				using (SqlCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
					cm.CommandText = "addTerritory";
					// Input All Fields - Except Calculated Columns
					cm.Parameters.AddWithValue("@TerritoryID", territoryID);
					cm.Parameters.AddWithValue("@TerritoryDescription", territoryDescription);
					cm.Parameters.AddWithValue("@RegionID", myRegion.RegionID);
					// Output Calculated Columns
					// TODO: Define any additional output parameters
					cm.ExecuteNonQuery();
					// Save all values being returned from the Procedure
			// No Timestamp value to return
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Territory.Add", ex);
				throw new DbCslaException("Territory.Add", ex);
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		protected override void DataPortal_Update()
		{
			if (!IsDirty) return;	// If not dirty - nothing to do
			Database.LogInfo("Territory.DataPortal_Update", GetHashCode());
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					ApplicationContext.LocalContext["cn"] = cn;
					SQLUpdate();
					// removing of item only needed for local data portal
					if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Client)
						ApplicationContext.LocalContext.Remove("cn");
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Territory.DataPortal_Update", ex);
				_ErrorMessage = ex.Message;
				if (!ex.Message.EndsWith("has been edited by another user.")) throw ex;
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		internal void SQLUpdate()
		{
			if (!IsDirty) return;	// If not dirty - nothing to do
			Database.LogInfo("Territory.SQLUpdate", GetHashCode());
			try
			{
				if(_MyRegion != null) _MyRegion.Update();
				SqlConnection cn = (SqlConnection)ApplicationContext.LocalContext["cn"];
				if (base.IsDirty)
				{
					using (SqlCommand cm = cn.CreateCommand())
					{
						cm.CommandType = CommandType.StoredProcedure;
						cm.CommandText = "updateTerritory";
						// All Fields including Calculated Fields
						cm.Parameters.AddWithValue("@TerritoryID", _TerritoryID);
						cm.Parameters.AddWithValue("@TerritoryDescription", _TerritoryDescription);
						cm.Parameters.AddWithValue("@RegionID", RegionID);
						// Output Calculated Columns
						// TODO: Define any additional output parameters
						cm.ExecuteNonQuery();
						// Save all values being returned from the Procedure
					}
				}
				MarkOld();
				// use the open connection to update child objects
				if (_TerritoryEmployeeTerritories != null) _TerritoryEmployeeTerritories.Update(this);
			}
			catch (Exception ex)
			{
				Database.LogException("Territory.SQLUpdate", ex);
				_ErrorMessage = ex.Message;
				if (!ex.Message.EndsWith("has been edited by another user.")) throw ex;
			}
		}
		internal void Update()
		{
			if (!this.IsDirty) return;
			if (base.IsDirty)
			{
				SqlConnection cn = (SqlConnection)ApplicationContext.LocalContext["cn"];
				if (IsNew)
					Territory.Add(cn, _TerritoryID, _TerritoryDescription, _MyRegion);
				else
					Territory.Update(cn, _TerritoryID, _TerritoryDescription, _MyRegion);
				MarkOld();
			}
			if (_TerritoryEmployeeTerritories != null) _TerritoryEmployeeTerritories.Update(this);
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		public static void Update(SqlConnection cn, string territoryID, string territoryDescription, Region myRegion)
		{
			Database.LogInfo("Territory.Update", 0);
			try
			{
				using (SqlCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
					cm.CommandText = "updateTerritory";
					// Input All Fields - Except Calculated Columns
					cm.Parameters.AddWithValue("@TerritoryID", territoryID);
					cm.Parameters.AddWithValue("@TerritoryDescription", territoryDescription);
					cm.Parameters.AddWithValue("@RegionID", myRegion.RegionID);
					// Output Calculated Columns
					// TODO: Define any additional output parameters
					cm.ExecuteNonQuery();
					// Save all values being returned from the Procedure
				// No Timestamp value to return
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Territory.Update", ex);
				throw new DbCslaException("Territory.Update", ex);
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new PKCriteria(_TerritoryID));
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		private void DataPortal_Delete(PKCriteria criteria)
		{
			Database.LogInfo("Territory.DataPortal_Delete", GetHashCode());
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					using (SqlCommand cm = cn.CreateCommand())
					{
						cm.CommandType = CommandType.StoredProcedure;
						cm.CommandText = "deleteTerritory";
						cm.Parameters.AddWithValue("@TerritoryID", criteria.TerritoryID);
						cm.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Territory.DataPortal_Delete", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("Territory.DataPortal_Delete", ex);
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		public static void Remove(SqlConnection cn, string territoryID)
		{
			Database.LogInfo("Territory.Remove", 0);
			try
			{
				using (SqlCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
					cm.CommandText = "deleteTerritory";
					// Input PK Fields
					cm.Parameters.AddWithValue("@TerritoryID", territoryID);
					// TODO: Define any additional output parameters
					cm.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Territory.Remove", ex);
				throw new DbCslaException("Territory.Remove", ex);
			}
		}
		#endregion
		#region Exists
		public static bool Exists(string territoryID)
		{
			ExistsCommand result;
			try
			{
				result = DataPortal.Execute<ExistsCommand>(new ExistsCommand(territoryID));
				return result.Exists;
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on Territory.Exists", ex);
			}
		}
		[Serializable()]
		private class ExistsCommand : CommandBase
		{
			private string _TerritoryID;
			private bool _exists;
			public bool Exists
			{
				get { return _exists; }
			}
			public ExistsCommand(string territoryID)
			{
				_TerritoryID = territoryID;
			}
			protected override void DataPortal_Execute()
			{
				Database.LogInfo("Territory.DataPortal_Execute", GetHashCode());
				try
				{
					using (SqlConnection cn = Database.Northwind_SqlConnection)
					{
						cn.Open();
						using (SqlCommand cm = cn.CreateCommand())
						{
							cm.CommandType = CommandType.StoredProcedure;
							cm.CommandText = "existsTerritory";
							cm.Parameters.AddWithValue("@TerritoryID", _TerritoryID);
							int count = (int)cm.ExecuteScalar();
							_exists = (count > 0);
						}
					}
				}
				catch (Exception ex)
				{
					Database.LogException("Territory.DataPortal_Execute", ex);
					throw new DbCslaException("Territory.DataPortal_Execute", ex);
				}
			}
		}
		#endregion
		// Standard Default Code
		#region extension
		TerritoryExtension _TerritoryExtension = new TerritoryExtension();
		[Serializable()]
		partial class TerritoryExtension : extensionBase
		{
		}
		[Serializable()]
		class extensionBase
		{
			// Default Values
			// Authorization Rules
			public virtual void AddAuthorizationRules(Csla.Security.AuthorizationRules rules)
			{
				// Needs to be overriden to add new authorization rules
			}
			// Instance Authorization Rules
			public virtual void AddInstanceAuthorizationRules(Csla.Security.AuthorizationRules rules)
			{
				// Needs to be overriden to add new authorization rules
			}
			// Validation Rules
			public virtual void AddValidationRules(Csla.Validation.ValidationRules rules)
			{
				// Needs to be overriden to add new validation rules
			}
			// InstanceValidation Rules
			public virtual void AddInstanceValidationRules(Csla.Validation.ValidationRules rules)
			{
				// Needs to be overriden to add new validation rules
			}
		}
		#endregion
	} // Class
	#region Converter
	internal class TerritoryConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
		{
			if (destType == typeof(string) && value is Territory)
			{
				// Return the ToString value
				return ((Territory)value).ToString();
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
	#endregion
} // Namespace


//// The following is a sample Extension File.  You can use it to create TerritoryExt.cs
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Csla;

//namespace Northwind.CSLA.Library
//{
//  public partial class Territory
//  {
//    partial class TerritoryExtension : extensionBase
//    {
//      // TODO: Override automatic defaults
//      public new void AddAuthorizationRules(Csla.Security.AuthorizationRules rules)
//      {
//        //rules.AllowRead(Dbid, "<Role(s)>");
//      }
//      public new void AddInstanceAuthorizationRules(Csla.Security.AuthorizationRules rules)
//      {
//        //rules.AllowInstanceRead(Dbid, "<Role(s)>");
//      }
//      public new void AddValidationRules(Csla.Validation.ValidationRules rules)
//      {
//        rules.AddRule(
//          Csla.Validation.CommonRules.StringMaxLength,
//          new Csla.Validation.CommonRules.MaxLengthRuleArgs("Name", 100));
//      }
//      public new void AddInstanceValidationRules(Csla.Validation.ValidationRules rules)
//      {
//        rules.AddInstanceRule(/* Instance Validation Rule */);
//      }
//    }
//  }
//}
