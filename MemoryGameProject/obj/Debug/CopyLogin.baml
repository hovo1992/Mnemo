   M S B A M L   `   `   `  ����L  HMemoryGameProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MemoryGameProjectMemoryGameProject  5   	   !    MemoryGameProject.CopyLogin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MemoryGameProject     5   	     � Title$  	CopyLogin��5   	   $��466.667��6   $	��354��6,    � 	Resources 5	         placeHolder �� 
TargetType �� BasedOn �� Property �� Value �� 
TargetType ��Name K� ZIndex	 �� Path
 �� RelativeSource �� Mode �� UpdateSourceTrigger
 � Tag �� Triggers �� Binding �� Source%  System.Windows.Markup.Reference �� Value��%z  &	        7���� 5
   
   " ��6$   8   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ 
textSource��5   "   
������ $ 2��5   "   ��5   &   �� $
	 Text�
 �� *TemplatedParent+$ TwoWay=�$ PropertyChanged=�5   "   �� 5      #��z 6&   #��z��6C   $ 1��6m   .��6~   ��5   "   �� 5   &   " ��6,   .�5   *   ��  � ��
 ���� 6G    5   *   �� 5   .    6:   �� $
	 Text�   *
textSource+  6y   .a�5   2   ��  � ��
 �����6O   5   /   5   '   .��5    1   5!      5"      5#      5%      5&      5E      .��5F      �  5G   
     myImage J� OpacityMask �� 
StartPoint �� EndPoint � Offset � Color  myBrush !� Visual��%  &	       &	 �     7  �� 5H      $��Images/test.jpg��6$    5I      �� 5J      $ 0,0.5&�6*   $ 1,0.5&�6=   .��5K      � $	 0.0Q�6'   $ 	#00000000��64   � 5L      $	 1.0Q�6'   $ 	#FF000000��64   5M      5O      !� 5P      8   6+   5Q       � RowDefinitions 5R   
   �� 5S      $	��23* �6   �� 5T      $
��195* �6    � ColumnDefinitions 5V   
   �� 5W      $
��166* �6   �� 5X      $
��129* �6   �� 5Y      $��4* �6   �� 5Z      $	��47* �6   ��5\   
   �� 5]      $	 0,0&�6"   $	 1,1&�61    � SpreadMethod$ Repeat=�6B   .��5^      � $ #2986B1��6   $ 0Q�6/   � 5_      $
 #fff��6   $ .5Q�6,   � 5`      $ #2986B1��6   $ 1Q�6/   5a      .+�5e   
   �� -   5         ��Name$ checkBox��5e      $��Play without registration��6%   $��	9,227,0,0q�6I   $��19��6w   $	��Top=�6�   $
��Left=�6�   $	��142��6�   $��Comic Sans MS)�6�   $��10(�6�   5g      �� 5h   
   -   5         ��Name$ 
LabelEmail��5h      $��Email��6$   $��Center=�64   ���	#FFB5B5B5$��Center=�6h   $��22��6�   $��
92,19,49,0q�6�   $	��Top=�6�   $	��154��6�    � ToolTip$ Email��6�   $��11(�6�   $��2��6  $��Comic Sans MS)�6.  $��1��6I  �� 5j   
   $��Images/user.png��6   $��UniformToFill=�6)   $��22��6A   $��22��6M   $��	0,47,79,0q�6X   $��Right=�6k   $	��Top=�6�    J� RenderTransformOrigin$ -12.692,-0.538&�6�   $ Email��6�   $��1��6�   �� 5k   
   -   5        $ TextBoxEmail��5k      #��[  6)   $ Email��6N   $
��Left=�6Z   $��23��6u   $��	92,46,0,0q�6�    �� TextWrapping$ NoWrap=�6�   $�� ��6�   $	��Top=�6�   $	��154��6�     �� 	MaxLength$  80��6�   $
��1, 1q�6�   $ Email��6�   $	 -10��6  $��2��6D  $��1��6X  �� 5l   
   -   5        $ LabelPassword��5l      $��Password��6'   $
��Left=�6:   $��22��6U   ���	#FFB5B5B5$��Center=�6x   $��11(�6�   $��	90,72,0,0q�6�   $	��Top=�6�   $	��154��6�   $ Password��6�   $ 0.5,0.5&�6#  $��Comic Sans MS)�6C  $��1��6^  $��2��6k  z�5m      V� 5n      .~�5o      �� �� 5p      ! �� AngleX$! 1.591Q�6$   �� 5q      T� 5r      " T� X$" 0.306Q�6)   5s      5u      �� 5v   
   $��Images/unlock.png��6   $��UniformToFill=�6+   $��22��6C   $��22��6O   $��	65,97,0,0q�6Z   $
��Left=�6m   $	��Top=�6�   $ -12.692,-0.538&�6�   $ Password��6�   $��1��6�   G� 5x   
   -   5        # G�Name$# PasswordBox��5x      $
��Left=�6,   $��23��6G   $��	92,97,0,0q�6S   $	��Top=�6f   $	��154��6~   $ G� 	MaxLength$$ 50��6�   $
��1, 3q�6�   $ Password��6�   $��2��6�   $��1��6�   �� 5y   
   -   5        % ��Name$% ErrorMsg��5y      $��20��6'   & �� TextAlignment$& Center=�63   $
