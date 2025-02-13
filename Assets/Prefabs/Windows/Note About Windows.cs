//NOTE ABOUT WINDOWS AND SCALING
//
//These will probably be reworked at a later date
//
//Windows have a base x scale of 6. If they are stretched, move the content out of the window and resize.
//Text and Buttons should have their x scale multiplied by the current x scale then divided by the new x scale of the window.
//Move them to where they look ok, their actual position doesn't matter too much. The buttons should be close enough together to look the same as the other windows.
//
//For y scale, stretch the background and shadow to fit. Take the background, copy it into content, and multiply the x by .97 and the y by .95
//
//I recommend keeping the x scale to be anywhere from 2-10, only whole numbers.