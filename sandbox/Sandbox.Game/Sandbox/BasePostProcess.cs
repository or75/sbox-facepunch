using System;
using NativeEngine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x020000E7 RID: 231
	public abstract class BasePostProcess
	{
		// Token: 0x06001395 RID: 5013 RVA: 0x0004FA9B File Offset: 0x0004DC9B
		public void SetCombo(string comboName, byte value)
		{
			this.attributes.SetComboValue(comboName, value);
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x0004FAAA File Offset: 0x0004DCAA
		public void SetCombo(string comboName, bool value)
		{
			this.attributes.SetComboValue(comboName, value ? 1 : 0);
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x0004FAC0 File Offset: 0x0004DCC0
		public void Set(string name, in int value)
		{
			this.attributes.SetIntValue(name, value);
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x0004FAD0 File Offset: 0x0004DCD0
		public void Set(string name, in bool value)
		{
			this.attributes.SetBoolValue(name, value);
		}

		// Token: 0x06001399 RID: 5017 RVA: 0x0004FAE0 File Offset: 0x0004DCE0
		public void Set(string name, in string value)
		{
			this.attributes.SetStringValue(name, value);
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x0004FAF0 File Offset: 0x0004DCF0
		public void Set(string name, in float value)
		{
			this.attributes.SetFloatValue(name, value);
		}

		// Token: 0x0600139B RID: 5019 RVA: 0x0004FB00 File Offset: 0x0004DD00
		public void Set(string name, Texture value, in int mipLevel = -1)
		{
			this.attributes.SetTextureValue(name, value.native, mipLevel);
		}

		// Token: 0x0600139C RID: 5020 RVA: 0x0004FB16 File Offset: 0x0004DD16
		public void Set(string name, in Vector2 value)
		{
			this.attributes.SetVector2DValue(name, value);
		}

		// Token: 0x0600139D RID: 5021 RVA: 0x0004FB2A File Offset: 0x0004DD2A
		public void Set(string name, in Vector3 value)
		{
			this.attributes.SetVectorValue(name, value);
		}

		// Token: 0x0600139E RID: 5022 RVA: 0x0004FB3E File Offset: 0x0004DD3E
		public void Set(string name, in Vector4 value)
		{
			this.attributes.SetVector4DValue(name, value);
		}

		// Token: 0x0600139F RID: 5023 RVA: 0x0004FB52 File Offset: 0x0004DD52
		public void Set(string name, in Matrix value)
		{
			this.attributes.SetVMatrixValue(name, value);
		}

		// Token: 0x060013A0 RID: 5024 RVA: 0x0004FB66 File Offset: 0x0004DD66
		public void Set(string name, in ConstantBuffer value, in uint view = 0)
		{
			this.attributes.SetConstantBufferValue(name, value.bufferHandle, view);
		}

		// Token: 0x060013A1 RID: 5025 RVA: 0x0004FB80 File Offset: 0x0004DD80
		~BasePostProcess()
		{
			if (this.attributes.IsValid)
			{
				SboxRender.DeleteRenderAttributes(this.attributes);
			}
		}

		// Token: 0x060013A2 RID: 5026 RVA: 0x0004FBC0 File Offset: 0x0004DDC0
		protected void RenderScreenQuad(bool useFullUvSpace = false)
		{
			Sandbox.Render.DrawScreenQuadEx(this.attributes, useFullUvSpace);
		}

		/// <summary>
		/// Flip the framebuffer or mark the current pass as complete. This is equivalent to
		/// adding a new layer to the post processing effects
		/// </summary>
		// Token: 0x060013A3 RID: 5027 RVA: 0x0004FBCE File Offset: 0x0004DDCE
		protected void NextPass()
		{
			GlobalGameNamespace.PostProcess.FlipFramebuffer();
		}

		/// <summary>
		/// Just copies the current source buffer to the output using the passthrough shader automatically
		/// </summary>
		// Token: 0x060013A4 RID: 5028 RVA: 0x0004FBDA File Offset: 0x0004DDDA
		protected void Passthrough()
		{
			GlobalGameNamespace.PostProcess.FramebufferBlit(false);
		}

		/// <summary>
		/// Resets the framebuffer after the object is disposed. This is mainly useful when you want to render to a temp render target
		/// </summary>
		// Token: 0x060013A5 RID: 5029 RVA: 0x0004FBE8 File Offset: 0x0004DDE8
		protected IDisposable ScopedRenderTarget()
		{
			return default(PostProcessRTScope);
		}

		// Token: 0x060013A6 RID: 5030 RVA: 0x0004FC03 File Offset: 0x0004DE03
		public virtual void Render()
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000481 RID: 1153
		internal CRenderAttributes attributes = SboxRender.CreateRenderAttributes();
	}
}
