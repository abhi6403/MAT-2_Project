using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InfinityJumper.Cloud
{
    public class CloundController : MonoBehaviour
    {
        public BoxCollider2D cloudTrigger;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            cloudTrigger.enabled = false;
        }

    }
}

