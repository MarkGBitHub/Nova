# Nova
**Nova Todo List**

How long did you spend on your solution? 
> Around 6 hours total.

How do you build and run your solution?
> Nova API (uses .Net 6)
1. Clone code
2. open powershell
3. cd to nova.api 
4. dotnet run (a console window will launch with the details of the running app. please take note of the port, you need this to update the config file in react)

Nova-ui (React)
1. Clone code
2. cd to nova-ui
3. find config.ts 
4. update the baseApi to the specified Nova API uri 
example: port 3400
    baseApi: 'https://localhost:3400/api/Todo'
5. npm i
6. npm start

What technical and functional assumptions did you make when implementing your solution?
- Using EF InMemory, as such data is lost after restart.
- There's no paging or sorting so UI experience is limited to small sample data.
- React application can benefit from caching, retry mechamism and for bigger app shared state management. 

Briefly explain your technical design and why do you think is the best approach to this problem.
- Backend API - main consideration is the separation of concern. Uses Repository pattern to access data
- Use Record to map Entity to Dto for a simple mapping operation, ideally would be using AutoMapper to handle more complex types
- React Frontend - Aim for reusability and separation of concern by using container/presentation components

