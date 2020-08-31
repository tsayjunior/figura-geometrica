using OpenTK;
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
            -0.2f, 0.1f, 0.0f,
            -0.2f, -0.4f, 0.0f,
            0.2f, -0.4f, 0.0f,
            0.2f, 0.1f, 0.0f
        };
        uint[] indices =
        {
            0, 1, 2,
            0, 2, 3
        };
        Color4 color = new Color4(8, 43, 215, 1);
        Vector3 centro = new Vector3(0, 0.15f, 0);

        Vector3 abrirPuerta = new Vector3(0.2f, 0f, 0);

        public puerta()
        {
            base.init(vertices, indices, color);
            base.ponerCentro(centro);
        }
    }
}
