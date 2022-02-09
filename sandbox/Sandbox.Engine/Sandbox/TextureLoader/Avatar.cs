using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Sandbox.Internal;
using Steamworks;
using Steamworks.Data;

namespace Sandbox.TextureLoader
{
	// Token: 0x020002E5 RID: 741
	internal static class Avatar
	{
		// Token: 0x060013BA RID: 5050 RVA: 0x00029D2B File Offset: 0x00027F2B
		internal static bool IsAppropriate(string url)
		{
			return url.StartsWith("avatar:") || url.StartsWith("avatarbig:") || url.StartsWith("avatarsmall:");
		}

		// Token: 0x060013BB RID: 5051 RVA: 0x00029D54 File Offset: 0x00027F54
		internal static Texture Load(string filename)
		{
			Texture result;
			try
			{
				Texture placeholder = Texture.Create(1, 1, ImageFormat.RGBA8888).Finish();
				placeholder.IsLoaded = false;
				Avatar.LoadIntoTexture(filename, placeholder);
				result = placeholder;
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't Load Avatar {0} ({1})", new object[] { filename, e.Message }));
				result = null;
			}
			return result;
		}

		// Token: 0x060013BC RID: 5052 RVA: 0x00029DC4 File Offset: 0x00027FC4
		internal static async Task LoadIntoTexture(string url, Texture placeholder)
		{
			try
			{
				int size = 0;
				string filename = url;
				if (filename.StartsWith("avatar:"))
				{
					filename = filename.Substring("avatar:".Length);
				}
				if (filename.StartsWith("avatarbig:"))
				{
					filename = filename.Substring("avatarbig:".Length);
					size = 1;
				}
				if (filename.StartsWith("avatarsmall:"))
				{
					filename = filename.Substring("avatarsmall:".Length);
					size = 2;
				}
				filename = filename.Trim(new char[] { '/', ' ' });
				ulong steamid;
				if (!ulong.TryParse(filename, out steamid))
				{
					GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("AvatarLoader - Couldn't parse steamid {0}", new object[] { filename }));
				}
				else
				{
					if (steamid >= 90071996842377216UL)
					{
						steamid = Rand.FromArray<ulong>(new ulong[]
						{
							76561198076731362UL, 76561198115447501UL, 76561198081295106UL, 76561198165412225UL, 76561198023414915UL, 76561198176366622UL, 76561198092430664UL, 76561198066084037UL, 76561198368894435UL, 76561198389241377UL,
							76561198158965172UL, 76561198306626714UL, 76561198208716648UL, 76561198835780877UL, 76561197970331648UL, 76561198051740093UL, 76561198111069943UL, 76561198075423731UL, 76561197965588718UL, 76561197960316241UL,
							76561198361294115UL, 76561197960555384UL, 76561198021354850UL, 76561198207495888UL, 76561198040673812UL, 76561198241363850UL, 76561198151921867UL, 76561198095212046UL, 76561198169445087UL
						}, 0UL);
					}
					Image? image;
					if (size == 0)
					{
						image = await SteamFriends.GetMediumAvatarAsync(steamid);
					}
					else
					{
						image = ((size != 1) ? (await SteamFriends.GetSmallAvatarAsync(steamid)) : (await SteamFriends.GetLargeAvatarAsync(steamid)));
					}
					Image? result = image;
					if (result == null)
					{
						GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("AvatarLoader - Couldn't get avatar for {0} ({1})", new object[] { steamid, url }));
					}
					else
					{
						Texture texture = Texture.Create((int)result.Value.Width, (int)result.Value.Height, ImageFormat.RGBA8888).WithData(result.Value.Data).Finish();
						placeholder.CopyFrom(texture);
					}
				}
			}
			finally
			{
				placeholder.IsLoaded = true;
			}
		}
	}
}
