   M S B A M L   `   `   `  ����B  >Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BolnicaBolnica  5   	       Bolnica.IzmenaOpreme   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Bolnica     5   	     � Title$  Izmena opreme��5   	   $��387.133��6   $	��400��60    � WindowStartupLocation$ CenterScreen=�6<   .��5	      � 
����ح�$��0,0,-0.4,-1.4q�6"    � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $	��60* �6   �� 5      $	��60* �6   �� 5      $	��60* �6   �� 5      $	��80* �6   .+�5   
   �� $��Naziv opreme:��6   $��Right=�6(   $��Center=�6D   $��Right=�6_   $��Center=�6�   $��0��5      $��0��6    $��0,19.4,19.6,19.4q�6-   $��30��6G   $	��150��6S   �� 5   
   -   5        $��NazivOpreme��5   (    �� AcceptsReturn . $��0��6;   $��1��6H   $
��Left=�6X   $��Center=�6s   $��20.4,19.4,0,19.4q�6�   $��30��6�   $	��155��6�   
�������$
��Left=�6�   $��Center=�6�   �� 5   
   $��Vrsta opreme:��6   $��Right=�6(   $��Center=�6D   $��Right=�6_   $��Center=�6�   $��0��5      $��1��6    $��0,19,19.6,19.8q�6-   $��30��6E   $	��150��6Q   �� 5   
   -   5        $��VrstaOpreme��5   %    �� 
IsEditable . $��1��68   $��1��6E   $
��Left=�6U   $��Center=�6p   $��20.4,18.4,0,18q�6�    �� SelectedIndex$ 0��6�   $��30��5       $	��155��6    
�������$
��Left=�6D   $��Center=�6f   .@�5"      �� $
��Left=�6   .��66   
staticka6@   �� 5#      $
��Left=�6   .��66   	dinamicka6A   5$      �� 5&   
   $��	Kolicina:��6   $��Right=�6$   $��Center=�6@   $��Right=�6[   $��Center=�6~   $��0��5'      $��2��6    $��0,19.8,19.6,19q�6-   $��30��6E   $	��150��6Q   �� 5)   
   -   5        $��Kolicina��5)   '    . $��2��67   $��1��6D   $
��Left=�6T   $��Center=�6o   $��20.4,19.8,0,19q�6�   $��30��6�   $	��155��6�   
�������$
��Left=�6�   $��Center=�6�   �� 5,   
   -   5        $��Odustani��5,      $��0��6$   $��4��64   $��46,19.8,45.6,19q�6B   $	��100��6\   $��25��6h   $��Center=�6t   $��Center=�6�   
�������$��2��5-   @   $��Center=�6Q   $��Right=�6l   �� 5/   
   -   5        $��Potrvdi��5/      $��1��6#   $��4��63   $��45.4,19.8,46.2,19q�6A   $	��100��6]   $��25��6i   $��Center=�6u   $��Center=�6�   
�������$��2��50   ?   $��Center=�6P   $
��Left=�6k   52      53      