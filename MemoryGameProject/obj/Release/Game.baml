   M S B A M L   `   `   `  ���� L  HMemoryGameProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MemoryGameProjectMemoryGameProject      MemoryGameProject.Game   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:MemoryGameProject       � WindowStartupLocation$  CenterScreen=� � Title$
 Game�� � Icon$ Images/icon.ico��$��953.792��$	��740�� � 
ResizeMode$ 	CanResize=� � 	Resources    Hint��%%   &	        �� $��Images\hint.png��.���� $
��Auto=�$
��Auto=�.��� -    �Name$ ContentElement��$��Stretch=�$��Stretch=�$	��400��$	��693��$	��916�� � LayoutTransform ��  �� CenterX$ 0Q� �� CenterY$ 0Q�	 �� ScaleX	 �� 
 �� ElementName$
 uiScaleSlider�� �� Path$ Value� �� ScaleY �� $
 uiScaleSlider��$ Value�.+��� -   
�������
������$��1,60,1,5q�._��� -    ��Name$ 	LabelUser��$��18(�$�� ��$��422,-45,308,637q��� -    ��Name$ ButtonLogOut��$��Log out��$��80��$��40��$��830,10,6,643q� � ToolTip$ Log out���� -   $ LabelBestScore��$��18(�$��629,15,87,635q�� -    �Name$ 	wrapPanel��$��80��$	��Top=�$��10, 0, 0, 0q�.+��� -    ��Name$ TextSize��$��10, 10q� �� 	MaxLength$ 2�� �� TextAlignment$ Center=�$��Center=�$
��Left=�$��41�� �� TextWrapping$
 Wrap=�$	��Top=�$��50�� J� RenderTransformOrigin$ 0.5,0.5&�$
 Size��.��z�V� .~��� �� ��  �� Angle$ 0.497Q�T� .���� -   $ 
ButtonPlay��$��Start��$��10, 10q�$
��Left=�$	��Top=�$��73��$��41�� J� Opacity$	 0.7Q�$ Start������  �� 
TargetType" ��.���  �� Property � �� �� Value
 �������  � �� ��  �� 
TargetType" ��.R��� #��z��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 ����� J� BitmapEffect F�   F� Color$
  Gray��! F� 	Direction$	! 320Q�" F� ShadowDepth$" 10Q�# F� Softness$	# 0.9Q�$ F� Opacity$	$ 0.5Q��� -	   $ 
ButtonHint��$��10, 10q�#��[  $��Center=�$��73��$��41��$	��Top=�{�.  $
 Hint������ " ��.���  � ��
 �������  � �� �� " ��.R��� #��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � ��
 ���� F� $
  Gray��$	! 320Q�$" 10Q�$	# 0.9Q�$	$ 0.5Q��� -
   $ 
LabelScore��$��Score :��$��10, 10q�$��Center=�$��Center=�$��43��$��18(�$	��Top=�$	��126��$ Score���� -   % ��Name$% uiScaleSlider��$��Right=�$��Bottom=�& �� Orientation$& Vertical=�$��0��$��0��' � Value$' 1Q�( � Minimum$	( 0.1Q�) � Maximum$) 4Q�� -   $ MyGrid��$��Stretch=�$��Stretch=�$��10,65,10,36q