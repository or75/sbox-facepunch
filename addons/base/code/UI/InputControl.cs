using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Sandbox.UI
{
	/// <summary>
	/// TextArea etc
	/// </summary>
	public interface IInputControl
	{
		bool HasValidationErrors { get; }
	}

}
