   M S B A M L   `   `   `  ����L  HStudentManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:StudentManagement.ViewStudentManagement.View  5      1    +StudentManagement.View.DepartmentDetailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:StudentManagement.View     5      .��5	      � .+�5
   
   � ��5      �� 5        �� ImageSource$/  )/Resources/Backgrounds/MainBackground.png��5      5      5      � 5   
   -   5        $��
Department��5      .+�5      � 
������� � RowDefinitions 5      �� 5      $
��Auto �6$   64   �� 5      $��* �6$   61   .+�5      � $��0��6    � ColumnDefinitions 5      �� 5      $
��1.5* �6+   6:   �� 5      $��* �6+   67   �� 5      $��* �6+   67   �� 5      $��* �6+   67    5       �� 5!      $
��0.5* �6(   68   �� 5"      $��* �6(   65   �� 5#      $��* �6(   65   �� 5$      $��* �6(   65   .+�5'      �� $��1��6    $��1��60   $��Department ID: ��6=   $��15(�6T   $
��Bold"�6b   6v   �� 5(      $��2��6P   $��1��6`   ��6    �� * DepartmentInfo[0].DepartmentID+5)      �� 5+      $��1��6!   $��2��61   $��Department Name: ��6>   $��15(�6W   $
��Bold"�6e   6y   �� 5,      $��2��6!   $��2��61   ��6>   �� *" DepartmentInfo[0].DepartmentName+6s   �� 5.      $��1��6    $��3��60   $��HeadTeacher: ��6=   $��15(�6R   $
��Bold"�6`   6t   �� 5/      $��2��6    $��3��60   ��6=   �� *$"DepartmentInfo[0].DepartmentHeader+6t   50      �� 52      $��30q�6   $��1��6'   ��53      �� 54      $��Detail��6$   $��18(�62   $
��Bold"�6@   6T   .��56      �� $
��Wrap=�6    $��consolas)�64   $��15(�6J   ��6X   �� *DepartmentInfo[0].Detail+6�   57      58      59      5:      5;      