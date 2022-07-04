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
    
        private static void LoadClient()
        {
            SceneManager.LoadScene(2);
        }

        private void LoadHost()
        {
            Port = int.Parse(_hostPort.text);
            SceneManager.LoadScene(1);
        }
    }
}

