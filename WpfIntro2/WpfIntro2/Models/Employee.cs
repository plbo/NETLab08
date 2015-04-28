using System.Runtime.Serialization;

namespace WpfIntro2.Models
{
	[DataContract]
	public class Employee
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int Age { get; set; }

		[DataMember]
		public decimal Salary { get; set; }

		[DataMember]
		public bool IsHired { get; set; }
	}
}
