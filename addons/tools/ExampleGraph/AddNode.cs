using System.ComponentModel.DataAnnotations;
using Tools;

public class AdditionNode : NodeEditor.BaseNode
{
	[Input]
	public float X { get; set; }

	[Input]
	public float Y { get; set; }

	[Output]
	public float Result => X + Y;
}
