Feature: NumberFeature
		Begining with something not complex
		Change a simple number to words

@converter
Scenario Outline: Convert
	Given I have entered <Input> into the converter
	When I press enter
	Then the result should be <Result> on the screen

	Examples: 
			| Input | Result                                   |
			| 1     | One                                      |
			| 9     | Nine                                     |
			| 15    | Fifteen                                  |
			| 12    | Twelve                                   |
			| 61    | Sixty One                                |
			| 100   | One Houndred                             |
			| 252   | Two Houndred Fifty Two                   |
			| 1520  | One Thousand Five Houndred Twenty        |
			| 9999  | Nine Thousand Nine Houndred Ninety Nine  |

Scenario: Throws exception if I entered a not valid number
	Given I have entered ABCD into the number converter
	And I press enter
	Then the exception message should be "ABCD" is not a valid number on the screen

Scenario: Throws exception if I entered number greather than 9999
	Given I have entered 99999 into the number converter
	And I press enter
	Then the exception message should be "99999" is not a valid number on the screen
