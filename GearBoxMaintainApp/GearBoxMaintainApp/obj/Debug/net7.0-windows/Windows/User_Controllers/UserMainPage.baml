   M S B A M L   `   `   `  ����M  IGearBoxMaintainApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:GearBoxMaintainApp.Windows.User_Controllers+GearBoxMaintainApp.Windows.User_Controllers  5   	   >    8GearBoxMaintainApp.Windows.User_Controllers.UserMainPage   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Klocal9clr-namespace:GearBoxMaintainApp.Windows.User_Controllers     5   	     � Title$  UserMainPage��5   	   $	��450��6   $	��800��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $
��0.5* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DrGrid��5   %      
IsReadOnly$
 True��6   $��0��65   �� 5   
   $��1��6   .+�5      �� -   5         ��Name$ Refresh��5      $��Refresh��6<   $	��100��6N   $��30��6Z   $��0 10 0 0q�6f   �� 5      -   5        $ Create��5      $��Create��6:   $	��100��6K   $��30��6W   $��0 10 0 0q�6c   �� 5      -   5        $
 Edit��5      $
��Edit��6#   $	��100��6E   $��30��6Q   $��0 10 0 0q�6]   �� 5      -   5        $ Delete��5      $��Delete��6%   $	��100��6K   $��30��6W   $��0 10 0 0q�6c   5      �� 5   
   -   5        $
 Back��5      $
��Back��6   $	��100��6A   $��30��6M   $��0 0 0 10q�6Y   $��Bottom=�6k   $��1��6�   5      5      