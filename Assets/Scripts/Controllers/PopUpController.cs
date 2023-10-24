using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Sunbase.Controllers
{
    public class PopUpController : MonoBehaviour
    {
        public GameObject popUpPanel;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI pointsText;
        public TextMeshProUGUI addressText;

        public void ActivatePopUp(string name, string address, string points)
        {
            nameText.text = "Name: " + name;
            addressText.text = "Address: " + address;
            pointsText.text = "Points: " + points;
            popUpPanel.SetActive(true);
        }

        private void OnDisable()
        {
            nameText.text = "Name: ";
            addressText.text = "Address: ";
            pointsText.text = "Points: ";
        }
    }

}