using TMPro;
using UnityEngine;
using System.Collections;

namespace Myfps
{
    public class PutinItem : Interactive
    {
        public GameObject fakefulleye;
        public GameObject realfulleye;
        public GameObject fakewall;
        public GameObject exitwall;
        public GameObject exitTrigger;
        private PlayerState player;
        private Animator animator;
        public TextMeshProUGUI textBox;

        private void Start()
        {
            player = PlayerState.Instance;
            animator = exitwall.GetComponent<Animator>();
        }
        private void FixedUpdate()
        {
            if(player.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY)
                    && player.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY))
            {
                fakewall.SetActive(false);
                exitwall.SetActive(true);
            }
        }
        protected override void DoAction()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (player.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY)
                    && player.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY))
                {
                    fakefulleye.SetActive(false);
                    realfulleye.SetActive(true);
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    animator.SetBool("IsOpen", true);
                    exitTrigger.SetActive(true);
                }
                else
                {
                    StartCoroutine(Enumerator());
                }
            }
        }
        IEnumerator Enumerator()
        {
            textBox.enabled = true;
            textBox.text = "You need more Eye Pictures";
            
            yield return new WaitForSeconds(1);
            textBox.enabled = false;
        }
    }
}