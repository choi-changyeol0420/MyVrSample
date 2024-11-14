using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyVrSample
{
    /// <summary>
    /// 권총 총알 발사
    /// </summary>
    public class FireBulletOnActivate : MonoBehaviour
    {
        #region Variables
        public GameObject buiietPrefab;
        public Transform firePoint;
        public float fireSpeed = 20f;
        #endregion

        private void Start()
        {
            XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
            grabInteractable.activated.AddListener(Fire);
        }
        void Fire(ActivateEventArgs args)
        {
            GameObject bulletGo = Instantiate(buiietPrefab, firePoint.position, firePoint.rotation);
            bulletGo.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * fireSpeed;
            Destroy(bulletGo, 5f);
        }
    }
}