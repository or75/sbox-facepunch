using System.ComponentModel.DataAnnotations;
using Tools;

[Display( Name = "Float Input", GroupName = "Generic" )]
public class FloatNode : NodeEditor.BaseNode
{
	[Input]
	public float Float { get; set; }

	[Output, Display( Name = "Out" )]
	public float FloatOut => Float;
}
