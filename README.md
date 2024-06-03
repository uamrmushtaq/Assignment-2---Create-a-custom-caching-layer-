Scenario: 
You have a clustered (Load balanced) system, your system is doing complex operations of the kind you 
only see on University Calculus exams, alongside process heavy data querying. 
A dear System Architect friend of yours suggested that you implement centralized caching on requests, 
where you would cache responses on requests to serve them from the centralized cache. 
Task: - - - - - 
Create a custom caching layer for a Web API (.Net Framework or .Net Core). 
Use MSSQL for storing the responses. 
Keep in mind that request parameters do play a role what are the responses, and cached items 
are considered not fresh after 2 hours of their creation and need to be deleted from the 
Database. 
Consider the API system is stateless and only request parameters are to be checked against. 
Do not waste your time on non-important sections of the system, we will only evaluate the 
caching laye
