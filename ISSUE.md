# JokeGenerator Application

This document lists the observed issues, and my applied improvements

## Stories

When running app for first time, I came across following issues:

SN | Description | Issue | Status
---| ----------- | ------| ------
1  | The multiple jokes are not shown when the user provides the count (No use of the number of times "n" variables) | BUG | TODO
2  | The user should be able to provide the joke count between 1-9 (No check for any invalid and out of range inputs) | BUG | TODO
3  | If user provides invalid instruction (hit enter), then the category api is called, instead "Invalid Input" message should be given, and return to main menu | ISSUE | TODO
4  | On random jokes option, when user chooses not to use random name, the category input is not taken | BUG | TODO
5  | When asked for a category, the input should be taken, before asking the count for number of jokes | ISSUE | TODO
6  | No dev logging is available for correct app debugging | IMPROVE | TODO 
7  | There is a in-consistency in the way user inputs are asked (sometime you need to press return sometimes not) | ISSUE | TODO
8  | The categories result can possibly cached instead of requesting the API each time | IMPROVE | TODO
9  | We can provide (when we type "c" its a pause due to api call, we can make is responsive by providing some update to user) | IMPROVE | TODO
10 | Add instruction to terminate the application (Provide new option 'x' to exit in main menu) | IMPROVE | TODO

## Design Improvements

The improvements made, with my considerations
- My solution goes here...

