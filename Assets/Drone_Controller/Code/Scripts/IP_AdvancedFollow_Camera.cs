using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace klon.Camera
{

    public class IP_AdvancedFollow_Camera : IP_Base_Camera
    {
        #region Variables
        public float m_Distance = 10f;
        public float m_Height = 5f;
        public float m_smoothSpeed = 2f;

        private Vector3 wantedPosition;
        private Vector3 wantedBack;
        private float wantedYAngle;
        #endregion

        #region Helper Methods
        protected override void HandleCamera()
        {
            base.HandleCamera();

            wantedYAngle = Mathf.LerpAngle(wantedYAngle, m_Target.eulerAngles.y, Time.deltaTime * m_smoothSpeed);
            Vector3 back = Vector3.back;
            back = Quaternion.AngleAxis(wantedYAngle, Vector3.up) * back;
            Debug.DrawRay(m_Target.position,back,Color.green);

            wantedPosition = (back * m_Distance) + (Vector3.up * m_Height);

            //Follow from same position
            // transform.position = wantedPosition;

            //Follow object
            transform.position =wantedPosition + m_Target.position;
            transform.LookAt(m_Target);
        }
        #endregion

    }
}