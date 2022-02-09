using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020002C6 RID: 710
	public class ModelBuilder
	{
		/// <summary>
		/// Total mass of the physics body (Default is 1000)
		/// </summary>
		// Token: 0x0600121E RID: 4638 RVA: 0x00025B10 File Offset: 0x00023D10
		public ModelBuilder WithMass(float mass)
		{
			this.mass = mass;
			return this;
		}

		/// <summary>
		/// Surface property to use for collision
		/// </summary>
		// Token: 0x0600121F RID: 4639 RVA: 0x00025B1A File Offset: 0x00023D1A
		public ModelBuilder WithSurface(string name)
		{
			this.surfaceProperty = name;
			return this;
		}

		/// <summary>
		/// LOD switch distance increment for each LOD level (Default is 50)
		/// </summary>
		// Token: 0x06001220 RID: 4640 RVA: 0x00025B24 File Offset: 0x00023D24
		public ModelBuilder WithLodDistance(float distance)
		{
			this.lodSwitchDistance = distance;
			return this;
		}

		/// <summary>
		/// Add box collision shape
		/// </summary>
		// Token: 0x06001221 RID: 4641 RVA: 0x00025B30 File Offset: 0x00023D30
		public ModelBuilder AddCollisionBox(Vector3 extents, Vector3? center = null, Rotation? rotation = null)
		{
			this.boxes.Add(new ModelBuilder.BoxDesc
			{
				extents = extents,
				transform = new Transform(center ?? Vector3.Zero, rotation ?? Rotation.Identity, 1f)
			});
			return this;
		}

		/// <summary>
		/// Add sphere collision shape
		/// </summary>
		// Token: 0x06001222 RID: 4642 RVA: 0x00025BA0 File Offset: 0x00023DA0
		public ModelBuilder AddCollisionSphere(float radius, Vector3 center = default(Vector3))
		{
			this.spheres.Add(new ModelBuilder.SphereDesc
			{
				center = center,
				radius = radius
			});
			return this;
		}

		/// <summary>
		/// Add capsule collision shape
		/// </summary>
		// Token: 0x06001223 RID: 4643 RVA: 0x00025BD4 File Offset: 0x00023DD4
		public ModelBuilder AddCollisionCapsule(Vector3 center0, Vector3 center1, float radius)
		{
			this.capsules.Add(new ModelBuilder.CapsuleDesc
			{
				center0 = center0,
				center1 = center1,
				radius = radius
			});
			return this;
		}

		/// <summary>
		/// Add a CONVEX hull collision shape
		/// </summary>
		// Token: 0x06001224 RID: 4644 RVA: 0x00025C10 File Offset: 0x00023E10
		public ModelBuilder AddCollisionHull(Vector3[] vertices, Vector3? center = null, Rotation? rotation = null)
		{
			if (vertices == null)
			{
				throw new ArgumentException("vertices is null");
			}
			int startVertex = this.vertices.Count;
			this.hulls.Add(new ModelBuilder.HullDesc
			{
				startVertex = startVertex,
				numVertex = vertices.Length,
				transform = new Transform(center ?? Vector3.Zero, rotation ?? Rotation.Identity, 1f)
			});
			this.vertices.AddRange(vertices);
			return this;
		}

		/// <summary>
		/// Add a CONCAVE mesh collision shape (This shape can NOT be physically simulated)
		/// </summary>
		// Token: 0x06001225 RID: 4645 RVA: 0x00025CB0 File Offset: 0x00023EB0
		public ModelBuilder AddCollisionMesh(Vector3[] vertices, int[] indices)
		{
			if (vertices == null)
			{
				throw new ArgumentException("vertices is null");
			}
			if (indices == null)
			{
				throw new ArgumentException("indices is null");
			}
			int startVertex = this.vertices.Count;
			int startIndex = this.indices.Count;
			this.meshShapes.Add(new ModelBuilder.MeshDesc
			{
				startVertex = startVertex,
				numVertex = vertices.Length,
				startIndex = startIndex,
				numIndex = indices.Length
			});
			this.vertices.AddRange(vertices);
			this.indices.AddRange(indices);
			return this;
		}

		/// <summary>
		/// Add a mesh
		/// </summary>
		// Token: 0x06001226 RID: 4646 RVA: 0x00025D42 File Offset: 0x00023F42
		public ModelBuilder AddMesh(Mesh mesh)
		{
			if (mesh == null || !mesh.IsValid)
			{
				return this;
			}
			if (!mesh.HasVertexBuffer)
			{
				throw new ArgumentException("Mesh has invalid vertex buffer");
			}
			this.meshes.Add(mesh);
			this.lods.Add(255);
			return this;
		}

		/// <summary>
		/// Add a bunch of meshes
		/// </summary>
		// Token: 0x06001227 RID: 4647 RVA: 0x00025D84 File Offset: 0x00023F84
		public ModelBuilder AddMeshes(Mesh[] meshes)
		{
			if (meshes == null || meshes.Length == 0)
			{
				return this;
			}
			int numMeshes = 0;
			foreach (Mesh mesh in meshes)
			{
				if (mesh != null && mesh.IsValid)
				{
					if (!mesh.HasVertexBuffer)
					{
						throw new ArgumentException("Mesh has invalid vertex buffer");
					}
					this.meshes.Add(mesh);
					numMeshes++;
				}
			}
			if (numMeshes > 0)
			{
				this.lods.AddRange(Enumerable.Repeat<int>(255, numMeshes));
			}
			return this;
		}

		/// <summary>
		/// Add a mesh to a LOD group
		/// </summary>
		// Token: 0x06001228 RID: 4648 RVA: 0x00025DFC File Offset: 0x00023FFC
		public ModelBuilder AddMesh(Mesh mesh, int lod)
		{
			if (lod >= 8)
			{
				throw new ArgumentException("Max LOD count is 8");
			}
			if (mesh == null || !mesh.IsValid)
			{
				return this;
			}
			if (!mesh.HasVertexBuffer)
			{
				throw new ArgumentException("Mesh has invalid vertex buffer");
			}
			if (lod < 0)
			{
				lod = 0;
			}
			lod = 1 << lod;
			this.meshes.Add(mesh);
			this.lods.Add(lod);
			return this;
		}

		/// <summary>
		/// Add a bunch of meshes to a LOD group
		/// </summary>
		// Token: 0x06001229 RID: 4649 RVA: 0x00025E60 File Offset: 0x00024060
		public ModelBuilder AddMeshes(Mesh[] meshes, int lod)
		{
			if (meshes == null || meshes.Length == 0)
			{
				return this;
			}
			if (lod >= 8)
			{
				throw new ArgumentException("Max LOD count is 8");
			}
			int numMeshes = 0;
			foreach (Mesh mesh in meshes)
			{
				if (mesh != null && mesh.IsValid)
				{
					if (!mesh.HasVertexBuffer)
					{
						throw new ArgumentException("Mesh has invalid vertex buffer");
					}
					this.meshes.Add(mesh);
					numMeshes++;
				}
			}
			if (numMeshes == 0)
			{
				return this;
			}
			if (lod < 0)
			{
				lod = 0;
			}
			lod = 1 << lod;
			this.lods.AddRange(Enumerable.Repeat<int>(lod, numMeshes));
			return this;
		}

		// Token: 0x0600122A RID: 4650 RVA: 0x00025EF0 File Offset: 0x000240F0
		public void AddBone(Bone bone)
		{
			this.AddBone(bone.Name, bone.Position, bone.Rotation, bone.ParentName);
		}

		// Token: 0x0600122B RID: 4651 RVA: 0x00025F14 File Offset: 0x00024114
		public void AddBones(Bone[] bones)
		{
			if (bones == null)
			{
				return;
			}
			foreach (Bone bone in bones)
			{
				this.AddBone(bone.Name, bone.Position, bone.Rotation, bone.ParentName);
			}
		}

		/// <summary>
		/// Add a bone to the skeleton
		/// </summary>
		// Token: 0x0600122C RID: 4652 RVA: 0x00025F5C File Offset: 0x0002415C
		public ModelBuilder AddBone(string name, Vector3 position, Rotation rotation, string parentName = null)
		{
			int nameOffset = -1;
			if (!string.IsNullOrWhiteSpace(name))
			{
				nameOffset = this.boneNames.Length;
				this.boneNames.Append(name);
			}
			int parentNameOffset = -1;
			if (!string.IsNullOrWhiteSpace(parentName))
			{
				parentNameOffset = this.boneNames.Length;
				this.boneNames.Append(parentName);
			}
			this.bones.Add(new ModelBuilder.BoneDesc
			{
				nameOffset = nameOffset,
				nameLength = ((name != null) ? name.Length : 0),
				parentNameOffset = parentNameOffset,
				parentNameLength = ((parentName != null) ? parentName.Length : 0),
				position = position,
				rotation = rotation,
				radius = -1f
			});
			return this;
		}

		/// <summary>
		/// Finish creation of model
		/// </summary>
		// Token: 0x0600122D RID: 4653 RVA: 0x0002601C File Offset: 0x0002421C
		public unsafe Model Create()
		{
			IMesh[] renderMeshes = (from x in this.meshes
				where x != null && x.IsValid
				select x.native).ToArray<IMesh>();
			Span<Vector3> vertices_span = CollectionsMarshal.AsSpan<Vector3>(this.vertices);
			Span<int> indices_span = CollectionsMarshal.AsSpan<int>(this.indices);
			Span<ModelBuilder.SphereDesc> spheres_span = CollectionsMarshal.AsSpan<ModelBuilder.SphereDesc>(this.spheres);
			Span<ModelBuilder.CapsuleDesc> capsules_span = CollectionsMarshal.AsSpan<ModelBuilder.CapsuleDesc>(this.capsules);
			Span<ModelBuilder.BoxDesc> boxes_span = CollectionsMarshal.AsSpan<ModelBuilder.BoxDesc>(this.boxes);
			Span<ModelBuilder.HullDesc> hulls_span = CollectionsMarshal.AsSpan<ModelBuilder.HullDesc>(this.hulls);
			Span<ModelBuilder.MeshDesc> meshes_span = CollectionsMarshal.AsSpan<ModelBuilder.MeshDesc>(this.meshShapes);
			Span<int> lods_span = CollectionsMarshal.AsSpan<int>(this.lods);
			Span<ModelBuilder.BoneDesc> bones_span = CollectionsMarshal.AsSpan<ModelBuilder.BoneDesc>(this.bones);
			IMesh[] array;
			IMesh* meshes_ptr;
			if ((array = renderMeshes) == null || array.Length == 0)
			{
				meshes_ptr = null;
			}
			else
			{
				meshes_ptr = &array[0];
			}
			fixed (Vector3* pinnableReference = vertices_span.GetPinnableReference())
			{
				Vector3* vertices_ptr = pinnableReference;
				fixed (int* pinnableReference2 = indices_span.GetPinnableReference())
				{
					int* indices_ptr = pinnableReference2;
					fixed (ModelBuilder.SphereDesc* pinnableReference3 = spheres_span.GetPinnableReference())
					{
						ModelBuilder.SphereDesc* spheres_ptr = pinnableReference3;
						fixed (ModelBuilder.CapsuleDesc* pinnableReference4 = capsules_span.GetPinnableReference())
						{
							ModelBuilder.CapsuleDesc* capsule_ptr = pinnableReference4;
							fixed (ModelBuilder.BoxDesc* pinnableReference5 = boxes_span.GetPinnableReference())
							{
								ModelBuilder.BoxDesc* boxes_ptr = pinnableReference5;
								fixed (ModelBuilder.HullDesc* pinnableReference6 = hulls_span.GetPinnableReference())
								{
									ModelBuilder.HullDesc* hulls_ptr = pinnableReference6;
									fixed (ModelBuilder.MeshDesc* pinnableReference7 = meshes_span.GetPinnableReference())
									{
										ModelBuilder.MeshDesc* meshShapes_ptr = pinnableReference7;
										fixed (int* pinnableReference8 = lods_span.GetPinnableReference())
										{
											int* lods_ptr = pinnableReference8;
											fixed (ModelBuilder.BoneDesc* pinnableReference9 = bones_span.GetPinnableReference())
											{
												ModelBuilder.BoneDesc* bones_ptr = pinnableReference9;
												IModel model = MeshGlue.CreateModel2(this.mass, this.generateHull, this.generateMesh, this.surfaceProperty, this.lodSwitchDistance, (IntPtr)((void*)meshes_ptr), renderMeshes.Length, (IntPtr)((void*)lods_ptr), (IntPtr)((void*)vertices_ptr), this.vertices.Count, (IntPtr)((void*)indices_ptr), this.indices.Count, (IntPtr)((void*)spheres_ptr), this.spheres.Count, (IntPtr)((void*)capsule_ptr), this.capsules.Count, (IntPtr)((void*)boxes_ptr), this.boxes.Count, (IntPtr)((void*)hulls_ptr), this.hulls.Count, (IntPtr)((void*)meshShapes_ptr), this.meshShapes.Count, (IntPtr)((void*)bones_ptr), this.bones.Count, (this.boneNames.Length > 0) ? this.boneNames.ToString() : null);
												long instanceId = model.GetBindingPtr().ToInt64();
												return new Model(model, instanceId);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04001456 RID: 5206
		internal List<Mesh> meshes = new List<Mesh>();

		// Token: 0x04001457 RID: 5207
		internal List<Vector3> vertices = new List<Vector3>();

		// Token: 0x04001458 RID: 5208
		internal List<int> indices = new List<int>();

		// Token: 0x04001459 RID: 5209
		internal List<ModelBuilder.BoxDesc> boxes = new List<ModelBuilder.BoxDesc>();

		// Token: 0x0400145A RID: 5210
		internal List<ModelBuilder.SphereDesc> spheres = new List<ModelBuilder.SphereDesc>();

		// Token: 0x0400145B RID: 5211
		internal List<ModelBuilder.CapsuleDesc> capsules = new List<ModelBuilder.CapsuleDesc>();

		// Token: 0x0400145C RID: 5212
		internal List<ModelBuilder.HullDesc> hulls = new List<ModelBuilder.HullDesc>();

		// Token: 0x0400145D RID: 5213
		internal List<ModelBuilder.MeshDesc> meshShapes = new List<ModelBuilder.MeshDesc>();

		// Token: 0x0400145E RID: 5214
		internal List<int> lods = new List<int>();

		// Token: 0x0400145F RID: 5215
		internal List<ModelBuilder.BoneDesc> bones = new List<ModelBuilder.BoneDesc>();

		// Token: 0x04001460 RID: 5216
		internal StringBuilder boneNames = new StringBuilder();

		// Token: 0x04001461 RID: 5217
		internal float mass = 1000f;

		// Token: 0x04001462 RID: 5218
		internal bool generateHull;

		// Token: 0x04001463 RID: 5219
		internal bool generateMesh;

		// Token: 0x04001464 RID: 5220
		internal string surfaceProperty = "";

		// Token: 0x04001465 RID: 5221
		internal float lodSwitchDistance = 50f;

		// Token: 0x02000413 RID: 1043
		internal struct BoxDesc
		{
			// Token: 0x04001A4E RID: 6734
			public Transform transform;

			// Token: 0x04001A4F RID: 6735
			public Vector3 extents;
		}

		// Token: 0x02000414 RID: 1044
		internal struct SphereDesc
		{
			// Token: 0x04001A50 RID: 6736
			public Vector3 center;

			// Token: 0x04001A51 RID: 6737
			public float radius;
		}

		// Token: 0x02000415 RID: 1045
		internal struct CapsuleDesc
		{
			// Token: 0x04001A52 RID: 6738
			public Vector3 center0;

			// Token: 0x04001A53 RID: 6739
			public Vector3 center1;

			// Token: 0x04001A54 RID: 6740
			public float radius;
		}

		// Token: 0x02000416 RID: 1046
		internal struct HullDesc
		{
			// Token: 0x04001A55 RID: 6741
			public Transform transform;

			// Token: 0x04001A56 RID: 6742
			public int startVertex;

			// Token: 0x04001A57 RID: 6743
			public int numVertex;
		}

		// Token: 0x02000417 RID: 1047
		internal struct MeshDesc
		{
			// Token: 0x04001A58 RID: 6744
			public int startVertex;

			// Token: 0x04001A59 RID: 6745
			public int numVertex;

			// Token: 0x04001A5A RID: 6746
			public int startIndex;

			// Token: 0x04001A5B RID: 6747
			public int numIndex;
		}

		// Token: 0x02000418 RID: 1048
		internal struct BoneDesc
		{
			// Token: 0x04001A5C RID: 6748
			public int nameOffset;

			// Token: 0x04001A5D RID: 6749
			public int nameLength;

			// Token: 0x04001A5E RID: 6750
			public int parentNameOffset;

			// Token: 0x04001A5F RID: 6751
			public int parentNameLength;

			// Token: 0x04001A60 RID: 6752
			public Vector3 position;

			// Token: 0x04001A61 RID: 6753
			public Rotation rotation;

			// Token: 0x04001A62 RID: 6754
			public float radius;
		}
	}
}
