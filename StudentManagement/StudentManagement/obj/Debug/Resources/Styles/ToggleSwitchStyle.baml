   M S B A M L   `   `   `  ����L  HStudentManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:StudentManagement.Resources.Styles"StudentManagement.Resources.Styles  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089U QMahApps.Metro, Version=1.4.0.42, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f %  !MahApps.Metro.Styles.ToggleSwitch  �� 
TargetType)   #MahApps.Metro.Controls.ToggleSwitch �� Property  ToggleSwitchFontFamily �� Value  ToggleSwitchFontSize  
BlackBrush   ToggleSwitchHeaderFontFamily+  %MahApps.Metro.Controls.ControlsHelper  ToggleSwitchHeaderFontSize  
GrayBrush4  AccentColorBrush + 'MahApps.Metro.Styles.ToggleSwitchButton 	 ValidationErrorTemplate �� 
TargetType J� SnapsToDevicePixels � RowDefinitions � ColumnDefinitions ��Name ��Name	   HeaderMargin
    HeaderFontFamily   HeaderFontSize   HeaderFontWeight �� HeaderStringFormat �� ContentStringFormat/  )MahApps.Metro.Controls.ToggleSwitchButton  Name    ToggleSwitchButtonStyle    OffSwitchBrush   OffSwitchBrush    OnSwitchBrush   OnSwitchBrush    ThumbIndicatorBrush   ThumbIndicatorBrush"    ThumbIndicatorDisabledBrush"   ThumbIndicatorDisabledBrush    ThumbIndicatorWidth   ThumbIndicatorWidth � FocusVisualStyle d� 	IsChecked �� RelativeSource �� Mode �� UpdateSourceTrigger'  !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup!   States   System.Windows.VisualState"   
Storyboard# g� Duration$ �� 
TargetName% �� TargetProperty	& W� To' �� Triggers( ]� 
Conditions) �� Property* �� Value+ �� 
TargetName, �� Path- �� Binding. �� Value/ P� Property0 P� Value +
 'MahApps.Metro.Styles.ToggleSwitch.Win101 �� BasedOn & "ToggleSwitchHeaderFontFamily.Win10 $  ToggleSwitchHeaderFontSize.Win10   ToggleSwitchFontFamily.Win10  ToggleSwitchFontSize.Win10 A =MahApps.Metro.Brushes.ToggleSwitchButton.OffSwitchBrush.Win10 @ <MahApps.Metro.Brushes.ToggleSwitchButton.OnSwitchBrush.Win10 F BMahApps.Metro.Brushes.ToggleSwitchButton.ThumbIndicatorBrush.Win10 N JMahApps.Metro.Brushes.ToggleSwitchButton.ThumbIndicatorDisabledBrush.Win10 1 -MahApps.Metro.Styles.ToggleSwitchButton.Win10�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      :local0clr-namespace:StudentManagement.Resources.Styles  5      ;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      %5  &	        &	
 �    7   7  �� 5      "    66   .�5   
   ��  � ��# �  6'   �� 5   
    � ��# �  6%   �� 5   
    � ��# �  6'   �� 5	   
    �@  HeaderFontFamily# �  6-   �� 5
   
    �@ HeaderFontSize# �  6C   �� 5   
    �@ HeaderMargin$ 0 0 0 5q�6A   �� 5   
    � ��$
 Left=�67   �� 5   
    � ��$ Center=�65   �� 5   
    � �� . 6&   �� 5   
    �@  OffSwitchBrush# �  6+   �� 5   
    �@  OnSwitchBrush# �  6*   �� 5   
    �@J�SnapsToDevicePixels . 60   �� 5   
    �@  ThumbIndicatorBrush# �  60   �� 5   
   # �@  ThumbIndicatorDisabledBrush# �  68   �� 5   
    �@  ThumbIndicatorWidth$ 13Q�60   �� 5   
    �@  ToggleSwitchButtonStyle# �  64   �� 5   
    �@=�ErrorTemplate# � 	 65   �� 5   
    � �� 5      �� 5      "   6"   .R�5      �� #��z��6   #��z��5      # z 5      ._�5      � 
������ #��z��68    5      �� 5   "   $
��Auto �60   �� 5    "   $
��Auto �60    5"      �� 5#   "   $ firstCol��63   $��* �6E   �� 5$   "   $ secCol��63   $
��Auto �6C   .+�5&      �� $ Header��6-   $��2��5'   -   #��z	 5(   -   #��z
 5)   -   #��z 5*   -   #��z 5+   -   #��z��5,   -   #��z��5-   -   #��z��5.   -   # z 5/   -   ��.  50   -   �� 51      $ Content��6-   $��0 0 2 0q�52   -   $��1��53   -   #��z��54   -   #��z��55   -   #��z��56   -   #��z��57   -   #��z��58   -   #��z��59   -   #��z��5:   -   # z 5;   -   ��.  5<   -     5=      $ Switch��6:   $��1��5>   :   $��1��5?   :   $��Center=�5@   :   #��z 5A   :   #��z��5B   :   # z 5E   :   # z 5F   :   # z 5G   :   # z 5H   :   # z 5I   :   # z 5J   :    5C   :   Z�  5D   :   �� *	IsChecked+ �� *TemplatedParent+$ TwoWay=�$ PropertyChanged=�5J   :   5K        5L        5M      CommonStates��.! 5N   "     
Normal��6.     5O   "   Disabled��." 5P   &   �� .��5Q   *   W� $# 0D�6:   $$ Header��5R   :   $% (UIElement.Opacity)�5S   :   $	& 0.3X�5T   :   W� 5U   *   $# 0D�6:   $$ Content��5V   :   $% (UIElement.Opacity)�5W   :   $	& 0.3X�5X   :   W� 5Y   *   $# 0D�6:   $$ Switch��5Z   :   $% (UIElement.Opacity)�5[   :   $
& 0.75X�5\   :   5]   '   5^   #   5_      5a      ' 5b      ]� 5c      ( 5d      �� 5e   "   ) �@  	IsChecked$
* TrueY�6A   �� 5f   "   * 6?   Z� ) � ��./�5h      �� $+ Content��6%    � �� 5i   "   �� 5j   &   $, OnLabel�5k   .   $ TwoWay=�5l   .    5j   .   �� *TemplatedParent+5l   .   5n      5o      ]� 5p      ( 5q      �� 5r   "   ) �@  	IsChecked$* FalseY�6A   �� 5s   "   * 6?   Z� ) � ��./�5u      �� $+ Content��6%    � �� 5v   "   �� 5w   &   $, OffLabel�5x   .   $ TwoWay=�5y   .    5w   .   �� *TemplatedParent+5y   .   5{      5|      �� 5}      - 6&   ��  �� *Self+$, Header�. 6l   Z� .a�5~      �� $+ Header��6%    � y�$ 	Collapsed=�6O   5      P� 5�      / �@  ContentDirection$0 RightToLeft=�6>   . �5�      �� $+ Content��6%    � ��$ 2 0 0 0q�6L   �� 5�      $+ Content��6%    � ��$ 1��6Q   �� 5�      $+ Switch��6%    � ��$ 0��6P   �� 5�      $+ firstCol��6%    � ��$
 Auto �6L   �� 5�      $+ secCol��6%    � ��$ * �6J   5�      5�      5�      5�      �� 5�      81   "    5�      .�5�   
   ��  �@  ContentDirection$ LeftToRight=�6-   �� 5�   
    �@  HeaderFontFamily# �  6-   �� 5�   
    �@ HeaderFontSize# �  6C   �� 5�   
    � ��# �  6'   �� 5�   
    � ��# �  6%   �� 5�   
    �@  OffSwitchBrush# �  6+   �� 5�   
    �@  OnSwitchBrush# �  6*   �� 5�   
    �@  ThumbIndicatorBrush# �  60   �� 5�   
   # �@  ThumbIndicatorDisabledBrush# �  68   �� 5�   
    �@  ThumbIndicatorWidth$ 10Q�60   �� 5�   
    �@  ToggleSwitchButtonStyle8  64   5�      5�      