   M S B A M L   `   `   `  ����R  NBigVisibleCruise, Version=1.3.5760.30378, Culture=neutral, PublicKeyToken=nullO1clr-namespace:BigVisibleCruise.Commands;assembly=BigVisibleCruise.Commands  5      -    'BigVisibleCruise.BigVisibleCruiseWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      FCommands1clr-namespace:BigVisibleCruise.Commands;assembly=     5        � WindowStartupLocation$  CenterScreen=�5       � Icon$! Cinema-Display-graphite.ico��5       � Title$ Big Visible Cruise��5      
���   �$	��400��5
      $	��600��6    � 	Resources 5         StandardNavigationContainer �� 
TargetType �� Property �� Value  
HostAction  Logo��%�  &	        &	 �     &	 �    �� 5      " ��6.   .�5      ��  � ��$ Center=�6)   �� 5       �@��Padding$ 10,10,10,10q�6   �� 5       � ��$ Segoe, Verdana)�6"   �� 5       � ��$ 10(�6    �� 5       � ��
 �����6"   5      �� 5      " ��6   .�5      ��  � ��$ Segoe, Verdana)�6"   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 10(�6)   �� 5       � ��
 �����6"   5      �� 5      " ��6   .�5      ��  � ��$ 18(�6    �� 5       � ��$
 Bold"�6"   �� 5        �@��Padding$ 5,5,5,5q�6   �� 5!       � ��$ Segoe, Verdana)�6"   �� 5"       � ��
 �����6"   5#      5%       J� InputBindings 5'      �� 5)      
 �� Key$ F5��6   0   *BigVisibleCruise.Commands.CommandContainer	   RefreshCommand
 �� Command#
 Z	 6   �� 5*      $	 F11��6      FullscreenCommand#
 Z 6   �� 5+      $	 F12��6      ShowSettingsCommand#
 Z 6   �� 5,      $ Escape��6   #
 Z 6   .��55      ]� .+�57      �� $��Bottom=�6   ._�58      ]� ��.  .+�59      �� $
��Left=�6   #��[ 6&   $��Big Visible Cruise��6D   �� 5:      $��Right=�6   #��[  6&   �� 5;      #��[ 6    �� Command# Z 5<   
   .�6M   
Settings6W    �� 5=      (F12)6   5>      �� 5?      $��Right=�6   #��[  6&   �� 5@      #��[ 6   # Z 5A   
   .�6K   Toggle Fullscreen6^    �� 5B      (F11)6   5C      �� 5D      $��Right=�6   #��[  6&   �� 5E      #��[ 6   # Z	 5F   
   .�6H   Force Refresh6W    �� 5G      (F5)6   5H      5I      5J      (� 5L      $	��Top=�6    (� Stretch$
 Fill=�6!   .��5M      ��   LiveStatusStyle#���  63   ��6   �� 63   5N      5P      5R      