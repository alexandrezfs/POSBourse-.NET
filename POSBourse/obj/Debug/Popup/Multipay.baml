   M S B A M L   `   `   `  ����D  @POSBourse, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:POSBourse.PopupPOSBourse.Popup  5   	       POSBourse.Popup.Multipay   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:POSBourse.Popup     5   	     � Title$  Paiement multiple��5   	   $	��150��6#   $	��500��60   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��124* �6   �� 5      $
��371* �6   .+�5   
   �� -   5         ��Name$ MultipayESP��5      $
��Left=�6'   $��23��6B   $��	43,59,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $��80��6�   6�   �� 5   
   -   5        $ 
MultipayCB��5      $
��Left=�6&   $��23��6A   $��79.853,59,0,0q�6M   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $��80��6�   $��1��6�   6�   �� 5   
   -   5        $ MultipayCHEQUE��5      $
��Left=�6*   $��23��6E   $��233.853,59,0,0q�6Q   $
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $��80��6�   $��1��6�   6�   �� 5   
   -   5         ��Name$ MultipayValider��5      $��Valider��6*   $��1��6<   $
��Left=�6L   $��80.853,91,0,0q�6g   $	��Top=�6~   $��80��6�   {�.  6�   �� 5   
   -   5         ��Name$ label��5      $	��ESP��6   $
��Left=�6-   $��	43,33,0,0q�6H   $	��Top=�6[   �� 5   
   -   5        $ 
label_Copy��5      $��CB��6$   $
��Left=�61   $��81.853,33,0,0q�6L   $	��Top=�6c   $��1��6{    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5       �� AngleY$ -1.487Q�6$   �� 5      T� 5       T� Y$ -0.378Q�6)   5      5      �� 5   
   -   5        $ label_Copy1��5      $��CHEQUE��6%   $
��Left=�66   $��233.853,33,0,0q�6Q   $	��Top=�6i   $��1��6�   �� 5   
   -   5        	 ��Name$	 ValeurAAtteindre��5      $
��Left=�6.   $��	43,10,0,0q�6I   $
��Wrap=�6\   $��ValeurAAtteindre��6p   $	��Top=�6�   $��2��6�   $	��395��6�   $
��Bold"�6�   5       5!      