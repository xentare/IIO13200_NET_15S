   M S B A M L   `   `   `  ����E  ATehtävä4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Tehtävä4
Tehtävä4  5   	       Tehtävä4.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Tehtävä4     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � 	Resources 5	       � XPath 
  viinit � Source��%B   &	        � 5   
   $ /viinikellari/wine��6   $  ?�6D   5      .��5      � .+�5   
   �� -   5         ��Name$ button��5      $��
Hae viinit��6!   $
��Left=�66   $��	21,25,0,0q�6Q   $	��Top=�6d   $��75��6|    J� RenderTransformOrigin$ 
0.37,0.177&�6�   6�   �� 5   
   -   5         ��Name$ maatComboBox��5      $
��Left=�6)   $��
113,25,0,0q�6D   $	��Top=�6X   $	��120��6p   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ viinitListView��5   m    � DataContext# [  6+   	   AutoGenerateColumns	 .  $
��Left=�6�   $	��248��6�   $��	10,62,0,0q�6�   $	��Top=�6�   $	��497��6�   ��6   �� 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Maisteltu viini��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� XPath$
 nimi��6D     5      $ Pojoja��6E    6%   �� $ arvio��6E     5      $	 Maa��6C    6%   �� $	 maa��6C   5      5      5      