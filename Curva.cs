using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;

namespace Proyek_UTS_Grafkom
{
    class Curva:Mesh
    {
        protected List<Vector3> indexBezier=new List<Vector3>();
        public void addPoint(float _x,float _y, float _z)
        {
            Vector3 temp_vector;
            temp_vector.X = _x;
            temp_vector.Y = _y;
            temp_vector.Z = _z;
            indexBezier.Add(temp_vector);
        }
        public void createbezierVertices()
        {
            Vector3 temp_vector;
            int i = 0;
            temp_vector.X = indexBezier[i].X;
            temp_vector.Y = indexBezier[i].Y;
            temp_vector.Z = indexBezier[i].Z;
            vertices.Add(temp_vector);
            i++;
            for (float t = 0; t < 1.0f; t += 0.01f)
            {
                Vector3 p;
                p.X = 0;
                p.Y = 0;
                p.Z = 0;
                int[] segitigapascal = new int[indexBezier.Count + 1];
                int rows = indexBezier.Count - 1, coef = 1;
                for (int j = 0; j <= rows; j++)
                {
                    segitigapascal[j] = coef;
                    coef = coef * (rows - j) / (j + 1);
                }
                for (int j = 0; j < indexBezier.Count; j++)
                {
                    float a = segitigapascal[j] * (float)Math.Pow((1 - t), (indexBezier.Count - (j + 1))) * (float)Math.Pow(t, j);
                    p.X += a * indexBezier[j].X;
                    p.Y += a * indexBezier[j].Y;
                    p.Z += a * indexBezier[j].Z;
                }
                vertices.Add(p);
                i++;
            }
        }
        public void setupObject(string vert, string frag)
        {
            transform = Matrix4.Identity;

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, vertices.Count * Vector3.SizeInBytes, vertices.ToArray(), BufferUsageHint.StaticDraw);

            _vertexArrayObject = GL.GenBuffer();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            _shader = new Shader(vert, frag);
        }

        public void render()
        {
            _shader.Use();
            _shader.SetMatrix4("transform", transform);
            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawArrays(PrimitiveType.Lines, 0, vertices.Count);
        }

    }
}
