Feature: NumberFeature
		Begining with something not complex
		Change a simple number to words

@converter
Scenario: Add simple number
	Given I have entered 1 into the converter
	When I press enter
	Then the result should be One  on the screen

Scenario: Add another simple number diferent
	Given  I have entered 9 into the converter
	When I press enter
	Then the result should be Nine  on the screen

Scenario: Add number greather than ten diferent 
	Given  I have entered 26 into the converter
	When I press enter
	Then the result should be Twenty Six  on the screen

Scenario: Add number greather than houndred diferent 
	Given  I have entered 261 into the converter
	When I press enter
	Then the result should be Two Houndred Sixty One  on the screen

Scenario: Throws exception if I entered a not valid number
	Given I have entered ABCD into the number converter
	And I press enter
	Then the exception message should be "ABCD" is not a valid number on the screen

Scenario: Throws exception if I entered number greather than 9999
	Given I have entered 99999 into the number converter
	And I press enter
	Then the exception message should be "99999" is not a valid number on the screen
