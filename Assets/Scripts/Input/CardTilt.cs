using UnityEngine;

namespace Aura.Input
{
    public sealed class CardTilt : MonoBehaviour
    {
        [SerializeField, Range(0f, 30f)] private float maxAngle = 12f;
        [SerializeField, Min(0.1f)] private float responsiveness = 8f;
        [SerializeField] private bool useGyroscope = true;
        private Quaternion initialRotation;

        private void Awake() { initialRotation = transform.localRotation; }
        private void OnEnable()
        {
            if (useGyroscope && SystemInfo.supportsGyroscope)
                UnityEngine.Input.gyro.enabled = true;
        }

        private void Update()
        {
            Vector2 tilt = Vector2.zero;
            if (useGyroscope && SystemInfo.supportsGyroscope)
            {
                Vector3 g = UnityEngine.Input.gyro.gravity;
                tilt = new Vector2(Mathf.Clamp(g.y, -1f, 1f), Mathf.Clamp(g.x, -1f, 1f));
            }
            Quaternion target = initialRotation * Quaternion.Euler(-tilt.x * maxAngle, tilt.y * maxAngle, 0f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, target,
                1f - Mathf.Exp(-responsiveness * Time.deltaTime));
        }
    }
}
