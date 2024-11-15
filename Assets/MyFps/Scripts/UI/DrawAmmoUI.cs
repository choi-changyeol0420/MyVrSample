using TMPro;
using UnityEngine;

namespace Myfps
{
    public class DrawAmmoUI : MonoBehaviour
    {
        public TextMeshProUGUI AmmoText;
        // Update is called once per frame
        void Update()
        {
            AmmoText.text = PlayerState.Instance.AmmoCount.ToString();
        }
    }
}