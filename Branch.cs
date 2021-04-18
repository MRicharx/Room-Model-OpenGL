using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace Proyek_UTS_Grafkom
{
    class Branch
    {
        //Vector 3 pastikan menggunakan OpenTK.Mathematics
        //tanpa protected otomatis komputer menganggap sebagai private
        List<Vector3> vertices = new List<Vector3>();
        List<Vector3> vertices_temporary = new List<Vector3>();
        int _vertexBufferObject;
        int _vertexArrayObject;
        Shader _shader;
        Matrix4 transform;
        public Branch()
        {
        }
        public void createbezierVertices()
        {
            Vector3 temp_vector;
            int i = 0;
            temp_vector.X = vertices_temporary[i].X;
            temp_vector.Y = vertices_temporary[i].Y;
            temp_vector.Z = vertices_temporary[i].Z;
            vertices.Add(temp_vector);
            i++;
            for (float t = 0; t < 1.0f; t+= 0.01f)
            {
                Vector3 p;
                p.X = 0;
                p.Y = 0;
                p.Z = 0;
                int[] segitigapascal = new int[vertices_temporary.Count + 1];
                int rows = vertices_temporary.Count - 1, coef = 1;
                for (int j = 0; j <= rows; j++)
                {
                    segitigapascal[j] = coef;
                    coef = coef * (rows - j) / (j + 1);
                }
                for (int j = 0; j < vertices_temporary.Count; j++)
                {
                    float a = segitigapascal[j] * (float)Math.Pow((1 - t), (vertices_temporary.Count - (j + 1))) * (float)Math.Pow(t, j);
                    p.X += a * vertices_temporary[j].X;
                    p.Y += a * vertices_temporary[j].Y;
                    p.Z += a * vertices_temporary[j].Z;
                }
                vertices.Add(p);
                i++;
            }
        }

        public void setupObject(string vert,string frag)
        {

            //inisialisasi Transformasi
            transform = Matrix4.Identity;
            //inisialisasi buffer
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            //parameter 2 yg kita panggil vertices.Count == array.length
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer,
                vertices.Count * Vector3.SizeInBytes,
                vertices.ToArray(),
                BufferUsageHint.StaticDraw);
            //inisialisasi array
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            _shader = new Shader(vert,frag);
            _shader.Use();
        }
        public void render()
        {
            //render itu akan selalu terpanggil setiap frame
            _shader.Use();
            _shader.SetMatrix4("transform", transform);
            GL.BindVertexArray(_vertexArrayObject);
            //perlu diganti di parameter 2
            GL.DrawArrays(PrimitiveType.LineStrip,
               0, vertices.Count);
        }
        public void addPoint(float x, float y, float z)
        {
            vertices_temporary.Add(new Vector3(x, y, z));
        }
        public void rotate(float degreeX, float degreeY, float degreeZ)
        {
            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degreeZ));
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degreeY));
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degreeX));
        }
        public void scale(float _scale)
        {
            transform = transform * Matrix4.CreateScale(_scale);
        }
        public void translate(float degreeX, float degreeY, float degreeZ)
        {
            transform = transform * Matrix4.CreateTranslation(degreeX, degreeY, degreeZ);
        }

    }
}
