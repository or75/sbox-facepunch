using System;
using System.Collections.Generic;
using NativeGlue;

namespace Sandbox
{
	// Token: 0x020000C0 RID: 192
	public static class NavMesh
	{
		// Token: 0x17000265 RID: 613
		// (get) Token: 0x060011F8 RID: 4600 RVA: 0x0004BC2E File Offset: 0x00049E2E
		public static bool IsLoaded
		{
			get
			{
				return NavMesh.IsLoaded();
			}
		}

		/// <summary>
		/// Returns the closest point on the navmesh. Or null if not found.
		/// </summary>
		// Token: 0x060011F9 RID: 4601 RVA: 0x0004BC38 File Offset: 0x00049E38
		public static Vector3? GetClosestPoint(Vector3 point)
		{
			Vector3 v = NavMesh.GetPointOnMesh(point);
			if (v.x == 3.4028235E+38f)
			{
				return null;
			}
			return new Vector3?(v);
		}

		/// <summary>
		/// Returns the closest point on the navmesh. Or null if not found.
		/// </summary>
		// Token: 0x060011FA RID: 4602 RVA: 0x0004BC6C File Offset: 0x00049E6C
		public static Vector3? GetPointWithinRadius(Vector3 point, float minRadius, float maxRadius)
		{
			Vector3 v = NavMesh.GetPointWithinRadius(point, minRadius, maxRadius);
			if (v.x == 3.4028235E+38f)
			{
				return null;
			}
			return new Vector3?(v);
		}

		// Token: 0x060011FB RID: 4603 RVA: 0x0004BCA0 File Offset: 0x00049EA0
		public unsafe static Vector3[] BuildPath(Vector3 point, Vector3 end)
		{
			Vector3* x;
			int c;
			Vector3[] outVec;
			checked
			{
				x = stackalloc Vector3[unchecked((UIntPtr)512) * (UIntPtr)sizeof(Vector3)];
				c = NavMesh.BuildPath(point, end, (IntPtr)((void*)x), 512);
				if (c <= 0)
				{
					return null;
				}
				outVec = new Vector3[c];
			}
			for (int i = 0; i < c; i++)
			{
				outVec[i] = x[c - i - 1];
			}
			return outVec;
		}

		// Token: 0x060011FC RID: 4604 RVA: 0x0004BD08 File Offset: 0x00049F08
		public unsafe static bool BuildPath(Vector3 point, Vector3 end, List<Vector3> outPoints)
		{
			Vector3* x;
			int c;
			checked
			{
				x = stackalloc Vector3[unchecked((UIntPtr)512) * (UIntPtr)sizeof(Vector3)];
				c = NavMesh.BuildPath(point, end, (IntPtr)((void*)x), 512);
				if (c <= 0)
				{
					return false;
				}
			}
			if (Host.IsServer)
			{
				for (int i = 0; i < c; i++)
				{
					if (i <= 0 || x[i].Distance(x[i - 1].WithZ(x[i].z)) >= 1f)
					{
						outPoints.Add(x[i]);
					}
				}
			}
			else
			{
				for (int j = 0; j < c; j++)
				{
					outPoints.Add(x[c - j - 1]);
				}
			}
			return true;
		}

		/// <summary>
		/// Return a path built between a start and an end point. This is different to BuildPath as it returns more detailed information
		/// on each node
		/// </summary>
		// Token: 0x060011FD RID: 4605 RVA: 0x0004BDD0 File Offset: 0x00049FD0
		public unsafe static bool BuildPathEx(Vector3 point, Vector3 end, List<NavNode> outPath, float stepHeight = 20f, float duckHeight = 36f)
		{
			NavNode* x;
			int c;
			checked
			{
				x = stackalloc NavNode[unchecked((UIntPtr)512) * (UIntPtr)sizeof(NavNode)];
				c = NavMesh.BuildPathEx(point, end, (IntPtr)((void*)x), 512, stepHeight, duckHeight);
				if (c <= 0)
				{
					return false;
				}
			}
			if (Host.IsServer)
			{
				for (int i = 0; i < c; i++)
				{
					outPath.Add(x[i]);
				}
			}
			else
			{
				for (int j = 0; j < c; j++)
				{
					outPath.Add(x[c - j - 1]);
				}
			}
			return true;
		}

		/// <summary>
		/// Return a path built between a start and an end point. This is different to BuildPath as it returns more detailed information
		/// on each node
		/// </summary>
		// Token: 0x060011FE RID: 4606 RVA: 0x0004BE5C File Offset: 0x0004A05C
		public unsafe static NavNode[] BuildPathEx(Vector3 point, Vector3 end, float stepHeight = 20f, float duckHeight = 36f)
		{
			NavNode* x;
			int c;
			NavNode[] outVec;
			checked
			{
				x = stackalloc NavNode[unchecked((UIntPtr)512) * (UIntPtr)sizeof(NavNode)];
				c = NavMesh.BuildPathEx(point, end, (IntPtr)((void*)x), 512, stepHeight, duckHeight);
				if (c <= 0)
				{
					return null;
				}
				outVec = new NavNode[c];
			}
			for (int i = 0; i < c; i++)
			{
				outVec[i] = x[c - i - 1];
			}
			return outVec;
		}

		/// <summary>
		/// Finds the closest nav area to a point and returns all the attributes associated with it as a bit flag.
		/// </summary>
		// Token: 0x060011FF RID: 4607 RVA: 0x0004BEC3 File Offset: 0x0004A0C3
		public static NavAreaAttribute GetAreaAttribute(Vector3 point)
		{
			return (NavAreaAttribute)NavMesh.GetNavAreaAttributes(point);
		}
	}
}
