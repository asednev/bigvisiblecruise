   M S B A M L   `   `   `  ����R  NBigVisibleCruise, Version=1.3.5760.30378, Culture=neutral, PublicKeyToken=nullS3clr-namespace:BigVisibleCruise.Converters;assembly=BigVisibleCruise.Converters  5      I)clr-namespace:BigVisibleCruise.PropertiesBigVisibleCruise.Properties  5      %    BigVisibleCruise.SettingsWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      J
Converters3clr-namespace:BigVisibleCruise.Converters;assembly=     5      QBigVisibleCruise_Properties)clr-namespace:BigVisibleCruise.Properties     5        � Title$  Settings��5       � WindowStyle$
 None=�5       � SizeToContent$ WidthAndHeight=�5	       � WindowStartupLocation$ CenterOwner=�5
       � AllowsTransparency .  � ShowInTaskbar .   � Topmost .  � Icon$! Cinema-Display-graphite.ico��5       � 
ResizeMode$ NoResize=�5      	 � 	Resources	 5      ;   5BigVisibleCruise.Converters.TimeSpanToDoubleConverter   TimeSpanToDoubleConverterS   MBigVisibleCruise.Converters.SliderValueInSecondsToReadableTimeFormatConverter 5 1SliderValueInSecondsToReadableTimeFormatConverterE   ?BigVisibleCruise.Converters.CruiseDashboardToStatusUrlConverter ' #CruiseDashboardToStatusUrlConverter  HeadingLabel
 �� 
TargetType �� Property �� Value  UrlTextStyle �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	      &	 &     &	 9     &	 �    '�� @    '�� �    '�� �      5      6)     5      6A     5      63   �� 5   
   "
 ��6%   .�5      ��  � ��$ 16(�6    �� 5       � ��
 �����6"   �� 5       � ��
 �   �6"   �� 5       � ��$
 Bold"�6"   �� 5       � ��$ Segoe, Verdana)�6"   �� 5       � ��$
 Auto��6   �� 5       � ��$ Stretch=�6+   �� 5       � ��$ Center=�6)   �� 5        � ��$ 10,10,10,10q�6   5!      �� 5#   
   "
 ��6%   .�5$      ��  � ��$ Tahoma, Verdana)�6+   �� 5%       � ��$ 14(�6)   5&      �� 5(   
   "
 ��6   .�5)      ��  � ��
 �����6"   5*      �� 5,   
   "
 ��6   .�5-      ��  � ��$ 70��6&   5.      �� 50      "
 ��6
   .�51      ��  � �� 52      �� 53      " ��6   .R�54      �� $ Border��6   
������ $��5q�69   $��	2,10,10,0q�6M   ._�55   	   �� # z 6   #��z��56      #��z��57      58   	    59      P� 5:   	    �@��
IsSelected . . �5;   
   �� $ Border��6(    � ��
 � ���6<   �� 5<   
   $ Border��6,    � ��$ 5q�6@   5=   
   5?      5A      5B      5D      .��5G      ��  �� Padding$ 10q�6   
���   �$��10q�6.   ._�5H      �  � RowDefinitions 5I      �� 5J      6   �� 5K      6   �� 5L      6"   �� 5M      6   �� 5N      6   �� 5O      6   �� 5P      6"    � ColumnDefinitions 5S      �� 5T      $��* �6   �� 5U      $	��350 �6   .+�5X      �� $��0��6   $��2��6   $��0��6/   $��0,0,0,10q�6<   #��[ 5Y      $!��Big Visible Cruise Settings��5Z      $��5q�6.   �� 5\      $��0��6   $��1��6$   $��2,5,2,5q�61   $��Dashboard Url��6B   �� 5^      -   5        $��
UrlTextBox��5^   3   $��1��6   $��1��6&   $��2,5,2,5q�6E   $��25��6V   $��0��6b   #��[ 6o   .��6�   .��5`      ��  �� Path$ 	Dashboard�6    �� Mode$ TwoWay=�5a   	   *  $BigVisibleCruise.Properties.Settings   Default �� Source# Z 5b   	    �� 	Converter# [ 5c   	   5d      5f      �� 5h      $��0��6   $��3��6   $��25��6(   $��2,5,2,5q�64   $��Check Status��5i      �� 5k      $��1��6   $��3��6   $��25��6(   $��2,5,2,5q�64   ��5l      ��  �� ElementName$ RefreshSlider��$ Value�# [ �� 5n      -   5        $��RefreshSlider��5n      $��1��6"   $��4��62   $��2,5,2,5q�6?    �� AutoToolTipPlacement$
 None=�5o       � Minimum$ 15Q�6"    � Maximum$	 600Q�6/     � SmallChange$  5Q�6=   ! � LargeChange$! 30Q�6M   $��1��5p   �   " � OverridesDefaultStyle" .  # � Value# 6   �� # Z $ PollFrequency�# [  $ TwoWay=�6�   �� 5r      $��0��6   $��5��6   $��25��6(   $��2,5,2,5q�64   $��Visual Appearance��5s      �� 5u      $��1��6   $��5��6   $��2,5,2,5q�6*   $��0q�5v      $ �� SelectedValuePath$	$ Tag��5x      $��2��6   % �� SelectedValue% 5w      �� # Z $
 Skin�$ TwoWay=���5z      �� 5{      .R�5|      �� & �� Orientation$& 
Horizontal=�6   5}      .@�5�      �� 
' � Tag$' LiveStackedStatus��6   .��5�      �� $��Images/StackedIcon.png��6   5�      �� 5�      $' LiveUniformStatus��6   .��5�      �� $��Images/GridIcon.png��6   5�      5�      �� 5�      $��Right=�6   $& 
Horizontal=�66   $��0��6O   $��2��6_   $��6��6s   .+�5�      �� -   5        ( �� 	IsDefault( . $��10,0,0,0q�5�   >   $��Close��6P   5�      5�      5�      5�      