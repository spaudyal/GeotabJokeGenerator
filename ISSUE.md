# JokeGenerator Application

This document lists the observed issues, and my applied improvements  
https://github.com/CodeWithSubash/JokeGenerator/blob/master/ISSUE.md

## Stories

When running app for first time, I came across following issues:

SN | Description | Issue | Status
---| ----------- | ------| ------
1  | The multiple jokes are not shown when the user provides the count (No use of the number of times "n" variables) | BUG | TODO
2  | The user should be able to provide the joke count between 1-9 (No check for any invalid and out of range inputs) | BUG | DONE
3  | From main menu, when user provides invalid input, "Invalid Input" message should be shown, and return to main menu | ISSUE | DONE
4  | On random jokes option, when user chooses not to use random name, the category input is not taken | BUG | DONE
5  | When asked for a category, the input should be taken, before asking the count for number of jokes | ISSUE | DONE
6  | No dev logging is available for correct app debugging | IMPROVE | DONE 
7  | There is a in-consistency in the way user inputs are asked (sometime you need to press return sometimes not) | ISSUE | DONE
8  | The categories result can possibly cached instead of requesting the API each time | IMPROVE | TODO
9  | Show the on-progress message to user during the API call  | IMPROVE | TODO
10 | Add instruction to terminate the application (Provide new option 'x' to exit in main menu) | IMPROVE | DONE
11 | Refactoring of the code (Currently, everything is defined within the driver class ) | ISSUE | WIP
12 | If a user provides invalid input, they should be prompted to correct their input. Or, use default value | BUG | DONE
13 | When user provide the invalid category, no proper message is displayed and program terminates illegally | BUG | TODO
14 | Handle the http response codes, and log the errors (500, 404) properly | BUG | TODO
15 | Fix the use of dynamic with the proper domain objects | IMPROVE | DONE

## Design Improvements

The improvements made, with my considerations
- Using a Log4net, one of the top logging frameworks
- Use a static logger wrapper, so we don't need to construct the Logger from each project. Also, easily extendible if want to replace by other framework in future
- Reformat the code to various classes/files giving single responsibility
-- Console Reader (responsible for reading inputs)
-- Console Writer (Responsible for writign outputs)
-- DisplayControl (Responsible for all display messages)
-- Application (Main Application logic resides here)
-- Program/Main (Application Driver method only)

- Reformat the code into different libraries
-- Service Layer (will handle all the API functionality)
-- Core Layer (all global level functionality resides in Core project)
-- Model Layer (all the DTO and types for the solution resides)

