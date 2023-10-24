using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sunbase.Controllers;

namespace Sunbase.Class
{
    public class SunbaseViewClass : MonoBehaviour
    {
        [Header("Class variables")]
        public int id;
        public string label;
        public bool isManager;
        public string address;
        public string name;
        public int points;
        [Header("Display Variables")]
        public TextMeshProUGUI displayID;
        public TextMeshProUGUI displayLabel;
        public TextMeshProUGUI displayPoints;
        public PopUpController popUpController;
        [Header("DoTween Variables")]
        public bool isFading = false;

        private void OnEnable()
        {
            displayID.text = id.ToString();
            displayLabel.text = label;
            displayPoints.text = points.ToString();
        }

        public void ShowDataInPopUp()
        {
            popUpController.ActivatePopUp(name, address, points.ToString());
        }

        private void Start()
        {
            popUpController = GameObject.Find("PopUpController").GetComponent<PopUpController>();
        }
    }
}