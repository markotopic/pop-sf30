   M S B A M L   `   `   `  ����H  Dpop-sf30-2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:pop_sf30_2016.UI.IzmenaEntitetapop_sf30_2016.UI.IzmenaEntiteta  5   	   8    2pop_sf30_2016.UI.IzmenaEntiteta.IzmenaAkcijaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:pop_sf30_2016.UI.IzmenaEntiteta     5   	     � Title$  IzmenaAkcijaWindow��5   	   $	��300��6$   $	��300��61   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��75* �6   �� 5      $
��100* �6   �� 5      $
��117* �6    � RowDefinitions 5   
   �� 5      $	��12* �6   �� 5      $	��11* �6   �� 5      $	��12* �6   �� 5      $	��12* �6   �� 5      $	��12* �6   �� 5      $	��76* �6   .+�5   
   �� $��0��6   $��0��6   $��Datum pocetka��6-   $
��Left=�6E   $��75��6`   6m   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpDatumPocetka��5      $��15(�6.   $	��100��6<   $��30��6H   $��0��6T   $��1��6a      SelectedDate 6q   ��  �� Path$ DatumPocetka��� 5   
   $��1��6   $��0��6   $��Datum zavrsetka��6-   $
��Left=�6G   $��70��6b     5   
   -   5        $ dpDatumZavrsetka��5      $��15(�6/   $	��100��6=   $��30��6I   $��1��6U   $��1��6b    6r   �� $ DatumZavrsetka��� 5   
   $��2��6   $��0��6   $��Popust��6-   $
��Left=�6>   $��75��6Y   �� 5   
   -   5        $��tbPopust��5   X   $��2��6   $��1��6   $��15(�6/   $
��Left=�6=   $	��100��6h   ��6t   �� $ Popust��� 5!   
   -   5        $��Sacuvaj��5!      $��Right=�6#   $��
0,126,22,0q�6?   $��5��6S   $��46��6`   6k   �� 5"   
   -   5        $��Izlaz��5"      $��Right=�6!    J� RenderTransformOrigin$ 1.009,0.562&�6=   $��1��6a   $��
0,126,41,0q�6q   $��5��6�   $��53��6�   6�   5#      5$      