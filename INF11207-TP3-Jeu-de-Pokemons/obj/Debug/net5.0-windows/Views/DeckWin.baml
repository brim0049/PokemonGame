   M S B A M L   `   `   `  ����W  SINF11207-TP3-Jeu-de-Pokemons, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:INF11207_TP3_Jeu_de_Pokemons.Views"INF11207_TP3_Jeu_de_Pokemons.Views  5   	   0    *INF11207_TP3_Jeu_de_Pokemons.Views.DeckWin   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:INF11207_TP3_Jeu_de_Pokemons.Views     5   	     � Title$
  Deck��5   	   $	��180��6   $	��600��6#    � 
ResizeMode$ CanMinimize=�6/   $	��600��6H   $	��180��6W   $	��600��6g   $	��300��6v    � WindowStartupLocation$ CenterScreen=�6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��40* �6   �� 5      $	��40* �6   �� 5      $
��100* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��
Nom Joueur��6   $��0��6&   $��0��66   $
��Left=�6C   $��35��6^   $	��Top=�6k   $	��140��6�   $��2��6�   �� 5   
   $��1��6*   $��0��6:   $
��Left=�6G   $��35��6b   $	��Top=�6o   $	��140��6�   $��2��6�   ��6   �� *Name+6�   �� 5   
   $��DeckId��6   $��0��6"   $��1��62   $
��Left=�6?   $��35��6Z   $	��Top=�6g   $	��140��6   $��2��6�   �� 5   
   $��0��6(   $��2��68   $
��Left=�6E   $��35��6`   $	��Top=�6m   $	��140��6�   $��2��6�   ��6   �� *Id+6�   �� 5   
   $��FirstPokemonId��6   $��1��6*   $��1��6:   $
��Left=�6G   $��35��6b   $	��Top=�6n   $	��140��6�   $��2��6�   �� 5   
   $��1��6+   $��2��6;   $
��Left=�6H   $��35��6c   $	��Top=�6p   $	��140��6�   $��2��6�   ��6   �� *First+6�   �� 5   
   $��SecondPokemonId��6   $��2��6+   $��1��6;   $
��Left=�6H   $��35��6c   $	��Top=�6p   $	��140��6�   $��2��6�   �� 5   
   $��2��6,   $��2��6<   $
��Left=�6I   $��35��6d   $	��Top=�6p   $	��140��6�   $��2��6�   ��6   �� *Second+6�   �� 5    
   $��ThirdPokemonId��6   $��3��6*   $��1��6:   $
��Left=�6G   $��35��6b   $	��Top=�6o   $	��140��6�   $��2��6�   �� 5!   
   $��3��6+   $��2��6;   $
��Left=�6H   $��35��6c   $	��Top=�6p   $	��140��6�   $��2��6�   ��6   �� *Third+6�   5#      5$      