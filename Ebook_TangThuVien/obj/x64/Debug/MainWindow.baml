   M S B A M L   `   `   `  ����L  HEbook_TangThuVien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Ebook_TangThuVienEbook_TangThuVien  5   	   O,clr-namespace:Ebook_TangThuVien.Ebook_ModelsEbook_TangThuVien.Ebook_Models  5   	   "    Ebook_TangThuVien.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Ebook_TangThuVien     5   	   >bding,clr-namespace:Ebook_TangThuVien.Ebook_Models     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � AllowsTransparency . 
������  � WindowStyle$
 None=�5   	    � DataContext 5      /  )Ebook_TangThuVien.Ebook_Models.Loading_LB  5   
   .��5      ��  �� CornerRadius$ 15��6   
�������
�������._�5   
   �  � RowDefinitions 5      �� 5      �� 5      $	��14* �6    .+�5      � -   5        $��0��5      .+�5      �� $ 	15,15,0,0��6   
���/kU�._�5      � .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��RightToLeft=�6>   $��Stretch=�5   %   $��Stretch=�5   %   .+�5      �� -   5        $	��╳��5   %   $��18(�61   $��7,0,0,0q�6?   
������ $��40��6i   
������ 5   >   �� 5       -   5        $	��━��5    %   $��18(�61   $��0q�6?   
������ $��40��5!   %   
������ 5"   >   5$      5%      5&      5'      � 5(      $��1��6    � ColumnDefinitions 5)      �� 5*      $	��65* �6'   �� 5+      $	��35* �6'   .+�5-      � $��0��6   
���OO/�.+�5.      �� 
�������$	��0.5q�65   $ 10��5/      $��4q�6/   ._�51      � .+�52      �� .+�53   "   �� $.��(TANG THU VIEN DOWNLOAD EBOOK (HTWeathrt)��6(   
�������54   (   � 56   "   $��5,10,0,0q�6,   .+�57   &   �� $��Link URL WEB��6,   
�������6D   �� 58   &   -   5         ��Name$ ULR_Web��58   .   
������ $	��400��6X   
�������
�������$��Stretch=�5:   .   $��Stretch=�5;   .   $��Center=�5<   .   $��Center=�5=   .   $@��:https://truyen.tangthuvien.vn/doc-truyen/cuu-vuc-pham-tien��5>   .   5@   #   � 5A   "   $��5,10,0,0q�6,   .+�5B   &   �� $��Download Chappter��6,   
�������6I   �� 5C   &   $�� FROM:��6,   
�������6>   �� 5D   &   -   5        $ ChapterStart��5D   .   
������ $	��100��6]   
�������
�������$��Center=�5E   /   $��Center=�5F   9   $��1��5G   .   �� 5I   &   $
�� TO:��6,   
�������6<   �� 5J   &   -   5        $ 
ChapterEND��5J   .   
������ $	��100��6[   
�������
�������$��Center=�5K   )   $��Center=�5L   )   6K   5M   #   � 5N   "   $��5,10,0,0q�6,   .+�5O   &   �� $�� Type Save File: ��6,   
�������6I   �� 5P   &   -   5        	 ��Name$	 	Save_TYPE��5P   _   $	��120��6/   $��Center=�6;   $��Center=�5Q   /   
 �� SelectedItem
 6Q   ��  �� ElementName$ comboBoxItem�� �� Mode$ OneWay=�.@�5R   *   �� .��67   epub6=   �� 5S   *   -   5         ��Name$ comboBoxItem��5S   7   .��6M   txt6R   5T   '   5U   #   � 5V   "   $��5,10,0,0q�6-   .+�5W   &   �� -	   5        $��
btdownload��5W   s   $��Start Download ��6-   $��5,0,0,0q�6G   $��30��6X   $	��100��6d    � 	Resources 5X   *    �� 
TargetType �� Property �� Value��%^   '��       �� 5Y   .   " ��64   .�5Z   2   ��  �@��CornerRadius$ 5��6Q   5[   /   5\   +   5]   '   �� 5^   &   -
   5        $��btcancel��5^   >   $��Cancel��6-   $��5,0,0,0q�6N   $��30��6_   $��80��6k    5_   *   ��%^   '��       �� 5`   .   " ��64   .�5a   2   ��  �@��CornerRadius$ 5��6Q   5b   /   5c   +   5d   '   5e   #   � 5f   "   $��5,10,0,0q�6-   .+�5g   &   �� -   5        $��Openfilelocation��5g   -   $��5,0,0,0q�6H   $��30��6Y   $	��100��6e    5h   *   ��%^   '��       �� 5i   .   " ��64   .�5j   2   ��  �@��CornerRadius$ 5��6Q   5k   /   5l   +   5m   '   5n   #   5o      5p      5q      5r      � 5s      $��1��6   
���OO/�.+�5t      �� -   5         ��Name$ LOG_CONSOLE��5v      
������ 
�������$��5q�5u      
������� �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�5w   H    5y      ��%^   '��       �� 5z      " ��6$   .�5{   "   ��  �@��CornerRadius$ 9��6A   5|      5}      5~      5      5�      � 5�      -   5        $��ProgressbarShow��5�       $��1��6   $y�	Collapsed=�67   $��Center=�5�      $��Center=�60   $	��300��5�      $	��100��6   .+�5�      �� 
�������$��1q�6,   $ 10��5�      ���#FFDAB9._�5�      � .+�5�      �� .+�5�      � $��25��6*    � Maximum$	 100Q�6O    � Minimum$ 0Q�6]   $��5,20,5,0q�6i    � Value 66   �� *_Value+6i   �� 5�      $��5,5,5,0q�6A   $��Center=�5�   $   $��Center=�5�   $   ��5�   $   �� *
_Content+5�   $   5�      5�      5�      5�      5�      5�      5�      