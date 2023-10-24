using UnityEngine;
using Sunbase.Class;
using System.Collections.Generic;
using TMPro;

namespace Sunbase.Controllers
{
    public class DisplayController : MonoBehaviour
    {
        [Header("Data Panel")]
        public GameObject dataPrefab;
        public Transform content;
        public List<GameObject> generatedUI = new List<GameObject>();
        public Transform errorPopup;

        public void ShowData(SunbaseClass tempData)
        {
            foreach (Client client in tempData.clients)
            {
                GameObject newDataObject = Instantiate(dataPrefab, content);
                SunbaseViewClass viewObject = newDataObject.GetComponent<SunbaseViewClass>();
                viewObject.id = client.id;
                viewObject.label = client.label;
                viewObject.isManager = client.isManager;
                if (tempData.data.ContainsKey(client.id.ToString()))
                {
                    Data cData = tempData.data[client.id.ToString()];
                    viewObject.name = cData.name;
                    viewObject.address = cData.address;
                    viewObject.points = cData.points;
                }
                else
                {
                    viewObject.name = "--No Data--";
                    viewObject.address = "--No Data--";
                    viewObject.points = 0;
                }
                // newDataObject.SetActive(true);
                generatedUI.Add(newDataObject);
            }

            foreach (var obj in generatedUI) obj.SetActive(true);
        }

        public void ErrorData(string message)
        {
            TextMeshProUGUI textInPopup = errorPopup.GetComponentInChildren<TextMeshProUGUI>();
            textInPopup.text = message;
            errorPopup.gameObject.SetActive(true);
        }
    }
}

