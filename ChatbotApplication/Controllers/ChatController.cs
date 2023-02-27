using Microsoft.AspNetCore.Mvc;
using Google.Protobuf;
using Google.Cloud.Dialogflow.V2;

namespace ChatbotApplication.Controllers;

/* 
Create a webhook that will be a HttpPost endpoint that receives a request from the Dialogflow api,
parse that request and prepare a response for it.
Chat API Controller for Bewhaos A/S.
*/


[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private readonly ILogger<ChatController> _logger;
    private static readonly JsonParser jsonParser =
    new JsonParser(JsonParser.Settings.Default.WithIgnoreUnknownFields(true));

    public ChatController(ILogger<ChatController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ContentResult DialogAction()
    {
        WebhookRequest request;
        using (var reader = new StreamReader(Request.Body))
        {
            request = jsonParser.Parse<WebhookRequest>(reader);
        }

        string parameter = "";

        if (request.QueryResult.Action == "screwdriver")
        {
            //Parse intent params from Dialogflow set as actions
            var requestParameters = request.QueryResult.Parameters;
            parameter = requestParameters.Fields["notAvailable"].StringValue;
        }
        // Populate the response
        WebhookResponse response = new WebhookResponse
        {
            FulfillmentText = "Thank you for choosing to shop with us! We look forward to welcome you back"
        };

        string responseJson = response.ToString();
        return Content(responseJson, "application/json");
    }
}
