using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedPic.Domain;



namespace SharedPic.DataAccess
{
	public class SharedPicDbContext :DbContext
	{

		public DbSet<SharedImage> SharedImages { get; set; }
		public DbSet<Comment> Comments { get; set; }

		public SharedPicDbContext()
			:base("name=DefaultConnection")
		{

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Add additional model configuration steps here

			base.OnModelCreating(modelBuilder);
		}


	}
}
