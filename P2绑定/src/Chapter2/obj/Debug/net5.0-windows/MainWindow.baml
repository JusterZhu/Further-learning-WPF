   M S B A M L   `   `   `  ����C  ?Chapter2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Chapter2Chapter2  5      #clr-namespace:Chapter2Chapter2  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	          Chapter2.MainWindow   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      *convertclr-namespace:Chapter2     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Chapter2     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      9system&clr-namespace:System;assembly=mscorlib     5	        � Title$  
MainWindow��5
      $	��800��5      $	��450��5       � 	Resources 5         Chapter2.TestMultiConvert   TestMultiConverter   Chapter2.Data 	 data1  textBoxInError �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Self	 �� RelativeSource
 �� Path  validationTemplate��%�  &	        &	      &	 &     &	 �       5   
   6#     5   
   6   �� 5   
   " ��6'    5      P� 5       �@=�HasError$
 true��69   . �5      ��  �@�ToolTip 60   �� #	 Z $&
  (Validation.Errors)/ErrorContent�5      5      �� 5   
   .R�5      ]� .+�5      �� $��20(�6   
���  ��!6>   �� 5      5      5      5      .��5      � .+�5    
   �� .+�5!      �� .+�56      �� -   5         ��Name$ ListboxTest��56      ��60   �� *	Employees+ �� SelectedItem 6R   �� *Employees/Name+�� 57      
���  ����6-   ��  �� ElementName$ ListboxTest��$
 SelectedItem��� 58      
���  ����6-   �� *
Employees/+59      5?      5�      5�      