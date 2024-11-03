Feature: ValidJourneyPlanning

//  Verify that a valid journey can be planned using the widget
Background:
	Given User navigate to Tfl journey planning widget page
	When User enter a starting point
	And User enter destination point
	And Click the Plan my journey  button

@smoke @Test1
Scenario: Verify that a valid journey can be planned using widget

	Then User should see a valid journey result  displayed
@smoke @Test2
Scenario:Verify that journey route preference can be set
	
	When User click the Edit preferences
	And Select Routes with least walking
	And Click on Update Journey
	Then User should see a route details
	And User can Verify complete access information 
	
	
