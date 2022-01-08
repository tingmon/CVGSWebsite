using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CVGS_Site.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class CVGSContext : DbContext
    {
        public CVGSContext()
        {
        }

        public CVGSContext(DbContextOptions<CVGSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<CreditCardRecord> CreditCardRecord { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeePayCategory> EmployeePayCategory { get; set; }
        public virtual DbSet<EmployeePosition> EmployeePosition { get; set; }
        public virtual DbSet<EsrbContentDescriptor> EsrbContentDescriptor { get; set; }
        public virtual DbSet<EsrbRating> EsrbRating { get; set; }
        public virtual DbSet<EventLog> EventLog { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameCategory> GameCategory { get; set; }
        public virtual DbSet<GameCompany> GameCompany { get; set; }
        public virtual DbSet<GameEsrbContentDescriptor> GameEsrbContentDescriptor { get; set; }
        public virtual DbSet<GamePerspective> GamePerspective { get; set; }
        public virtual DbSet<GameStatus> GameStatus { get; set; }
        public virtual DbSet<GameSubCategory> GameSubCategory { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationType> LocationType { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Platform> Platform { get; set; }
        public virtual DbSet<Population> Population { get; set; }
        public virtual DbSet<PopulationClassification> PopulationClassification { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<SalesRecord> SalesRecord { get; set; }
        public virtual DbSet<Sku> Sku { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplierContact> SupplierContact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS19;Database=CVGS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId)
                    .HasColumnName("CartID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedGameIds).HasMaxLength(2000);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__PersonID__13F1F5EB");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Country_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.Alpha2Code)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("CreditCard_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.CardNumberPrefixList)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CreditCardRecord>(entity =>
            {
                entity.HasKey(e => e.CardId)
                    .HasName("PK__CreditCa__55FECD8EB1A80FB8");

                entity.Property(e => e.CardId)
                    .HasColumnName("CardID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CardCode)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Cvv)
                    .HasColumnName("CVV")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.ExpiryDateMonth)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ExpiryDateYear)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.CardCodeNavigation)
                    .WithMany(p => p.CreditCardRecord)
                    .HasForeignKey(d => d.CardCode)
                    .HasConstraintName("FK__CreditCar__CardC__793DFFAF");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.CreditCardRecord)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CreditCardR__CVV__7849DB76");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Department_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("Employee_PK");

                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Gln)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.PayCategoryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.PositionCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.TerminationDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.DepartmentCodeNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Department_FK");

                entity.HasOne(d => d.GlnNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Gln)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Location_FK");

                entity.HasOne(d => d.PayCategoryCodeNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PayCategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_EmployeePayCategory_FK");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Person_FK");

                entity.HasOne(d => d.PositionCodeNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PositionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_EmployeePosition_FK");
            });

            modelBuilder.Entity<EmployeePayCategory>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("EmployeePayCategory_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<EmployeePosition>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("EmployeePosition_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EsrbContentDescriptor>(entity =>
            {
                entity.Property(e => e.EnglishDescriptor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FrenchDescriptor)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EsrbRating>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("EsrbRatingCode_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.EnglishRating)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FrenchRating)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__EventLog__2DC7BD09B0799862");

                entity.Property(e => e.EventId)
                    .HasColumnName("eventId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasColumnName("creator")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Detail)
                    .HasColumnName("detail")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasColumnName("eventName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.EventLog)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventLog__person__0880433F");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("Game_PK");

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.EnglishDescription).HasMaxLength(4000);

                entity.Property(e => e.EnglishDetail).HasMaxLength(4000);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.EnglishPlayerCount).HasMaxLength(30);

                entity.Property(e => e.EnglishTrailer).HasMaxLength(4000);

                entity.Property(e => e.EsrbRatingCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.FrenchDescription).HasMaxLength(4000);

                entity.Property(e => e.FrenchDetail).HasMaxLength(4000);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.FrenchPlayerCount).HasMaxLength(30);

                entity.Property(e => e.FrenchTrailer).HasMaxLength(4000);

                entity.Property(e => e.GamePerspectiveCode)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.GameStatusCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.EsrbRatingCodeNavigation)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.EsrbRatingCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Game_EsrbRating_FK");

                entity.HasOne(d => d.GameCategory)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.GameCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Game_GameCategory_FK");

                entity.HasOne(d => d.GamePerspectiveCodeNavigation)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.GamePerspectiveCode)
                    .HasConstraintName("Game_GamePerspective_FK");

                entity.HasOne(d => d.GameStatusCodeNavigation)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.GameStatusCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Game_GameStatus_FK");

                entity.HasOne(d => d.GameSubCategory)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.GameSubCategoryId)
                    .HasConstraintName("Game_GameSubCategory_FK");
            });

            modelBuilder.Entity<GameCategory>(entity =>
            {
                entity.Property(e => e.EnglishCategory)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FrenchCategory)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<GameCompany>(entity =>
            {
                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<GameEsrbContentDescriptor>(entity =>
            {
                entity.HasKey(e => new { e.GameGuid, e.EsrbContentDescriptorId })
                    .HasName("GameEsrbContentDescriptor_PK");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.EsrbContentDescriptor)
                    .WithMany(p => p.GameEsrbContentDescriptor)
                    .HasForeignKey(d => d.EsrbContentDescriptorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GameEsrbContentDescriptor_EsrbContentDescriptor_FK");

                entity.HasOne(d => d.GameGu)
                    .WithMany(p => p.GameEsrbContentDescriptor)
                    .HasForeignKey(d => d.GameGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GameEsrbContentDescriptor_Game_FK");
            });

            modelBuilder.Entity<GamePerspective>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("GamePerspective_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.EnglishPerspectiveName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.FrenchPerspectiveName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GameStatus>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("GameStatus_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.EnglishCategory)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.FrenchCategory)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<GameSubCategory>(entity =>
            {
                entity.Property(e => e.EnglishCategory)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FrenchCategory)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.ProductGuid, e.LocationGln })
                    .HasName("Inventory_PK");

                entity.Property(e => e.LocationGln)
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.LocationGlnNavigation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.LocationGln)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inventory_Location_FK");

                entity.HasOne(d => d.ProductGu)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ProductGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inventory_Product_FK");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Gln)
                    .HasName("Location_PK");

                entity.Property(e => e.Gln)
                    .HasMaxLength(11)
                    .IsFixedLength()
                    .HasDefaultValueSql("('?')");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.Fax).HasMaxLength(22);

                entity.Property(e => e.LocalPhone)
                    .IsRequired()
                    .HasMaxLength(22);

                entity.Property(e => e.LocationTypeCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Sequence).ValueGeneratedOnAdd();

                entity.Property(e => e.SiteName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.TollFreePhone).HasMaxLength(22);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Location_Country_FK");

                entity.HasOne(d => d.LocationTypeCodeNavigation)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.LocationTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Location_LocationType_FK");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.ProvinceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Location_Province_FK");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Location_Region_FK");
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("LocationType_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => new { e.Surname, e.GivenName })
                    .HasName("Person_SurnameGivenName_IX");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Extension).HasMaxLength(6);

                entity.Property(e => e.Fax).HasMaxLength(22);

                entity.Property(e => e.GivenName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LandLine).HasMaxLength(22);

                entity.Property(e => e.Mobile).HasMaxLength(22);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('somebody')");

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.ProvinceCode)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Person_Country_FK");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.ProvinceCode)
                    .HasConstraintName("Person_Province_FK");
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Platform_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Population>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("Population_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.City)
                    .HasName("Population_City_IX");

                entity.HasIndex(e => new { e.Surname, e.GivenName })
                    .HasName("Population_SurnameGivenName_IX");

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Amex)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.BankCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BranchAddress).HasMaxLength(60);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Extension).HasMaxLength(6);

                entity.Property(e => e.Fax).HasMaxLength(22);

                entity.Property(e => e.FinancialInstitution).HasMaxLength(50);

                entity.Property(e => e.GivenName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hin)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LandLine).HasMaxLength(22);

                entity.Property(e => e.MasterCard)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Mobile).HasMaxLength(22);

                entity.Property(e => e.PopulationClassificationCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.ProvinceCode)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Sequence).ValueGeneratedOnAdd();

                entity.Property(e => e.Sin)
                    .HasMaxLength(9)
                    .IsFixedLength();

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TransitNumber)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Visa)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Population)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Population_Country_FK");

                entity.HasOne(d => d.PopulationClassificationCodeNavigation)
                    .WithMany(p => p.Population)
                    .HasForeignKey(d => d.PopulationClassificationCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Population_PopulationClassification_FK");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.Population)
                    .HasForeignKey(d => d.ProvinceCode)
                    .HasConstraintName("Population_Province_FK");
            });

            modelBuilder.Entity<PopulationClassification>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PopulationClassification_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("Product_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.Gtin)
                    .HasName("Product_Gtin_IX")
                    .IsClustered();

                entity.HasIndex(e => e.NewSku)
                    .HasName("Product_NewSku_IX");

                entity.HasIndex(e => e.UsedSku)
                    .HasName("Product_UsedSku_IX");

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.AcceptUsed).HasDefaultValueSql("((0))");

                entity.Property(e => e.GameCompanyPartNumber).HasMaxLength(20);

                entity.Property(e => e.Gtin)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsFixedLength();

                entity.Property(e => e.Msrp).HasColumnType("money");

                entity.Property(e => e.NewSku)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsFixedLength()
                    .HasDefaultValueSql("('?')");

                entity.Property(e => e.NewStorePrice).HasColumnType("money");

                entity.Property(e => e.NewWebPrice).HasColumnType("money");

                entity.Property(e => e.PlatformCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.UsedCustomerCredit)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UsedSku)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsFixedLength()
                    .HasDefaultValueSql("('?')");

                entity.Property(e => e.UsedStorePrice)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UsedWebPrice)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.ProductDeveloper)
                    .HasForeignKey(d => d.DeveloperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_GameCompany_Developer_FK");

                entity.HasOne(d => d.GameGu)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.GameGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Game_FK");

                entity.HasOne(d => d.PlatformCodeNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.PlatformCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Platform_FK");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.ProductPublisher)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_GameCompany_Publisher_FK");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("ProvinceLookup_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FederalTax).HasDefaultValueSql("((0))");

                entity.Property(e => e.FederalTaxAcronym)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProvincialTax).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProvincialTaxAcronym)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PstOnGst).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.Property(e => e.RegistrationId)
                    .HasColumnName("registrationId")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Registrat__event__0B5CAFEA");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Review).HasColumnType("text");

                entity.Property(e => e.ReviewDate).HasColumnType("date");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reviews__GameID__69FBBC1F");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reviews__PersonI__690797E6");
            });

            modelBuilder.Entity<SalesRecord>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("PK__SalesRec__FBDF78E982945DA8");

                entity.Property(e => e.RecordId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasMaxLength(30);

                entity.Property(e => e.CreditCard).HasMaxLength(20);

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.ProductList).HasMaxLength(300);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.SalesRecord)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SalesReco__Perso__1C873BEC");
            });

            modelBuilder.Entity<Sku>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.Fax).HasMaxLength(22);

                entity.Property(e => e.LocalPhone)
                    .IsRequired()
                    .HasMaxLength(22);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.TollFreePhone).HasMaxLength(22);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.Property(e => e.WebSite).HasMaxLength(60);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Supplier_Country_FK");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.ProvinceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Supplier_Province_FK");
            });

            modelBuilder.Entity<SupplierContact>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Extension).HasMaxLength(6);

                entity.Property(e => e.GivenName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LandLine).HasMaxLength(22);

                entity.Property(e => e.Mobile).HasMaxLength(22);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierContact)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SupplierContact_Supplier_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<CVGS_Site.Models.Wishlist> Wishlist { get; set; }

        public DbSet<CVGS_Site.Models.Report> Report { get; set; }
    }
}
