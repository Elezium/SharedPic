using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedPic.Domain
{
	public class SharedImage : BaseDomain
	{

		public string User { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }

		public int CommentId { get; set; }
		public List<Comment> Comment { get; set; }

	}
}
