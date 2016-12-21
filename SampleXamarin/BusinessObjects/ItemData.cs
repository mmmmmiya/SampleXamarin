using System;
using Realms;

namespace SampleXamarin
{
	public class ItemData : RealmObject
	{
		[PrimaryKey]
		public int Id { get; set; }

		public string Message { get; set; }
	}
}
