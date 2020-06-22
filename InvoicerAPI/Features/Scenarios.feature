Feature: Scenarios for Invoicer API enhancements

@basic
@regression
Scenario Outline: Search Invoice by Invoice Id HTTP 200
	When I call the endpoint for <invoiceid>
	Then all the invoices should be retrieved with <invoiceid>
Examples: 
| invoiceid |
|   93823   |

@basic
@regression
Scenario Outline: Generate access token
    Given I have the invoices URL
    And I call then endpoint for token generation
    When I call the post method for <clientid>, <clientsecret> and <granttype>
    Then I am able to generate the access token <clientid>, <clientsecret> and <granttype>
Examples:
| clientid                             | clientsecret                         | granttype          |
| 0BB95804-D6EC-4A37-A4F3-C5258015A798 | EA179667-9604-4C6C-A452-A3118C6454C5 | client_credentials |

@exception
@regression
Scenario Outline: Search Invoice by Invoice Id HTTP 404
	Given I have the invoices URL
	When I call the incorrect endpoint with <invoiceid>
	Then all the appropriate error for <invoiceid>
Examples: 
| invoiceid |
|   93823   |