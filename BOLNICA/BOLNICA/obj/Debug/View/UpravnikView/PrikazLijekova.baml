   M S B A M L   `   `   `  ����B  >Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BolnicaBolnica  5          Bolnica.PrikazLijekova   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Bolnica     5      .��5	      �� 
�������$��	0,0,0,0.4q�6$   .+�5
   
   � 
����ح�$	��390��6&     � ColumnDefinitions  5      �� 5      $
��650* �6#   �� 5      $
��181* �6#    � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridLijekovi��5         
IsReadOnly .    SelectionMode$ Single=�5      $��4��6*   $��20,20,71,97.4q�6;   
�������$��Center=�5      $��Center=�67      AutoGenerateColumns .  ��5   1   �� *
Lijekovi+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  Naziv lijeka��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 80* 6^   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6@   �� *	NazivLeka+6^     5      $  Jacina lijeka��6)   $	 70* 6\   	 6A   �� *Jacina+6\     5      $  Proizvodjac��6)   $	 80* 6_   	 6?   �� *Proizvodjac+6_     5       $ 	 Kolicina��6)   $	 67* 6Y   	 6<   �� *
Kolicina+6Y   5$      �� 5%      -   5        
 ��Name$
 image��5%      $'��!/Slike/UpravnikSlike/lijekovi.png��6#   $
��Left=�6N   $	��100��6i   $��2��6v   $	��Top=�6�   $	��100��6�    J� RenderTransformOrigin$ 6.066,1.468&�6�   $��1��6�   $��	10,20,0,0q�6�   �� 5&      -   5         ��Name$ UkloniLijek��5&      $��Ukloni lijek��6D   $
��Left=�6[   $	��Top=�6v   $��96��6�   $��361,43.2,0,0q�6�   $��3��6�   $��25��6�   �� 5'      -   5        $ Sastojci��5'      $��Sastojci lijeka��6>   $
��Left=�6X   $	��Top=�6s   $��96��6�   $��20,43.2,0,0q�6�   $��3��6�   $��25��6�   �� 5(      -   5        $ IzmijeniKolicinu��5(      $��Izmijeni kolicinu ��6N   $
��Left=�6k   $	��Top=�6�   $	��108��6�   $��179,43.2,0,0q�6�   $��3��6�   $��25��6�   5*      5,      5-      