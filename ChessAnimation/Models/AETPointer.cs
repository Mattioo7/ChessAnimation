using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnimation.Models
{
	internal class AETPointer
	{
		public float y_max { get; set; }
		public float x { get; set; }
		public float alfa { get; set; }

		public AETPointer() {}

		public AETPointer(AETPointer aetPointer)
		{
			this.y_max = aetPointer.y_max;
			this.x = aetPointer.x;
			this.alfa = aetPointer.alfa;
		}

		public AETPointer(float y_max, float x, float alfa)
		{
			this.y_max = y_max;
			this.x = x;
			this.alfa = alfa;
		}
	}
}
