using UnityEngine;

namespace Myfps
{
    public class PickupAmmoBox : Interactive
    {
        [SerializeField]private int giveAmmo = 7;
        //private bool isChting = true;

        protected override void DoAction()
        {
            /*if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("탄환 7개를 지급 했습니다");
                PlayerState.Instance.AddAmmo(giveAmmo);
                Destroy(gameObject);
                HideActionUI();
            }*/
            /*else if (Input.GetKeyDown(KeyCode.Z) && isChting)
            {
                Debug.Log("isChting을 사용했습니다");
                PlayerState.Instance.AddAmmo(99);
                Destroy(gameObject);
                HideActionUI();
            }*/
        }
    }
}