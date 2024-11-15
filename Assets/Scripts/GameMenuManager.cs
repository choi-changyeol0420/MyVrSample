using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;

namespace MyVrSample
{
    /// <summary>
    /// 게임중 메뉴 UI 관리하는 클래스
    /// </summary>
    public class GameMenuManager : MonoBehaviour
    {
        #region Variables
        public GameObject gameMenu;
        public InputActionProperty showButton;

        public Transform head;
        [SerializeField] private float distance = 1.5f;

        //Drop UI
        public SnapTurnProvider snapTurn;
        public ContinuousTurnProvider continuousTurn;
        #endregion
        private void Update()
        {
            if(showButton.action.WasPressedThisFrame())
            {
                Toggle();
            }
        }
        void Toggle()
        {
            gameMenu.SetActive(!gameMenu.activeSelf);
            if (gameMenu.activeSelf)
            {
                gameMenu.transform.position = head.position + new Vector3(head.forward.x,1.5f, head.forward.z).normalized * distance;
                gameMenu.transform.LookAt(new Vector3(head.position.x, gameMenu.transform.position.y, head.position.z));
                gameMenu.transform.forward *= -1f;
            }
            
        }
        public void SetTurnTypeFromIndex(int index)
        {
            switch (index)
            {
                case 0:
                    snapTurn.enabled = false;
                    continuousTurn.enabled = true;
                    break;
                case 1:
                    snapTurn.enabled = true;
                    continuousTurn.enabled = false;
                    break;
            }    

        }
        public void Quit()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}