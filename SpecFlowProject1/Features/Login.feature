Feature: Member addition

   Background: Navigate to application
      Given launch URL
      Then enter name and password

    Scenario: Admin user addition
      Given user is on admin user addition screen
      When access admin user tab
      Then user should be added as admin user

   Scenario: Internal user addition
      Given normal user addition screen
      When navigate to external contact tab
      Then added as external contact