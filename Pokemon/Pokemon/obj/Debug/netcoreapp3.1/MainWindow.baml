   M S B A M L   `   `   `  ����B  >Pokemon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PokemonPokemon  5   	       Pokemon.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Pokemon     5   	   V RXamlAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=20a987d8023d9690<gif2https://github.com/XamlAnimatedGif/XamlAnimatedGif  5
   	     � 
ResizeMode$  CanMinimize=�5   	    � Title$ Scegli il tuo Pokémon��5	   	   $	��547��6'   $	��824��64   .��5      � .+�5   
   �� -   5         ��Name$	 pkm��5      $
��Left=�6   $	��241��68   $��110,104,0,0q�6E   $	��Top=�6Z   $	��320��6r   �� 5   
   $��Squadra��6   $
��Left=�6"   $��
678,28,0,0q�6=   $	��Top=�6Q   $��34��6i   $��60��6u   $��13(�6�   �� 5   
   -   5         ��Name$ 
btnIdietro��5      $�� ��6%   $
��Left=�60   $��
67,394,0,0q�6K   $	��Top=�6_   $��50��6�   $��75��6�   
�������$��0,0,0,0q�6�    � Cursor$
 Hand��6�   ��6�   Z� ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value 5      �� 5       �� 
TargetType" ��6.   .R�5   "   �� #��z��6)   ._�5   &   �� $��Center=�67   $��Center=�6T   5   #   5      5      	 �� Triggers	 5      P� 5      
 P� Property
 �@J�IsMouseOver P� Value$
 True��69   . �5      ��  � ��
 ���� 6;   5      5      5!      �� 5"   
   -   5        $ btnSeleziona��5"      $�� ��6'   $
��Left=�62   $��161,386,0,0q�6M   $	��Top=�6b   $��66��6�   $	��215��6�   
�������$��0,0,0,0q�6�   $
 Hand��6�   ��5#      �� 5$      " ��6   .�5%      ��  � �� 5&      �� 5'      " ��6.   .R�5(   "   �� #��z��6)   ._�5)   &   �� $��Center=�67   $��Center=�6T   5*   #   5+      5-      	 5.      P� 5/      
 �@J�IsMouseOver$
 True��69   . �50      ��  � ��
 ���� 6;   51      53      55      �� 56   
   -   5        $ 	btnAvanti��56      $�� ��6$   $
��Left=�6/   $��394,394,0,0q�6J   $	��Top=�6_   $��50��6�   $��75��6�   ���	#FFFFFCFC$��0,0,0,0q�6�   $
 Hand��6�   ��57      �� 58      " ��6   .�59      ��  � �� 5:      �� 5;      " ��6.   .R�5<   "   �� #��z��6)   ._�5=   &   �� $��Center=�67   $��Center=�6T   5>   #   5?      5A      	 5B      P� 5C      
 �@J�IsMouseOver$
 True��69   . �5D      ��  � ��
 ���� 6;   5E      5G      5I      �� 5J   
   -   5        $ btnStats��5J      $�� ��6#   $
��Left=�6.   $��
206,92,0,0q�6I   $	��Top=�6]   $��0,0,0,0q�6�   $	��124��6�   $��30��6�   $
 Hand��6�   ��5K      �� 5L      " ��6   .�5M      ��  � �� 5N      �� 5O      " ��6.   .R�5P   "   �� #��z��6)   ._�5Q   &   �� $��Center=�67   $��Center=�6T   5R   #   5S      5U      	 5V      P� 5W      
 �@J�IsMouseOver$
 True��69   . �5X      ��  � ��
 ���� 6;   5Y      5[      5]      �� 5^   
   -   5        $ 
btnRimuovi��5^      $��Rimuovi dalla squadra��6%   $
��Left=�6E   $��622,190,0,0q�6`   $	��Top=�6u   $	��172��6�   $y�Visible=�6�   $
 Hand��6�   $��13(�6�   �� 5_   
   -   5        $ btnLotta��5_      $�� ��6#   $
��Left=�6.   $��640,417,0,0q�6I   $	��Top=�6^   $	��136��6v   $��70��6�   $
 Hand��6�   ��5`      �� 5a      " ��6   .�5b      ��  � �� 5c      �� 5d      " ��6.   .R�5e   "   �� #��z��6)   ._�5f   &   �� $��Center=�67   $��Center=�6T   5g   #   5h      5j      	 5k      P� 5l      
 �@J�IsMouseOver$
 True��69   . �5m      ��  � ��
 ���� 6;   5n      5p      5r      �� 5s   
   -   5         ��Name$ lbl_nome_pkm��5s      $�� ��6&   $
��Left=�61   $��Center=�6L   $��64��6p   $��	67,13,0,0q�6|   $	��Top=�6�   $	��402��6�   $��40(�6�   $
��Bold"�6�   �� 5t   
   -	   5         ��Name$ lb��5t      $
��Left=�6   $	��128��69   $��
613,55,0,0q�6F   $	��Top=�6Z   $	��190��6r   �� 5u   
   $��Inserisci il tuo nickname��6   $
��Left=�64   $��635,219,0,0q�6O   $	��Top=�6d   $��13(�6|   �� 5v   
   -
   5         ��Name$ txtNome��5v      $
��Left=�6#   $��648,247,0,0q�6>    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��120��6   $��13(�6�   �� 5w   
   -   5        $ 	btnScores��5w      $�� ��6$   $
��Left=�6/   $��28��6J   $��199,470,0,0q�6V   $	��Top=�6k   $	��138��6�   $
 Hand��6�   ��5x      �� 5y      " ��6   .�5z      ��  � �� 5{      �� 5|      " ��6.   .R�5}   "   �� #��z��6)   ._�5~   &   �� $��Center=�67   $��Center=�6T   5   #   5�      5�      	 5�      P� 5�      
 �@J�IsMouseOver$
 True��69   . �5�      ��  � ��
 ���� 6;   5�      5�      5�      5�      5�      