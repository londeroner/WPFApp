   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5   	   5clr-namespace:WPFApp.ViewModelsWPFApp.ViewModels  5   	       WPFApp.Views.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFApp     5   	   .vmclr-namespace:WPFApp.ViewModels     5   	     � Title$  
MainWindow��5	   	   $	��473��6   $	��850��6)    � DataContext 5
      +   %WPFApp.ViewModels.MainWindowViewModel  5   
    � 	Resources 5         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.7* �6   �� 5      .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �  5      �� 5      �� 5      .+�5      �� $��0��6   $��Center=�6)   $��Center=�6F   $��0 3 0 3q�6a   $��30��6r   $��90��6�   $��Add Building��6�   ��6�   �� *AddBuilding+�� 5       $��1��6   $��Center=�6)   $��Center=�6F   $��0 3 0 3q�6a   $��30��6r   $��90��6�   $��
Add Parcel��6�   ��6�   �� *	AddParcel+5!      �� 5#      $
��Auto=�6   .��5$      �� $��5 0 0 0q�6   $	��0.8q�6*   
���   � �� CornerRadius$ 8��6T   ._�5%      �� $	��390��6   $	��390��6.   ��6>   �� *DomainViewModels+ �� SelectedItem 6g   �� *
Selected+��5&      �� 5'       �� 
TargetType" ��6$   .�5(   "   ��  �� Property � ��	 �� Value$	 Stretch=�6O   6a   5)      ��5+      �� 5,      .R�5-   "   �� $	��0.8q�6)   
���   �$ 8��6S   
 �� Padding$
 2 1 5 1q�6d   ._�5.   &   � .+�5/   *   �� $ Vertical=�65   $
��Left=�6L   .+�50   .   �� ��68   �� *
Model.Name+�� 51   .   ��68   �� *
Model.Id+52   +   �� 53   *   $��W��64   
��� ���$��Right=�6Q   y�6m   ��  �� Path$ 	HasErrors� �� 	Converter# [  54   '   55   #   56      58      59      5:      5;      � 5=   
   $��1��6   $��5 0 0 0q�6    � RowDefinitions 5>      �� 5?      �� 5@      $
��0.6* �6    .+�5C      �� $��0��6   ��6*   �� *
Selected+�� 5E      $��1��6   $	��0.8q�6"   
���   �$ 8��6L   $
 2q�6]   $��0 0 5 5q�6i   ._�5F      �� -   5         ��Name$ Errors��5F   %   $��5q�6   $��Stretch=�6w    65   �� *Errors+��6T   �� *
ErrorsList+��5G      �� 5H      .R�5I      � ���	#00000000 J� InputBindings 5J   "   d� 5K   &    d� MouseAction$ LeftDoubleClicke�63    �� Command 5L   /   �� *DataContext.MoveToError+ �� RelativeSource ��  �� AncestorType" � �� CommandParameter 5M   /   ��  �� ElementName$ Errors��$ SelectedItem� 5O   "   �� 5P   &   $
��0.4* �67   �� 5Q   &   $
��0.2* �67   �� 5R   &   $
��0.4* �67   .+�5U   "   �� $��5 0 5 0q�6,   $��0��6=   ��6M   �� *	ModelId+�� 5V   "   $��5 0 5 0q�6,   $��1��6=   ��6M   �� *	FieldName+�� 5W   "   $��5 0 5 0q�6,   $��2��6=   ��6M   �� *	Message+5X      5Y      5[      5\      5]      5^      5_      