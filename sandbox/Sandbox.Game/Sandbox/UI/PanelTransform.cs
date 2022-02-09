using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Sandbox.UI
{
	// Token: 0x02000135 RID: 309
	[Hotload.SkipAttribute]
	public struct PanelTransform
	{
		// Token: 0x06001869 RID: 6249 RVA: 0x000638CC File Offset: 0x00061ACC
		public void BuildTransform(float width, float height)
		{
			this.Transform = Matrix.Identity;
			if (this.List == null)
			{
				return;
			}
			foreach (PanelTransform.Entry e in this.List)
			{
				this.Transform *= e.ToMatrix(width, height);
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x0600186A RID: 6250 RVA: 0x00063948 File Offset: 0x00061B48
		public int Entries
		{
			get
			{
				ImmutableList<PanelTransform.Entry> list = this.List;
				if (list == null)
				{
					return 0;
				}
				return list.Count;
			}
		}

		// Token: 0x0600186B RID: 6251 RVA: 0x0006395C File Offset: 0x00061B5C
		private PanelTransform.Entry GetEntry(int i)
		{
			if (i >= this.Entries)
			{
				return new PanelTransform.Entry
				{
					Type = PanelTransform.EntryType.Invalid
				};
			}
			return this.List[i];
		}

		// Token: 0x0600186C RID: 6252 RVA: 0x00063990 File Offset: 0x00061B90
		public bool AddTranslate(Length? lengthX, Length? lengthY)
		{
			if (lengthX == null || lengthY == null)
			{
				return false;
			}
			if (this.List == null)
			{
				this.List = ImmutableList.Create<PanelTransform.Entry>();
			}
			this.List = this.List.Add(new PanelTransform.Entry
			{
				Type = PanelTransform.EntryType.Translate,
				X = lengthX.Value,
				Y = lengthY.Value
			});
			return true;
		}

		// Token: 0x0600186D RID: 6253 RVA: 0x00063A04 File Offset: 0x00061C04
		public bool AddTranslateX(Length? length)
		{
			if (length == null)
			{
				return false;
			}
			if (this.List == null)
			{
				this.List = ImmutableList.Create<PanelTransform.Entry>();
			}
			this.List = this.List.Add(new PanelTransform.Entry
			{
				Type = PanelTransform.EntryType.Translate,
				X = length.Value
			});
			return true;
		}

		// Token: 0x0600186E RID: 6254 RVA: 0x00063A60 File Offset: 0x00061C60
		public bool AddTranslateY(Length? length)
		{
			if (length == null)
			{
				return false;
			}
			if (this.List == null)
			{
				this.List = ImmutableList.Create<PanelTransform.Entry>();
			}
			this.List = this.List.Add(new PanelTransform.Entry
			{
				Type = PanelTransform.EntryType.Translate,
				Y = length.Value
			});
			return true;
		}

		// Token: 0x0600186F RID: 6255 RVA: 0x00063ABC File Offset: 0x00061CBC
		public bool AddScale(float scale)
		{
			if (this.List == null)
			{
				this.List = ImmutableList.Create<PanelTransform.Entry>();
			}
			this.List = this.List.Add(new PanelTransform.Entry
			{
				Type = PanelTransform.EntryType.Scale,
				Data = Vector3.One * scale
			});
			return true;
		}

		// Token: 0x06001870 RID: 6256 RVA: 0x00063B14 File Offset: 0x00061D14
		public bool AddScale(Vector3 scale)
		{
			if (this.List == null)
			{
				this.List = ImmutableList.Create<PanelTransform.Entry>();
			}
			this.List = this.List.Add(new PanelTransform.Entry
			{
				Type = PanelTransform.EntryType.Scale,
				Data = scale
			});
			return true;
		}

		// Token: 0x06001871 RID: 6257 RVA: 0x00063B60 File Offset: 0x00061D60
		public bool AddSkew(float x, float y, float z)
		{
			if (this.List == null)
			{
				this.List = ImmutableList.Create<PanelTransform.Entry>();
			}
			this.List = this.List.Add(new PanelTransform.Entry
			{
				Type = PanelTransform.EntryType.Skew,
				X = x,
				Y = y,
				Z = z
			});
			return true;
		}

		// Token: 0x06001872 RID: 6258 RVA: 0x00063BCC File Offset: 0x00061DCC
		public bool AddRotation(float x, float y, float z)
		{
			if (this.List == null)
			{
				this.List = ImmutableList.Create<PanelTransform.Entry>();
			}
			this.List = this.List.Add(new PanelTransform.Entry
			{
				Type = PanelTransform.EntryType.Rotation,
				Data = new Vector3(x, y, z)
			});
			return true;
		}

		// Token: 0x06001873 RID: 6259 RVA: 0x00063C20 File Offset: 0x00061E20
		public bool AddMatrix3D(float[] matrix)
		{
			if (this.List == null)
			{
				this.List = ImmutableList.Create<PanelTransform.Entry>();
			}
			this.List = this.List.Add(new PanelTransform.Entry
			{
				Type = PanelTransform.EntryType.Matrix,
				MatrixData = matrix
			});
			return true;
		}

		// Token: 0x06001874 RID: 6260 RVA: 0x00063C6C File Offset: 0x00061E6C
		internal static PanelTransform? Lerp(PanelTransform? a, PanelTransform? b, float delta)
		{
			PanelTransform ma = a.GetValueOrDefault();
			PanelTransform mb = b.GetValueOrDefault();
			int entries = Math.Max(ma.Entries, mb.Entries);
			if (entries <= 0)
			{
				return new PanelTransform?(default(PanelTransform));
			}
			ImmutableList<PanelTransform.Entry>.Builder builder = ImmutableList.CreateBuilder<PanelTransform.Entry>();
			for (int i = 0; i < entries; i++)
			{
				PanelTransform.Entry ea = ma.GetEntry(i);
				PanelTransform.Entry eb = mb.GetEntry(i);
				if (ea.Type == PanelTransform.EntryType.Invalid)
				{
					builder.Add(PanelTransform.Entry.Lerp(eb.GetDefault(), eb, delta));
				}
				else
				{
					if (ea.Type != PanelTransform.EntryType.Invalid)
					{
						builder.Add(PanelTransform.Entry.Lerp(ea, ea.GetDefault(), delta));
					}
					if (eb.Type != PanelTransform.EntryType.Invalid)
					{
						builder.Add(PanelTransform.Entry.Lerp(eb.GetDefault(), eb, delta));
					}
				}
			}
			return new PanelTransform?(new PanelTransform
			{
				List = builder.ToImmutable()
			});
		}

		// Token: 0x06001875 RID: 6261 RVA: 0x00063D58 File Offset: 0x00061F58
		public override bool Equals(object obj)
		{
			if (obj is PanelTransform)
			{
				PanelTransform transform = (PanelTransform)obj;
				if (this.Transform.Equals(transform.Transform))
				{
					return EqualityComparer<ImmutableList<PanelTransform.Entry>>.Default.Equals(this.List, transform.List);
				}
			}
			return false;
		}

		// Token: 0x06001876 RID: 6262 RVA: 0x00063D9F File Offset: 0x00061F9F
		public override int GetHashCode()
		{
			return HashCode.Combine<Matrix, ImmutableList<PanelTransform.Entry>>(this.Transform, this.List);
		}

		// Token: 0x06001877 RID: 6263 RVA: 0x00063DB2 File Offset: 0x00061FB2
		public static bool operator ==(PanelTransform a, PanelTransform b)
		{
			return a.GetHashCode() == b.GetHashCode();
		}

		// Token: 0x06001878 RID: 6264 RVA: 0x00063DD0 File Offset: 0x00061FD0
		public static bool operator !=(PanelTransform a, PanelTransform b)
		{
			return a.GetHashCode() != b.GetHashCode();
		}

		// Token: 0x06001879 RID: 6265 RVA: 0x00063DF4 File Offset: 0x00061FF4
		internal void Parse(string value)
		{
			Parse p = new Parse(value, "nofile");
			p.SkipWhitespaceAndNewlines(null);
			if (this.List == null)
			{
				this.List = ImmutableList.Create<PanelTransform.Entry>();
			}
			while (!p.IsEnd)
			{
				string key = p.ReadWord("(", false);
				p = p.SkipWhitespaceAndNewlines(null);
				if (p.Current != '(')
				{
					throw new Exception("Expecting ( " + p.FileAndLine);
				}
				p.Pointer++;
				p = p.SkipWhitespaceAndNewlines(null);
				string val = p.ReadUntil(")");
				if (p.Current != ')')
				{
					throw new Exception("Expecting ) " + p.FileAndLine);
				}
				p.Pointer++;
				p = p.SkipWhitespaceAndNewlines(null);
				this.Set(key, val);
			}
		}

		// Token: 0x0600187A RID: 6266 RVA: 0x00063EDC File Offset: 0x000620DC
		private bool ParseSkew(string val)
		{
			Parse p = new Parse(val, "nofile");
			float valueX;
			if (!p.TryReadFloat(out valueX))
			{
				return false;
			}
			p = p.SkipWhitespaceAndNewlines(null);
			float x = StyleHelpers.RotationDegrees(valueX, p.ReadUntilWhitespaceOrNewlineOrEnd(null));
			p = p.SkipWhitespaceAndNewlines(null);
			float valueY;
			if (!p.TryReadFloat(out valueY))
			{
				return false;
			}
			float y = StyleHelpers.RotationDegrees(valueY, p.ReadRemaining(true));
			return this.AddSkew(x, y, 0f);
		}

		// Token: 0x0600187B RID: 6267 RVA: 0x00063F50 File Offset: 0x00062150
		private bool ParseTranslate(string val)
		{
			Parse p = new Parse(val, "nofile");
			Length x;
			if (!p.TryReadLength(out x))
			{
				return false;
			}
			Length y;
			if (!p.TryReadLength(out y))
			{
				return this.AddTranslate(new Length?(x), new Length?(default(Length)));
			}
			return this.AddTranslate(new Length?(x), new Length?(y));
		}

		// Token: 0x0600187C RID: 6268 RVA: 0x00063FB0 File Offset: 0x000621B0
		private bool ParseMatrix(string val)
		{
			Parse p = new Parse(val, "nofile");
			float[] matrix = new float[6];
			for (int i = 0; i < 6; i++)
			{
				if (!p.TryReadFloat(out matrix[i]))
				{
					return false;
				}
				p = p.SkipWhitespaceAndNewlines(",");
			}
			return this.AddMatrix3D(new float[]
			{
				matrix[0],
				matrix[1],
				0f,
				0f,
				matrix[2],
				matrix[3],
				0f,
				0f,
				0f,
				0f,
				1f,
				0f,
				matrix[4],
				matrix[5],
				0f,
				1f
			});
		}

		// Token: 0x0600187D RID: 6269 RVA: 0x00064044 File Offset: 0x00062244
		private bool ParseMatrix3D(string val)
		{
			Parse p = new Parse(val, "nofile");
			float[] matrix = new float[16];
			for (int i = 0; i < 16; i++)
			{
				if (!p.TryReadFloat(out matrix[i]))
				{
					return false;
				}
				p = p.SkipWhitespaceAndNewlines(",");
			}
			return this.AddMatrix3D(matrix);
		}

		// Token: 0x0600187E RID: 6270 RVA: 0x0006409C File Offset: 0x0006229C
		private bool Set(string key, string val)
		{
			if (string.Compare(key, "rotate", true) == 0)
			{
				return this.AddRotation(0f, 0f, this.ReadRotation(val));
			}
			if (string.Compare(key, "rotatex", true) == 0)
			{
				return this.AddRotation(this.ReadRotation(val), 0f, 0f);
			}
			if (string.Compare(key, "rotatey", true) == 0)
			{
				return this.AddRotation(0f, this.ReadRotation(val), 0f);
			}
			if (string.Compare(key, "rotatez", true) == 0)
			{
				return this.AddRotation(0f, 0f, this.ReadRotation(val));
			}
			if (string.Compare(key, "scale", true) == 0)
			{
				return this.AddScale(this.ReadVector(val));
			}
			if (string.Compare(key, "scalex", true) == 0)
			{
				return this.AddScale(new Vector3(this.ReadFloat(val), 1f, 1f));
			}
			if (string.Compare(key, "scaley", true) == 0)
			{
				return this.AddScale(new Vector3(1f, this.ReadFloat(val), 1f));
			}
			if (string.Compare(key, "skew", true) == 0)
			{
				return this.ParseSkew(val);
			}
			if (string.Compare(key, "skewx", true) == 0)
			{
				return this.AddSkew(this.ReadRotation(val), 0f, 0f);
			}
			if (string.Compare(key, "skewy", true) == 0)
			{
				return this.AddSkew(0f, this.ReadRotation(val), 0f);
			}
			if (string.Compare(key, "translate", true) == 0)
			{
				return this.ParseTranslate(val);
			}
			if (string.Compare(key, "translatex", true) == 0)
			{
				return this.AddTranslateX(new Length?(Length.Parse(val).GetValueOrDefault()));
			}
			if (string.Compare(key, "translatey", true) == 0)
			{
				return this.AddTranslateY(new Length?(Length.Parse(val).GetValueOrDefault()));
			}
			if (string.Compare(key, "matrix") == 0)
			{
				return this.ParseMatrix(val);
			}
			return string.Compare(key, "matrix3d", true) == 0 && this.ParseMatrix3D(val);
		}

		// Token: 0x0600187F RID: 6271 RVA: 0x000642A8 File Offset: 0x000624A8
		private bool AddEntry(PanelTransform.EntryType type, Vector3 data)
		{
			this.List = this.List.Add(new PanelTransform.Entry
			{
				Type = type,
				Data = data
			});
			return true;
		}

		// Token: 0x06001880 RID: 6272 RVA: 0x000642E0 File Offset: 0x000624E0
		private float ReadFloat(string value)
		{
			Parse p = new Parse(value, "nofile");
			float val;
			if (!p.TryReadFloat(out val))
			{
				return 0f;
			}
			return val;
		}

		// Token: 0x06001881 RID: 6273 RVA: 0x0006430C File Offset: 0x0006250C
		private float ReadRotation(string value)
		{
			Parse p = new Parse(value, "nofile");
			float val;
			if (!p.TryReadFloat(out val))
			{
				return 0f;
			}
			p = p.SkipWhitespaceAndNewlines(null);
			return StyleHelpers.RotationDegrees(val, p.ReadRemaining(true));
		}

		// Token: 0x06001882 RID: 6274 RVA: 0x00064350 File Offset: 0x00062550
		private Vector3 ReadVector(string value)
		{
			Parse p = new Parse(value, "nofile");
			Vector3 val = Vector3.One;
			float x;
			if (p.TryReadFloat(out x))
			{
				val.x = x;
				val.y = x;
			}
			p = p.SkipWhitespaceAndNewlines(null);
			float y;
			if (p.TryReadFloat(out y))
			{
				val.y = y;
			}
			return new Vector3(val);
		}

		// Token: 0x04000671 RID: 1649
		public Matrix Transform;

		// Token: 0x04000672 RID: 1650
		public ImmutableList<PanelTransform.Entry> List;

		// Token: 0x0200028E RID: 654
		public struct Entry
		{
			// Token: 0x06001F72 RID: 8050 RVA: 0x000790F4 File Offset: 0x000772F4
			internal static PanelTransform.Entry Lerp(PanelTransform.Entry a, PanelTransform.Entry b, float delta)
			{
				return new PanelTransform.Entry
				{
					Type = a.Type,
					Data = Vector3.Lerp(a.Data, b.Data, delta, false),
					MatrixData = a.MatrixData.LerpTo(b.MatrixData, delta, false),
					X = (Length.Lerp(a.X, b.X, delta) ?? b.X),
					Y = (Length.Lerp(a.Y, b.Y, delta) ?? b.Y),
					Z = (Length.Lerp(a.Z, b.Z, delta) ?? b.Z)
				};
			}

			// Token: 0x06001F73 RID: 8051 RVA: 0x000791E4 File Offset: 0x000773E4
			public Matrix ToMatrix(float width, float height)
			{
				switch (this.Type)
				{
				case PanelTransform.EntryType.Rotation:
					return Matrix.CreateRotation(this.Data);
				case PanelTransform.EntryType.Scale:
					return Matrix.CreateScale(this.Data);
				case PanelTransform.EntryType.Translate:
					return Matrix.CreateTranslation(new Vector3(this.X.GetPixels(width), this.Y.GetPixels(height), this.Z.GetPixels(0f)));
				case PanelTransform.EntryType.Skew:
					return Matrix.CreateSkew(new Vector2(this.X.GetPixels(width), this.Y.GetPixels(height)));
				case PanelTransform.EntryType.Matrix:
					return Matrix.CreateMatrix3D(this.MatrixData);
				default:
					return Matrix.Identity;
				}
			}

			// Token: 0x06001F74 RID: 8052 RVA: 0x00079298 File Offset: 0x00077498
			public PanelTransform.Entry GetDefault()
			{
				return new PanelTransform.Entry
				{
					Type = this.Type,
					Data = Vector3.One,
					MatrixData = new float[16],
					X = new Length
					{
						Unit = this.X.Unit
					},
					Y = new Length
					{
						Unit = this.Y.Unit
					},
					Z = new Length
					{
						Unit = this.Z.Unit
					}
				};
			}

			// Token: 0x040012C2 RID: 4802
			public PanelTransform.EntryType Type;

			// Token: 0x040012C3 RID: 4803
			public Vector3 Data;

			// Token: 0x040012C4 RID: 4804
			public float[] MatrixData;

			// Token: 0x040012C5 RID: 4805
			public Length X;

			// Token: 0x040012C6 RID: 4806
			public Length Y;

			// Token: 0x040012C7 RID: 4807
			public Length Z;
		}

		// Token: 0x0200028F RID: 655
		public enum EntryType
		{
			// Token: 0x040012C9 RID: 4809
			Invalid,
			// Token: 0x040012CA RID: 4810
			Rotation,
			// Token: 0x040012CB RID: 4811
			Scale,
			// Token: 0x040012CC RID: 4812
			Translate,
			// Token: 0x040012CD RID: 4813
			Skew,
			// Token: 0x040012CE RID: 4814
			Matrix
		}
	}
}
