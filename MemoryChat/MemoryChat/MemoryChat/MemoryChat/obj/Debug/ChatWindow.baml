   M S B A M L   `   `   `  ����E  AMemoryChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MemoryChat
MemoryChat  5   	       MemoryChat.ChatWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MemoryChat     5   	   -   5          � Icon$  Images/chatIcon.png��5   	    � Title$ My Chat��5	   	   $	��715��6   $	��330��6&   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 
lbMessages��5      $��
18,73,18,0q�6&   $��2��6:   $	��469��6N   $	��Top=�6[   �� 5   
   -   5         ��Name$ btnSend��5      $
��Send��6"   $��
70,608,0,0q�61   $��Center=�6E   
����������	#FF1BA68A���	#FF1BA68A$��Center=�6�   $��16(�6�   $��1��6�   $
��Left=�6  $��73��6  $��36��6'  $	��Top=�63   � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � �� �#45454564   �� 5       �@��CornerRadius$ 2��65   �� 5       � ��$ 2q�68   5      5      	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      
   
BlurRadius$
 5Q�6#      	Direction$ 10Q�62      RenderingBias$ Quality=�6A      ShadowDepth$ 0Q�6Y   ��5      �� 5      " ��6   .�5      ��  � ��
 �����63   �� 5       � �� 5       �� 5!       �� 
TargetType" ��6.   .R�5"   "   �� #��z��6)   ._�5#   &   �� $��Center=�67   $��Center=�6T   5$   #   5%      5'       �� Triggers 5(      P� 5)       P� Property �@J�IsMouseOver P� Value . . �5*      ��  � �� �#E2DCDB6;   �� 5+       � �� �#4CB9A36<   5,      5/      51      �� 52   
   -   5         ��Name$ 	tbMessage��52      $��5q�6%   $��31��61   $��94,558,18,0q�6=    �� TextWrapping$
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $��2��6�   
���   �6�   �� 53   
   -   5         ��Name$ label2��53      $��	Message :��6    $
��Left=�64   $��31��6O   $��
18,558,0,0q�6[   $	��Top=�6o   $��71��6�    J� RenderTransformOrigin$ 0.409,6.219&�6�   �� 54   
   -   5        $ TbName��54      $��37��6"   $��
18,18,18,0q�6.   $
 Wrap=�6B   $�� ��6V   $	��Top=�6^   $��2��6v   
��� � �6�   56      57      