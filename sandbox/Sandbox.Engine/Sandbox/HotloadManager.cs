using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Facebook.Yoga;
using NLog;
using Sandbox.Internal;
using Sandbox.Upgraders;
using Sentry;

namespace Sandbox
{
	// Token: 0x020002AD RID: 685
	[Hotload.SkipAttribute]
	internal class HotloadManager
	{
		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06001154 RID: 4436 RVA: 0x00022ADB File Offset: 0x00020CDB
		// (set) Token: 0x06001155 RID: 4437 RVA: 0x00022AE3 File Offset: 0x00020CE3
		internal bool VerboseLogging { get; set; }

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06001156 RID: 4438 RVA: 0x00022AEC File Offset: 0x00020CEC
		// (set) Token: 0x06001157 RID: 4439 RVA: 0x00022AF4 File Offset: 0x00020CF4
		public bool NeedsSwap { get; set; }

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06001158 RID: 4440 RVA: 0x00022AFD File Offset: 0x00020CFD
		// (set) Token: 0x06001159 RID: 4441 RVA: 0x00022B05 File Offset: 0x00020D05
		public Hotload Hotload { get; protected set; }

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x0600115A RID: 4442 RVA: 0x00022B10 File Offset: 0x00020D10
		// (remove) Token: 0x0600115B RID: 4443 RVA: 0x00022B48 File Offset: 0x00020D48
		public event Action OnSuccess;

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x0600115C RID: 4444 RVA: 0x00022B80 File Offset: 0x00020D80
		// (remove) Token: 0x0600115D RID: 4445 RVA: 0x00022BB8 File Offset: 0x00020DB8
		public event Action OnFail;

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x0600115E RID: 4446 RVA: 0x00022BF0 File Offset: 0x00020DF0
		// (remove) Token: 0x0600115F RID: 4447 RVA: 0x00022C28 File Offset: 0x00020E28
		public event Action PreSwap;

		// Token: 0x06001160 RID: 4448 RVA: 0x00022C60 File Offset: 0x00020E60
		public HotloadManager()
		{
			this.Hotload = new Hotload(true);
			this.Hotload.AddUpgrader<AutoSkipUpgrader>();
			this.Hotload.WatchAssembly("Sandbox.Engine");
			this.Hotload.WatchAssembly("Sandbox.System");
			this.Hotload.IgnoreAssembly<NLog.Logger>();
			this.Hotload.IgnoreAssembly<YogaNode>();
			this.Hotload.IgnoreAssembly<SentryStackFrame>();
		}

		// Token: 0x06001161 RID: 4449 RVA: 0x00022CCB File Offset: 0x00020ECB
		internal void Watch(Assembly assembly)
		{
			this.Hotload.WatchAssembly(assembly);
		}

		// Token: 0x06001162 RID: 4450 RVA: 0x00022CD9 File Offset: 0x00020ED9
		internal void Ignore(Assembly gameAssembly)
		{
			if (gameAssembly == null)
			{
				return;
			}
			this.Hotload.IgnoreAssembly(gameAssembly);
		}

		// Token: 0x06001163 RID: 4451 RVA: 0x00022CF1 File Offset: 0x00020EF1
		internal void Ignore<T>()
		{
			this.Hotload.IgnoreAssembly<T>();
		}

		/// <summary>
		/// Does the actual hotload
		/// </summary>
		// Token: 0x06001164 RID: 4452 RVA: 0x00022D00 File Offset: 0x00020F00
		public void DoSwap()
		{
			Hotload hotload = this.Hotload;
			lock (hotload)
			{
				this.NeedsSwap = false;
				Action preSwap = this.PreSwap;
				if (preSwap != null)
				{
					preSwap();
				}
				this.Hotload.GetOutgoingAssemblies();
				this.Hotload.TraceRoots = this.VerboseLogging;
				try
				{
					HotloadResult info = this.Hotload.UpdateReferences();
					if (info.NoAction)
					{
						return;
					}
					if (info.InstancesProcessed > 0 && this.VerboseLogging)
					{
						HotloadManager.LogVerboseTimingInfo(info);
					}
					if (info.HasErrors)
					{
						foreach (HotloadResultEntry e in info.Errors)
						{
							GlobalSystemNamespace.Log.Warning(e.Exception, e.ToString());
						}
					}
					if (info.HasWarnings)
					{
						foreach (HotloadResultEntry e2 in info.Warnings)
						{
							GlobalSystemNamespace.Log.Warning(e2.ToString());
						}
					}
					Action onSuccess = this.OnSuccess;
					if (onSuccess != null)
					{
						onSuccess();
					}
				}
				catch (Exception e3)
				{
					GlobalSystemNamespace.Log.Warning(e3, "Hotload exception");
					SentrySdk.CaptureException(e3);
					Action onFail = this.OnFail;
					if (onFail != null)
					{
						onFail();
					}
				}
			}
			GC.Collect();
		}

