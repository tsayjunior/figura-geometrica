using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figura.casa
{
    class techo : controlador
    {
        float[] vertices = {
            -0.4f, 0.4f, 0.0f,
            0.4f, 0.4f, 0.0f,
            0.0f, 0.8f, -0.6f,
            0.4f, 0.4f, -1.2f,
            -0.4f, 0.4f, -1.2f
        };
        uint[] indices =
        {
            0, 1, 2,
            1, 2, 3,
            2, 3, 4,
            2, 4, 0
        };
        Color4 color = new Color4(13, 184, 170, 1);
        Vector3 centro = new Vector3(0, -0.6f, 0.6f);
        public techo()
        {
            base.init(vertices, indices, color);
            base.ponerCentro(centro);
        }
        
    }
}
