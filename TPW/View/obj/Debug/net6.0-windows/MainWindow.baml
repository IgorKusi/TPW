   M S B A M L   `   `   `  ����D  @ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ViewModel;assembly=ViewModel	ViewModel  5   	   @ <Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null,"clr-namespace:Model;assembly=ModelModel 5   	    View   Etap1.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @	viewModel*clr-namespace:ViewModel;assembly=ViewModel     5   	   4model"clr-namespace:Model;assembly=Model     5   	     � Title$  
MainWindow��5	   	   $	��500��6   $	��800��6)    � 
ResizeMode$ NoResize=�65   .��5
      �  � DataContext 5   
      ViewModel.Controller  5      .+�5   
   �� $
��PLAY��6   $��
685,8,15,0q�6    $	��Top=�64   $��39��6L   ��6X   �� *OnButtonStart+d� 5   
   $��PAUSE��6   $��685,52,15,0q�6'   $	��Top=�6<   $��39��6T   ��6`   �� *OnButtonPauseResume+�� 5   
   $
��STOP��6   $��685,96,15,0q�6    $	��Top=�65   $��40��6M   ��6Y   �� *OnButtonStop+�� 5   
   $��588,288,-82,0q�6   $	��Top=�6(    J� RenderTransformOrigin$ 0.5,0.5&�6@   $��27��6`    � Minimum$ 1Q�6l    � Maximum$ 30Q�6x    �� IsSnapToTickEnabled$
 True��6�    �� AutoToolTipPlacement$ BottomRight=�6�    �� AutoToolTipPrecision$ 0��6�   	 � Value	 6�   �� *	BallNum+z�5      V� 5      .~�5      �� �� 5      �� 5      
 �� Angle$	
 -90Q�6&   T� 5      5      5      �� 5   
   $	��480��6   $��	0,0,120,0q�6$   ��67   �� *	Circles+��5      �� 5      .R�5       �� $��Canvas��6   $	��680��6+   $	��480��67   
�������6b   5!      ��5#      �� 5$       �� 
TargetType" ��6   .�5%      ��  �� Property �@��Left �� Value 64   �� *X+6J   �� 5&       �@��Top 63   �� *Y+6I   5'      ��5)      �� 5*       �� DataType  Model.Circle"  6   .R�5+      A� 
����·�
����  ���6   �� *Radius+��68   �� *Radius+6p   5,      5.      5/      50      