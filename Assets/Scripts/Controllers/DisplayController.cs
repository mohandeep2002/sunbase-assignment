using UnityEngine;
using Sunbase.Class;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

namespace Sunbase.Controllers
{
    public class DisplayController : MonoBehaviour
    {
        [Header("Data Panel Variables")]
        public GameObject dataPrefab;
        public Transform content;
        public List<GameObject> generatedUI = new List<GameObject>();
        public Transform errorPopup;
        [Header("Dropdown Variables")]
        public Transform panelToPopUp;
        public float animationDuration = 0.5f;
        public float fadeDuration = 1f;
        public bool isPanelVisible = false;

        #region Main Data Display
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
        #endregion

        private void Start()
        {
            TogglePopUp();
        }

        #region DropDown Display
        public void TogglePopUp()
        {
            if (isPanelVisible)
            {
                panelToPopUp.DOMoveY(panelToPopUp.position.y - 500f, animationDuration);
            }  
            else
            {
                panelToPopUp.DOMoveY(panelToPopUp.position.y + 500f, animationDuration);
            }
            isPanelVisible = !isPanelVisible;
        }
        #endregion
    }
}

