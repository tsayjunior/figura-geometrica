using figura.recursos;
using OpenTK;
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

        Matrix4 model;
        Matrix4 view;
        Matrix4 projection;
        float escala;
        Matrix4 translation;//translacion

        Vector3 position;
        Vector3 front;
        Vector3 up;


        bool rotacion;
        bool traslacion;
        bool escalacion;

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


            Vector3 position = new Vector3(3.0f, 0.0f, 3.0f);//posicion de camara
            Vector3 front = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);

            view = Matrix4.LookAt(position, /*position + */front, up);
            model = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0)); //rotacion

            translation = Matrix4.CreateTranslation(0.0f, 0.0f, 0.0f);
            escala = 45;

            rotacion = false;
            traslacion = false;
            escalacion = false;
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
        public void introducirMatrices(Matrix4 model, Matrix4 view, Matrix4 projection)
        {

            this.model = model;
            this.projection = projection;
            this.view = view;
        }
        public void meterWidthHeight(float width, float height)
        {
            projection = translation * Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(escala),
                width / height, 0.1f, 100.0f);//escalacion
            //projection = translation * Matrix4.CreateScale(0.5f, 0.5f, 0.5f);
        }
        public void rotar()
        {
            rotacion = true;
            traslacion = false;
            escalacion = false;
        }
        public void trasladar()
        {
            traslacion = true;
            rotacion = false;
            escalacion = false;
        }
        public void escalar()
        {
            escalacion = true;
            rotacion = false;
            traslacion = false;
        }
        public void trasladarDerechaX()
        {
            if (traslacion)
            {
                translation = translation * Matrix4.CreateTranslation(0.01f, 0.0f, 0.0f);
            }
        }
        public void trasladarIzquierdaX()
        {
            if (traslacion)
            {
                translation = translation * Matrix4.CreateTranslation(-0.01f, 0.0f, 0.0f);
            }
        }
        public void trasladarArribaY()
        {
            if (traslacion)
            {
                translation = translation * Matrix4.CreateTranslation(0.0f, 0.01f, 0.0f);
            }
        }
        public void trasladarAbajoY()
        {
            if (traslacion)
            {
                translation = translation * Matrix4.CreateTranslation(0.0f, -0.01f, 0.0f);
            }
        }
        public void moverEnZpositivo()
        {
            if (traslacion)
            {
                translation = translation * Matrix4.CreateTranslation(0.0f, 0.0f, 0.01f);
            }
        }
        public void moverEnZnegativo()
        {
            if (traslacion)
            {
                translation = translation * Matrix4.CreateTranslation(0.0f, 0.0f, -0.01f);
            }
        }
        public void escalarAgrandar()
        {
            if (escalacion)
            {
                escala = escala - 1;
            }
        }
        public void escalarAchicar()
        {
            if (escalacion)
            {
                escala = escala + 1;
            }
        }
        public void rotarXarriba()
        {
            if (rotacion)
            {
                model = model * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(1)); //rotacion
            }
        }
        public void rotarXabajo()
        {
            if (rotacion)
            {
                model = model * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-1)); //rotacion
            }
        }
        public void rotarYderecha()
        {
            if (rotacion)
            {
                model = model * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(1)); //rotacion
            }
        }
        public void rotarYizquierda()
        {
            if (rotacion)
            {
                model = model * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(-1)); //rotacion
            }
        }

        public void rotarZderecha()
        {
            if (rotacion)
            {
                model = model * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(1)); //rotacion
            }
        }
        public void rotarZizquierda()
        {
            if (rotacion)
            {
                model = model * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-1)); //rotacion
            }
        }
        public void setterMatrix4()
        {
            shader.SetMatrix4("model", model);
            shader.SetMatrix4("view", view);
            shader.SetMatrix4("projection", projection);
        }
    }
}
