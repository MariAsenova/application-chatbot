# application-chatbot

The purpose of the prototype is to build a chatbot model utilizing a NLP/NLU framework, Dialogflow. A C# ASP.NET Core Web Application will serve as a webhook that will be a HttpPost endpoint that receives a request from the Dialog api, parses it and prepares response for it according to the needs of Bewhaos A/S. The Web API will be hanlding the business logic, while the UI and language processing will be handled by DialogFlow.


The idea behind the project is to build a chatbot model using Dialogflow, utilizing natural language understanding 
that will make it easier to handle various inputs from the user, and match those into a general intent. To understand the user's intent when they are communicating with the model, an agent with an intent was created using the Dialogfow console.

Creatting an intent for screwdriver reposnse

![image](https://user-images.githubusercontent.com/64922954/221755105-e54594f0-0bb7-48a6-acfb-2cd258e8265a.png)

To create communication between the Web API and Dialogflow, the Web API will be published to a cloud provider, Google Cloud. To get Cloud Run and Cloud Build to work, a Dockerfile and a cloudbuild.yaml fire are created. The buuild will be triggered on pull requests.


######## the communication between the Web API and Dialog flow is not established due to unsolved build errors 
