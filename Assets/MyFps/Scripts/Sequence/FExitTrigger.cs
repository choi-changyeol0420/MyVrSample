using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    public class FExitTrigger : MonoBehaviour
    {
        public SceneFader fader;
        private string loadtoscene = "MainMenu";
        
        private void OnTriggerEnter(Collider other)
        {
            AudioManager.Instance.StopBgm();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fader.FadeTo(loadtoscene);
            PlayerState.Instance.SceneNumber = 1;
            SaveLoad.SaveData();
        }
    }
}