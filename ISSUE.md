# JokeGenerator Application

This document lists the observed issues, and my applied improvements  
https://github.com/CodeWithSubash/JokeGenerator/blob/master/ISSUE.md

## Stories

When running app for first time, I came across following issues, and my address on the issues:

SN | Description | Issue | Status
---| ----------- | ------| ------
1  | The multiple jokes are not shown when the user provides the count (No use of the number of times "n" variables) | BUG | DONE
2  | The user should be able to provide the joke count between 1-9 (No check for any invalid and out of range inputs) | BUG | DONE
3  | From main menu, when user provides invalid input, "Invalid Input" message should be shown, and return to main menu | ISSUE | DONE
4  | On random jokes option, when user chooses not to use random name, the category input is not taken | BUG | DONE
5  | When asked for a category, the input should be taken, before asking the count for number of jokes | ISSUE | DONE
6  | No dev logging is available for correct app debugging | IMPROVE | DONE 
7  | There is a in-consistency in the way user inputs are asked (sometime you need to press return sometimes not) | ISSUE | DONE
8  | The categories result can possibly cached instead of requesting the API each time | IMPROVE | DONE
10 | Add instruction to terminate the application (Provide new option 'x' to exit in main menu) | IMPROVE | DONE
11 | Refactoring of the code (Currently, everything is defined within the driver class ) | ISSUE | DONE
12 | If a user provides invalid input, they should be prompted to correct their input. Or, use default value | BUG | DONE
13 | When user provide the invalid category, no proper message is displayed and program terminates illegally | BUG | DONE
14 | Handle errors during http request/async calls, and throw them gracefully | BUG | DONE
15 | Fix the use of dynamic with the proper domain objects | IMPROVE | DONE
16 | The category can be pre-fetched and stored, and before making request we can verify validity | IMPROVE | DONE
17 | Refactor the HttpClient class with proper arguments | IMPROVE | DONE
19 | Add the unit tests for the business layer (service, domain) | IMPROVE | DONE
20 | Add the unit tests for the Application layer | IMPROVE | TODO
9  | Show the on-progress message to user during the API call  | IMPROVE | TODO
18 | Show n random names for n various jokes | IMPROVE | TODO 

## Design Improvements

The improvements made, with my considerations
1. Using a Log4net, one of the top logging frameworks
- Use a static logger wrapper, so we don't need to construct the Logger from each project. Also, easily extendible if want to replace by other framework in future

2. Reformat the code to various classes/files giving single responsibility
- Console Reader (responsible for reading inputs)
- Console Writer (Responsible for writing outputs)
- DisplayControl (Responsible for all display messages)
- Application (Main Application logic resides here)
- Program/Main (Application Driver method only)

3. Create various dll libraries based on functionality
- Service Layer (will handle all the API functionality)
- Core Layer (all global level functionality resides in Core project)
- Model Layer (all the DTO and types for the solution resides)
- Application Layer (all user input and driver code resides)

4. Handle the HttpRequest and response correctly
- Create a separate api services for the geotab api v/s nameserver api
- Proper handling of error from the HttpResponse object

5. Using the typed DTO for deserializing
- Remove the dynamic object mapping
- Create proper DTO (domain models) and deserialize the httpresponsemessage properly

6. Add the missing functionality
- Enhance the user input and menu options
- User can request for multiple jokes
- Provide interactive menu for providing re-enter option for invalid user inputs
- Add other missing minor features (as listed in the bugs above)

7. Adding Unit Tests
- Add the unit test for the domain object
- Add the unit tests for the service/api layer
- Add the unit tests for the application code (TODO)

8. Improvements left TODO
- Add the in-progress feature for API request
- For multiple joke request, use multiple random names, if requested (currently app uses single random name in all jokes requested at once)