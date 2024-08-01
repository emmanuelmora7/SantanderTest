﻿namespace SantanderCodeTest.Models
{
	public class Story
	{
		public int id { get; set; }
		public string title { get; set; }
		public string by { get; set; }
		public string type { get; set; }
		public string url { get; set; }
		public long time { get; set; }
		public long score { get; set; }
		public int descendants { get; set; }
	}
}
