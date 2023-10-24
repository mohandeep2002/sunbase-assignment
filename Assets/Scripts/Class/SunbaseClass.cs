using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sunbase.Class
{
    [System.Serializable]
    public class Client
    {
        public bool isManager;
        public int id;
        public string label;
    }

    [System.Serializable]
    public class Data
    {
        public string address;
        public string name;
        public int points;
    }

    [System.Serializable]
    public class SunbaseClass
    {
        public List<Client> clients;
        public Dictionary<string, Data> data;
        public string label;
    }
}
