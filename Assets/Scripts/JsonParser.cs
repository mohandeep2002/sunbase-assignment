using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

public class JsonParser : MonoBehaviour
{
    public string jsonString; // Assign your JSON string here
    public ClientData cData;

    void Start()
    {
        // Deserialize the JSON data into the ClientData class
        ClientData clientData = JsonConvert.DeserializeObject<ClientData>(jsonString);
        Debug.Log(clientData.data.Count);
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
            cData = clientData;
        }
        else
        {
            Debug.LogError("Failed to deserialize JSON.");
        }
    }
}
