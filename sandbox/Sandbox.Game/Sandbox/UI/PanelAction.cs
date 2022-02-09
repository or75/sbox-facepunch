using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sandbox.Internal;

namespace Sandbox.UI
{
	// Token: 0x0200014C RID: 332
	internal class PanelAction
	{
		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x0600192E RID: 6446 RVA: 0x0006A054 File Offset: 0x00068254
		// (set) Token: 0x0600192F RID: 6447 RVA: 0x0006A05C File Offset: 0x0006825C
		public PanelAction.Argument[] Args { get; set; }

		/// <summary>
		/// Parse the code line into multiple PanelActions
		/// </summary>
		// Token: 0x06001930 RID: 6448 RVA: 0x0006A068 File Offset: 0x00068268
		internal static void Parse(string eventName, string codeline, List<PanelAction> events)
		{
			if (eventName.Contains('.'))
			{
				string[] parts = eventName.Split('.', StringSplitOptions.None);
				PanelEventSpecial pa = new PanelEventSpecial
				{
					EventName = parts[0],
					Name = parts[1],
					CodeLine = codeline
				};
				events.Add(pa);
				return;
			}
			foreach (SyntaxNode syntaxNode in CSharpSyntaxTree.ParseText(codeline, CSharpParseOptions.Default.WithKind(SourceCodeKind.Script), "", null, default(CancellationToken)).GetRoot(default(CancellationToken)).ChildNodes())
			{
				syntaxNode.ChildNodes();
				InvocationExpressionSyntax syntax = syntaxNode.DescendantNodes(null, false).OfType<InvocationExpressionSyntax>().FirstOrDefault<InvocationExpressionSyntax>();
				if (syntax != null)
				{
					ExpressionSyntax expression = syntax.Expression;
					MemberAccessExpressionSyntax member = expression as MemberAccessExpressionSyntax;
					PanelAction pa2;
					if (member != null)
					{
						string target = "this";
						IdentifierNameSyntax iname = member.Expression as IdentifierNameSyntax;
						if (iname != null)
						{
							target = iname.Identifier.ToString();
						}
						PanelAction panelAction = new PanelAction();
						panelAction.EventName = eventName;
						panelAction.Target = target;
						panelAction.Name = member.Name.ToString();
						panelAction.Args = syntax.ArgumentList.Arguments.Select((ArgumentSyntax x) => PanelAction.CreateArgument(x.ToString())).ToArray<PanelAction.Argument>();
						pa2 = panelAction;
					}
					else
					{
						PanelAction panelAction2 = new PanelAction();
						panelAction2.EventName = eventName;
						panelAction2.Name = expression.ToString();
						panelAction2.Args = syntax.ArgumentList.Arguments.Select((ArgumentSyntax x) => PanelAction.CreateArgument(x.ToString())).ToArray<PanelAction.Argument>();
						pa2 = panelAction2;
					}
					events.Add(pa2);
				}
			}
		}

		// Token: 0x06001931 RID: 6449 RVA: 0x0006A260 File Offset: 0x00068460
		internal virtual void Apply(Panel panel, Panel context)
		{
			panel.AddEventListener(new Panel.EventCallback
			{
				EventName = this.EventName,
				Event = new Action<Panel.EventCallback, PanelEvent>(this.RunEvent),
				Panel = panel,
				Context = context
			});
		}

		// Token: 0x06001932 RID: 6450 RVA: 0x0006A2AC File Offset: 0x000684AC
		internal void RunEvent(Panel.EventCallback callback, PanelEvent pe)
		{
			try
			{
				object target = this.FindTarget(callback.Panel, callback.Context, this.Target);
				if (target == null)
				{
					GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't find target '{0}' on {1}", new object[] { this.Target, callback.Context }));
				}
				else
				{
					MethodInfo i = target.GetType().GetMethod(this.Name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
					if (i == null)
					{
						GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't find public method '{0}' on {1}", new object[] { this.Name, target }));
					}
					else
					{
						this.CallMethod(i, callback.Panel, callback.Context, target, pe);
					}
				}
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Warning(e, FormattableStringFactory.Create("Template event error when calling {0}", new object[] { this.Name }));
			}
		}

		// Token: 0x06001933 RID: 6451 RVA: 0x0006A39C File Offset: 0x0006859C
		private void CallMethod(MethodInfo m, Panel panel, Panel context, object target, PanelEvent pe)
		{
			ParameterInfo[] param = m.GetParameters();
			object[] args = new object[param.Length];
			for (int i = 0; i < param.Length; i++)
			{
				if (this.Args.Length > i)
				{
					args[i] = this.Args[i].GetValue(panel, context, pe);
				}
				else
				{
					if (!param[i].HasDefaultValue)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 2);
						defaultInterpolatedStringHandler.AppendLiteral("Missing argument for ");
						defaultInterpolatedStringHandler.AppendFormatted(param[i].Name);
						defaultInterpolatedStringHandler.AppendLiteral(" in ");
						defaultInterpolatedStringHandler.AppendFormatted<MethodInfo>(m);
						throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					args[i] = param[i].DefaultValue;
				}
			}
			m.Invoke(target, args);
		}

