using System;
using Sandbox;

namespace ModelDoc
{
	/// <summary>
	/// Indicates that this class/struct should be available as GenericGameData node in ModelDoc
	/// </summary>
	// Token: 0x020001F0 RID: 496
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class GameDataAttribute : LibraryAttribute
	{
		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000C90 RID: 3216 RVA: 0x000158A3 File Offset: 0x00013AA3
		// (set) Token: 0x06000C91 RID: 3217 RVA: 0x000158AB File Offset: 0x00013AAB
		internal string ListName { get; private set; }

		/// <summary>
		/// Indicates that this type compiles as list, rather than a single entry in the model.
		/// This will also affect how you retrieve this data via Model.GetData().
		/// </summary>
		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000C92 RID: 3218 RVA: 0x000158B4 File Offset: 0x00013AB4
		// (set) Token: 0x06000C93 RID: 3219 RVA: 0x000158BC File Offset: 0x00013ABC
		public bool AllowMultiple { get; set; }

		// Token: 0x06000C94 RID: 3220 RVA: 0x000158C5 File Offset: 0x00013AC5
		public GameDataAttribute(string name)
			: base(name)
		{
			if (name == "particle")
			{
				this.ListName = "particles_list";
				return;
			}
			if (name == "break_list_piece")
			{
				this.ListName = "break_list";
			}
		}
	}
}
