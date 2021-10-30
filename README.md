# SplashScreen
Splash Screen to show during installations

This application will display a splash screen with the text located in the “Texts.txt” file on all monitors.

Usage:
The application will look for a file called RunSplashScreen.txt in the same folder as the executable. If this file does not exist,the application will exit.

ALL FILENAMES ARE CASE SENSATIVE

Texts.txt
The Text.txt file contains the texts that should be shown. This file must be located in the same directory as the executable. 
Each line will be displayed in the selected textblock
The application has two text blocks, one in the middle of the screen and one in the lower part of the screen. 
The text block in the middle of the screen is designated 1 and the one in the lower part of the screen is designated 2.

To add text to the text block in the middle of the screen start the line with 1: (no spaces) and then add the text you want to show the user:
Ex.
1:This is an example text

To add text to the lower text block start the line with 2: (no spaces) and then add the text you want to show the user:
Ex.
2:This is an example text

 
The texts will be displayed in the same order as in the Texts.txt-file. However, you do not need to organize the texts base on lower or middle text blocks.
This will work just as well:
1:This is an example text 
1:This is an example text
2:This is an example text
1:This is an example text

The text will loop once they are all displayed.

A text that does not start with a 1: or a 2: will not be displayed.

To exit the application, dubble click in the top left corner or press Alt+Q.