		// Token: 0x06001934 RID: 6452 RVA: 0x0006A455 File Offset: 0x00068655
		private object FindTarget(Panel panel, Panel context, string name)
		{
			if (name == null)
			{
				return context;
			}
			if (name == "this")
			{
				return panel;
			}
			return null;
		}

		// Token: 0x06001935 RID: 6453 RVA: 0x0006A46C File Offset: 0x0006866C
		public static PanelAction.Argument CreateArgument(string str)
		{
			if (str.StartsWith('\'') && str.EndsWith('\''))
			{
				str = str.Substring(1, str.Length - 2);
				str = str.Replace("\\'", "'");
				return new PanelAction.StringLiteralArgument(str);
			}
			if (str.StartsWith('"') && str.EndsWith('"'))
			{
				str = str.Substring(1, str.Length - 2);
				str = str.Replace("\\\"", "\"");
				return new PanelAction.StringLiteralArgument(str);
			}
			return new PanelAction.RuntimeArgument(str);
		}

		// Token: 0x040006DA RID: 1754
		public string EventName;

		// Token: 0x040006DB RID: 1755
		public string Name;

		// Token: 0x040006DC RID: 1756
		public string Target;

		/// <summary>
		/// This is a mechanism to pass in possibly dynamic arguments
		/// </summary>
		// Token: 0x020002AB RID: 683
		public abstract class Argument
		{
			// Token: 0x06001FC3 RID: 8131
			public abstract object GetValue(Panel thisPanel, Panel context, PanelEvent pe);

			// Token: 0x06001FC4 RID: 8132
			public abstract string GetString();
		}

		/// <summary>
		/// A string literal means that the argument is just a static string, passed in 'liek this
		/// </summary>
		// Token: 0x020002AC RID: 684
		public class StringLiteralArgument : PanelAction.Argument
		{
			// Token: 0x06001FC6 RID: 8134 RVA: 0x00079840 File Offset: 0x00077A40
			public StringLiteralArgument(string val)
			{
				this.String = val;
			}

			// Token: 0x06001FC7 RID: 8135 RVA: 0x0007984F File Offset: 0x00077A4F
			public override object GetValue(Panel thisPanel, Panel context, PanelEvent pe)
			{
				return this.String;
			}

			// Token: 0x06001FC8 RID: 8136 RVA: 0x00079857 File Offset: 0x00077A57
			public override string GetString()
			{
				return this.String;
			}

			// Token: 0x0400130C RID: 4876
			public string String;
		}

		/// <summary>
		/// A string literal means that the argument is just a static string, passed in 'liek this
		/// </summary>
		// Token: 0x020002AD RID: 685
		public class RuntimeArgument : PanelAction.Argument
		{
			// Token: 0x06001FC9 RID: 8137 RVA: 0x0007985F File Offset: 0x00077A5F
			public RuntimeArgument(string name)
			{
				this.name = name;
			}

			// Token: 0x06001FCA RID: 8138 RVA: 0x00079870 File Offset: 0x00077A70
			public override object GetValue(Panel thisPanel, Panel context, PanelEvent pe)
			{
				string text = this.name;
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
				if (num <= 1303515621U)
				{
					if (num != 184981848U)
					{
						if (num != 1113510858U)
						{
							if (num != 1303515621U)
							{
								goto IL_EA;
							}
							if (!(text == "true"))
							{
								goto IL_EA;
							}
						}
						else
						{
							if (!(text == "value"))
							{
								goto IL_EA;
							}
							return pe.Value;
						}
					}
					else
					{
						if (!(text == "false"))
						{
							goto IL_EA;
						}
						goto IL_E3;
					}
				}
				else if (num <= 3453902341U)
				{
					if (num != 2541049336U)
					{
						if (num != 3453902341U)
						{
							goto IL_EA;
						}
						if (!(text == "True"))
						{
							goto IL_EA;
						}
					}
					else
					{
						if (!(text == "False"))
						{
							goto IL_EA;
						}
						goto IL_E3;
					}
				}
				else if (num != 3660305025U)
				{
					if (num != 4264611999U)
					{
						goto IL_EA;
					}
					if (!(text == "event"))
					{
						goto IL_EA;
					}
					return pe;
				}
				else
				{
					if (!(text == "this"))
					{
						goto IL_EA;
					}
					return thisPanel;
				}
				return true;
				IL_E3:
				return false;
				IL_EA:
				throw new Exception("unknown runtime argument '" + this.name + "'");
			}

			// Token: 0x06001FCB RID: 8139 RVA: 0x00079981 File Offset: 0x00077B81
			public override string GetString()
			{
				return string.Empty;
			}

			// Token: 0x0400130D RID: 4877
			public string name;
		}
	}
}
