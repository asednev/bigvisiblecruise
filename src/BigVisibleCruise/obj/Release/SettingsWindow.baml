   M S B A M L   `   `   `  ���� R  NBigVisibleCruise, Version=1.3.5760.30641, Culture=neutral, PublicKeyToken=nullS3clr-namespace:BigVisibleCruise.Converters;assembly=BigVisibleCruise.Converters  I)clr-namespace:BigVisibleCruise.PropertiesBigVisibleCruise.Properties  %    BigVisibleCruise.SettingsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     J
Converters3clr-namespace:BigVisibleCruise.Converters;assembly=     QBigVisibleCruise_Properties)clr-namespace:BigVisibleCruise.Properties       � Title$  Settings�� � WindowStyle$
 None=� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterOwner=� � AllowsTransparency .  � ShowInTaskbar .   � Topmost .  � Icon$! Cinema-Display-graphite.ico�� � 
ResizeMode$ NoResize=�	 � 	Resources	 ;   5BigVisibleCruise.Converters.TimeSpanToDoubleConverter   TimeSpanToDoubleConverterS   MBigVisibleCruise.Converters.SliderValueInSecondsToReadableTimeFormatConverter 5 1SliderValueInSecondsToReadableTimeFormatConverterE   ?BigVisibleCruise.Converters.CruiseDashboardToStatusUrlConverter ' #CruiseDashboardToStatusUrlConverter  HeadingLabel
 �� 
TargetType �� Property �� Value  UrlTextStyle �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	      &	 
     &	      &	     '�� N    '�� s    '�� �          �� "
 ��.���  � ��$ 16(���  � ��
 �������  � ��
 �   ���  � ��$
 Bold"���  � ��$ Segoe, Verdana)���  � ��$
 Auto����  � ��$ Stretch=���  � ��$ Center=���  � ��$ 10,10,10,10q��� "
 ��.���  � ��$ Tahoma, Verdana)���  � ��$ 14(��� "
 ��.���  � ��
 ������� "
 ��.���  � ��$ 70���� "
 ��.���  � �� �� " ��.R��� $ Border��
������ $��5q�$��	2,10,10,0q�._��� # z #��z��#��z�� P�  �@��
IsSelected . . ��� $ Border�� � ��
 � ����� $ Border�� � ��$ 5q�.����  �� Padding$ 10q�
���   �$��10q�._��  � RowDefinitions �� �� �� �� �� �� ��  � ColumnDefinitions �� $��* ��� $	��350 �.+��� $��0��$��2��$��0��$��0,0,0,10q�#��[ $!��Big Visible Cruise Settings��$��5q��� $��0��$��1��$��2,5,2,5q�$��Dashboard Url���� -   $��
UrlTextBox��$��1��$��1��$��2,5,2,5q�$��25��$��0��#��[ .��.����  �� Path$ 	Dashboard� �� Mode$ TwoWay=�*  $BigVisibleCruise.Properties.Settings   Default �� Source# Z  �� 	Converter# [ �� $��0��$��3��$��25��$��2,5,2,5q�$��Check Status���� $��1��$��3��$��25��$��2,5,2,5q�����  �� ElementName$ RefreshSlider��$ Value�# [ �� -   $��RefreshSlider��$��1��$��4��$��2,5,2,5q� �� AutoToolTipPlacement$
 None=� � Minimum$ 15Q� � Maximum$	 600Q�  � SmallChange$  5Q�! � LargeChange$! 30Q�$��1��" � OverridesDefaultStyle" .  # � Value# �� # Z $ PollFrequency�# [  $ TwoWay=��� $��0��$��5��$��25��$��2,5,2,5q�$��Visual Appearance���� $��1��$��5��$��2,5,2,5q�$��0q�$ �� SelectedValuePath$	$ Tag��$��2��% �� SelectedValue% �� # Z $
 Skin�$ TwoWay=����� .R��� & �� Orientation$& 
Horizontal=�.@��� 
' � Tag$' LiveStackedStatus��.���� $��Images/StackedIcon.png���� $' LiveUniformStatus��.���� $��Images/GridIcon.png���� $��Right=�$& 
Horizontal=�$��0��$��2��$��6��.+��� -   ( �� 	IsDefault( . $��10,0,0,0q�$��Close��