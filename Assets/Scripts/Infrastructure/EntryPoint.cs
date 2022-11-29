using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            ConfigureServices();
            SceneManager.LoadSceneAsync(Globals.GameScene, LoadSceneMode.Single)
                .completed += OnSceneLoaded;
        }

        private void ConfigureServices() { }

        private void OnSceneLoaded(AsyncOperation obj)
        {
        }
    }
}