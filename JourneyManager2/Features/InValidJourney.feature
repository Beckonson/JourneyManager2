Feature: InValidJourney

A short summary of the feature

@regression @Test3
Scenario Outline: To Verify Invalid location Journey Planning  with Widget
	Given User is om Tfl journey planning widget page 
	When User Enter "<start>" and "<destination>" and veryfy "<outcome>"
	Examples:
      | starting Point | destinatio | outcome |
      |ert34u         |edgsg       |more than one location matching'ert34u'|
      |                |           |The From field is required.|
	
