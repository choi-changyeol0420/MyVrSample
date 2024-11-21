using TMPro;
using UnityEngine;

namespace MyFps
{
    public class WorldMenu : MonoBehaviour
    {
        #region Variables
        public GameObject worldMenuUI;
        public TextMeshProUGUI textbox;

        private Transform head;
        private float distance = 1.5f;
        [SerializeField]private float offset = 0f;
        #endregion
        protected virtual void Start()
        {
            head = Camera.main.transform;
        }
        protected virtual void Update()
        {
            distance = PlayerCasting.distanceFromTarget;
        }
        protected void ShowMenuUI(string sequenceText = "")
        {
            worldMenuUI.SetActive(true);

            //Show 설정
            distance = (distance < offset) ? distance - 0.1f : offset;
            worldMenuUI.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * distance;
            worldMenuUI.transform.LookAt(new Vector3(head.position.x, worldMenuUI.transform.position.y, head.position.z));
            worldMenuUI.transform.forward *= -1;
            //text설정
            if (textbox)
            {
                textbox.text = sequenceText;
            }
        }
        protected void HideMenuUI()
        {
            worldMenuUI.SetActive(false);
            textbox.text = "";
        }
    }
}