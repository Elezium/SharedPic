using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedPic.Domain
{
	public class Comment : BaseDomain
	{
		public string User { get; set; }
		public string Body { get; set; }
	}
}
