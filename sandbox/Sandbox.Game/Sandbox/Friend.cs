using System;
using System.Collections.Generic;
using System.Linq;
using Sandbox.Internal;
using Steamworks;

namespace Sandbox
{
	// Token: 0x020000BD RID: 189
	public struct Friend
	{
		// Token: 0x060011AF RID: 4527 RVA: 0x0004B104 File Offset: 0x00049304
		internal Friend(Friend value)
		{
			this.Internal = value;
		}

		// Token: 0x060011B0 RID: 4528 RVA: 0x0004B10D File Offset: 0x0004930D
		internal Friend(SteamId value)
		{
			this.Internal = new Friend(value);
		}

		// Token: 0x060011B1 RID: 4529 RVA: 0x0004B11B File Offset: 0x0004931B
		[Obsolete]
		public Friend(ulong steamid)
		{
			this.Internal = new Friend(steamid);
		}

		// Token: 0x060011B2 RID: 4530 RVA: 0x0004B12E File Offset: 0x0004932E
		public Friend(long steamid)
		{
			this.Internal = new Friend((ulong)steamid);
		}

		/// <summary>
		/// Returns true if this friend is the local user
		/// </summary>
		// Token: 0x1700024D RID: 589
		// (get) Token: 0x060011B3 RID: 4531 RVA: 0x0004B144 File Offset: 0x00049344
		public readonly bool IsMe
		{
			get
			{
				Friend @internal = this.Internal;
				return @internal.IsMe;
			}
		}

		/// <summary>
		/// The friend's Steam Id
		/// </summary>
		// Token: 0x1700024E RID: 590
		// (get) Token: 0x060011B4 RID: 4532 RVA: 0x0004B15F File Offset: 0x0004935F
		public readonly long Id
		{
			get
			{
				return (long)this.Internal.Id.Value;
			}
		}

		/// <summary>
		/// The friend's name
		/// </summary>
		// Token: 0x1700024F RID: 591
		// (get) Token: 0x060011B5 RID: 4533 RVA: 0x0004B174 File Offset: 0x00049374
		public readonly string Name
		{
			get
			{
				Friend @internal = this.Internal;
				return @internal.Name;
			}
		}

		/// <summary>
		/// Returns true if your friend is online
		/// </summary>
		// Token: 0x17000250 RID: 592
		// (get) Token: 0x060011B6 RID: 4534 RVA: 0x0004B190 File Offset: 0x00049390
		public readonly bool IsOnline
		{
			get
			{
				Friend @internal = this.Internal;
				return @internal.IsOnline;
			}
		}

		/// <summary>
		/// Returns true if this user is your friend
		/// </summary>
		// Token: 0x17000251 RID: 593
		// (get) Token: 0x060011B7 RID: 4535 RVA: 0x0004B1AC File Offset: 0x000493AC
		public readonly bool IsFriend
		{
			get
			{
				Friend @internal = this.Internal;
				return @internal.IsFriend;
			}
		}

		/// <summary>
		/// Returns true if your friend is away
		/// </summary>
		// Token: 0x17000252 RID: 594
		// (get) Token: 0x060011B8 RID: 4536 RVA: 0x0004B1C8 File Offset: 0x000493C8
		public readonly bool IsAway
		{
			get
			{
				Friend @internal = this.Internal;
				return @internal.IsAway;
			}
		}

		/// <summary>
		/// Returns a string that was possibly set by rich presence
		/// </summary>
		// Token: 0x060011B9 RID: 4537 RVA: 0x0004B1E4 File Offset: 0x000493E4
		public readonly string GetRichPresence(string key)
		{
			Friend @internal = this.Internal;
			return @internal.GetRichPresence(key);
		}

		/// <summary>
		/// Returns true if they're playing this game
		/// </summary>
		// Token: 0x17000253 RID: 595
		// (get) Token: 0x060011BA RID: 4538 RVA: 0x0004B200 File Offset: 0x00049400
		public readonly bool IsPlayingThisGame
		{
			get
			{
				Friend @internal = this.Internal;
				Friend.FriendGameInfo? friendGameInfo;
				return ((@internal.GameInfo != null) ? friendGameInfo.GetValueOrDefault().GameId : 0UL) == GlobalGameNamespace.Global.AppId;
			}
		}

		/// <summary>
		/// Returns true if they're playing any game
		/// </summary>
		// Token: 0x17000254 RID: 596
		// (get) Token: 0x060011BB RID: 4539 RVA: 0x0004B244 File Offset: 0x00049444
		public readonly bool IsPlayingAGame
		{
			get
			{
				Friend @internal = this.Internal;
				Friend.FriendGameInfo? friendGameInfo;
				return ((@internal.GameInfo != null) ? friendGameInfo.GetValueOrDefault().GameId : 0UL) > 0UL;
			}
		}

		/// <summary>
		/// Get all friends. 
		/// </summary>
		/// <returns></returns>
		// Token: 0x060011BC RID: 4540 RVA: 0x0004B280 File Offset: 0x00049480
		public static IEnumerable<Friend> GetAll()
		{
			return from x in SteamFriends.GetFriends()
				select x.ToSandbox();
		}

		// Token: 0x04000385 RID: 901
		internal Friend Internal;
	}
}
