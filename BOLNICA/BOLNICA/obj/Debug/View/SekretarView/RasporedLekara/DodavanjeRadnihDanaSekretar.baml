   M S B A M L   `   `   `  ����B  >Bolnica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Bolnica.SekretarFolderBolnica.SekretarFolder  5      8    2Bolnica.SekretarFolder.DodavanjeRadnihDanaSekretar   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Bolnica.SekretarFolder     5      .��5	      �� $	��738��6   $
��1024��6   $��Bottom=�6,     �� Orientation$  
Horizontal=�6G   .+�5
   
   � 
���   �$��80��6"   $��0,0,0,0q�6-    � RowDefinitions 5      �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   �� 5      $��* �6    6-   .+�5      �� -   5        $��0��5      
���   �.��5      �� $)��#/Slike/Sekretar/Ikonice/pocetna.jpg��6   $��57��6E   5      �� 5      -   5         ��Name$ Termini��5   5   $��1��6   
���   �.��5      �� $)��#/Slike/Sekretar/Ikonice/termini.jpg��6   5      �� 5      -   5        $ 	Operacije��5   6   $��2��6   
���   �.��5       �� $+��%/Slike/Sekretar/Ikonice/operacije.jpg��6   5!      �� 5"      -   5        $ Nalozi��5"   5   $��3��6   
���   �.��5#      �� $(��"/Slike/Sekretar/Ikonice/nalozi.jpg��6   5$      �� 5%      -   5        $ Obavestenja��5%   5   $��4��6   
���   �.��5&      �� $-��'/Slike/Sekretar/Ikonice/obavestenja.jpg��6   5'      �� 5(      -   5        $ Naplata��5(   5   $��5��6   
���   �.��5)      �� $)��#/Slike/Sekretar/Ikonice/naplata.jpg��6   5*      �� 5+      -   5        $ Stacionarno��5+   5   $��6��6   
���   �.��5,      �� $-��'/Slike/Sekretar/Ikonice/stacionarno.jpg��6   5-      �� 5.      -   5        $ Transfer��5.   5   $��7��6   
���   �.��5/      �� $*��$/Slike/Sekretar/Ikonice/transfer.jpg��6   50      �� 51      -	   5        $ Nazad��51   5   $��8��6   
���   �.��52      �� $'��!/Slike/Sekretar/Ikonice/nazad.jpg��6   53      �� 54      -
   5        $ Licna��54   5   $��9��6   
���   �.��55      �� $'��!/Slike/Sekretar/Ikonice/licna.jpg��6   56      �� 57      -   5        $ Nalog��57   6   $��10��6   
���   �.��58      �� $'��!/Slike/Sekretar/Ikonice/nalog.jpg��6   59      �� 5:      -   5        $ Odjava��5:   6   $��11��6   
���   �.��5;      �� $(��"/Slike/Sekretar/Ikonice/odjava.jpg��6   5<      5=      � 5>   
   -   5         �Name$ 	MainPanel��5>      $	��942��6"   $��	0,0,0,-68q�6.   ���#2b78e4$	��738��6V   $	��Top=�6c   .+�5?      �� $��28,10,98,138q�6   $��1��6+   $��3��68   $��2��6I   ._�5@      F� 
���   �$��1��6&   
����� �$��0,86.837,-68.093,223.5q�6F    �� Stretch$
 Fill=�6f   ��5A      �� 5B       �� Rect$ 20,20,150,50�5C       �� RadiusX$ 3Q�6!    �� RadiusY$ 3Q�6-   5E      5F      �� 5H      $��Raspored lekara��6   $��40(�6.   $
��Left=�6<   $��
305,26,0,0q�6W   $	��Top=�6k   $��67��6�   $	��332��6�   $
��Bold"�6�   �� 5I      $��Dodavanje radnih dana:��6   $��20(�65   $
��Left=�6C   $��
50,105,0,0q�6^   $	��Top=�6r   $��37��6�   $	��219��6�   �� 5J      -   5        $��Odustani��5J      $��298,324,518,376q�6(   $��Center=�6A   $��Center=�6c   
�������6�   �� 5K      -   5        $��Potvrdi��5K      $��445,324,371,376q�6'   $��Center=�6@   $��Center=�6b   
�������6�   (  "System.Windows.Controls.DatePicker  5L      -   5        $��dpPocetniDatum��5L      $
��Left=�6/   $��387,159,0,0q�6J   $	��Top=�6_    J� RenderTransformOrigin$ 1.897,-7.729&�6w   $��27��6�   $	��250��6�   �� 5M      $��Početni datum:��6   $��20(�6-   $
��Left=�6;   $��232,149,0,0q�6V   $	��Top=�6k   $��37��6�   $	��141��6�     5N      -   5        $��dpKrajnjiDatum��5N      $
��Left=�6/   $��387,211,0,0q�6J   $	��Top=�6_   $ 1.897,-7.729&�6w   $��27��6�   $	��250��6�   �� 5O      $��Krajnji datum:��6   $��20(�6-   $
��Left=�6;   $��241,201,0,0q�6V   $	��Top=�6k   $��37��6�   $	��132��6�   �� 5P      $��Smena:��6   $��20(�6%   $
��Left=�63   $��296,252,0,0q�6N   $	��Top=�6c   $��37��6{   $��77��6�   �� 5Q      -   5        $��cbSmena��5Q      $
��Left=�6&   $��Center=�6A   $��387,259,0,449q�6\   	 �� SelectedIndex$	 0��6s   $��30��5R      $	��250��6    
�������$
��Left=�6D   $��Center=�6f   .@�5T      �� $
��Left=�6   .��6:   Prva6@   �� 5U      $
��Left=�6   .��6:   Druga6A   �� 5V      $
��Left=�6   .��6:   Treća6A   5X      5Y      5Z      5[      