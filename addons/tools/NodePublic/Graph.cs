using System.Collections.Generic;
using Tools;

namespace NodeEditor;

public class Graph
{
	public List<BaseNode> Nodes { get; protected set; }

	public Graph()
	{
		Nodes = new List<BaseNode>();
	}
}
