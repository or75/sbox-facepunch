using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Sandbox
{
	[Display( Name = "Gib" ), Icon( "broken_image" )]
	public partial class PropGib : Prop
	{
		/// <summary>
		/// Used to track individual break pieces for the purposes of Model Break Commands.
		/// ModelDoc guarantees that these names will be unique.
		/// </summary>
		public string BreakpieceName { get; set; }
	}
}
