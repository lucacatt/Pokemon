   M S B A M L   `   `   `  ����B  >Pokemon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PokemonPokemon  5   	       Pokemon.score   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Pokemon     5   	     � Title$  score��5   	   $	��384��6   $	��583��6$    � 
ResizeMode$ CanMinimize=�60   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
grd_scores��5
      $
��Left=�6'   $��Center=�6B   $	��148��6f   $	��Top=�6s   $	��200��6�   $��
123,97,0,0q�6�   $��16(�6�   �� 5   
   -   5         ��Name$ lbl_scoreboard��5      $�� ��6(   $��Center=�63   $��54��6P   $��0,29,0,0q�6\   $	��Top=�6n   $	��340��6�   �� 5   
   -   5         ��Name$	 rct��5      $
��Left=�6!   $	��147��6<   $��
328,98,0,0q�6I   
���   �$	��Top=�6l   $	��133��6�   �� 5   
   $��Visualizza per��6   $��Center=�6)   $��31��6M   $��333,112,127,0q�6Y   $	��Top=�6p   $��16(�6�   	� 5   
   -   5         	�Name$ 	sconfitta��5      $��	Sconfitta��6)   $
��Left=�6=   $��Center=�6X   $��27��6z   $��333,190,0,0q�6�   $	��Top=�6�   $	��124��6�    	� 	GroupName$ gruppo��6�   $��16(�6�   6�   	� 5   
   -   5        $ vittoria��5      $��Vittoria��6(   $
��Left=�6;   $��Center=�6V   $��27��6x   $��333,158,0,0q�6�   $	��Top=�6�   $	��124��6�   $ gruppo��6�   $��16(�6�   �� 5   
   -   5         ��Name$ btn_home��5      $�� ��6#   $��Center=�6.   $��53��6K   $��	0,264,0,0q�6W   $	��Top=�6j   $	��131��6�    � Cursor$
 Hand��6�   ��5      �� 5      	 �� 
TargetType"	 ��6   .�5      �� 
 �� Property
 � �� �� Value 5      �� 5       �� 
TargetType" ��6.   .R�5   "   �� #��z��6)   ._�5   &   �� $��Center=�67   $��Center=�6T   5   #   5      5       �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5      �� 
 � ��
 ���� 6;   5      5!      5#      5%      5&      