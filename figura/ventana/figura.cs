using figura.casa;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figura
{
    class figura : GameWindow
    {
        techo tech;
        pared paredd;
        puerta puert;
        public figura(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);


            GL.Enable(EnableCap.DepthTest);

            tech = new techo();
            paredd = new pared();
            puert = new puerta();

            base.OnLoad(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            tech.meterWidthHeight(Width, Height);
            paredd.meterWidthHeight(Width, Height);
            puert.meterWidthHeight(Width, Height);

            puert.setterMatrix4();
            paredd.setterMatrix4();
            tech.setterMatrix4();

            puert.dibujar();
            paredd.dibujar();
            tech.dibujar();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            if (!Focused) // check to see if the window is focused
            {
                return;
            }
            if (input.IsKeyDown(Key.R))
            {
                //presionando R pone en true mi rotacion
                tech.rotar();
                paredd.rotar();
                puert.rotar();
            }
            if (input.IsKeyDown(Key.T))
            {
                //presionando T pone en true mi traslacion
                tech.trasladar();
                paredd.trasladar();
                puert.trasladar();
            }
            if (input.IsKeyDown(Key.E))
            {
                //presionando E pone en true mi escalacion
                tech.escalar();
                paredd.escalar();
                puert.escalar();
            }
            if (input.IsKeyDown(Key.Right))
            {
                //presionando flechaDerecha se mueve a la derecha
                tech.trasladarDerechaX();
                paredd.trasladarDerechaX();
                puert.trasladarDerechaX();
                //presionando flechaDerecha rota en Y hacia la derecha
                tech.rotarYderecha();
                paredd.rotarYderecha();
                puert.rotarYderecha();

            }

            if (input.IsKeyDown(Key.Left))
            {
                //presionando flechaIzquierda se mueve a la izquierda
                tech.trasladarIzquierdaX();
                paredd.trasladarIzquierdaX();
                puert.trasladarIzquierdaX();
                //presionando flechaIzquierda rota en Y hacia la izquierda
                tech.rotarYizquierda();
                paredd.rotarYizquierda();
                puert.rotarYizquierda();


            }

            if (input.IsKeyDown(Key.Up))
            {
                //presionando flechaHaciaArriba se mueve en Y, hacia arriba
                tech.trasladarArribaY();
                paredd.trasladarArribaY();
                puert.trasladarArribaY();
                //presionando flechaHaciaArriba se agranda, aumenta su escala
                tech.escalarAgrandar();
                paredd.escalarAgrandar();
                puert.escalarAgrandar();
                //presionando flechaHaciaArriba rota en X hacia arriba
                tech.rotarXarriba();
                paredd.rotarXarriba();
                puert.rotarXarriba();
            }

            if (input.IsKeyDown(Key.Down))
            {
                //presionando flechaHaciaAbajo se mueve en Y hacia abajo
                tech.trasladarAbajoY();
                paredd.trasladarAbajoY();
                puert.trasladarAbajoY();
                //presionando flechaHaciaAbajo se achica, disminuye su escala
                tech.escalarAchicar();
                paredd.escalarAchicar();
                puert.escalarAchicar();
                //presionando flechaHaciaAbajo rota en X hacia abajo
                tech.rotarXabajo();
                paredd.rotarXabajo();
                puert.rotarXabajo();

            }

            if (input.IsKeyDown(Key.Keypad9))
            {

                //presionando numero 9 se mueve hacia el eje Z positivo
                tech.moverEnZpositivo();
                paredd.moverEnZpositivo();
                puert.moverEnZpositivo();
                //presionando numero 9 rota en Z positivo
                tech.rotarZderecha();
                paredd.rotarZderecha();
                puert.rotarZderecha();
            }

            if (input.IsKeyDown(Key.Keypad1))
            {
                //presionando numero 1 se mueve hacia el eje Z negativo
                tech.moverEnZnegativo();
                paredd.moverEnZnegativo();
                puert.moverEnZnegativo();
                //presionando numero 1 rota en z negativo
                tech.rotarZizquierda();
                paredd.rotarZizquierda();
                puert.rotarZizquierda();
            }
            base.OnUpdateFrame(e);
        }
        protected override void OnUnload(EventArgs e)
        {
            tech.destroy();
            paredd.destroy();
            puert.destroy();


            base.OnUnload(e);
        }
    }
}
