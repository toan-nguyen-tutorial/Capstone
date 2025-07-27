════════════════════════════════════════════════════════════════════════════════════════════════════
─// [(Panel)] [0] - [Initialize]
main()
{
  
}
────────────────────────────────────────────────────────────────────────────────────────────────────
─// [btnSend] [1] - [Clicked]
main(mapping event)
{
    string Request;
    getValue("txtRequest", "text", Request);

    string displayText;
    string apiKey = "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";

    // Classify questions base on function strpos
    bool isRunningQuestion = false;
    bool isFaultQuestion = false;
    string lowerRequest = strtolower(Request);

    // Use strpos (return int) to define keywords
    if (strpos(lowerRequest, "chạy") != -1 || strpos(lowerRequest, "running") != -1 || strpos(lowerRequest, "hoạt động") != -1)
    {
        isRunningQuestion = true;
    }
    else if (strpos(lowerRequest, "lỗi") != -1 || strpos(lowerRequest, "fault") != -1 || strpos(lowerRequest, "hỏng") != -1)
    {
        isFaultQuestion = true;
    }

    string url;
    if (isRunningQuestion)
    {
        url = "https://localhost:8080/reporting/Dps?System1:MOTOR_1.CMD&System1:MOTOR_2.CMD&System1:MOTOR_3.CMD&System1:MOTOR_4.CMD&System1:MOTOR_5.CMD";
    }
    else if (isFaultQuestion)
    {
        url = "https://localhost:8080/reporting/Dps?System1:MOTOR_1.Fault&System1:MOTOR_2.Fault&System1:MOTOR_3.Fault&System1:MOTOR_4.Fault&System1:MOTOR_5.Fault";
    }
    else
    {
        url = "";
    }

    mapping data;
    data["ignoreSslErrors"] = "";

    string username = "para";
    string password = "Toannguyen123@";
    string authValue = username + ":" + password;
    string encodedAuth = base64Encode(authValue);

    mapping headers;
    headers["Authorization"] = "Basic " + encodedAuth;
    headers["Content-Type"] = "application/json";
    data["headers"] = headers;

    mapping result;
    string rawResponse;
    string jsonValue;

    if (isRunningQuestion || isFaultQuestion)
    {
        // REST API: GET Method <Response> JSON API
        int status = netGet(url, result, data);

        if (status == 0)
        {
            //Handle JSON Data
            rawResponse = result["content"];
            mapping responseData = jsonDecode(rawResponse);
            jsonValue = responseData["dps"];
            DebugN("Response Dps", jsonValue);
        }
        else
        {
            DebugN("Error: NetGet failed with status ", status);
            jsonValue = ""; // The same normal questions
        }
    }
    else
    {
        jsonValue = ""; // The same normal questions
    }

    // Use Deepseek API to response for " motor questions " && " normal questions "
    string userQuestion = Request + (strlen(jsonValue) > 0 ? jsonValue : "");
    string jsonBodyDS = "{"
                      + "\\\"model\\\": \\\"deepseek/deepseek-prover-v2:free\\\","
                      + "\\\"messages\\\": ["
                      + "{\\\"role\\\": \\\"user\\\", \\\"content\\\": \\\"" + userQuestion + "\\\"}"
                      + "]"
                      + "}";

    mapping dataDS;
    dataDS["content"] = jsonBodyDS;
    dataDS["ignoreSslErrors"] = "";

    mapping headersDS;
    headersDS["Authorization"] = "Bearer " + apiKey;
    headersDS["Content-Type"] = "application/json";
    headersDS["HTTP-Referer"] = "<YOUR_SITE_URL>";
    headersDS["X-Title"] = "<YOUR_SITE_NAME>";
    dataDS["headers"] = headersDS;

    mapping resultDS;
    int statusDS = netPost("https://openrouter.ai/api/v1/chat/completions", dataDS, resultDS);
    if (statusDS == 0)
    {
        string responseDataDS = resultDS["content"];
        //RAW DATA;
        //DebugN("RAW DATA: ", responseDataDS);
        mapping jsonPrettier = jsonDecode(responseDataDS);
        dyn_anytype choices = jsonPrettier["choices"];
        mapping choice = choices[1]; // Note : dyn_anytype index = 1 in WINCCOA
        mapping message = choice["message"];
        displayText = message["content"];
        DebugN("DeepSeek response: ", displayText);
    }
    else
    {
        DebugN("netPost failed! Error: ", resultDS["errorString"]);
        DebugN("SSL Errors: ", resultDS["sslErrors"]);
        displayText = "ERROR: " + resultDS["errorString"];
    }

    setValue("txtResponse", "text", displayText);


}
════════════════════════════════════════════════════════════════════════════════════════════════════
─// [PUSH_BUTTON3] [5] - [Clicked]
main(mapping event)
{

      string url = "https://localhost:8080/reporting/Dps?System1:MOTOR_1.RunFeedBack&System1:MOTOR_2.RunFeedBack&System1:MOTOR_3.RunFeedBack&System1:MOTOR_4.RunFeedBack&System1:MOTOR_5.RunFeedBack&System1:MOTOR_1.Fault&System1:MOTOR_2.Fault&System1:MOTOR_3.Fault&System1:MOTOR_4.Fault&System1:MOTOR_5.Fault&System1:MOTOR_1.Speed&System1:MOTOR_2.Speed&System1:MOTOR_3.Speed&System1:MOTOR_4.Speed&System1:MOTOR_5.Speed&System1:MOTOR_1.Runtime&System1:MOTOR_2.Runtime&System1:MOTOR_3.Runtime&System1:MOTOR_4.Runtime&System1:MOTOR_5.Runtime";
      mapping dataURL;
      dataURL["ignoreSslErrors"] = "";
      string username = "para";
      string password = "Toannguyen123@";
      string authValue = username + ":" + password;
      string encodedAuth = base64Encode(authValue);
      mapping headersURL;
      headersURL["Authorization"] = "Basic " + encodedAuth;
      headersURL["Content-Type"] = "application/json";
      dataURL["headers"] = headersURL;

      mapping resultURL;
      string rawResponse;
      string jsonValue;
      int status = netGet(url, resultURL, dataURL);
      if (status == 0)
      {
          rawResponse = resultURL["content"];
          mapping responseData = jsonDecode(rawResponse);
          jsonValue = responseData["dps"];
          DebugN("Response Dps", jsonValue);
       }


    string path = "D:\\05122025\\Gateway-WinCCOA\\WinCCOA-GateWay\\data\\html\\report.html";
    string apiKey = "AIzaSyCcAr2WZ6KrAwvY0B0R6yLOA_NmVAgI8sk";
    string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=" + apiKey;

    string Request;
    getValue("txtRequest", "text", Request);

    string jsonBody = "{\"contents\": [{\"parts\": [{\"text\": \"" + Request + "Chỉ cần tạo ra phần nội dung trong body, dùng thư viện bootstrap và chartjs tôi đã nhúng sẵn rùi trình bày cách đối tượng class,id thì (dùng dấu '' thay vì dấu "" ) không thêm giải thích chỉ có code mà thôi" +"Dựa vào" + jsonValue + "\"}]}]}";
    //string jsonBody = "{\"system_instruction\":{\"parts\":[{\"text\":\"" + jsonValue + "\"}]},\"contents\":[{\"parts\":[{\"text\":\"" + Request + " Chỉ cần tạo ra phần nội dung trong body, dùng thư viện bootstrap và chartjs tôi đã nhúng sẵn rùi trình bày cách đối tượng class,id thì (dùng dấu '' thay vì dấu \"\" ) không thêm giải thích chỉ có code mà thôi\"}]}]}";

    mapping data;
    data["method"] = "POST";
    data["content"] = jsonBody;
    data["ignoreSslErrors"] = true;

    mapping headers;
    headers["Content-Type"] = "application/json";
    data["headers"] = headers;


    mapping result;
    string generatedHtmlContent = "";
    int status = netPost(url, data, result);

    if (status != 0)
    {
        setValue("txtResponse", "text", "Lỗi khi gọi Gemini API: " + result["errorString"]);
        generatedHtmlContent = "<h2>Lỗi kết nối API</h2><p>Không thể kết nối đến Gemini API: " + result["errorString"] + "</p>";
    }
    else
    {
        string responseText = result["content"];
        mapping jsonResp = jsonDecode(responseText);
        dyn_anytype candidates = jsonResp["candidates"];

        if (dynlen(candidates) == 0)
        {
            setValue("txtResponse", "text", "Gemini không trả về câu trả lời.");
            generatedHtmlContent = "<h2>Không có phản hồi</h2><p>Gemini không trả về câu trả lời.</p>";
        }
        else
        {
            mapping candidate = candidates[1];
            mapping content = candidate["content"];
            dyn_anytype parts = content["parts"];
            generatedHtmlContent = (string)parts[1]["text"];
            strreplace(generatedHtmlContent,"```html","");
            strreplace(generatedHtmlContent,"```","");
            strreplace(generatedHtmlContent,"\\\"","\"");

        }
    }
    DebugN("console",generatedHtmlContent);



      dyn_anytype htmlLines;

      htmlLines[1]  = "<!DOCTYPE html>";
      htmlLines[2]  = "<html lang='en'>";
      htmlLines[3]  = "<head>";
      htmlLines[4]  = "  <meta charset='UTF-8'>";
      htmlLines[5]  = "  <meta name='viewport' content='width=device-width, initial-scale=1.0'>";
      htmlLines[6]  = "  <title>Overview</title>";
      htmlLines[7]  = "  <script src='node_modules/chart.js/dist/chart.umd.js'></script>";
      htmlLines[8]  = "  <script src='node_modules/chart.js/dist/chart.js'></script>";
      htmlLines[9]  = "  <script src='node_modules/gaugeJS/dist/gauge.min.js'></script>";
      htmlLines[10] = "  <script src='node_modules/gaugeJS/dist/gauge.js'></script>";
      htmlLines[11] = "  <script src='node_modules/d3/dist/d3.js'></script>";
      htmlLines[12] = "  <script src='node_modules/bootstrap/dist/js/bootstrap.min.js'></script>";
      htmlLines[13] = "  <link rel='stylesheet' href='node_modules/bootstrap/dist/css/bootstrap.min.css'>";
      htmlLines[14] = "</head>";
      htmlLines[15] = "<body class='bg-light'>";
      htmlLines[16] = generatedHtmlContent;
      htmlLines[17] = "  <script src='node_modules/bootstrap/dist/js/bootstrap.bundle.min.js'></script>";
      htmlLines[18] = "</body>";
      htmlLines[19] = "</html>";
    csvFileWrite(path, htmlLines, 1, 0);

    webview.loadSnippet("/data/html/report.html");



}
════════════════════════════════════════════════════════════════════════════════════════════════════
─// [PUSH_BUTTON4] [6] - [Clicked]
main(mapping event)
{
 webview.loadSnippet("/data/html/report.html");
}
════════════════════════════════════════════════════════════════════════════════════════════════════
