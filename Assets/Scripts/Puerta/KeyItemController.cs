using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool Door = false;
        [SerializeField] private bool key = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorContoller doorObject;

        private void Start()
        {
            if (Door)
            {
                doorObject = GetComponent<KeyDoorContoller>();
            }
        }
         
        public void ObjectInteraction()
        {
            if (Door)
            {
                doorObject.PlayAnimation();
            }
            else if (key)
            {
                _keyInventory.HasKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
