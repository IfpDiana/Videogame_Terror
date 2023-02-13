using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KeySystem
{
    public class KeyDoorContoller : MonoBehaviour
    {
        private Animator doorAnim;
        private bool doorOpen = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private bool pauseInteraction = false;

        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
        }
        public void PlayAnimation()
        {
            if (_keyInventory.HasKey)
            {
                if(!doorOpen && !pauseInteraction)
                {
                    SceneManager.LoadScene("Credits");
                }
            }
        }
    }
}