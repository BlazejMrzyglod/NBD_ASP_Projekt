using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBD_ASP_Projekt.Models.Models
{
	public class Computers
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }

		[DisplayName("Computer name")]
		public string? Name { get; set; }

		[DisplayName("Creation year")]
		public int? Year { get; set; }

		public string? ImageId { get; set; }
		public bool HasImage() => !string.IsNullOrWhiteSpace(ImageId);
	}
}
