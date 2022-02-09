using System;

namespace Tools
{
	// Token: 0x0200009F RID: 159
	public enum KeyCode
	{
		// Token: 0x0400023A RID: 570
		Escape = 16777216,
		// Token: 0x0400023B RID: 571
		Tab,
		// Token: 0x0400023C RID: 572
		Backtab,
		// Token: 0x0400023D RID: 573
		Backspace,
		// Token: 0x0400023E RID: 574
		Return,
		// Token: 0x0400023F RID: 575
		Enter,
		// Token: 0x04000240 RID: 576
		Insert,
		// Token: 0x04000241 RID: 577
		Delete,
		// Token: 0x04000242 RID: 578
		Pause,
		// Token: 0x04000243 RID: 579
		Print,
		// Token: 0x04000244 RID: 580
		SysReq,
		// Token: 0x04000245 RID: 581
		Clear,
		// Token: 0x04000246 RID: 582
		Home = 16777232,
		// Token: 0x04000247 RID: 583
		End,
		// Token: 0x04000248 RID: 584
		Left,
		// Token: 0x04000249 RID: 585
		Up,
		// Token: 0x0400024A RID: 586
		Right,
		// Token: 0x0400024B RID: 587
		Down,
		// Token: 0x0400024C RID: 588
		PageUp,
		// Token: 0x0400024D RID: 589
		PageDown,
		// Token: 0x0400024E RID: 590
		Shift = 16777248,
		// Token: 0x0400024F RID: 591
		Control,
		// Token: 0x04000250 RID: 592
		Meta,
		// Token: 0x04000251 RID: 593
		Alt,
		// Token: 0x04000252 RID: 594
		CapsLock,
		// Token: 0x04000253 RID: 595
		NumLock,
		// Token: 0x04000254 RID: 596
		ScrollLock,
		// Token: 0x04000255 RID: 597
		F1 = 16777264,
		// Token: 0x04000256 RID: 598
		F2,
		// Token: 0x04000257 RID: 599
		F3,
		// Token: 0x04000258 RID: 600
		F4,
		// Token: 0x04000259 RID: 601
		F5,
		// Token: 0x0400025A RID: 602
		F6,
		// Token: 0x0400025B RID: 603
		F7,
		// Token: 0x0400025C RID: 604
		F8,
		// Token: 0x0400025D RID: 605
		F9,
		// Token: 0x0400025E RID: 606
		F10,
		// Token: 0x0400025F RID: 607
		F11,
		// Token: 0x04000260 RID: 608
		F12,
		// Token: 0x04000261 RID: 609
		F13,
		// Token: 0x04000262 RID: 610
		F14,
		// Token: 0x04000263 RID: 611
		F15,
		// Token: 0x04000264 RID: 612
		F16,
		// Token: 0x04000265 RID: 613
		F17,
		// Token: 0x04000266 RID: 614
		F18,
		// Token: 0x04000267 RID: 615
		F19,
		// Token: 0x04000268 RID: 616
		F20,
		// Token: 0x04000269 RID: 617
		F21,
		// Token: 0x0400026A RID: 618
		F22,
		// Token: 0x0400026B RID: 619
		F23,
		// Token: 0x0400026C RID: 620
		F24,
		// Token: 0x0400026D RID: 621
		F25,
		// Token: 0x0400026E RID: 622
		F26,
		// Token: 0x0400026F RID: 623
		F27,
		// Token: 0x04000270 RID: 624
		F28,
		// Token: 0x04000271 RID: 625
		F29,
		// Token: 0x04000272 RID: 626
		F30,
		// Token: 0x04000273 RID: 627
		F31,
		// Token: 0x04000274 RID: 628
		F32,
		// Token: 0x04000275 RID: 629
		F33,
		// Token: 0x04000276 RID: 630
		F34,
		// Token: 0x04000277 RID: 631
		F35,
		// Token: 0x04000278 RID: 632
		Super_L,
		// Token: 0x04000279 RID: 633
		Super_R,
		// Token: 0x0400027A RID: 634
		Menu,
		// Token: 0x0400027B RID: 635
		Hyper_L,
		// Token: 0x0400027C RID: 636
		Hyper_R,
		// Token: 0x0400027D RID: 637
		Help,
		// Token: 0x0400027E RID: 638
		Direction_L,
		// Token: 0x0400027F RID: 639
		Direction_R = 16777312,
		// Token: 0x04000280 RID: 640
		Space = 32,
		// Token: 0x04000281 RID: 641
		Any = 32,
		// Token: 0x04000282 RID: 642
		Exclam,
		// Token: 0x04000283 RID: 643
		QuoteDbl,
		// Token: 0x04000284 RID: 644
		NumberSign,
		// Token: 0x04000285 RID: 645
		Dollar,
		// Token: 0x04000286 RID: 646
		Percent,
		// Token: 0x04000287 RID: 647
		Ampersand,
		// Token: 0x04000288 RID: 648
		Apostrophe,
		// Token: 0x04000289 RID: 649
		ParenLeft,
		// Token: 0x0400028A RID: 650
		ParenRight,
		// Token: 0x0400028B RID: 651
		Asterisk,
		// Token: 0x0400028C RID: 652
		Plus,
		// Token: 0x0400028D RID: 653
		Comma,
		// Token: 0x0400028E RID: 654
		Minus,
		// Token: 0x0400028F RID: 655
		Period,
		// Token: 0x04000290 RID: 656
		Slash,
		// Token: 0x04000291 RID: 657
		Num0,
		// Token: 0x04000292 RID: 658
		Num1,
		// Token: 0x04000293 RID: 659
		Num2,
		// Token: 0x04000294 RID: 660
		Num3,
		// Token: 0x04000295 RID: 661
		Num4,
		// Token: 0x04000296 RID: 662
		Num5,
		// Token: 0x04000297 RID: 663
		Num6,
		// Token: 0x04000298 RID: 664
		Num7,
		// Token: 0x04000299 RID: 665
		Num8,
		// Token: 0x0400029A RID: 666
		Num9,
		// Token: 0x0400029B RID: 667
		Colon,
		// Token: 0x0400029C RID: 668
		Semicolon,
		// Token: 0x0400029D RID: 669
		Less,
		// Token: 0x0400029E RID: 670
		Equal,
		// Token: 0x0400029F RID: 671
		Greater,
		// Token: 0x040002A0 RID: 672
		Question,
		// Token: 0x040002A1 RID: 673
		At,
		// Token: 0x040002A2 RID: 674
		A,
		// Token: 0x040002A3 RID: 675
		B,
		// Token: 0x040002A4 RID: 676
		C,
		// Token: 0x040002A5 RID: 677
		D,
		// Token: 0x040002A6 RID: 678
		E,
		// Token: 0x040002A7 RID: 679
		F,
		// Token: 0x040002A8 RID: 680
		G,
		// Token: 0x040002A9 RID: 681
		H,
		// Token: 0x040002AA RID: 682
		I,
		// Token: 0x040002AB RID: 683
		J,
		// Token: 0x040002AC RID: 684
		K,
		// Token: 0x040002AD RID: 685
		L,
		// Token: 0x040002AE RID: 686
		M,
		// Token: 0x040002AF RID: 687
		N,
		// Token: 0x040002B0 RID: 688
		O,
		// Token: 0x040002B1 RID: 689
		P,
		// Token: 0x040002B2 RID: 690
		Q,
		// Token: 0x040002B3 RID: 691
		R,
		// Token: 0x040002B4 RID: 692
		S,
		// Token: 0x040002B5 RID: 693
		T,
		// Token: 0x040002B6 RID: 694
		U,
		// Token: 0x040002B7 RID: 695
		V,
		// Token: 0x040002B8 RID: 696
		W,
		// Token: 0x040002B9 RID: 697
		X,
		// Token: 0x040002BA RID: 698
		Y,
		// Token: 0x040002BB RID: 699
		Z,
		// Token: 0x040002BC RID: 700
		BracketLeft,
		// Token: 0x040002BD RID: 701
		Backslash,
		// Token: 0x040002BE RID: 702
		BracketRight,
		// Token: 0x040002BF RID: 703
		AsciiCircum,
		// Token: 0x040002C0 RID: 704
		Underscore,
		// Token: 0x040002C1 RID: 705
		QuoteLeft,
		// Token: 0x040002C2 RID: 706
		BraceLeft = 123,
		// Token: 0x040002C3 RID: 707
		Bar,
		// Token: 0x040002C4 RID: 708
		BraceRight,
		// Token: 0x040002C5 RID: 709
		AsciiTilde,
		// Token: 0x040002C6 RID: 710
		nobreakspace = 160,
		// Token: 0x040002C7 RID: 711
		exclamdown,
		// Token: 0x040002C8 RID: 712
		cent,
		// Token: 0x040002C9 RID: 713
		sterling,
		// Token: 0x040002CA RID: 714
		currency,
		// Token: 0x040002CB RID: 715
		yen,
		// Token: 0x040002CC RID: 716
		brokenbar,
		// Token: 0x040002CD RID: 717
		section,
		// Token: 0x040002CE RID: 718
		diaeresis,
		// Token: 0x040002CF RID: 719
		copyright,
		// Token: 0x040002D0 RID: 720
		ordfeminine,
		// Token: 0x040002D1 RID: 721
		guillemotleft,
		// Token: 0x040002D2 RID: 722
		notsign,
		// Token: 0x040002D3 RID: 723
		hyphen,
		// Token: 0x040002D4 RID: 724
		registered,
		// Token: 0x040002D5 RID: 725
		macron,
		// Token: 0x040002D6 RID: 726
		degree,
		// Token: 0x040002D7 RID: 727
		plusminus,
		// Token: 0x040002D8 RID: 728
		twosuperior,
		// Token: 0x040002D9 RID: 729
		threesuperior,
		// Token: 0x040002DA RID: 730
		acute,
		// Token: 0x040002DB RID: 731
		mu,
		// Token: 0x040002DC RID: 732
		paragraph,
		// Token: 0x040002DD RID: 733
		periodcentered,
		// Token: 0x040002DE RID: 734
		cedilla,
		// Token: 0x040002DF RID: 735
		onesuperior,
		// Token: 0x040002E0 RID: 736
		masculine,
		// Token: 0x040002E1 RID: 737
		guillemotright,
		// Token: 0x040002E2 RID: 738
		onequarter,
		// Token: 0x040002E3 RID: 739
		onehalf,
		// Token: 0x040002E4 RID: 740
		threequarters,
		// Token: 0x040002E5 RID: 741
		questiondown,
		// Token: 0x040002E6 RID: 742
		Agrave,
		// Token: 0x040002E7 RID: 743
		Aacute,
		// Token: 0x040002E8 RID: 744
		Acircumflex,
		// Token: 0x040002E9 RID: 745
		Atilde,
		// Token: 0x040002EA RID: 746
		Adiaeresis,
		// Token: 0x040002EB RID: 747
		Aring,
		// Token: 0x040002EC RID: 748
		AE,
		// Token: 0x040002ED RID: 749
		Ccedilla,
		// Token: 0x040002EE RID: 750
		Egrave,
		// Token: 0x040002EF RID: 751
		Eacute,
		// Token: 0x040002F0 RID: 752
		Ecircumflex,
		// Token: 0x040002F1 RID: 753
		Ediaeresis,
		// Token: 0x040002F2 RID: 754
		Igrave,
		// Token: 0x040002F3 RID: 755
		Iacute,
		// Token: 0x040002F4 RID: 756
		Icircumflex,
		// Token: 0x040002F5 RID: 757
		Idiaeresis,
		// Token: 0x040002F6 RID: 758
		ETH,
		// Token: 0x040002F7 RID: 759
		Ntilde,
		// Token: 0x040002F8 RID: 760
		Ograve,
		// Token: 0x040002F9 RID: 761
		Oacute,
		// Token: 0x040002FA RID: 762
		Ocircumflex,
		// Token: 0x040002FB RID: 763
		Otilde,
		// Token: 0x040002FC RID: 764
		Odiaeresis,
		// Token: 0x040002FD RID: 765
		multiply,
		// Token: 0x040002FE RID: 766
		Ooblique,
		// Token: 0x040002FF RID: 767
		Ugrave,
		// Token: 0x04000300 RID: 768
		Uacute,
		// Token: 0x04000301 RID: 769
		Ucircumflex,
		// Token: 0x04000302 RID: 770
		Udiaeresis,
		// Token: 0x04000303 RID: 771
		Yacute,
		// Token: 0x04000304 RID: 772
		THORN,
		// Token: 0x04000305 RID: 773
		ssharp,
		// Token: 0x04000306 RID: 774
		division = 247,
		// Token: 0x04000307 RID: 775
		ydiaeresis = 255,
		// Token: 0x04000308 RID: 776
		AltGr = 16781571,
		// Token: 0x04000309 RID: 777
		Multi_key = 16781600,
		// Token: 0x0400030A RID: 778
		Codeinput = 16781623,
		// Token: 0x0400030B RID: 779
		SingleCandidate = 16781628,
		// Token: 0x0400030C RID: 780
		MultipleCandidate,
		// Token: 0x0400030D RID: 781
		PreviousCandidate,
		// Token: 0x0400030E RID: 782
		Mode_switch = 16781694,
		// Token: 0x0400030F RID: 783
		Kanji = 16781601,
		// Token: 0x04000310 RID: 784
		Muhenkan,
		// Token: 0x04000311 RID: 785
		Henkan,
		// Token: 0x04000312 RID: 786
		Romaji,
		// Token: 0x04000313 RID: 787
		Hiragana,
		// Token: 0x04000314 RID: 788
		Katakana,
		// Token: 0x04000315 RID: 789
		Hiragana_Katakana,
		// Token: 0x04000316 RID: 790
		Zenkaku,
		// Token: 0x04000317 RID: 791
		Hankaku,
		// Token: 0x04000318 RID: 792
		Zenkaku_Hankaku,
		// Token: 0x04000319 RID: 793
		Touroku,
		// Token: 0x0400031A RID: 794
		Massyo,
		// Token: 0x0400031B RID: 795
		Kana_Lock,
		// Token: 0x0400031C RID: 796
		Kana_Shift,
		// Token: 0x0400031D RID: 797
		Eisu_Shift,
		// Token: 0x0400031E RID: 798
		Eisu_toggle,
		// Token: 0x0400031F RID: 799
		Hangul,
		// Token: 0x04000320 RID: 800
		Hangul_Start,
		// Token: 0x04000321 RID: 801
		Hangul_End,
		// Token: 0x04000322 RID: 802
		Hangul_Hanja,
		// Token: 0x04000323 RID: 803
		Hangul_Jamo,
		// Token: 0x04000324 RID: 804
		Hangul_Romaja,
		// Token: 0x04000325 RID: 805
		Hangul_Jeonja = 16781624,
		// Token: 0x04000326 RID: 806
		Hangul_Banja,
		// Token: 0x04000327 RID: 807
		Hangul_PreHanja,
		// Token: 0x04000328 RID: 808
		Hangul_PostHanja,
		// Token: 0x04000329 RID: 809
		Hangul_Special = 16781631,
		// Token: 0x0400032A RID: 810
		Back = 16777313,
		// Token: 0x0400032B RID: 811
		Forward,
		// Token: 0x0400032C RID: 812
		Stop,
		// Token: 0x0400032D RID: 813
		Refresh,
		// Token: 0x0400032E RID: 814
		VolumeDown = 16777328,
		// Token: 0x0400032F RID: 815
		VolumeMute,
		// Token: 0x04000330 RID: 816
		VolumeUp,
		// Token: 0x04000331 RID: 817
		BassBoost,
		// Token: 0x04000332 RID: 818
		BassUp,
		// Token: 0x04000333 RID: 819
		BassDown,
		// Token: 0x04000334 RID: 820
		TrebleUp,
		// Token: 0x04000335 RID: 821
		TrebleDown,
		// Token: 0x04000336 RID: 822
		MediaPlay = 16777344,
		// Token: 0x04000337 RID: 823
		MediaStop,
		// Token: 0x04000338 RID: 824
		MediaPrevious,
		// Token: 0x04000339 RID: 825
		MediaNext,
		// Token: 0x0400033A RID: 826
		MediaRecord,
		// Token: 0x0400033B RID: 827
		MediaPause,
		// Token: 0x0400033C RID: 828
		MediaTogglePlayPause,
		// Token: 0x0400033D RID: 829
		HomePage = 16777360,
		// Token: 0x0400033E RID: 830
		Favorites,
		// Token: 0x0400033F RID: 831
		Search,
		// Token: 0x04000340 RID: 832
		Standby,
		// Token: 0x04000341 RID: 833
		OpenUrl,
		// Token: 0x04000342 RID: 834
		LaunchMail = 16777376,
		// Token: 0x04000343 RID: 835
		LaunchMedia,
		// Token: 0x04000344 RID: 836
		Launch0,
		// Token: 0x04000345 RID: 837
		Launch1,
		// Token: 0x04000346 RID: 838
		Launch2,
		// Token: 0x04000347 RID: 839
		Launch3,
		// Token: 0x04000348 RID: 840
		Launch4,
		// Token: 0x04000349 RID: 841
		Launch5,
		// Token: 0x0400034A RID: 842
		Launch6,
		// Token: 0x0400034B RID: 843
		Launch7,
		// Token: 0x0400034C RID: 844
		Launch8,
		// Token: 0x0400034D RID: 845
		Launch9,
		// Token: 0x0400034E RID: 846
		LaunchA,
		// Token: 0x0400034F RID: 847
		LaunchB,
		// Token: 0x04000350 RID: 848
		LaunchC,
		// Token: 0x04000351 RID: 849
		LaunchD,
		// Token: 0x04000352 RID: 850
		LaunchE,
		// Token: 0x04000353 RID: 851
		LaunchF,
		// Token: 0x04000354 RID: 852
		MonBrightnessUp,
		// Token: 0x04000355 RID: 853
		MonBrightnessDown,
		// Token: 0x04000356 RID: 854
		KeyboardLightOnOff,
		// Token: 0x04000357 RID: 855
		KeyboardBrightnessUp,
		// Token: 0x04000358 RID: 856
		KeyboardBrightnessDown,
		// Token: 0x04000359 RID: 857
		PowerOff,
		// Token: 0x0400035A RID: 858
		WakeUp,
		// Token: 0x0400035B RID: 859
		Eject,
		// Token: 0x0400035C RID: 860
		ScreenSaver,
		// Token: 0x0400035D RID: 861
		WWW,
		// Token: 0x0400035E RID: 862
		Memo,
		// Token: 0x0400035F RID: 863
		LightBulb,
		// Token: 0x04000360 RID: 864
		Shop,
		// Token: 0x04000361 RID: 865
		History,
		// Token: 0x04000362 RID: 866
		AddFavorite,
		// Token: 0x04000363 RID: 867
		HotLinks,
		// Token: 0x04000364 RID: 868
		BrightnessAdjust,
		// Token: 0x04000365 RID: 869
		Finance,
		// Token: 0x04000366 RID: 870
		Community,
		// Token: 0x04000367 RID: 871
		AudioRewind,
		// Token: 0x04000368 RID: 872
		BackForward,
		// Token: 0x04000369 RID: 873
		ApplicationLeft,
		// Token: 0x0400036A RID: 874
		ApplicationRight,
		// Token: 0x0400036B RID: 875
		Book,
		// Token: 0x0400036C RID: 876
		CD,
		// Token: 0x0400036D RID: 877
		Calculator,
		// Token: 0x0400036E RID: 878
		ToDoList,
		// Token: 0x0400036F RID: 879
		ClearGrab,
		// Token: 0x04000370 RID: 880
		Close,
		// Token: 0x04000371 RID: 881
		Copy,
		// Token: 0x04000372 RID: 882
		Cut,
		// Token: 0x04000373 RID: 883
		Display,
		// Token: 0x04000374 RID: 884
		DOS,
		// Token: 0x04000375 RID: 885
		Documents,
		// Token: 0x04000376 RID: 886
		Excel,
		// Token: 0x04000377 RID: 887
		Explorer,
		// Token: 0x04000378 RID: 888
		Game,
		// Token: 0x04000379 RID: 889
		Go,
		// Token: 0x0400037A RID: 890
		iTouch,
		// Token: 0x0400037B RID: 891
		LogOff,
		// Token: 0x0400037C RID: 892
		Market,
		// Token: 0x0400037D RID: 893
		Meeting,
		// Token: 0x0400037E RID: 894
		MenuKB,
		// Token: 0x0400037F RID: 895
		MenuPB,
		// Token: 0x04000380 RID: 896
		MySites,
		// Token: 0x04000381 RID: 897
		News,
		// Token: 0x04000382 RID: 898
		OfficeHome,
		// Token: 0x04000383 RID: 899
		Option,
		// Token: 0x04000384 RID: 900
		Paste,
		// Token: 0x04000385 RID: 901
		Phone,
		// Token: 0x04000386 RID: 902
		Calendar,
		// Token: 0x04000387 RID: 903
		Reply,
		// Token: 0x04000388 RID: 904
		Reload,
		// Token: 0x04000389 RID: 905
		RotateWindows,
		// Token: 0x0400038A RID: 906
		RotationPB,
		// Token: 0x0400038B RID: 907
		RotationKB,
		// Token: 0x0400038C RID: 908
		Save,
		// Token: 0x0400038D RID: 909
		Send,
		// Token: 0x0400038E RID: 910
		Spell,
		// Token: 0x0400038F RID: 911
		SplitScreen,
		// Token: 0x04000390 RID: 912
		Support,
		// Token: 0x04000391 RID: 913
		TaskPane,
		// Token: 0x04000392 RID: 914
		Terminal,
		// Token: 0x04000393 RID: 915
		Tools,
		// Token: 0x04000394 RID: 916
		Travel,
		// Token: 0x04000395 RID: 917
		Video,
		// Token: 0x04000396 RID: 918
		Word,
		// Token: 0x04000397 RID: 919
		Xfer,
		// Token: 0x04000398 RID: 920
		ZoomIn,
		// Token: 0x04000399 RID: 921
		ZoomOut,
		// Token: 0x0400039A RID: 922
		Away,
		// Token: 0x0400039B RID: 923
		Messenger,
		// Token: 0x0400039C RID: 924
		WebCam,
		// Token: 0x0400039D RID: 925
		MailForward,
		// Token: 0x0400039E RID: 926
		Pictures,
		// Token: 0x0400039F RID: 927
		Music,
		// Token: 0x040003A0 RID: 928
		Battery,
		// Token: 0x040003A1 RID: 929
		Bluetooth,
		// Token: 0x040003A2 RID: 930
		WLAN,
		// Token: 0x040003A3 RID: 931
		UWB,
		// Token: 0x040003A4 RID: 932
		AudioForward,
		// Token: 0x040003A5 RID: 933
		AudioRepeat,
		// Token: 0x040003A6 RID: 934
		AudioRandomPlay,
		// Token: 0x040003A7 RID: 935
		Subtitle,
		// Token: 0x040003A8 RID: 936
		AudioCycleTrack,
		// Token: 0x040003A9 RID: 937
		Time,
		// Token: 0x040003AA RID: 938
		Hibernate,
		// Token: 0x040003AB RID: 939
		View,
		// Token: 0x040003AC RID: 940
		TopMenu,
		// Token: 0x040003AD RID: 941
		PowerDown,
		// Token: 0x040003AE RID: 942
		Suspend,
		// Token: 0x040003AF RID: 943
		ContrastAdjust,
		// Token: 0x040003B0 RID: 944
		LaunchG,
		// Token: 0x040003B1 RID: 945
		LaunchH,
		// Token: 0x040003B2 RID: 946
		TouchpadToggle,
		// Token: 0x040003B3 RID: 947
		TouchpadOn,
		// Token: 0x040003B4 RID: 948
		TouchpadOff,
		// Token: 0x040003B5 RID: 949
		MicMute,
		// Token: 0x040003B6 RID: 950
		Red,
		// Token: 0x040003B7 RID: 951
		Green,
		// Token: 0x040003B8 RID: 952
		Yellow,
		// Token: 0x040003B9 RID: 953
		Blue,
		// Token: 0x040003BA RID: 954
		ChannelUp,
		// Token: 0x040003BB RID: 955
		ChannelDown,
		// Token: 0x040003BC RID: 956
		Guide,
		// Token: 0x040003BD RID: 957
		Info,
		// Token: 0x040003BE RID: 958
		Settings,
		// Token: 0x040003BF RID: 959
		MicVolumeUp,
		// Token: 0x040003C0 RID: 960
		MicVolumeDown,
		// Token: 0x040003C1 RID: 961
		New = 16777504,
		// Token: 0x040003C2 RID: 962
		Open,
		// Token: 0x040003C3 RID: 963
		Find,
		// Token: 0x040003C4 RID: 964
		Undo,
		// Token: 0x040003C5 RID: 965
		Redo,
		// Token: 0x040003C6 RID: 966
		MediaLast = 16842751,
		// Token: 0x040003C7 RID: 967
		Select,
		// Token: 0x040003C8 RID: 968
		Yes,
		// Token: 0x040003C9 RID: 969
		No,
		// Token: 0x040003CA RID: 970
		Cancel = 16908289,
		// Token: 0x040003CB RID: 971
		Printer,
		// Token: 0x040003CC RID: 972
		Execute,
		// Token: 0x040003CD RID: 973
		Sleep,
		// Token: 0x040003CE RID: 974
		Play,
		// Token: 0x040003CF RID: 975
		Zoom,
		// Token: 0x040003D0 RID: 976
		Exit = 16908298,
		// Token: 0x040003D1 RID: 977
		Context1 = 17825792,
		// Token: 0x040003D2 RID: 978
		Context2,
		// Token: 0x040003D3 RID: 979
		Context3,
		// Token: 0x040003D4 RID: 980
		Context4,
		// Token: 0x040003D5 RID: 981
		Call,
		// Token: 0x040003D6 RID: 982
		Hangup,
		// Token: 0x040003D7 RID: 983
		Flip,
		// Token: 0x040003D8 RID: 984
		ToggleCallHangup,
		// Token: 0x040003D9 RID: 985
		VoiceDial,
		// Token: 0x040003DA RID: 986
		LastNumberRedial,
		// Token: 0x040003DB RID: 987
		Camera = 17825824,
		// Token: 0x040003DC RID: 988
		CameraFocus,
		// Token: 0x040003DD RID: 989
		Unknown = 33554431
	}
}
