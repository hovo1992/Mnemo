   M S B A M L   `   `   `  ����L  HMemoryGameProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MemoryGameProjectMemoryGameProject  5      $    MemoryGameProject.CustomMsgBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      1localclr-namespace:MemoryGameProject     5        � Title$  Congratulations��5      $	��300��6   $	��500��6(    � Icon$% Images/icon_congratulations.png��65    � 	Resources 5	       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value   NoChromeButton	 �� 
TargetType
 �Name J� SnapsToDevicePixels �� Triggers �� 
TargetName��%k  '��       &	  �     �� 5
   
   " ��6    5      P� 5       �@J�IsMouseOver . . �5      ��  �@J�Opacity$ .8Q�60   �� 5       � ��
 �   �63   �� 5       �@�Cursor$
 Hand��6/   5      5      �� 5   
   " ��6'   .�5      ��  � ��
 ���� 6+   �� 5       � ��$ 1q�60   �� 5       � ��# � ��6+   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 1q�6(   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      � $
 Chrome��6   #��z��6/    . .+�5      �� #��z��6/   #��z��6r   ��. # z 6�   #��z��6�   5       5       P� 5!       � {� .  . �5"   "   ��  � �� �#ADADAD6?   �� 5#   "   $ Chrome��6<    �@J�Opacity$	 0.5Q�6P   5$      5&      5(      5)      5*      .��5+      � -   5        $
 Screen��5+      .+�5,   
   �� -   5         ��Name$ LabelMsg��5,      $��Center=�6"   $��Center=�6?   $��38��6c   $��18(�6o   $��
18,28,10,0q�6}   $	��Top=�6�   $	��464��6�   �� 5-   
   -   5         ��Name$ ButtonFb��5-      #���   6$    � Cursor$
 Hand��6M   $�� ��6[   $
��Left=�6f   $��58��6�   $��
84,157,0,0q�6�   $	��Top=�6�   $��58��6�   ��5.      �� 5/       �� ImageSource$ Images/fb.ico��6   52      �� 53   
   -   5        $ ButtonOK��53      $	��✅��6#   $
 Hand��65   $
��Left=�6C   $��58��6^   $��356,157,0,0q�6j   $	��Top=�6   $��58��6�   $
��Bold"�6�   $��40(�6�   
����������	#FFffffff
������� 54      ��%�   '��       �� 55      " ��6   .�56      ��  � ��
 �����64   �� 57       �@��CornerRadius$ 8��65   �� 58       � ��$ 8q�68   59      5;      5=      �� 5>   
   -   5         ��Name$ fbProfilePicture��5>      $
��Left=�6*   $��156,71,0,47q�6E   $	��178��6Z   �� 5?   
   -   5        $ fbName��5?      $
��Left=�6    $��Center=�6;   $��27��6_   $��156,233,143,0q�6k   $�� ��6�   $	��Top=�6�   $	��193��6�   5@      5A      