   M S B A M L   `   `   `  ����W  SINF11207-TP3-Jeu-de-Pokemons, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:INF11207_TP3_Jeu_de_Pokemons.Views.UserControls/INF11207_TP3_Jeu_de_Pokemons.Views.UserControls  5   	   8    2INF11207_TP3_Jeu_de_Pokemons.Views.LancementCombat   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Qcontrol=clr-namespace:INF11207_TP3_Jeu_de_Pokemons.Views.UserControls     5   	   -   5        .��5
      �   � RowDefinitions  5   
   �� 5      $
��0.5* �6   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Lancer un nouveau combat��5      $��Center=�5      $��Center=�5      $��2��5      $��0��5      $��2��5      $��30(�5      �� 5   
    �� Orientation$ 
Horizontal=�5      $��2��5      $��4��5       $��Center=�5!      .+�5#      �� $��Lancer un combat��5$      $��50��5%      $��	20,0,20,0q�5&      $��10,0,0,0q�5'      $��15(�5(      ��5)      �� *CommandeLancer+5*      � 5+   
   $��1��6     5,      �� 5-      $	��40* �6    �� 5.      $
��245* �6     � ColumnDefinitions 51      �� 52      $��* �6#   �� 53      $��* �6#   �� 54      $��* �6#   �� 55      $��* �6#   .+�57      �� $��Adeversaire��6   $��0��6+   $��0��6;   �� 58      $��0��6   $��0��6&   $��
71,5,150,5q�63   $��Center=�6G   $��2��6�   ��6i   �� *AddedIdInvitation+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 59      $
��Mise��6   $��1��6$   $��0��64   �� 5:      $��1��6   $��0��6&   $��61,5,1,5q�63   $��Center=�6E   ��6g   �� *
AddMoney+$ PropertyChanged=��� 5;      $��Stretch=�6   $��Stretch=�63   $��0��6O   $��2��6\   $��5,5,5,5q�6l   ��6}   �� *AddInvitationCommand+.��5<      �� $ 
Horizontal=�6   .+�5>      �� $�� Ajouter��6    $��Center=�60   5?      5@      �� 5B      $��Stretch=�6   $��Stretch=�63   $��0��6O   $��3��6\   $��5,5,5,5q�6l   ��6}   �� *SyncInvitationCommand+.��5C      �� $ 
Horizontal=�6   .+�5E      �� $�� Synchroniser��6    $��Center=�65   5F      5G      &   System.Windows.Controls.DataGrid  5I      $��5,5,5,5q�6      AutoGenerateColumns$ False��6h      CanUserAddRows$ False��6�      
IsReadOnly$
 True��6�   $
��True��6�   $
��Auto=�6�   $
��Auto=�6  $��4��6`  $��1��6t  ��6(   �� *Invitations+ �� NotifyOnSourceUpdated$
 True�� �� SelectedItem 64  �� *SelectedInvitation+	   Columns	 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn
   Header$
 InvitationId��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6?   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *InvitationId+  5M      $
 Money��6)   $ * 68    6B   �� *Money+  5N      $
 Status��6)   $ * 69    6C   �� *Status+  5O      $
 Player Emitter��6)   $ * 6A    6K   �� *PlayerEmitterId+  5P      $
 Player Received��6)   $ * 6B    6L   �� *PlayerReceiverId+4  .System.Windows.Controls.DataGridTemplateColumn  5Q      $
 Refuser��6-   $ * 6>      CellTemplate 5R      �� 5S      .R�5T   "   �� ��6)   ��  �� Path$ DataContext.RefuseCommand� �� RelativeSource �� *FindAncestor+ �� AncestorType"  .��5U   &   �� $ 
Horizontal=�61   .+�5V   *   �� $��Refuser��64   $��Center=�6C   5W   '   5X   #   5Y      5[        5\      $
 Accepter��6-   $ * 6?    5]      �� 5^      .R�5_   "   �� ��6)   �� $  DataContext.AccepteCommand� �� *FindAncestor+"  .��5`   &   �� $ 
Horizontal=�61   .+�5b   *   �� $��Accepter��64   $��Center=�6D   5c   '   5d   #   5e      5g        5h      $
 Terminer��6-   $ * 6?    5i      �� 5j      .R�5k   "   �� ��6)   �� $" DataContext.CommandeTerminer� �� *FindAncestor+"  .��5l   &   �� $ 
Horizontal=�61   .+�5n   *   �� $��Terminer��64   $��Center=�6D   5o   '   5p   #   5q      5s      5u      5w      5x      5y      