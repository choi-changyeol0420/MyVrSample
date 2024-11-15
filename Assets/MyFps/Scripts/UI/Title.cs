using System.Collections;
using UnityEngine;


namespace Myfps
{
    public class Title : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadtoScene = "MainMenu";

        private bool isAnykey = false;
        public GameObject anykeyUI;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            fader.FromFade();
            //초기화
            isAnykey = false;
            StartCoroutine(TitleProcess());
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.anyKey && isAnykey)
            {
                GotoMenu();
            }
        }
        IEnumerator TitleProcess()
        {
            yield return new WaitForSeconds(3);
            anykeyUI.SetActive(true);
            isAnykey=true;
            yield return new WaitForSeconds(10);
            GotoMenu();
        }
        private void GotoMenu()
        {
            StopAllCoroutines();
            fader.FadeTo(loadtoScene);
        }
    }
}