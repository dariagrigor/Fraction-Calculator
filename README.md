# Fraction_Calculator
 a GUI app which allows the user to multiply, divide, add and subtract two fractions

Functionalities/Features required by the Application.
Design
Your form must look and feel like normal application. Buttons are meant to be clicked, and Label are not meant to be clicked. Textboxes should take user inputs. Do not make controls appear or disappear. Do not change the color or size of text unless you have a compelling reason to do so.
Naming
1.	All controls accessed in your code must have names with well-known prefixes.
Method
private void DoCalculation() - this method does the actual calculation. The logic in contained in a method so that it can be invoked from different parts of the application.
•	It performs the appropriate computation based on the value of the string variable operation.
•	And assigns the resulting value to the appropriate textboxes.

EventHandlers
1.	To handle the Click event of the button:
This will invoke the DoCalculation() method above.
2.	To handle the KeyPress event for all the textboxes:
This will prevent non-digit entry to the required textboxes. Copy and paste the following statements into the handler.

if (char.IsDigit(e.KeyChar))
    return;
else
    e.Handled = true;          //discard the non-digit entries

This will filter the input to the textboxes so that only digits are accepted.
3.	To handle the CheckChanged event for all the radio buttons:
The text of the radio button is assigned to the string variable operation. To do this, you will use the first argument (sender) and cast to a RadioButton, now you will be able to get the text of the control.
Then invoke the DoCalculation() method above.

Behavior
You must be able to use this application with or without a pointing device. i.e. You must be able to use with keyboard only.
The tab key is used to “jump” from one control to another. The space-bar toggles properties. Such as a Checkbox or a RadioButton. If you don’t want a control get focus via the tab key, then set the TabStop property on the control to false.

Specify the tab order:
Set the TabIndex property for all the interactable components so that the user can use the application without the support of a mouse. The first control to have focus must have its TabIndex property set to 0 and the next o 1 and so on…
