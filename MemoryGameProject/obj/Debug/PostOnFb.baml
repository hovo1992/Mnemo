   M S B A M L   `   `   `  ����L  HMemoryGameProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MemoryGameProjectMemoryGameProject  5   	        MemoryGameProject.PostOnFb   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MemoryGameProject     5   	     � Title$#  Share your result on Facebook��5	   	   $	��345��6/   $��651.47��6<    � Icon$ Images/fb.ico��6K   .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��451* �6   �� 5      $
��192* �6   .+�5   
   �� $
��Left=�6   $��49��6/   $��
106,17,0,0q�6;   $
��Wrap=�6O   $��Status:��6c   $	��Top=�6r   $��20(�6�   $��80��6�    �� Padding$ 8,8,0,0q�6�   �� 5   
   -   5         ��Name$ 
TBoxStatus��5      $��49��6&   $��204,0,0,248q�62    �� TextWrapping$
 Wrap=�6G   $�� ��6[   $��20(�6c   $��Bottom=�6q   $
��Left=�6�   $	��262��6�   $��2��6�   �� 5    
   -   5         ��Name$ 
ButtonPost��5        � Cursor$
 Hand��6%   $��Share��63   $��439,263,0,0q�6C   $��75��6X   ���	#FF4267B2���	#FF4267B2
�������$
��Bold"�6�   $��14(�6�   $
��Left=�6�   $��29��6�   $	��Top=�6  $��2��6   � 	Resources 5!      	 �� 
TargetType
 �� Property �� Value �� Triggers P� Property P� Value��%=  '��       '�� w     �� 5"      "	 ��6   .�5#      �� 
 �@��CornerRadius$ 2��65   �� 5$      
 � ��$ 2q�68   5%      �� 5&      "	 ��6   .�5'      �� 
 � ��
 � � �63    5(      P� 5)       �@J�IsMouseOver . . �5*      �� 
 � ��
 �  ��6;   5+      5-      5.      50      �� 51   
   -   5        $ ButtonCancel��51      $
 Hand��6'   $��Cancel��65   $��
81,263,0,0q�6F   $��74��6Z   $
��Bold"�6e   $��14(�6w   $
��Left=�6�   $��29��6�   $	��Top=�6�   $��1��6�    52      ��%�   '��       �� 53      "	 ��6   .�54      �� 
 �@��CornerRadius$ 2��65   �� 55      
 � ��$ 2q�68   56      57      59      �� 5:   
   -   5         ��Name$ 	ImagePost��5:      $��
204,96,0,0q�6#   $
��Left=�67   $	��263��6R   $	��128��6^   $	��Top=�6k   $��2��6�   �� 5;   
   -   5        $ TBoxPath��5;      $��28��6$   $��204,243,175,0q�60   $y�Hidden=�6G   $
 Wrap=�6[   $�� ��6o   $��20(�6w   $	��Top=�6�   5=      5>      