@users
Feature: Users

	@get @listUsers
	Scenario Outline: ListUsers_FindByName_ReturnUser
		Given The list of users is requested
		When The name '<firstName>' '<lastName>' is searched
		Then The user exists

		Examples:
			| firstName | lastName |
			| Janet     | Weaver   |
			| Rachel    | Howell   |

	@get @singleUser
	Scenario: SingleUser_ValidId_StatusOK
		Given A user is requested with id as '2'
		Then The request succeeds

	@get @singleUser
	Scenario: SingleUser_InvalidId_StatusNotFound
		Given A user is requested with id as '23'
		Then The request is not found

	@post @createUser
	Scenario: CreateUser_WithNameAndJob_StatusCreated
		Given A user with name as 'Morpheus' and job as 'Leader' is requested
		Then The request is created
