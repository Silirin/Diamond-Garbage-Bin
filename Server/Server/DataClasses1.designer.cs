﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Library")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertAuthors(Authors instance);
    partial void UpdateAuthors(Authors instance);
    partial void DeleteAuthors(Authors instance);
    partial void InsertBooks(Books instance);
    partial void UpdateBooks(Books instance);
    partial void DeleteBooks(Books instance);
    partial void InsertPictures(Pictures instance);
    partial void UpdatePictures(Pictures instance);
    partial void DeletePictures(Pictures instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::Server.Properties.Settings.Default.LibraryConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Authors> Authors
		{
			get
			{
				return this.GetTable<Authors>();
			}
		}
		
		public System.Data.Linq.Table<Books> Books
		{
			get
			{
				return this.GetTable<Books>();
			}
		}
		
		public System.Data.Linq.Table<Pictures> Pictures
		{
			get
			{
				return this.GetTable<Pictures>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Authors")]
	public partial class Authors : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Firstname;
		
		private string _Lastname;
		
		private EntitySet<Books> _Books;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFirstnameChanging(string value);
    partial void OnFirstnameChanged();
    partial void OnLastnameChanging(string value);
    partial void OnLastnameChanged();
    #endregion
		
		public Authors()
		{
			this._Books = new EntitySet<Books>(new Action<Books>(this.attach_Books), new Action<Books>(this.detach_Books));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Firstname", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Firstname
		{
			get
			{
				return this._Firstname;
			}
			set
			{
				if ((this._Firstname != value))
				{
					this.OnFirstnameChanging(value);
					this.SendPropertyChanging();
					this._Firstname = value;
					this.SendPropertyChanged("Firstname");
					this.OnFirstnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Lastname", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Lastname
		{
			get
			{
				return this._Lastname;
			}
			set
			{
				if ((this._Lastname != value))
				{
					this.OnLastnameChanging(value);
					this.SendPropertyChanging();
					this._Lastname = value;
					this.SendPropertyChanged("Lastname");
					this.OnLastnameChanged();
				}
			}
		}

        [global::System.Data.Linq.Mapping.AssociationAttribute(Name="Authors_Books", Storage="_Books", ThisKey="Id", OtherKey="AuthorId")]
		public EntitySet<Books> Books
		{
			get
			{
				return this._Books;
			}
			set
			{
				this._Books.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Books(Books entity)
		{
			this.SendPropertyChanging();
			entity.Authors = this;
		}
		
		private void detach_Books(Books entity)
		{
			this.SendPropertyChanging();
			entity.Authors = null;
		}

		public override string ToString()
		{
			return $"Id: {Id} First Name: {Firstname} Last Name: {Lastname}";
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Books")]
	public partial class Books : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _AuthorId;
		
		private string _Title;
		
		private System.Nullable<int> _PRICE;
		
		private System.Nullable<int> _PAGES;
		
		private string _ExtraInfo;
		
		private EntitySet<Pictures> _Pictures;
		
		private EntityRef<Authors> _Authors;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnAuthorIdChanging(int value);
    partial void OnAuthorIdChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnPRICEChanging(System.Nullable<int> value);
    partial void OnPRICEChanged();
    partial void OnPAGESChanging(System.Nullable<int> value);
    partial void OnPAGESChanged();
    partial void OnExtraInfoChanging(string value);
    partial void OnExtraInfoChanged();
    #endregion
		
		public Books()
		{
			this._Pictures = new EntitySet<Pictures>(new Action<Pictures>(this.attach_Pictures), new Action<Pictures>(this.detach_Pictures));
			this._Authors = default(EntityRef<Authors>);
			OnCreated();
		}

		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuthorId", DbType="Int NOT NULL")]
		public int AuthorId
		{
			get
			{
				return this._AuthorId;
			}
			set
			{
				if ((this._AuthorId != value))
				{
					if (this._Authors.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAuthorIdChanging(value);
					this.SendPropertyChanging();
					this._AuthorId = value;
					this.SendPropertyChanged("AuthorId");
					this.OnAuthorIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PRICE", DbType="Int")]
		public System.Nullable<int> PRICE
		{
			get
			{
				return this._PRICE;
			}
			set
			{
				if ((this._PRICE != value))
				{
					this.OnPRICEChanging(value);
					this.SendPropertyChanging();
					this._PRICE = value;
					this.SendPropertyChanged("PRICE");
					this.OnPRICEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PAGES", DbType="Int")]
		public System.Nullable<int> PAGES
		{
			get
			{
				return this._PAGES;
			}
			set
			{
				if ((this._PAGES != value))
				{
					this.OnPAGESChanging(value);
					this.SendPropertyChanging();
					this._PAGES = value;
					this.SendPropertyChanged("PAGES");
					this.OnPAGESChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExtraInfo", DbType="VarChar(100)")]
		public string ExtraInfo
		{
			get
			{
				return this._ExtraInfo;
			}
			set
			{
				if ((this._ExtraInfo != value))
				{
					this.OnExtraInfoChanging(value);
					this.SendPropertyChanging();
					this._ExtraInfo = value;
					this.SendPropertyChanged("ExtraInfo");
					this.OnExtraInfoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Books_Pictures", Storage="_Pictures", ThisKey="Id", OtherKey="BookId")]
		public EntitySet<Pictures> Pictures
		{
			get
			{
				return this._Pictures;
			}
			set
			{
				this._Pictures.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Authors_Books", Storage="_Authors", ThisKey="AuthorId", OtherKey="Id", IsForeignKey=true)]
		public Authors Authors
		{
			get
			{
				return this._Authors.Entity;
			}
			set
			{
				Authors previousValue = this._Authors.Entity;
				if (((previousValue != value) 
							|| (this._Authors.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Authors.Entity = null;
						previousValue.Books.Remove(this);
					}
					this._Authors.Entity = value;
					if ((value != null))
					{
						value.Books.Add(this);
						this._AuthorId = value.Id;
					}
					else
					{
						this._AuthorId = default(int);
					}
					this.SendPropertyChanged("Authors");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Pictures(Pictures entity)
		{
			this.SendPropertyChanging();
			entity.Books = this;
		}
		
		private void detach_Pictures(Pictures entity)
		{
			this.SendPropertyChanging();
			entity.Books = null;
		}

		public override string ToString()
		{
			return $"Id: {Id} AuthorId: {AuthorId} Title: {Title} Price: {PRICE} Pages: {PAGES} Extra Info: {ExtraInfo}\n Author => ";
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Pictures")]
	public partial class Pictures : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _BookId;
		
		private string _Name;
		
		private System.Data.Linq.Binary _Picture;
		
		private EntityRef<Books> _Books;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnBookIdChanging(int value);
    partial void OnBookIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPictureChanging(System.Data.Linq.Binary value);
    partial void OnPictureChanged();
    #endregion
		
		public Pictures()
		{
			this._Books = default(EntityRef<Books>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookId", DbType="Int NOT NULL")]
		public int BookId
		{
			get
			{
				return this._BookId;
			}
			set
			{
				if ((this._BookId != value))
				{
					if (this._Books.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBookIdChanging(value);
					this.SendPropertyChanging();
					this._BookId = value;
					this.SendPropertyChanged("BookId");
					this.OnBookIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Picture", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Picture
		{
			get
			{
				return this._Picture;
			}
			set
			{
				if ((this._Picture != value))
				{
					this.OnPictureChanging(value);
					this.SendPropertyChanging();
					this._Picture = value;
					this.SendPropertyChanged("Picture");
					this.OnPictureChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Books_Pictures", Storage="_Books", ThisKey="BookId", OtherKey="Id", IsForeignKey=true)]
		public Books Books
		{
			get
			{
				return this._Books.Entity;
			}
			set
			{
				Books previousValue = this._Books.Entity;
				if (((previousValue != value) 
							|| (this._Books.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Books.Entity = null;
						previousValue.Pictures.Remove(this);
					}
					this._Books.Entity = value;
					if ((value != null))
					{
						value.Pictures.Add(this);
						this._BookId = value.Id;
					}
					else
					{
						this._BookId = default(int);
					}
					this.SendPropertyChanged("Books");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
