   M S B A M L   `   `   `  ����B  >Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BolnicaBolnica  5          Bolnica.RasporedOpreme   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Bolnica     5      .��5	      �� 
�������$��	0,0,0,0.4q�6$   .+�5
   
   � 
����ح�$	��390��6&     � ColumnDefinitions  5      �� 5      $
��559* �6#   �� 5      $
��241* �6#    � RowDefinitions 5      �� 5      $	��43* �6    �� 5      $
��150* �6    �� 5      $	��98* �6    �� 5      $	��98* �6    .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridRasporedOpreme��5         
IsReadOnly .    SelectionMode$ Single=�5      $��4��6*   $��51,43,118,31.4q�6;   
�������$��Center=�5      $��Center=�67      AutoGenerateColumns .  ��5   7   �� *Oprema+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
 ID opreme��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 105 6Z   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6=   �� *
IdOpreme+6Z     5      $  Naziv opreme��6)   $
 120* 6`   	 6@   �� *NazivOpreme+6`     5      $ 	 Kolicina��6)   $ 90 6Y   	 6<   �� *
Kolicina+6Y   5       �� 5!      -   5        $��1��5!      $��2��6%   $��Dodaj opremu��62   $��35,73.4,20.2,0q�6I   $��Center=�6a   $��Center=�5"      
�������$��25��6g   $	��Top=�6s   �� 5#      -   5        $��1��5#      $��3��6%   $��Premjesti opremu��62   $��35,10,20.2,63.4q�6M   $��Center=�6f   $��Center=�5$      $��25��65   
�������6_   �� 5%      -   5        $��1��5%      $��3��6%   $��Nazad��62   $��35,0,20.2,31.4q�6B   $��Center=�6Z   $��Center=�5&      
�������$��25��6a   $��Bottom=�6m   �� 5'      -   5        
 ��Name$
 image��5'      $(��"/Slike/UpravnikSlike/slusalice.png��6#   $
��Left=�6O   $��82��6j   $	��Top=�6v   $��89��6�    J� RenderTransformOrigin$ 6.066,1.468&�6�   $��1��6�   $��	94,43,0,0q�6�   $��2��6�   5)      5+      5,      