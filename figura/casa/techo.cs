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
            0.0f, 0.7f, -0.2f,
            0.4f, 0.4f, -0.4f,
            -0.4f, 0.4f, -0.4f
        };
        uint[] indices =
        {
            0, 1, 2,
            1, 2, 3,
            2, 3, 4,
            2, 4, 0
        };
        Color4 color = new Color4(13, 184, 170, 1);
        public techo()
        {
            base.init(vertices, indices, color);
        }
    }
}
