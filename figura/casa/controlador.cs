using figura.recursos;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figura.casa
{
    class controlador
    {
        public float[] vertices;
        public uint[] indices;
        Color4 color;

        int VertexBufferObject;//objeto de bufer de vertices VBO
        int ElementBufferObject; // EBO
        int VertexArrayObject; //VAO

        shader shader;
        public controlador()
        {

        }
        public void init(float[] vertice, uint[] indice, Color4 color)
        {
            this.vertices = vertice;
            this.indices = indice;
            this.color = color;


            VertexBufferObject = GL.GenBuffer();
            ElementBufferObject = GL.GenBuffer();
            VertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayObject); ////habilitamos el VA0
            //enlaza VBO con buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            //enlaza el ebo con el buffer 
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            setShader();
            shader.setColor(color);
            

        }
        public void setShader()
        {
            shader = new shader("recursos/shaders/shader.vert", "recursos/shaders/shader.frag");
            shader.Use();

        }

        public void destroy()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);// lo enlaza a nulo
            GL.DeleteBuffer(VertexBufferObject);//borra vbo

            shader.Dispose();//elimina shader
        }
        public void dibujar()
        {
            shader.Use();
            //setUniforms();
            GL.BindVertexArray(VertexArrayObject);
            //dibuja
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}
