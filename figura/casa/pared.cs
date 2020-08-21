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
             -0.3f, 0.2f, 0.0f,
             -0.9f, 0.2f, 0.0f,
             -0.3f, -0.9f, 0.0f,
            -0.9f, -0.9f, 0,
            -0.5f, -0.9f, 0,
            -0.5f, -0.4f, 0,
            -0.7f, -0.4f, 0f,
            -0.7f, -0.9f, 0f,
            0.9f, 0.2f, 0f,
            0.9f, -0.9f, 0f,
            -0.3f, -0.4f, 0f,
            -0.9f, -0.4f, 0f
        };
        uint[] indices =
        {
            0, 10, 11,
            1, 0, 11,
            10, 2, 4,
            5, 10, 4,
            6, 7, 3,
            11, 6, 3,
            8, 0, 2,
            8, 9, 2

        };
        Color4 color = new Color4(90, 243, 52, 1);
        public pared()
        {
            base.init(vertices, indices, color);
        }
    }
}
