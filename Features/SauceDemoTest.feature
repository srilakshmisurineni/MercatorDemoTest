Feature: SauceDemoTest
  As a sauce demo shopper
  I want to select a product and add it to basket

Background:
    Given I am logged in as a standard user

@regression @smoke
Scenario: Add an item with max price to the basket
    Given I am on home page
    And I select an item with max price on the page
    When I click Add to cart 
    Then I see the selected product in basket

    #Still working on comments in script
    #Reporting*
    #GitIgnore file