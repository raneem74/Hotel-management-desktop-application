   M S B A M L   `   `   `  ����O  KHotelManegmantWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:HotelManegmantWpfAppHotelManegmantWpfApp  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 6:   %    HotelManegmantWpfApp.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:HotelManegmantWpfApp     5   	   9system&clr-namespace:System;assembly=mscorlib     6:   -   5          �Name$  login��5   	   $	��457��5      $	��582��6'   $��Comic Sans MS)�63   
�����p�#��� ��6e    � Icon$6 0/Hybridworks-Haunted-Hotel-Haunted-Hotel.256.png��6�    � Topmost .  � 	Resources 5         ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers	 P� Property
 P� Value��%]  &	        �� 5	   
   " ��6$   .�5
      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $��2,2,2,2q�6K   #��� ��6e   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  � ��
 �OO/�63   5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      $	��59* �6   �� 5      $
��316* �6   �� 5       $	��65* �6   �� 5!      $
��142* �6   .+�5#   
   �� $��Login��6   $
��Left=�6    $��	30,10,0,0q�6;   $	��Top=�6N   $	��306��6f   $��2��6r   $��66��6�   $��22(�6�   $��1��6�   �� 5$   
   -   5        $��Username��5$      $��2��6F   $
��Left=�6V   $��131,154,0,0q�6q   $	��Top=�6�   $	��202��6�   $��35��6�   $��20(�6�   $��2��6�   ���	#FF074247.��6�   ��5%      �� 5&       �� ImageSource$ assets\Username.PNG��6    j� 
AlignmentX$
 Left=�6?    j� Stretch$
 None=�6Q   .��5'   "   5(      �� 5)   
   -   5        $��Password��5)      $��2��6E   $
��Left=�6U   $��131,235,0,0q�6p   $	��Top=�6�   $	��202��6�   $��35��6�   $��2��6�   $��20(�6�   ���	#FF074247.��6�   ��5*      �� 5+      $ assets\Password.PNG��6   $
 Left=�6?   $
 None=�6Q   .��5,   "   5-      �� 5.   
   -   5         ��Name$ 	SigninBtn��5.      #��[  6$   $��2��6I   $��Sign in��6Y   $
��Left=�6k   $��131,310,0,0q�6�   $	��Top=�6�   $��2��6�   $	��202��6�   $��35��6�   $��16(�6�   #��� ��6�   $��0,0,0,0q�6L  59      5:      