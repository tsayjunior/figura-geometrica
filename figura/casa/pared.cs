using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figura.casa
{
    class pared : controlador
    {
        float[] vertices = {
            -0.4f, 0.4f, 0.0f,
            -0.4f, -0.4f, 0.0f,
            0.4f, -0.4f, 0.0f,
            0.4f, 0.4f, 0.0f,

            0.4f, 0.4f, -0.4f,
            0.4f, -0.4f, -0.4f,

            -0.4f, 0.4f, -0.4f,
            -0.4f, -0.4f, -0.4f,

            -0.4f, 0.1f, 0.0f,
            -0.2f, 0.1f, 0.0f,
            0.2f, 0.1f, 0.0f,
            0.4f, 0.1f, 0.0f,
            -0.2f, -0.4f, 0.0f,
            0.2f, -0.4f, 0.0f
            //-0.9f, -0.4f, 0f
        };
        uint[] indices =
        {
            0, 3, 11,
            0, 11, 8,
            8, 9, 12,
            8, 12, 1,
            10, 11, 2,
            10, 13, 2,

            2, 3, 4,
            2, 4, 5,
            0, 6, 1,
            1, 6, 7,
            4, 5, 6,
            5, 6, 7,
            5, 2, 1,
            5, 7, 1

        };
        Color4 color = new Color4(90, 243, 52, 1);
        public pared()
        {
            base.init(vertices, indices, color);
        }
    }
}
