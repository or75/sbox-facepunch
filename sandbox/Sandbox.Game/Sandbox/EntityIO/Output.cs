using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using NativeEngine;
using Sandbox.Internal;
using Sandbox.Internal.Globals;

namespace Sandbox.EntityIO
{
	// Token: 0x0200016B RID: 363
	internal class Output
	{
		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06001B49 RID: 6985 RVA: 0x0006E429 File Offset: 0x0006C629
		// (set) Token: 0x06001B4A RID: 6986 RVA: 0x0006E430 File Offset: 0x0006C630
		[ServerVar(null, Help = "If above 0, enables map io debug/visualization and controls the length of the visualization")]
		public static float debug_mapio { get; set; } = 0f;

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06001B4B RID: 6987 RVA: 0x0006E438 File Offset: 0x0006C638
		// (set) Token: 0x06001B4C RID: 6988 RVA: 0x0006E440 File Offset: 0x0006C640
		public string OutputName { get; internal set; }

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x06001B4D RID: 6989 RVA: 0x0006E449 File Offset: 0x0006C649
		// (set) Token: 0x06001B4E RID: 6990 RVA: 0x0006E451 File Offset: 0x0006C651
		public string TargetName { get; internal set; }

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x06001B4F RID: 6991 RVA: 0x0006E45A File Offset: 0x0006C65A
		// (set) Token: 0x06001B50 RID: 6992 RVA: 0x0006E462 File Offset: 0x0006C662
		public string InputName { get; internal set; }

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x06001B51 RID: 6993 RVA: 0x0006E46B File Offset: 0x0006C66B
		// (set) Token: 0x06001B52 RID: 6994 RVA: 0x0006E473 File Offset: 0x0006C673
		public string Param { get; internal set; }

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x06001B53 RID: 6995 RVA: 0x0006E47C File Offset: 0x0006C67C
		// (set) Token: 0x06001B54 RID: 6996 RVA: 0x0006E484 File Offset: 0x0006C684
		public float Delay { get; internal set; }

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06001B55 RID: 6997 RVA: 0x0006E48D File Offset: 0x0006C68D
		// (set) Token: 0x06001B56 RID: 6998 RVA: 0x0006E495 File Offset: 0x0006C695
		public int TimesToFire { get; internal set; }

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06001B57 RID: 6999 RVA: 0x0006E49E File Offset: 0x0006C69E
		// (set) Token: 0x06001B58 RID: 7000 RVA: 0x0006E4A6 File Offset: 0x0006C6A6
		public Action<Entity, Entity, object> Delegate { get; internal set; }

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x06001B59 RID: 7001 RVA: 0x0006E4AF File Offset: 0x0006C6AF
		// (set) Token: 0x06001B5A RID: 7002 RVA: 0x0006E4B7 File Offset: 0x0006C6B7
		internal EntityIOTargetType TargetType { get; set; }

