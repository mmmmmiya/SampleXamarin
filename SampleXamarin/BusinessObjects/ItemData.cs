using System;
using Realms;

namespace SampleXamarin
{
	public class ItemData : RealmObject
	{
		[PrimaryKey]
		public string Id { get; set; }

		public string Message { get; set; }
	}
}
