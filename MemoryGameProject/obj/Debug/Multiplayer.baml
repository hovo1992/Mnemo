   M S B A M L   `   `   `  ����L  HMemoryGameProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MemoryGameProjectMemoryGameProject  5   	   #    MemoryGameProject.Multiplayer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MemoryGameProject     5   	     � 
ResizeMode$  NoResize=�5   	    � Icon$! Images/multiplayer_icon.png��5	   
    � Title$ Multiplayer��5
   	   $	��300��6   $	��300��6*    � WindowStartupLocation$ CenterScreen=�66   .��5      � $��-2,0,2,0q�6    � 	Resources 5   
      AddButtonImageBrush �� ImageSource j� Stretch��%L   &	        �� 5      $ Images/back.png��65   $ UniformToFill=�6S   5      ��5   
   �� 5       �� EndPoint$ 0.5,.3&�6"    �� 
StartPoint$ 1.3,.1&�64   	 � SpreadMethod$	 Repeat=�6H   .��5      � 
 � Color$
 #1BBC9B��6    � Offset$ 2Q�6/   � 5      $

 #fff��6   $ .1Q�6,   � 5      $
 White��6   $	 .13Q�6-   5      .+�5   
   �� -   5         ��Name$ IpBox��5      $
��Left=�6!   $��34��6<   $��	18,81,0,0q�6H    �� TextWrapping$
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��252��6�   $��3,6,0,0q�6�   $��14(�6�   �� 5   
   -   5        $ PortBox��5      $y�Hidden=�6#   $
��Left=�67   $��34��6R   $��
206,81,0,0q�6^   $
 Wrap=�6r   $��25565��6�   $	��Top=�6�   $��76��6�   �� 5   
   -   5         ��Name$ StartAsServerBtn��5      $��Server��6+   $��37��6<   ���	#FF323A45$
��Left=�6_   $��
18,173,0,0q�6z   $	��Top=�6�   $��98��6�    � ToolTip$  Start as Server��6�   $��14(�6�   $
��Bold"�6�   
�������  BackgroundButton#���  6   5       �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value �� Property �� Value��%1  &	       �� 5      " ��6;   .R�5      �� $��border��6   $��1q�6+   ���	#FF707070$ 2��6W   #��z��6h   ._�5      �� $��Center=�6+   $��Center=�6H   5       5       P� 5!       �@J�IsMouseOver . . �5"      ��  �@J�Opacity$ .8Q�68   5#      5%      5&      5'      �� 5(   
   -   5        $ StartAsClientBtn��5(      $��Client��6+   $��37��6<   $
��Left=�6H   ���	#FF1BA68A$��171,173,0,0q�6z   $	��Top=�6�   $��98��6�   $  Start as Client��6�   
�������$��14(�6�   $
��Bold"�6    BackgroundButton1#���  6   5)      ��%1  &	       �� 5*      " ��6<   .R�5+      �� $��border��6   $��1q�6,   ���	#FF707070$ 2��6X   #��z��6i   ._�5,      �� $��Center=�6+   $��Center=�6H   5-       5.      P� 5/       �@J�IsMouseOver . . �50      ��  �@J�Opacity$ .8Q�68   51      53      54      55      �� 56   
   -   5         ��Name$ IpAndPortLbl��56      $��Set IP��6&   $��24(�67   $
��Left=�6E   $��48��6`   $��	18,28,0,0q�6l   $	��Top=�6   $	��178��6�   ���	#FF4040406�   �� 57   
   -   5        $ 
StartAsLbl��57      $��	Start as:��6$   $��18(�68   $
��Left=�6F   $��33��6a   $��
18,127,0,0q�6m   $	��Top=�6�   $	��252��6�   ���	#FF4040406�   �� 58   
   -   5        $ button��58      $
��Left=�6!   ���#D4F2EC���#D4F2EC$��3,3,0,0q�6g   $	��Top=�6x   $��20��6�   $��20��6�    J� RenderTransformOrigin$ 0.35,0.5&�6�   .��5:      �� $��Images/back.png��6   $��UniformToFill=�6-   $��14��6E   $��14��6Q   $ 0.35,0&�6\   5<      5=      5>      