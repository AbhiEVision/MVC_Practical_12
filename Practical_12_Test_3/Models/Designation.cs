using System.ComponentModel.DataAnnotations;

namespace Practical_12_Test_3.Models
{
	public class Designation
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string DesignationName { get; set; }
	}
}