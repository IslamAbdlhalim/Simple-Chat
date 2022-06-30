using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _hostPort;
        public static int Port;
    
        public void LoadClient()
        {
            SceneManager.LoadScene(2);
        }

        public void LoadHost()
        {
            Port = int.Parse(_hostPort.text);
            Debug.Log(Port);
            SceneManager.LoadScene(1);
        }
    }
}