		/// <summary>
		/// Should be called semi regularly, in a semi-safe place. Will perform a hotswap if needed.
		/// </summary>
		// Token: 0x06001165 RID: 4453 RVA: 0x00022EC4 File Offset: 0x000210C4
		internal void Tick()
		{
			if (!this.NeedsSwap)
			{
				return;
			}
			this.DoSwap();
		}

		// Token: 0x06001166 RID: 4454 RVA: 0x00022ED8 File Offset: 0x000210D8
		private static void LogVerboseTimingInfo(HotloadResult info)
		{
			var array = (from x in info.Timings.OrderByDescending((KeyValuePair<string, TypeTimingEntry> x) => x.Value.Milliseconds).Take(20)
				select new
				{
					Key = x.Key,
					Value = x.Value,
					Roots = x.Value.Roots.OrderByDescending((KeyValuePair<string, TimingEntry> y) => y.Value.Milliseconds).Take(10).ToArray<KeyValuePair<string, TimingEntry>>()
				}).ToArray();
			int nameWidth = array.Max(x => Math.Max(x.Key.Length + 2, x.Roots.Max((KeyValuePair<string, TimingEntry> y) => y.Key.Length)));
			int instancesWidth = array.Max(x => Math.Max(x.Value.Instances, x.Roots.Max((KeyValuePair<string, TimingEntry> y) => y.Value.Instances))).ToString().Length;
			int timeWidth = array.Max(x => Math.Max(x.Value.Milliseconds, x.Roots.Max((KeyValuePair<string, TimingEntry> y) => y.Value.Milliseconds))).ToString("0.0").Length;
			int totalWidth = nameWidth + instancesWidth + timeWidth + 12;
			string hdiv = new string('-', totalWidth);
			GlobalSystemNamespace.Log.Info(hdiv);
			var array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				var timingEntry = array2[i];
				GlobalSystemNamespace.Log.Info(string.Concat(new string[]
				{
					"| ",
					timingEntry.Key.PadRight(nameWidth),
					" | ",
					timingEntry.Value.Instances.ToString().PadLeft(instancesWidth),
					" | ",
					timingEntry.Value.Milliseconds.ToString("0.0").PadLeft(timeWidth),
					"ms |"
				}));
				if (timingEntry.Value.Roots != null)
				{
					foreach (KeyValuePair<string, TimingEntry> rootEntry in timingEntry.Roots)
					{
						GlobalSystemNamespace.Log.Info(string.Concat(new string[]
						{
							"|   ",
							rootEntry.Key.PadRight(nameWidth - 2),
							" | ",
							rootEntry.Value.Instances.ToString().PadLeft(instancesWidth),
							" | ",
							rootEntry.Value.Milliseconds.ToString("0.0").PadLeft(timeWidth),
							"ms |"
						}));
					}
					if (timingEntry.Value.Roots.Count > 10)
					{
						Sandbox.Logger log = GlobalSystemNamespace.Log;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
						defaultInterpolatedStringHandler.AppendLiteral("|   ... and ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(timingEntry.Value.Roots.Count - 10);
						defaultInterpolatedStringHandler.AppendLiteral(" other roots");
						log.Info(defaultInterpolatedStringHandler.ToStringAndClear().PadRight(totalWidth - 1) + "|");
					}
					GlobalSystemNamespace.Log.Info(hdiv);
				}
			}
			if (info.Timings.Count > 20)
			{
				Sandbox.Logger log2 = GlobalSystemNamespace.Log;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
				defaultInterpolatedStringHandler.AppendLiteral("| ... and ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(info.Timings.Count - 20);
				defaultInterpolatedStringHandler.AppendLiteral(" other types");
				log2.Info(defaultInterpolatedStringHandler.ToStringAndClear().PadRight(totalWidth - 1) + "|");
				GlobalSystemNamespace.Log.Info(hdiv);
			}
		}

		/// <summary>
		/// Lets the hotload system know that something has changed. If we detect that we are
		/// replacing a dll (instead of just adding one) we'll queue up a swap.
		/// </summary>
		// Token: 0x06001167 RID: 4455 RVA: 0x00023255 File Offset: 0x00021455
		internal void Replace(Assembly oldAssembly, Assembly newAssembly)
		{
			if (this.Hotload.ReplacingAssembly(oldAssembly, newAssembly))
			{
				this.NeedsSwap = true;
			}
		}
	}
}
