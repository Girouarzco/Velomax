   M S B A M L   `   `   `  ����B  >VeloMax, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:VeloMaxVeloMax  5   	       VeloMax.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:VeloMax     5   	   -   5        $��LoginWindow��5   	     � Title$  Login��5	   	   $	��450��6   $	��800��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��585* �6   �� 5      $	��76* �6   �� 5      $	��30* �6   �� 5      $
��101* �6   ��5   
   �� 5       �� ImageSource$$ pack://siteoforigin:,,,/bg.jpg��6   .+�5   
   �� $��LOGIN��6   $��0,69,8,0q�6    $	��Top=�62   $��24(�6J   $
��Bold"�6X   $��Right=�6k   $	��239��6�   �� 5   
   
���   �$
��Bold"�6#   $��Nom D'Utilisateur��65   $��	0,132,8,0q�6Q   $	��Top=�6d   $��18(�6|    J� RenderTransformOrigin$ 0.342,3.958&�6�   {�.   � Cursor$
 None��6�   $��Right=�6�   $	��239��6�   �� 5   
   -   5         ��Name$ 
tbUserName��5      $��30��6&   $�� ��62   $��
0,171,34,0q�6:    �� TextWrapping$
 Wrap=�6N   $	��Top=�6b   $��18(�6z   $��0,0,0,1q�6�   ���	#FF5C5876$��Right=�6�   $	��420��6�   $��4��6�   �� 5   
   
���   �$
��Bold"�6#   $��Mot de passe��65   $��	0,210,8,0q�6L   $	��Top=�6_   $��18(�6w   $ 0.342,3.958&�6�   {�.  $
 None��6�   $��Right=�6�   $	��239��6�   G� 5   
   -   5        	 G�Name$
	 pass��5      $��30��6$   $��
0,249,34,0q�60   $	��Top=�6D   $��18(�6\   $��0,0,0,1q�6j   ���	#FF5C5876$��Right=�6�   $	��420��6�   $��4��6�   �� 5   
   -   5        
���   �$
��Bold"�5   $   $��S'identifier��66   $��
0,310,34,0q�6M   $	��Top=�6a   $��30��6y   
�������$��18(�6�   $��Right=�6�   $	��420��6�   $��4��6�   ��6�   Z� 6�   5      5      