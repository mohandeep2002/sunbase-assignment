using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Sunbase.Task1.Class;

namespace Sunbase.Task1.Controllers
{
    public class APIController : MonoBehaviour
    {
        public DisplayController displayController;
        private string apiURL = "https://qa2.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data";
        private void Start()
        {
            StartCoroutine(GetDataFromAPI());
        }

        IEnumerator GetDataFromAPI()
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(apiURL))
            {
                yield return webRequest.SendWebRequest();
                if (webRequest.isHttpError || webRequest.isNetworkError)
                {
                    Debug.Log(webRequest.error);
                    displayController.ErrorData(webRequest.error);
                }
                else
                {
                    string jsonString = webRequest.downloadHandler.text;
                    // Deserialize the JSON data into the ClientData class
                    SunbaseClass clientData = JsonConvert.DeserializeObject<SunbaseClass>(jsonString);
                    // Debug.Log(clientData.data.Count);
                    // Check if the deserialization was successful
                    if (clientData != null)
                    {
                        Debug.Log("Label: " + clientData.label);

                        foreach (Client client in clientData.clients)
                        {
                            Debug.Log("Client Info:");
                            Debug.Log("ID: " + client.id);
                            Debug.Log("Label: " + client.label);
                            Debug.Log("Is Manager: " + client.isManager);

                            // Check if there's additional data for this client
                            if (clientData.data.ContainsKey(client.id.ToString()))
                            {
                                Data clientDat = clientData.data[client.id.ToString()];
                                Debug.Log("Name: " + clientDat.name);
                                Debug.Log("Address: " + clientDat.address);
                                Debug.Log("Points: " + clientDat.points);
                            }
                        }
                        displayController.ShowData(clientData);
                    }
                    else
                    {
                        Debug.LogError("Failed to deserialize JSON.");
                        displayController.ErrorData("Failed to deserialize JSON.");
                    }
                }
            }
        }
    }
}
