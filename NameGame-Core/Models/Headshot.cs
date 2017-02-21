using System;
using Newtonsoft.Json;

namespace WillowTree.NameGame.Core
{
	public class Headshot
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("mimeType")]
		public string MimeType { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("alt")]
		public string AltText { get; set; }

		[JsonProperty("width")]
		public int Width { get; set; }

		[JsonProperty("height")]
		public int Height { get; set; }
	}
}
