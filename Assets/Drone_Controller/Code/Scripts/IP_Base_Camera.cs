using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace klon.Camera
{
    public class IP_Base_Camera : MonoBehaviour
    {
        #region Variables
        public Transform m_Target;
        #endregion

        #region Main Methods
        void Start()
        {
            HandleCamera();
        }

        // Update is called once per frame
        void Update()
        {
            HandleCamera();
        }
        #endregion

        #region Helper Methods
        protected virtual void HandleCamera()
        {
            if(!m_Target)
            {
                return;
            }
        }
        #endregion
    }
}
