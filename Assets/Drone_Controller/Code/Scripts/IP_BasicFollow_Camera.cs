using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace klon.Camera
{
    public class IP_BasicFollow_Camera : IP_Base_Camera
    {

        #region Variables
        public float m_Distance = 10f;
        public float m_Height = 5f;
        public float m_smoothSpeed = 2f;

        private Vector3 wantedPosition;
        private Vector3 debugDistance;
        private Vector3 refVelosity;
        #endregion

        #region Helper Methods
        protected override void HandleCamera()
        {
            base.HandleCamera();

            wantedPosition = m_Target.position + (-m_Target.forward * m_Distance) + (Vector3.up * m_Height);

            debugDistance = Vector3.SmoothDamp(debugDistance, -m_Target.forward,ref refVelosity,m_smoothSpeed);
            Debug.DrawRay(m_Target.position, -m_Target.forward, Color.red);
            Debug.DrawRay(m_Target.position, debugDistance, Color.green);

            transform.position = Vector3.Lerp(transform.position,wantedPosition,Time.deltaTime * m_smoothSpeed);
            transform.LookAt(m_Target);
        }
        #endregion
    }
}