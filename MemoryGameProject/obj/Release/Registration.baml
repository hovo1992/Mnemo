   M S B A M L   `   `   `  ���� L  HMemoryGameProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MemoryGameProjectMemoryGameProject  $    MemoryGameProject.Registration   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:MemoryGameProject       � WindowStartupLocation$  CenterScreen=� � Icon$ Images/registration.ico�� � Title$ Registration��$��386.611��$��543.515�� � 	Resources    NoChromeButton �� 
TargetType �� Property �� Value �� 
TargetType �Name	 J� SnapsToDevicePixels
 �� Triggers P� Property P� Value �� 
TargetName��%m  &	        �� " ��.���  � ��
 ���� ��  � ��$ 1q���  � ��# � ����  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R�� $ Chrome��#��z��	 . .+��� #��z��#��z����. #	 z	 #��z��
 P�  � {� .  . ���  � �� �#ADADAD�� $ Chrome�� �@J�Opacity$	 0.5Q�.��� $	��350��$	��525�����	#FFEAE1D7.+��� -   $��textBlockHeading��$��23��$
��Left=�$��10,5,0,0q�$��Registration:��$	��Top=�$	��110��$��17(�$��ExtraCondensed&� � ToolTip$ Registration���� -   $��451,5,12,322q�$��Log In�� � Cursor$
 Hand��$ Log In������ " ��.R��� $��	Underline{��� ���� " ��.���  � ��
 ��  � �� Triggers P�  �@J�IsMouseOver . . ���  � ��
 � � �� $��
30,0,30,24q�
�������$	��297��$��Bottom=� � RowDefinitions �� $
��252* �.+��� -    ��Name$ ErrorMsg��$��20��$
��Left=�$��45,4,0,0q�$	��Top=�$	��247�� J� OpacityMask
 �<�����	#FFE5572C�� -   $��TextBlockFirstname��$��23��$
��Left=�$��	67,31,0,0q�$��First Name :��$	��Top=�$	��110��$ 	FirstName���� -   $��TextBlockLastName��$��23��$
��Left=�$��	67,59,0,0q�$��Last Name :��$	��Top=�$	��110��$ LastName���� -   $��TextBlockEmailId��$��23��$
��Left=�$��	67,88,0,0q�$��Email :��$	��Top=�$	��110��$ Email���� -   $��TextBlockPassword��$��23��$
��Left=�$��
67,114,0,0q�$��
Password :��$	��Top=�$	��110��$ Password���� -   $��TextBlockConfirmPwd��$��23��$
��Left=�$��
67,141,0,0q�$��ConfirmPassword :��$	��Top=�$	��110��$ ConfirmPassword���� -	   $��TextBoxFirstName��$��23��$
��Left=�$��
183,29,0,0q�$	��Top=�$	��222��$ 	FirstName���� -
   $��TextBoxLastName��$��23��$
��Left=�$��
183,56,0,0q�$	��Top=�$	��222��$ LastName���� -   $��TextBoxEmail��$��23��$
��Left=�$��
183,84,0,0q�$	��Top=�$	��222��$ Email��G� -   $��PasswordBox��$��23��$
��Left=�$��183,112,0,0q�$	��Top=�$	��222��$ Password��G� -   $��PasswordBoxConfirm��$��23��$
��Left=�$��183,139,0,0q�$	��Top=�$	��222��$ ConfirmPassword���� -    ��Name$ Image��$
��Left=�$��45��$��185,171,0,0q�$	��Top=�$	��220���� -    ��Name$ TextBoxCaptcha��$
��Left=�$��37��$��222,221,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��148���� -   $��SubmitButton��$��Submit��$��23��$
��Left=�$��188,265,0,0q�$	��Top=�$��70��$ Submit���� -   $��ResetButton��$��Reset��$��23��$
��Left=�$��334,265,0,0q�$	��Top=�$��70��$ Reset���� -    ��Name$ ButtonSpeech��#���   $��410,171,37,105q�$ Spell��.���� $��Images/iconSpeech.jpg��$��UniformToFill=�$��17��$��17���� -   $ ButtonAgain��#���   $��410,192,37,81q�$ Change image��.���� $��Images/aroundArrow.jpg��$��UniformToFill=�$��17��$��17��