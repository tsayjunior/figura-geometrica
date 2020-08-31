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
        bool todo;
        public figura(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            todo = false;
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
            if (input.IsKeyDown(Key.F1))
            {
                // activa variable casa para que todas las figuras hagan transformaciones basicas
                tech.activarCasa();
                paredd.activarCasa();
                puert.activarCasa();
                todo = true;
            }
            if (input.IsKeyDown(Key.F2))
            {
                //activa variable casa para que solo techo haga transformaciones basicas
                tech.activarCasa();
                paredd.desactivarCasa();
                puert.desactivarCasa();
                todo = false;
            }
            if (input.IsKeyDown(Key.F3))
            {
                //activa variable casa para que solo pared haga transformaciones basicas
                tech.desactivarCasa();
                paredd.activarCasa();
                puert.desactivarCasa();
                todo = false;
            }
            if (input.IsKeyDown(Key.F4))
            {
                //activa variable casa para que solo puerta haga transformaciones basicas
                tech.desactivarCasa();
                paredd.desactivarCasa();
                puert.activarCasa();
                todo = false;
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
                if (todo)
                {
                    tech.rotarYderecha();
                    paredd.rotarYderecha();
                    puert.rotarYderecha();
                }
                else { 
                tech.rotarYderechaParte();
                paredd.rotarYderechaParte();
                puert.rotarYderechaParte();
                }
            }

            if (input.IsKeyDown(Key.Left))
            {
                //presionando flechaIzquierda se mueve a la izquierda
                tech.trasladarIzquierdaX();
                paredd.trasladarIzquierdaX();
                puert.trasladarIzquierdaX();
                //presionando flechaIzquierda rota en Y hacia la izquierda
                
                if (todo)
                {
                    tech.rotarYizquierda();
                    paredd.rotarYizquierda();
                    puert.rotarYizquierda();
                }
                else
                {
                    tech.rotarYizquierdaParte();
                    paredd.rotarYizquierdaParte();
                    puert.rotarYizquierdaParte();
                }

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
                
                if (todo)
                {
                    tech.rotarXarriba();
                    paredd.rotarXarriba();
                    puert.rotarXarriba();
                }
                else
                {
                    tech.rotarXarribaParte();
                    paredd.rotarXarribaParte();
                    puert.rotarXarribaParte();
                }
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
                
                if (todo)
                {
                    tech.rotarXabajo();
                    paredd.rotarXabajo();
                    puert.rotarXabajo();
                }
                else
                {
                    tech.rotarXabajoParte();
                    paredd.rotarXabajoParte();
                    puert.rotarXabajoParte();
                }

            }

            if (input.IsKeyDown(Key.Keypad9))
            {

                //presionando numero 9 se mueve hacia el eje Z positivo
                tech.moverEnZpositivo();
                paredd.moverEnZpositivo();
                puert.moverEnZpositivo();
                //presionando numero 9 rota en Z positivo
                
                if (todo)
                {
                    tech.rotarZderecha();
                    paredd.rotarZderecha();
                    puert.rotarZderecha();
                }
                else
                {
                    tech.rotarZderechaParte();
                    paredd.rotarZderechaParte();
                    puert.rotarZderechaParte();
                }
            }

            if (input.IsKeyDown(Key.Keypad1))
            {
                //presionando numero 1 se mueve hacia el eje Z negativo
                tech.moverEnZnegativo();
                paredd.moverEnZnegativo();
                puert.moverEnZnegativo();
                //presionando numero 1 rota en z negativo
                
                if (todo)
                {
                    tech.rotarZizquierda();
                    paredd.rotarZizquierda();
                    puert.rotarZizquierda();
                }
                else
                {
                    tech.rotarZizquierdaParte();
                    paredd.rotarZizquierdaParte();
                    puert.rotarZizquierdaParte();
                    
                }
            }
            if (input.IsKeyDown(Key.A))
            {
                puert.abrirPuerta("abrir");
            }
            if (input.IsKeyDown(Key.C))
            {
                puert.abrirPuerta("cerrar");
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
