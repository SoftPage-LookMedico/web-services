Feature: SupplierServiceTests
As a Developer
I want to add a new Supplier through API
In order to make it available for applications.
	
    Background: 
        Given the Endpoint https://localhost:7070/api/v1/suppliers is available
		
    @supplier-adding
    Scenario: Add Supplier with unique Username
        When a Post Request is sent
          | UserName      | FirstName | LastName | Email                    | Phone     | Address             |
          | angrytiger705 | Claudia   | Costa    | claudiacosta@example.com | 932946322 | Av. Las Perlas 7760 |
        Then A Response is received with Status 200
        And a Supplier Resource is included in Response Body
          | UserName      | FirstName | LastName | Email                    | Phone     | Address             |
          | angrytiger705 | Claudia   | Costa    | claudiacosta@example.com | 932946322 | Av. Las Perlas 7760 |

    @supplier-adding
    Scenario: Add Supplier with existing Username
        Given A Supplier is already stored
          | UserName      | FirstName | LastName | Email                    | Phone     | Address             |
          | angrytiger705 | Claudia   | Costa    | claudiacosta@example.com | 932946322 | Av. Las Perlas 7760 |
        When a Post Request is sent
          | UserName      | FirstName | LastName | Email                    | Phone     | Address             |
          | angrytiger705 | Claudia   | Costa    | claudiacosta@example.com | 932946322 | Av. Las Perlas 7760 |
        Then A Response is received with Status 400
        And An Error Message is returned with value "Username already exists."
