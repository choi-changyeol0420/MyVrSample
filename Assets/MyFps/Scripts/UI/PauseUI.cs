using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    public class PauseUI : MonoBehaviour
    {
        private GameObject theplayer;
        public GameObject pauseUI;
        public SceneFader fader;
        [SerializeField] private string lodetoname = "MainMenu";
        public GameObject Sounds;
        private void Start()
        {
            theplayer = GameObject.Find("Player");
        }
        private void Update()
        {
            /*if(Input.GetKeyDown(KeyCode.Escape))
            {
                Continue();
            }
            else if(Input.GetKeyDown(KeyCode.Return))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }*/
        }
        public void Continue()
        {
            pauseUI.SetActive(!pauseUI.activeSelf);

            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                theplayer.GetComponent<FirstPersonController>().MoveSpeed = 0f;
                theplayer.GetComponent<FirstPersonController>().RotationSpeed = 0f;
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                theplayer.GetComponent<FirstPersonController>().MoveSpeed = 4f;
                theplayer.GetComponent<FirstPersonController>().RotationSpeed = 1f;
            }
        }
        public void MainMenu()
        {
            Time.timeScale = 1f;
            //씬 종료 처리
            if(AudioManager.Instance != null)
            {
                AudioManager.Instance.StopBgm();
            }
            else
            {
                Sounds.SetActive(false);
            }
            fader.FadeTo(lodetoname);
        }
    }
}