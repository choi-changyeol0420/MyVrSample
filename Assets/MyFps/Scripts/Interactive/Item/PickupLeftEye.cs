using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Myfps
{
    public class PickupLeftEye : Interactive
    {
        #region Variables
        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI puzzleText;

        public GameObject puzzleitemGP;

        
        public Sprite itemSprite;
        [SerializeField] private string puzzleStr = "Puzzle Text";
        #endregion
        protected override void DoAction()
        {
            keyText.gameObject.SetActive(true);
            actionText.gameObject.SetActive(true);
            /*if(Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(PuzzleItem());
            }*/
        }
        IEnumerator PuzzleItem()
        {
            //LEFTEYE_KEY 퍼즐 아이템 획득
            PlayerState.Instance.AcquirePuzzleItem(PuzzleKey.LEFTEYE_KEY);
            
            //연출
            if(puzzleUI != null)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                puzzleitemGP.SetActive(false);
                HideActionUI();

                puzzleUI.SetActive(true);
                itemImage.sprite = itemSprite;
                puzzleText.text = puzzleStr;
                yield return new WaitForSeconds(2f);
                puzzleUI.SetActive(false);
                
            }
            //킬
            Destroy(gameObject);
        }
    }
}