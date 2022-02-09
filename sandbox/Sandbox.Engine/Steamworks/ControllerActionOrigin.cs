using System;

namespace Steamworks
{
	// Token: 0x02000083 RID: 131
	internal enum ControllerActionOrigin
	{
		// Token: 0x04000654 RID: 1620
		None,
		// Token: 0x04000655 RID: 1621
		A,
		// Token: 0x04000656 RID: 1622
		B,
		// Token: 0x04000657 RID: 1623
		X,
		// Token: 0x04000658 RID: 1624
		Y,
		// Token: 0x04000659 RID: 1625
		LeftBumper,
		// Token: 0x0400065A RID: 1626
		RightBumper,
		// Token: 0x0400065B RID: 1627
		LeftGrip,
		// Token: 0x0400065C RID: 1628
		RightGrip,
		// Token: 0x0400065D RID: 1629
		Start,
		// Token: 0x0400065E RID: 1630
		Back,
		// Token: 0x0400065F RID: 1631
		LeftPad_Touch,
		// Token: 0x04000660 RID: 1632
		LeftPad_Swipe,
		// Token: 0x04000661 RID: 1633
		LeftPad_Click,
		// Token: 0x04000662 RID: 1634
		LeftPad_DPadNorth,
		// Token: 0x04000663 RID: 1635
		LeftPad_DPadSouth,
		// Token: 0x04000664 RID: 1636
		LeftPad_DPadWest,
		// Token: 0x04000665 RID: 1637
		LeftPad_DPadEast,
		// Token: 0x04000666 RID: 1638
		RightPad_Touch,
		// Token: 0x04000667 RID: 1639
		RightPad_Swipe,
		// Token: 0x04000668 RID: 1640
		RightPad_Click,
		// Token: 0x04000669 RID: 1641
		RightPad_DPadNorth,
		// Token: 0x0400066A RID: 1642
		RightPad_DPadSouth,
		// Token: 0x0400066B RID: 1643
		RightPad_DPadWest,
		// Token: 0x0400066C RID: 1644
		RightPad_DPadEast,
		// Token: 0x0400066D RID: 1645
		LeftTrigger_Pull,
		// Token: 0x0400066E RID: 1646
		LeftTrigger_Click,
		// Token: 0x0400066F RID: 1647
		RightTrigger_Pull,
		// Token: 0x04000670 RID: 1648
		RightTrigger_Click,
		// Token: 0x04000671 RID: 1649
		LeftStick_Move,
		// Token: 0x04000672 RID: 1650
		LeftStick_Click,
		// Token: 0x04000673 RID: 1651
		LeftStick_DPadNorth,
		// Token: 0x04000674 RID: 1652
		LeftStick_DPadSouth,
		// Token: 0x04000675 RID: 1653
		LeftStick_DPadWest,
		// Token: 0x04000676 RID: 1654
		LeftStick_DPadEast,
		// Token: 0x04000677 RID: 1655
		Gyro_Move,
		// Token: 0x04000678 RID: 1656
		Gyro_Pitch,
		// Token: 0x04000679 RID: 1657
		Gyro_Yaw,
		// Token: 0x0400067A RID: 1658
		Gyro_Roll,
		// Token: 0x0400067B RID: 1659
		PS4_X,
		// Token: 0x0400067C RID: 1660
		PS4_Circle,
		// Token: 0x0400067D RID: 1661
		PS4_Triangle,
		// Token: 0x0400067E RID: 1662
		PS4_Square,
		// Token: 0x0400067F RID: 1663
		PS4_LeftBumper,
		// Token: 0x04000680 RID: 1664
		PS4_RightBumper,
		// Token: 0x04000681 RID: 1665
		PS4_Options,
		// Token: 0x04000682 RID: 1666
		PS4_Share,
		// Token: 0x04000683 RID: 1667
		PS4_LeftPad_Touch,
		// Token: 0x04000684 RID: 1668
		PS4_LeftPad_Swipe,
		// Token: 0x04000685 RID: 1669
		PS4_LeftPad_Click,
		// Token: 0x04000686 RID: 1670
		PS4_LeftPad_DPadNorth,
		// Token: 0x04000687 RID: 1671
		PS4_LeftPad_DPadSouth,
		// Token: 0x04000688 RID: 1672
		PS4_LeftPad_DPadWest,
		// Token: 0x04000689 RID: 1673
		PS4_LeftPad_DPadEast,
		// Token: 0x0400068A RID: 1674
		PS4_RightPad_Touch,
		// Token: 0x0400068B RID: 1675
		PS4_RightPad_Swipe,
		// Token: 0x0400068C RID: 1676
		PS4_RightPad_Click,
		// Token: 0x0400068D RID: 1677
		PS4_RightPad_DPadNorth,
		// Token: 0x0400068E RID: 1678
		PS4_RightPad_DPadSouth,
		// Token: 0x0400068F RID: 1679
		PS4_RightPad_DPadWest,
		// Token: 0x04000690 RID: 1680
		PS4_RightPad_DPadEast,
		// Token: 0x04000691 RID: 1681
		PS4_CenterPad_Touch,
		// Token: 0x04000692 RID: 1682
		PS4_CenterPad_Swipe,
		// Token: 0x04000693 RID: 1683
		PS4_CenterPad_Click,
		// Token: 0x04000694 RID: 1684
		PS4_CenterPad_DPadNorth,
		// Token: 0x04000695 RID: 1685
		PS4_CenterPad_DPadSouth,
		// Token: 0x04000696 RID: 1686
		PS4_CenterPad_DPadWest,
		// Token: 0x04000697 RID: 1687
		PS4_CenterPad_DPadEast,
		// Token: 0x04000698 RID: 1688
		PS4_LeftTrigger_Pull,
		// Token: 0x04000699 RID: 1689
		PS4_LeftTrigger_Click,
		// Token: 0x0400069A RID: 1690
		PS4_RightTrigger_Pull,
		// Token: 0x0400069B RID: 1691
		PS4_RightTrigger_Click,
		// Token: 0x0400069C RID: 1692
		PS4_LeftStick_Move,
		// Token: 0x0400069D RID: 1693
		PS4_LeftStick_Click,
		// Token: 0x0400069E RID: 1694
		PS4_LeftStick_DPadNorth,
		// Token: 0x0400069F RID: 1695
		PS4_LeftStick_DPadSouth,
		// Token: 0x040006A0 RID: 1696
		PS4_LeftStick_DPadWest,
		// Token: 0x040006A1 RID: 1697
		PS4_LeftStick_DPadEast,
		// Token: 0x040006A2 RID: 1698
		PS4_RightStick_Move,
		// Token: 0x040006A3 RID: 1699
		PS4_RightStick_Click,
		// Token: 0x040006A4 RID: 1700
		PS4_RightStick_DPadNorth,
		// Token: 0x040006A5 RID: 1701
		PS4_RightStick_DPadSouth,
		// Token: 0x040006A6 RID: 1702
		PS4_RightStick_DPadWest,
		// Token: 0x040006A7 RID: 1703
		PS4_RightStick_DPadEast,
		// Token: 0x040006A8 RID: 1704
		PS4_DPad_North,
		// Token: 0x040006A9 RID: 1705
		PS4_DPad_South,
		// Token: 0x040006AA RID: 1706
		PS4_DPad_West,
		// Token: 0x040006AB RID: 1707
		PS4_DPad_East,
		// Token: 0x040006AC RID: 1708
		PS4_Gyro_Move,
		// Token: 0x040006AD RID: 1709
		PS4_Gyro_Pitch,
		// Token: 0x040006AE RID: 1710
		PS4_Gyro_Yaw,
		// Token: 0x040006AF RID: 1711
		PS4_Gyro_Roll,
		// Token: 0x040006B0 RID: 1712
		XBoxOne_A,
		// Token: 0x040006B1 RID: 1713
		XBoxOne_B,
		// Token: 0x040006B2 RID: 1714
		XBoxOne_X,
		// Token: 0x040006B3 RID: 1715
		XBoxOne_Y,
		// Token: 0x040006B4 RID: 1716
		XBoxOne_LeftBumper,
		// Token: 0x040006B5 RID: 1717
		XBoxOne_RightBumper,
		// Token: 0x040006B6 RID: 1718
		XBoxOne_Menu,
		// Token: 0x040006B7 RID: 1719
		XBoxOne_View,
		// Token: 0x040006B8 RID: 1720
		XBoxOne_LeftTrigger_Pull,
		// Token: 0x040006B9 RID: 1721
		XBoxOne_LeftTrigger_Click,
		// Token: 0x040006BA RID: 1722
		XBoxOne_RightTrigger_Pull,
		// Token: 0x040006BB RID: 1723
		XBoxOne_RightTrigger_Click,
		// Token: 0x040006BC RID: 1724
		XBoxOne_LeftStick_Move,
		// Token: 0x040006BD RID: 1725
		XBoxOne_LeftStick_Click,
		// Token: 0x040006BE RID: 1726
		XBoxOne_LeftStick_DPadNorth,
		// Token: 0x040006BF RID: 1727
		XBoxOne_LeftStick_DPadSouth,
		// Token: 0x040006C0 RID: 1728
		XBoxOne_LeftStick_DPadWest,
		// Token: 0x040006C1 RID: 1729
		XBoxOne_LeftStick_DPadEast,
		// Token: 0x040006C2 RID: 1730
		XBoxOne_RightStick_Move,
		// Token: 0x040006C3 RID: 1731
		XBoxOne_RightStick_Click,
		// Token: 0x040006C4 RID: 1732
		XBoxOne_RightStick_DPadNorth,
		// Token: 0x040006C5 RID: 1733
		XBoxOne_RightStick_DPadSouth,
		// Token: 0x040006C6 RID: 1734
		XBoxOne_RightStick_DPadWest,
		// Token: 0x040006C7 RID: 1735
		XBoxOne_RightStick_DPadEast,
		// Token: 0x040006C8 RID: 1736
		XBoxOne_DPad_North,
		// Token: 0x040006C9 RID: 1737
		XBoxOne_DPad_South,
		// Token: 0x040006CA RID: 1738
		XBoxOne_DPad_West,
		// Token: 0x040006CB RID: 1739
		XBoxOne_DPad_East,
		// Token: 0x040006CC RID: 1740
		XBox360_A,
		// Token: 0x040006CD RID: 1741
		XBox360_B,
		// Token: 0x040006CE RID: 1742
		XBox360_X,
		// Token: 0x040006CF RID: 1743
		XBox360_Y,
		// Token: 0x040006D0 RID: 1744
		XBox360_LeftBumper,
		// Token: 0x040006D1 RID: 1745
		XBox360_RightBumper,
		// Token: 0x040006D2 RID: 1746
		XBox360_Start,
		// Token: 0x040006D3 RID: 1747
		XBox360_Back,
		// Token: 0x040006D4 RID: 1748
		XBox360_LeftTrigger_Pull,
		// Token: 0x040006D5 RID: 1749
		XBox360_LeftTrigger_Click,
		// Token: 0x040006D6 RID: 1750
		XBox360_RightTrigger_Pull,
		// Token: 0x040006D7 RID: 1751
		XBox360_RightTrigger_Click,
		// Token: 0x040006D8 RID: 1752
		XBox360_LeftStick_Move,
		// Token: 0x040006D9 RID: 1753
		XBox360_LeftStick_Click,
		// Token: 0x040006DA RID: 1754
		XBox360_LeftStick_DPadNorth,
		// Token: 0x040006DB RID: 1755
		XBox360_LeftStick_DPadSouth,
		// Token: 0x040006DC RID: 1756
		XBox360_LeftStick_DPadWest,
		// Token: 0x040006DD RID: 1757
		XBox360_LeftStick_DPadEast,
		// Token: 0x040006DE RID: 1758
		XBox360_RightStick_Move,
		// Token: 0x040006DF RID: 1759
		XBox360_RightStick_Click,
		// Token: 0x040006E0 RID: 1760
		XBox360_RightStick_DPadNorth,
		// Token: 0x040006E1 RID: 1761
		XBox360_RightStick_DPadSouth,
		// Token: 0x040006E2 RID: 1762
		XBox360_RightStick_DPadWest,
		// Token: 0x040006E3 RID: 1763
		XBox360_RightStick_DPadEast,
		// Token: 0x040006E4 RID: 1764
		XBox360_DPad_North,
		// Token: 0x040006E5 RID: 1765
		XBox360_DPad_South,
		// Token: 0x040006E6 RID: 1766
		XBox360_DPad_West,
		// Token: 0x040006E7 RID: 1767
		XBox360_DPad_East,
		// Token: 0x040006E8 RID: 1768
		SteamV2_A,
		// Token: 0x040006E9 RID: 1769
		SteamV2_B,
		// Token: 0x040006EA RID: 1770
		SteamV2_X,
		// Token: 0x040006EB RID: 1771
		SteamV2_Y,
		// Token: 0x040006EC RID: 1772
		SteamV2_LeftBumper,
		// Token: 0x040006ED RID: 1773
		SteamV2_RightBumper,
		// Token: 0x040006EE RID: 1774
		SteamV2_LeftGrip_Lower,
		// Token: 0x040006EF RID: 1775
		SteamV2_LeftGrip_Upper,
		// Token: 0x040006F0 RID: 1776
		SteamV2_RightGrip_Lower,
		// Token: 0x040006F1 RID: 1777
		SteamV2_RightGrip_Upper,
		// Token: 0x040006F2 RID: 1778
		SteamV2_LeftBumper_Pressure,
		// Token: 0x040006F3 RID: 1779
		SteamV2_RightBumper_Pressure,
		// Token: 0x040006F4 RID: 1780
		SteamV2_LeftGrip_Pressure,
		// Token: 0x040006F5 RID: 1781
		SteamV2_RightGrip_Pressure,
		// Token: 0x040006F6 RID: 1782
		SteamV2_LeftGrip_Upper_Pressure,
		// Token: 0x040006F7 RID: 1783
		SteamV2_RightGrip_Upper_Pressure,
		// Token: 0x040006F8 RID: 1784
		SteamV2_Start,
		// Token: 0x040006F9 RID: 1785
		SteamV2_Back,
		// Token: 0x040006FA RID: 1786
		SteamV2_LeftPad_Touch,
		// Token: 0x040006FB RID: 1787
		SteamV2_LeftPad_Swipe,
		// Token: 0x040006FC RID: 1788
		SteamV2_LeftPad_Click,
		// Token: 0x040006FD RID: 1789
		SteamV2_LeftPad_Pressure,
		// Token: 0x040006FE RID: 1790
		SteamV2_LeftPad_DPadNorth,
		// Token: 0x040006FF RID: 1791
		SteamV2_LeftPad_DPadSouth,
		// Token: 0x04000700 RID: 1792
		SteamV2_LeftPad_DPadWest,
		// Token: 0x04000701 RID: 1793
		SteamV2_LeftPad_DPadEast,
		// Token: 0x04000702 RID: 1794
		SteamV2_RightPad_Touch,
		// Token: 0x04000703 RID: 1795
		SteamV2_RightPad_Swipe,
		// Token: 0x04000704 RID: 1796
		SteamV2_RightPad_Click,
		// Token: 0x04000705 RID: 1797
		SteamV2_RightPad_Pressure,
		// Token: 0x04000706 RID: 1798
		SteamV2_RightPad_DPadNorth,
		// Token: 0x04000707 RID: 1799
		SteamV2_RightPad_DPadSouth,
		// Token: 0x04000708 RID: 1800
		SteamV2_RightPad_DPadWest,
		// Token: 0x04000709 RID: 1801
		SteamV2_RightPad_DPadEast,
		// Token: 0x0400070A RID: 1802
		SteamV2_LeftTrigger_Pull,
		// Token: 0x0400070B RID: 1803
		SteamV2_LeftTrigger_Click,
		// Token: 0x0400070C RID: 1804
		SteamV2_RightTrigger_Pull,
		// Token: 0x0400070D RID: 1805
		SteamV2_RightTrigger_Click,
		// Token: 0x0400070E RID: 1806
		SteamV2_LeftStick_Move,
		// Token: 0x0400070F RID: 1807
		SteamV2_LeftStick_Click,
		// Token: 0x04000710 RID: 1808
		SteamV2_LeftStick_DPadNorth,
		// Token: 0x04000711 RID: 1809
		SteamV2_LeftStick_DPadSouth,
		// Token: 0x04000712 RID: 1810
		SteamV2_LeftStick_DPadWest,
		// Token: 0x04000713 RID: 1811
		SteamV2_LeftStick_DPadEast,
		// Token: 0x04000714 RID: 1812
		SteamV2_Gyro_Move,
		// Token: 0x04000715 RID: 1813
		SteamV2_Gyro_Pitch,
		// Token: 0x04000716 RID: 1814
		SteamV2_Gyro_Yaw,
		// Token: 0x04000717 RID: 1815
		SteamV2_Gyro_Roll,
		// Token: 0x04000718 RID: 1816
		Switch_A,
		// Token: 0x04000719 RID: 1817
		Switch_B,
		// Token: 0x0400071A RID: 1818
		Switch_X,
		// Token: 0x0400071B RID: 1819
		Switch_Y,
		// Token: 0x0400071C RID: 1820
		Switch_LeftBumper,
		// Token: 0x0400071D RID: 1821
		Switch_RightBumper,
		// Token: 0x0400071E RID: 1822
		Switch_Plus,
		// Token: 0x0400071F RID: 1823
		Switch_Minus,
		// Token: 0x04000720 RID: 1824
		Switch_Capture,
		// Token: 0x04000721 RID: 1825
		Switch_LeftTrigger_Pull,
		// Token: 0x04000722 RID: 1826
		Switch_LeftTrigger_Click,
		// Token: 0x04000723 RID: 1827
		Switch_RightTrigger_Pull,
		// Token: 0x04000724 RID: 1828
		Switch_RightTrigger_Click,
		// Token: 0x04000725 RID: 1829
		Switch_LeftStick_Move,
		// Token: 0x04000726 RID: 1830
		Switch_LeftStick_Click,
		// Token: 0x04000727 RID: 1831
		Switch_LeftStick_DPadNorth,
		// Token: 0x04000728 RID: 1832
		Switch_LeftStick_DPadSouth,
		// Token: 0x04000729 RID: 1833
		Switch_LeftStick_DPadWest,
		// Token: 0x0400072A RID: 1834
		Switch_LeftStick_DPadEast,
		// Token: 0x0400072B RID: 1835
		Switch_RightStick_Move,
		// Token: 0x0400072C RID: 1836
		Switch_RightStick_Click,
		// Token: 0x0400072D RID: 1837
		Switch_RightStick_DPadNorth,
		// Token: 0x0400072E RID: 1838
		Switch_RightStick_DPadSouth,
		// Token: 0x0400072F RID: 1839
		Switch_RightStick_DPadWest,
		// Token: 0x04000730 RID: 1840
		Switch_RightStick_DPadEast,
		// Token: 0x04000731 RID: 1841
		Switch_DPad_North,
		// Token: 0x04000732 RID: 1842
		Switch_DPad_South,
		// Token: 0x04000733 RID: 1843
		Switch_DPad_West,
		// Token: 0x04000734 RID: 1844
		Switch_DPad_East,
		// Token: 0x04000735 RID: 1845
		Switch_ProGyro_Move,
		// Token: 0x04000736 RID: 1846
		Switch_ProGyro_Pitch,
		// Token: 0x04000737 RID: 1847
		Switch_ProGyro_Yaw,
		// Token: 0x04000738 RID: 1848
		Switch_ProGyro_Roll,
		// Token: 0x04000739 RID: 1849
		Switch_RightGyro_Move,
		// Token: 0x0400073A RID: 1850
		Switch_RightGyro_Pitch,
		// Token: 0x0400073B RID: 1851
		Switch_RightGyro_Yaw,
		// Token: 0x0400073C RID: 1852
		Switch_RightGyro_Roll,
		// Token: 0x0400073D RID: 1853
		Switch_LeftGyro_Move,
		// Token: 0x0400073E RID: 1854
		Switch_LeftGyro_Pitch,
		// Token: 0x0400073F RID: 1855
		Switch_LeftGyro_Yaw,
		// Token: 0x04000740 RID: 1856
		Switch_LeftGyro_Roll,
		// Token: 0x04000741 RID: 1857
		Switch_LeftGrip_Lower,
		// Token: 0x04000742 RID: 1858
		Switch_LeftGrip_Upper,
		// Token: 0x04000743 RID: 1859
		Switch_RightGrip_Lower,
		// Token: 0x04000744 RID: 1860
		Switch_RightGrip_Upper,
		// Token: 0x04000745 RID: 1861
		PS4_DPad_Move,
		// Token: 0x04000746 RID: 1862
		XBoxOne_DPad_Move,
		// Token: 0x04000747 RID: 1863
		XBox360_DPad_Move,
		// Token: 0x04000748 RID: 1864
		Switch_DPad_Move,
		// Token: 0x04000749 RID: 1865
		PS5_X,
		// Token: 0x0400074A RID: 1866
		PS5_Circle,
		// Token: 0x0400074B RID: 1867
		PS5_Triangle,
		// Token: 0x0400074C RID: 1868
		PS5_Square,
		// Token: 0x0400074D RID: 1869
		PS5_LeftBumper,
		// Token: 0x0400074E RID: 1870
		PS5_RightBumper,
		// Token: 0x0400074F RID: 1871
		PS5_Option,
		// Token: 0x04000750 RID: 1872
		PS5_Create,
		// Token: 0x04000751 RID: 1873
		PS5_Mute,
		// Token: 0x04000752 RID: 1874
		PS5_LeftPad_Touch,
		// Token: 0x04000753 RID: 1875
		PS5_LeftPad_Swipe,
		// Token: 0x04000754 RID: 1876
		PS5_LeftPad_Click,
		// Token: 0x04000755 RID: 1877
		PS5_LeftPad_DPadNorth,
		// Token: 0x04000756 RID: 1878
		PS5_LeftPad_DPadSouth,
		// Token: 0x04000757 RID: 1879
		PS5_LeftPad_DPadWest,
		// Token: 0x04000758 RID: 1880
		PS5_LeftPad_DPadEast,
		// Token: 0x04000759 RID: 1881
		PS5_RightPad_Touch,
		// Token: 0x0400075A RID: 1882
		PS5_RightPad_Swipe,
		// Token: 0x0400075B RID: 1883
		PS5_RightPad_Click,
		// Token: 0x0400075C RID: 1884
		PS5_RightPad_DPadNorth,
		// Token: 0x0400075D RID: 1885
		PS5_RightPad_DPadSouth,
		// Token: 0x0400075E RID: 1886
		PS5_RightPad_DPadWest,
		// Token: 0x0400075F RID: 1887
		PS5_RightPad_DPadEast,
		// Token: 0x04000760 RID: 1888
		PS5_CenterPad_Touch,
		// Token: 0x04000761 RID: 1889
		PS5_CenterPad_Swipe,
		// Token: 0x04000762 RID: 1890
		PS5_CenterPad_Click,
		// Token: 0x04000763 RID: 1891
		PS5_CenterPad_DPadNorth,
		// Token: 0x04000764 RID: 1892
		PS5_CenterPad_DPadSouth,
		// Token: 0x04000765 RID: 1893
		PS5_CenterPad_DPadWest,
		// Token: 0x04000766 RID: 1894
		PS5_CenterPad_DPadEast,
		// Token: 0x04000767 RID: 1895
		PS5_LeftTrigger_Pull,
		// Token: 0x04000768 RID: 1896
		PS5_LeftTrigger_Click,
		// Token: 0x04000769 RID: 1897
		PS5_RightTrigger_Pull,
		// Token: 0x0400076A RID: 1898
		PS5_RightTrigger_Click,
		// Token: 0x0400076B RID: 1899
		PS5_LeftStick_Move,
		// Token: 0x0400076C RID: 1900
		PS5_LeftStick_Click,
		// Token: 0x0400076D RID: 1901
		PS5_LeftStick_DPadNorth,
		// Token: 0x0400076E RID: 1902
		PS5_LeftStick_DPadSouth,
		// Token: 0x0400076F RID: 1903
		PS5_LeftStick_DPadWest,
		// Token: 0x04000770 RID: 1904
		PS5_LeftStick_DPadEast,
		// Token: 0x04000771 RID: 1905
		PS5_RightStick_Move,
		// Token: 0x04000772 RID: 1906
		PS5_RightStick_Click,
		// Token: 0x04000773 RID: 1907
		PS5_RightStick_DPadNorth,
		// Token: 0x04000774 RID: 1908
		PS5_RightStick_DPadSouth,
		// Token: 0x04000775 RID: 1909
		PS5_RightStick_DPadWest,
		// Token: 0x04000776 RID: 1910
		PS5_RightStick_DPadEast,
		// Token: 0x04000777 RID: 1911
		PS5_DPad_Move,
		// Token: 0x04000778 RID: 1912
		PS5_DPad_North,
		// Token: 0x04000779 RID: 1913
		PS5_DPad_South,
		// Token: 0x0400077A RID: 1914
		PS5_DPad_West,
		// Token: 0x0400077B RID: 1915
		PS5_DPad_East,
		// Token: 0x0400077C RID: 1916
		PS5_Gyro_Move,
		// Token: 0x0400077D RID: 1917
		PS5_Gyro_Pitch,
		// Token: 0x0400077E RID: 1918
		PS5_Gyro_Yaw,
		// Token: 0x0400077F RID: 1919
		PS5_Gyro_Roll,
		// Token: 0x04000780 RID: 1920
		XBoxOne_LeftGrip_Lower,
		// Token: 0x04000781 RID: 1921
		XBoxOne_LeftGrip_Upper,
		// Token: 0x04000782 RID: 1922
		XBoxOne_RightGrip_Lower,
		// Token: 0x04000783 RID: 1923
		XBoxOne_RightGrip_Upper,
		// Token: 0x04000784 RID: 1924
		XBoxOne_Share,
		// Token: 0x04000785 RID: 1925
		SteamDeck_A,
		// Token: 0x04000786 RID: 1926
		SteamDeck_B,
		// Token: 0x04000787 RID: 1927
		SteamDeck_X,
		// Token: 0x04000788 RID: 1928
		SteamDeck_Y,
		// Token: 0x04000789 RID: 1929
		SteamDeck_L1,
		// Token: 0x0400078A RID: 1930
		SteamDeck_R1,
		// Token: 0x0400078B RID: 1931
		SteamDeck_Menu,
		// Token: 0x0400078C RID: 1932
		SteamDeck_View,
		// Token: 0x0400078D RID: 1933
		SteamDeck_LeftPad_Touch,
		// Token: 0x0400078E RID: 1934
		SteamDeck_LeftPad_Swipe,
		// Token: 0x0400078F RID: 1935
		SteamDeck_LeftPad_Click,
		// Token: 0x04000790 RID: 1936
		SteamDeck_LeftPad_DPadNorth,
		// Token: 0x04000791 RID: 1937
		SteamDeck_LeftPad_DPadSouth,
		// Token: 0x04000792 RID: 1938
		SteamDeck_LeftPad_DPadWest,
		// Token: 0x04000793 RID: 1939
		SteamDeck_LeftPad_DPadEast,
		// Token: 0x04000794 RID: 1940
		SteamDeck_RightPad_Touch,
		// Token: 0x04000795 RID: 1941
		SteamDeck_RightPad_Swipe,
		// Token: 0x04000796 RID: 1942
		SteamDeck_RightPad_Click,
		// Token: 0x04000797 RID: 1943
		SteamDeck_RightPad_DPadNorth,
		// Token: 0x04000798 RID: 1944
		SteamDeck_RightPad_DPadSouth,
		// Token: 0x04000799 RID: 1945
		SteamDeck_RightPad_DPadWest,
		// Token: 0x0400079A RID: 1946
		SteamDeck_RightPad_DPadEast,
		// Token: 0x0400079B RID: 1947
		SteamDeck_L2_SoftPull,
		// Token: 0x0400079C RID: 1948
		SteamDeck_L2,
		// Token: 0x0400079D RID: 1949
		SteamDeck_R2_SoftPull,
		// Token: 0x0400079E RID: 1950
		SteamDeck_R2,
		// Token: 0x0400079F RID: 1951
		SteamDeck_LeftStick_Move,
		// Token: 0x040007A0 RID: 1952
		SteamDeck_L3,
		// Token: 0x040007A1 RID: 1953
		SteamDeck_LeftStick_DPadNorth,
		// Token: 0x040007A2 RID: 1954
		SteamDeck_LeftStick_DPadSouth,
		// Token: 0x040007A3 RID: 1955
		SteamDeck_LeftStick_DPadWest,
		// Token: 0x040007A4 RID: 1956
		SteamDeck_LeftStick_DPadEast,
		// Token: 0x040007A5 RID: 1957
		SteamDeck_LeftStick_Touch,
		// Token: 0x040007A6 RID: 1958
		SteamDeck_RightStick_Move,
		// Token: 0x040007A7 RID: 1959
		SteamDeck_R3,
		// Token: 0x040007A8 RID: 1960
		SteamDeck_RightStick_DPadNorth,
		// Token: 0x040007A9 RID: 1961
		SteamDeck_RightStick_DPadSouth,
		// Token: 0x040007AA RID: 1962
		SteamDeck_RightStick_DPadWest,
		// Token: 0x040007AB RID: 1963
		SteamDeck_RightStick_DPadEast,
		// Token: 0x040007AC RID: 1964
		SteamDeck_RightStick_Touch,
		// Token: 0x040007AD RID: 1965
		SteamDeck_L4,
		// Token: 0x040007AE RID: 1966
		SteamDeck_R4,
		// Token: 0x040007AF RID: 1967
		SteamDeck_L5,
		// Token: 0x040007B0 RID: 1968
		SteamDeck_R5,
		// Token: 0x040007B1 RID: 1969
		SteamDeck_DPad_Move,
		// Token: 0x040007B2 RID: 1970
		SteamDeck_DPad_North,
		// Token: 0x040007B3 RID: 1971
		SteamDeck_DPad_South,
		// Token: 0x040007B4 RID: 1972
		SteamDeck_DPad_West,
		// Token: 0x040007B5 RID: 1973
		SteamDeck_DPad_East,
		// Token: 0x040007B6 RID: 1974
		SteamDeck_Gyro_Move,
		// Token: 0x040007B7 RID: 1975
		SteamDeck_Gyro_Pitch,
		// Token: 0x040007B8 RID: 1976
		SteamDeck_Gyro_Yaw,
		// Token: 0x040007B9 RID: 1977
		SteamDeck_Gyro_Roll,
		// Token: 0x040007BA RID: 1978
		SteamDeck_Reserved1,
		// Token: 0x040007BB RID: 1979
		SteamDeck_Reserved2,
		// Token: 0x040007BC RID: 1980
		SteamDeck_Reserved3,
		// Token: 0x040007BD RID: 1981
		SteamDeck_Reserved4,
		// Token: 0x040007BE RID: 1982
		SteamDeck_Reserved5,
		// Token: 0x040007BF RID: 1983
		SteamDeck_Reserved6,
		// Token: 0x040007C0 RID: 1984
		SteamDeck_Reserved7,
		// Token: 0x040007C1 RID: 1985
		SteamDeck_Reserved8,
		// Token: 0x040007C2 RID: 1986
		SteamDeck_Reserved9,
		// Token: 0x040007C3 RID: 1987
		SteamDeck_Reserved10,
		// Token: 0x040007C4 RID: 1988
		SteamDeck_Reserved11,
		// Token: 0x040007C5 RID: 1989
		SteamDeck_Reserved12,
		// Token: 0x040007C6 RID: 1990
		SteamDeck_Reserved13,
		// Token: 0x040007C7 RID: 1991
		SteamDeck_Reserved14,
		// Token: 0x040007C8 RID: 1992
		SteamDeck_Reserved15,
		// Token: 0x040007C9 RID: 1993
		SteamDeck_Reserved16,
		// Token: 0x040007CA RID: 1994
		SteamDeck_Reserved17,
		// Token: 0x040007CB RID: 1995
		SteamDeck_Reserved18,
		// Token: 0x040007CC RID: 1996
		SteamDeck_Reserved19,
		// Token: 0x040007CD RID: 1997
		SteamDeck_Reserved20,
		// Token: 0x040007CE RID: 1998
		Count,
		// Token: 0x040007CF RID: 1999
		MaximumPossibleValue = 32767
	}
}
