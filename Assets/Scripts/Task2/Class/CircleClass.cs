using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sunbase.Task2.Class
{
    public class CircleClass : MonoBehaviour
    {
        public bool shouldDestroy = false;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag.Equals("Line")) shouldDestroy = true;
        }
    }
}
