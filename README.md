**HOW TO RUN THE APPLICATION**
I created a very simple applicacion just to implement a very basic way to resolve the problem for this code test.
To run the application just follow the next steps:

1. Open the solution in visual studio and .Net 8
2. Run the application in debug mode
3. Swagger will display an interfase showing an endpoint called GetStories
4. The endpoint has just 1 input parameter called "count", type any number and the application will return that number of records.
5. If you want you can debugg and see the code step by step

**ENHANCEMENTS OR CHANGES**
As I mention previously this is just a very simple solution because I do not have much time to create a most robust application.
See below the propousal enhancements:

1. Implement error handling (is not emplemented)
2. Implement audit logs (is not implemented)
3. Separate services in a different project
4. Implement the repository pattern in data layer
5. Adding settings for some parameters like URL values
6. Adding a chache pattern to get a better perfomance (Now The application is doing all the work every time)

