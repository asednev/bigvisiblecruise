   M S B A M L   `   `   `  ���� R  NBigVisibleCruise, Version=1.3.5760.30641, Culture=neutral, PublicKeyToken=nullO1clr-namespace:BigVisibleCruise.Commands;assembly=BigVisibleCruise.Commands  -    'BigVisibleCruise.BigVisibleCruiseWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     FCommands1clr-namespace:BigVisibleCruise.Commands;assembly=       � WindowStartupLocation$  CenterScreen=� � Icon$! Cinema-Display-graphite.ico�� � Title$ Big Visible Cruise��
���   �$	��400��$	��600�� � 	Resources    StandardNavigationContainer �� 
TargetType �� Property �� Value  
HostAction  Logo��%�  &	        &	 �     &	     �� " ��.���  � ��$ Center=���  �@��Padding$ 10,10,10,10q���  � ��$ Segoe, Verdana)���  � ��$ 10(���  � ��
 ������� " ��.���  � ��$ Segoe, Verdana)���  � ��$
 Bold"���  � ��$ 10(���  � ��
 ������� " ��.���  � ��$ 18(���  � ��$
 Bold"���  �@��Padding$ 5,5,5,5q���  � ��$ Segoe, Verdana)���  � ��
 ����� J� InputBindings �� 
 �� Key$ F5��0   *BigVisibleCruise.Commands.CommandContainer	   RefreshCommand
 �� Command#
 Z	 �� $	 F11��   FullscreenCommand#
 Z �� $	 F12��   ShowSettingsCommand#
 Z �� $ Escape��#
 Z .��]� .+��� $��Bottom=�._�]� ��.  .+��� $
��Left=�#��[ $��Big Visible Cruise���� $��Right=�#��[  �� #��[  �� Command# Z .�
Settings �� (F12)�� $��Right=�#��[  �� #��[ # Z .�Toggle Fullscreen �� (F11)�� $��Right=�#��[  �� #��[ # Z	 .�Force Refresh �� (F5)(� $	��Top=� (� Stretch$
 Fill=�.����   LiveStatusStyle#���  ���� 