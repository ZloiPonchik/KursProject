   M S B A M L   `   `   `  ����W  SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   BaseFontButtonStyle �� BasedOn �� Property  BackgroundSecondaryBrush �� Value  
MediumSize  ForegroundMainBrush �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels �� Triggers	 P� Property
 P� Value �� 
TargetName ! BackgroundSecondaryLightBrush  BackgroundThirdLightBrush  MenuButtonUsersStyle �� ImageSource j� Stretch J� Effect3    -System.Windows.Media.Effects.DropShadowEffect �� Triggers  BorderButtonMenuBrush  MenuButtonPalletsStyle 	 MenuButtonMoveProductStyle 
 MenuButtonBoxesStyle  ToolBarButtonWrap �� Binding �� ElementName �� Value  ToolBarButtonClose  ToolBarButtonFullScreen  ButtonDeleteDataTable  ButtonEditDataTable�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�  '��       7   7  7  7  7  7  &	 ;    7  &	 �    7  &		 �    7  &	
 D
    7  &	 �    &	 �    &	 �    &	 �    &	     �� 5      "  ��6   8   .�5   
   ��  � ��8  6'   �� 5   
    � ��8  6%   �� 5   
    � ��$ Center=�67   �� 5   
    � ��$ 2q�6,   �� 5	   
    � ��8  6'   �� 5
   
    � �� 5      �� 5      " ��6"   .R�5      �� $ border��5      $ 5��5      #��z��5      #��z��5      #��z��5      $
 True��5      ._�5      �� #��z��5      $|�False��5      #��z��5      #��z��5      #��z��5      # z 5      #��z��5      5       5      P� 5      	 �@J�IsMouseOver$

 True��69   . �5      ��  �@�Cursor$
 Hand��67   �� 5       $ border��6;   8   � ��6O   5!      P� 5"      	 � {�$
 False��67   . �5#      �� $ border��6;   8   � ��6O   5$      5&      5(      5)      �� 5+      "  ��6   .�5,   
   ��  � �� 5-      �� 5.      " ��6"   .R�5/      �� $ Border��53      $��2q�50      $ 0��51      #��z��52      ��54      �� 55      $! \Images\Backgound\users.png��6)   $ Uniform=�6V    57         58      ��5:      �� 5;      "  ��6$    5<   "   P� 5=   &   	 �@J�IsMouseOver$

 True��6E   . �5>   *   ��  � ��8   6H   5?   '   5A      5C       5D      P� 5E      	 � ��$

 true��67   . �5F      �� $ Border��6%    6R   Z�  �@J�Effect5G      5I      5K      5L      �� 5N      "  ��6   .�5O   
   ��  � �� 5P      �� 5Q      " ��6"   .R�5R      �� $ Border��5V      $��2q�5S      $ 0��5T      #��z��5U      ��5W      �� 5X      $# \Images\Backgound\pallets.png��6)   $ Uniform=�6X    5Z         5[      ��5]      �� 5^      "  ��6$    5_   "   P� 5`   &   	 �@J�IsMouseOver$

 True��6E   . �5a   *   ��  � ��8   6H   5b   '   5d      5f       5g      P� 5h      	 � ��$

 true��67   . �5i      �� $ Border��6%    6R   Z�  �@J�Effect5j      5l      5n      5o      �� 5q      "  ��6   .�5r   
   ��  � �� 5s      �� 5t      " ��6"   .R�5u      �� $ Border��5y      $��2q�5v      $ 0��5w      #��z��5x      ��5z      �� 5{      $  \Images\Backgound\move.png��6)   $ Uniform=�6U    5}         5~      ��5�      �� 5�      "  ��6$    5�   "   P� 5�   &   	 �@J�IsMouseOver$

 True��6E   . �5�   *   ��  � ��8   6H   5�   '   5�      5�       5�      P� 5�      	 � ��$

 true��67   . �5�      �� $ Border��6%    6R   Z�  �@J�Effect5�      5�      5�      5�      �� 5�      "  ��6   .�5�   
   ��  � �� 5�      �� 5�      " ��6"   .R�5�      �� $ Border��5�      $��2q�5�      $ 0��5�      #��z��5�      ��5�      �� 5�      $! \Images\Backgound\boxes.png��6)   $ Uniform=�6V    5�         5�      ��5�      �� 5�      "  ��6$    5�   "   P� 5�   &   	 �@J�IsMouseOver$

 True��6E   . �5�   *   ��  � ��8   6H   5�   '   5�      5�       5�      P� 5�      	 � ��$

 true��67   . �5�      �� $ Border��6%    6R   Z�  �@J�Effect5�      5�      5�      5�      �� 5�      "  ��6   .�5�   
   ��  � ��$' !/Images/ToolBar/OffWrapScreen.png��6#    5�   
   �� 5�       5�      �� *IsMouseOver+$ WrapScreenButton�� True5�      .a�5�      ��  � ��$&  /Images/ToolBar/OnWrapScreen.png��6+   5�      5�      �� 5�      "  ��6   .�5�   
   ��  � ��$( "/Images/ToolBar/OffCloseWindow.png��6#    5�   
   �� 5�       5�      �� *IsMouseOver+$ CloseWindowButton�� True5�      .a�5�      ��  � ��$' !/Images/ToolBar/OnCloseWindow.png��6+   5�      5�      �� 5�      "  ��6   .�5�   
   ��  � ��$' !/Images/ToolBar/OffFullScreen.png��6#    5�   
   �� 5�       5�      �� *IsMouseOver+$ FullScreenButton�� True5�      .a�5�      ��  � ��$&  /Images/ToolBar/OnFullScreen.png��6+   5�      5�      �� 5�      "  ��6   .�5�   
   ��  � ��$. (\Images\TableButton\BtnDeletePassive.png��6#    5�   
   �� 5�       5�      �� *IsMouseOver+$ TableDeleteButton�� True5�      .a�5�      ��  � ��$- '\Images\TableButton\BtnDeleteActive.png��6+   5�      5�      �� 5�      "  ��6   .�5�   
   ��  � ��$, &\Images\TableButton\BtnEditPassive.png��6#    5�   
   �� 5�       5�      �� *IsMouseOver+$ TableEditButton�� True5�      .a�5�      ��  � ��$+ %\Images\TableButton\BtnEditActive.png��6+   5�      5�      5�      