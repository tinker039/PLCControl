   M S B A M L   `   `   `  ����E  APLCControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:PLCControl.Helper.ConverterPLCControl.Helper.Converter  5      ;"clr-namespace:PLCControl.ViewModelPLCControl.ViewModel  5      (    "PLCControl.View.ConnectionTestView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      >d2http://schemas.microsoft.com/expression/blend/2008    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      7h)clr-namespace:PLCControl.Helper.Converter     5      1dc"clr-namespace:PLCControl.ViewModel     5        N� Title$  ConnectionTestView��5
       � 	Resources 5      0  *PLCControl.Helper.Converter.ColorConverter   cc 
 nameDT  	addressDT  changeAddressDT �� UpdateSourceTrigger  statusDT �� Opacity �� Color �� Path �� 	Converter  istestDT d� 	IsChecked��%P  &	        &	      &	 W     &	 �     &	     7   &	 �      5   
   6   �� 5   
   .R�5      �� ��6   �� *Name+60   5      �� 5   
   .R�5      �� ��6   �� *	Address+63   5      �� 5   
   .R�5      �� -   5        $��50��5   L   ��6   �� *	Address+$ Explicit=�6|   5      �� 5   
   .R�5      A� $��15��6   $��15��6!   ��5      �� 5      $	 0.6Q�6c    6&   �� $ Status�8   6s   5      5      �� 5   
   .R�5      ��  6   �� *IsTest+$ PropertyChanged=�5       5!      5"       � DataContext 5#      2  ,PLCControl.ViewModel.ConnectionTestViewModel  5$   
   6'   .��5&      � .+�5'   
   �� .+�5(      �� ��6   �� *	FIOPoints+	 �� View	 5)      �� 5*      .P�5+      �� $��名称��6)   
 �� CellTemplate#
 [ 65   6^   �� 5,      $��地址��6)   #
 [ 65   6a   �� 5-      $��状态��6)   #
 [ 65   6`   �� 5.      $��修改地址��6)   #
 [ 67   6i   �� 5/      $��开启测试��6)   #
 [ 67   6b   50      52      54      55      57      