��Left=�6J   $��
39,126,0,0q�6e   $	��Top=�6y   $	��260��6�   
 �<�����	#FFE5572C$��3��6�   $��1��6�   �� 5z   
   -   5        ' ��Name$' ButtonSignIn��5z      $��Log In��6'   $
��Left=�68   $��26��6S   $��
90,151,0,0q�6_   $	��Top=�6s   $	��154��6�   $ Log In��6�   ���	#FF668F25���	#FFFCFFFE$��14(�6�   $��2��6   $��Comic Sans MS)�6  $��1��6/  ( J� Effect( 5{      3  -System.Windows.Media.Effects.DropShadowEffect  5|      )   
BlurRadius$) 5Q�6#   *   	Direction$	* -90Q�62   +   RenderingBias$+ Quality=�6B   ,   ShadowDepth$, 2Q�6Z    5~      ��%�   '��       �� 5      " ��6   .�5�      ��  � �� �#294D7163   �� 5�       � �� �#fff64   �� 5�       �@��CornerRadius$ 3��65   �� 5�       � ��$ 2q�68   �� 5�       � �� �#6CC4B264   5�      5�      5�      �� 5�   
   -   5        $' ButtonMultiplayer��5�      $��	2 Players��6,   $ 	2 Players��6@   $��152,212,0,0q�6U   ���	#FF668F25$	��Top=�6�   $ 0.269,0.028&�6�   
�������$
��Left=�6�   $��76��6  $��23��6  $��Comic Sans MS)�6"  $��1��6=  $��2��6J  ( 5�        5�      $) 5Q�6#   $	* -90Q�62   $+ Quality=�6B   $, 2Q�6Z    5�      ��%�   '��       �� 5�      " ��6   .�5�      ��  � �� �#294D7163   �� 5�       � �� �#fff64   �� 5�       �@��CornerRadius$ 3��65   �� 5�       � ��$ 2q�68   �� 5�       � �� �#6CC4B264   5�      5�      5�      �� 5�   
   -	   5        $' 
ButtonPlay��5�      $
��Play��6%   $
��Left=�64   $��
73,212,0,0q�6O   ���	#FF668F25$��76��6z   $��23��6�   $
 Play��6�   $ 0.269,0.028&�6�   
�������$��1��6�   $	��Top=�6   $��Comic Sans MS)�6  $��1��63  $��3��6@  ( 5�        5�      $) 5Q�6#   $	* -90Q�62   $+ Quality=�6B   $, 2Q�6Z    5�      ��%�   '��       �� 5�      " ��6   .�5�      ��  � �� �#294D7163   �� 5�       � �� �#fff64   �� 5�       �@��CornerRadius$ 3��65   �� 5�       � ��$ 2q�68   �� 5�       � �� �#6CC4B264   5�      5�      5�      �� 5�   
   -
   5        $��
81,280,0,0q�5�      $��Sign Up��6%   ���#B9472C$ Sign Up��6g   
�������$
��Left=�6�   $��76��6�   $��26��6�   $��1��6�   $	��Top=�6�   $��Comic Sans MS)�6�   $��1��6  $��3��6   5�      ��%�   '��       �� 5�      " ��6   .�5�      ��  � �� �#B9472C64   �� 5�       �@��CornerRadius$ 2��65   �� 5�       � ��$ 3q�68   �� 5�       � �� �#B9472C64   5�      5�      5�      �� 5�   
   $
��Wrap=�6   $��... or login with:��6(   $��136,318,0,0q�6B   $��2��6W   $
��Left=�6k   $��76��6�   $��23��6�   $	��Top=�6�   $��1��6�   $��10(�6�   ���	#FF657176$��Comic Sans MS)�6�   �� 5�   
   -   5        $' ButtonSignInWithFacebook��5�      $��Facebook��63   $
��Left=�6F   $��23��6a   $��
23,341,0,0q�6m   $	��Top=�6�   $��76��6�   $ Sign In With Facebook��6�   ���	#FF4267B2
����������	#FF4267B2$��1��6-   5�      ��%�   '��       �� 5�      " ��6   .�5�      ��  � �� �	#FF4267B264   �� 5�       �@��CornerRadius$ 2��65   �� 5�       � ��$ 2q�68   5�      5�      5�      �� 5�   
   -   5        $' ButtonSignInWithTwitter��5�      $��Twitter��62   $
��Left=�6D   $��23��6_   $��136,341,0,0q�6k   $	��Top=�6�   $��76��6�   $ Sign In With Twitter��6�   ���#54C1DE
�������$��1��6  $��2��6   5�      ��%�   '��       �� 5�      " ��6   .�5�      ��  � �� �#54C1DE64   �� 5�       �@��CornerRadius$ 2��65   �� 5�       � ��$ 2q�68   5�      5�      5�      �� 5�   
   -   5        $' ButtonSignInWithGoogle��5�      $��Google+��61   $��Right=�6C   $��23��6_   $��
0,341,23,0q�6k   $	��Top=�6   $��76��6�   $ Sign In With Google��6�   ���#E55E4C
�������$��1��6  $��3��6  $��1��6.   5�      ��%�   '��       �� 5�      " ��6   .�5�      ��  � �� �#E55E4C64   �� 5�       �@��CornerRadius$ 2��65   �� 5�       � ��$ 2q�68   5�      5�      5�      5�      5�      