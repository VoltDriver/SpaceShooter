using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [System.Serializable]
    public class Boundary
    {
        // These are the boundaries of position of the rigidBody. They prevent the rigidbody from going over those positions.
        // Those values are controlled from Unity. Do NOT set them here.
        public float m_xMin, m_xMax, m_zMin, m_zMax;
    }
}
