using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figura.casa
{
    class puerta : controlador
    {
        float[] vertices = {
             -0.5f, -0.4f, 0f,//0
             -0.5f, -0.9f, 0f,//1
             -0.7f, -0.9f, 0f,
             -0.7f, -0.4f, 0f
        };
        uint[] indices =
        {
            0, 1, 2,
            0, 2, 3
        };
        Color4 color = new Color4(8, 43, 215, 1);
        public puerta()
        {
            base.init(vertices, indices, color);
        }
    }
}
