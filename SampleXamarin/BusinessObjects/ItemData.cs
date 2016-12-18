using System;
using Realms;

namespace SampleXamarin
{
	public class ItemData : RealmObject
	{
		public int Id { get; set; }
		public string Message { get; set; }
	}
}
