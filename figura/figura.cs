using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figura
{
    class figura : GameWindow
    {
        float[] vertices = {
             -0.9f, 0.2f, 0.0f, 
             -0.6f, 0.7f, 0.0f, 
             -0.3f, 0.2f, 0.0f,  
             -0.9f, 0.2f, 0.0f,

            -0.3f, 0.2f, 0.0f,
            -0.6f, 0.7f, 0.0f,
            0.6f, 0.7f, 0,
            0.9f, 0.2f, 0,
            -0.3f, 0.2f, 0.0f,

            -0.3f, 0.2f, 0.0f,
            0.9f, 0.2f, 0,
            0.9f, -0.7f, 0,
            -0.3f, -0.7f, 0,
            -0.3f, 0.2f, 0.0f,

            -0.9f, 0.2f, 0.0f,
            -0.3f, 0.2f, 0.0f,
            -0.3f, -0.7f, 0,
            -0.9f, -0.7f, 0,
            -0.9f, 0.2f, 0.0f,

            -0.7f, -0.7f, 0,
            -0.7f, -0.3f, 0,
            -0.5f, -0.3f, 0,
            -0.5f, -0.7f, 0,
            -0.7f, -0.7f, 0,

            -0.1f, 0, 0,
            0.7f, 0, 0,
            0.7f, -0.4f, 0,
            -0.1f, -0.4f, 0,
            -0.1f, 0, 0,
        };
        int VertexBufferObject;//objeto de bufer de vertices
        public figura(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            //Code goes here
            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            //shader.Use()
            //3. now draw the object
            //someOpenGLFunctionThatDrawsOurTriangle();

            base.OnLoad(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.DrawArrays(PrimitiveType.LineStrip, 0, 4);
            GL.DrawArrays(PrimitiveType.LineStrip, 4, 5);
            GL.DrawArrays(PrimitiveType.LineStrip, 9, 5);
            GL.DrawArrays(PrimitiveType.LineStrip, 14, 5);
            GL.DrawArrays(PrimitiveType.LineStrip, 19, 5);
            GL.DrawArrays(PrimitiveType.LineStrip, 24, 5);

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(VertexBufferObject);
            base.OnUnload(e);
        }
    }
}