		// Token: 0x06001B5B RID: 7003 RVA: 0x0006E4C0 File Offset: 0x0006C6C0
		internal async ValueTask Fire(Entity entity, Entity activator, object value)
		{
			if (this.Delay > 0f)
			{
				await GameTask.DelaySeconds(this.Delay);
			}
			object actualParameter = ((!string.IsNullOrEmpty(this.Param)) ? this.Param : value);
			if (this.Delegate != null)
			{
				this.Delegate(entity, activator, value);
			}
			else
			{
				bool fired = false;
				foreach (Entity target in this.BuildTargets(entity).ToList<Entity>())
				{
					fired = true;
					InputAttribute method;
					if (!target.ClassInfo.InputMethods.TryGetValue(this.InputName, out method))
					{
						if (Output.debug_mapio > 0f)
						{
							GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("{0}.{1} => Missing input: {2}.{3}({4})", new object[] { entity, this.OutputName, this.TargetName, this.InputName, actualParameter }));
							GlobalGameNamespace.DebugOverlay.Text(entity.Position, this.OutputName + " =>", Output.missing_io, Output.debug_mapio, (float)Output.IOMaxVisibleDist);
							GlobalGameNamespace.DebugOverlay.Line(entity.Position, target.Position, Output.missing_io.WithAlpha(0.4f), Output.debug_mapio, false);
							GlobalGameNamespace.DebugOverlay.Line(entity.Position, target.Position, Output.missing_io, Output.debug_mapio / 10f, false);
							Sandbox.Internal.Globals.DebugOverlay debugOverlay = GlobalGameNamespace.DebugOverlay;
							Vector3 position = target.Position;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 2);
							defaultInterpolatedStringHandler.AppendLiteral("\n=> Missing input: ");
							defaultInterpolatedStringHandler.AppendFormatted(this.InputName);
							defaultInterpolatedStringHandler.AppendLiteral("(");
							defaultInterpolatedStringHandler.AppendFormatted<object>(actualParameter);
							defaultInterpolatedStringHandler.AppendLiteral(")");
							debugOverlay.Text(position, defaultInterpolatedStringHandler.ToStringAndClear(), Output.missing_io, Output.debug_mapio, (float)Output.IOMaxVisibleDist);
						}
					}
					else
					{
						if (Output.debug_mapio > 0f)
						{
							GlobalGameNamespace.DebugOverlay.Text(entity.Position, this.OutputName + " =>", Output.good_io, Output.debug_mapio, (float)Output.IOMaxVisibleDist);
							GlobalGameNamespace.DebugOverlay.Line(entity.Position, target.Position, Output.good_io.WithAlpha(0.4f), Output.debug_mapio, false);
							GlobalGameNamespace.DebugOverlay.Line(entity.Position, target.Position, Output.good_io, Output.debug_mapio / 10f, false);
							Sandbox.Internal.Globals.DebugOverlay debugOverlay2 = GlobalGameNamespace.DebugOverlay;
							Vector3 position2 = target.Position;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 2);
							defaultInterpolatedStringHandler.AppendLiteral("\n=> ");
							defaultInterpolatedStringHandler.AppendFormatted(this.InputName);
							defaultInterpolatedStringHandler.AppendLiteral("(");
							defaultInterpolatedStringHandler.AppendFormatted<object>(actualParameter);
							defaultInterpolatedStringHandler.AppendLiteral(")");
							debugOverlay2.Text(position2, defaultInterpolatedStringHandler.ToStringAndClear(), Output.good_io, Output.debug_mapio, (float)Output.IOMaxVisibleDist);
							GlobalGameNamespace.Log.Trace(FormattableStringFactory.Create("{0}.{1} => {2}.{3}({4})", new object[] { entity, this.OutputName, this.TargetName, this.InputName, actualParameter }));
						}
						ParameterInfo[] parameters = method.MethodInfo.GetParameters();
						object[] callargs = new object[parameters.Length];
						int arg = 0;
						foreach (ParameterInfo t in parameters)
						{
							if (t.ParameterType == typeof(Entity))
							{
								callargs[arg++] = activator;
							}
							else if (t.ParameterType == typeof(string))
							{
								callargs[arg++] = actualParameter.ToString();
							}
							else if (t.ParameterType == typeof(float))
							{
								callargs[arg++] = float.Parse(actualParameter.ToString());
							}
							else if (t.ParameterType == typeof(int))
							{
								callargs[arg++] = int.Parse(actualParameter.ToString());
							}
							else if (t.ParameterType == typeof(double))
							{
								callargs[arg++] = double.Parse(actualParameter.ToString());
							}
							else if (t.ParameterType == actualParameter.GetType())
							{
								callargs[arg++] = actualParameter;
							}
							else
							{
								GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("EntityIO: Unhandled type {0}", new object[] { t }));
								callargs[arg++] = null;
							}
						}
						method.MethodInfo.Invoke(target, callargs);
					}
				}
				if (!fired && Output.debug_mapio > 0f)
				{
					GlobalGameNamespace.DebugOverlay.Text(entity.Position, this.OutputName + " => Missing Entity", Output.missing_io, Output.debug_mapio, (float)Output.IOMaxVisibleDist);
					GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("{0}.{1} => Missing entity: {2}.{3}({4})", new object[] { entity, this.OutputName, this.TargetName, this.InputName, actualParameter }));
				}
			}
		}

		/// <summary>
		/// Get a list of entities that are appropriate targets for this
		/// </summary>
		// Token: 0x06001B5C RID: 7004 RVA: 0x0006E51B File Offset: 0x0006C71B
		internal IEnumerable<Entity> BuildTargets(Entity entity)
		{
			if (this.TargetName == "!self")
			{
				yield return entity;
			}
			foreach (Entity ent in Entity.All)
			{
				if (this.ShouldSendToEntity(ent))
				{
					yield return ent;
				}
			}
			IEnumerator<Entity> enumerator = null;
			yield break;
			yield break;
		}

		/// <summary>
		/// TODO - TargetType
		/// </summary>
		// Token: 0x06001B5D RID: 7005 RVA: 0x0006E532 File Offset: 0x0006C732
		private bool ShouldSendToEntity(Entity ent)
		{
			return !string.IsNullOrEmpty(ent.Name) && string.Compare(ent.Name, this.TargetName, true) == 0;
		}

		// Token: 0x04000778 RID: 1912
		internal static Color missing_io = Color.FromBytes(255, 255, 0, 255);

		// Token: 0x04000779 RID: 1913
		internal static Color good_io = Color.FromBytes(0, 255, 0, 255);

		// Token: 0x0400077A RID: 1914
		internal static int IOMaxVisibleDist = 2000;
	}
}
