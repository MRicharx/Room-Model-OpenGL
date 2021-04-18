using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;

namespace Proyek_UTS_Grafkom
{
    class Cube : Mesh
    {
        int _elementBufferObject;
        public Cube()
        {
        }

        //width length height
        public void createBoxVertices(float _length,float _width,float _height)
        {
            float _positionX = startPoint.X;
            float _positionY = startPoint.Y;
            float _positionZ = startPoint.Z;

            //float _boxLength = 0.5f;

            //buat temporary vector
            Vector3 temp_vector;

            // titik 1
            temp_vector.X = _positionX - _width / 2.0f; // x
            temp_vector.Y = _positionY + _height / 2.0f; // y
            temp_vector.Z = _positionZ - _length / 2.0f; // z

            vertices.Add(temp_vector);

            // titik 2
            temp_vector.X = _positionX + _width / 2.0f; // x
            temp_vector.Y = _positionY + _height / 2.0f; // y
            temp_vector.Z = _positionZ - _length / 2.0f; // z

            vertices.Add(temp_vector);

            // titik 3
            temp_vector.X = _positionX - _width / 2.0f; // x
            temp_vector.Y = _positionY - _height / 2.0f; // y
            temp_vector.Z = _positionZ - _length / 2.0f; // z

            vertices.Add(temp_vector);

            // titik 4
            temp_vector.X = _positionX + _width / 2.0f; // x
            temp_vector.Y = _positionY - _height / 2.0f; // y
            temp_vector.Z = _positionZ - _length / 2.0f; // z

            vertices.Add(temp_vector);

            // titik 5
            temp_vector.X = _positionX - _width / 2.0f; // x
            temp_vector.Y = _positionY + _height / 2.0f; // y
            temp_vector.Z = _positionZ + _length / 2.0f; // z

            vertices.Add(temp_vector);

            // titik 6
            temp_vector.X = _positionX + _width / 2.0f; // x
            temp_vector.Y = _positionY + _height / 2.0f; // y
            temp_vector.Z = _positionZ + _length/ 2.0f; // z
            vertices.Add(temp_vector);
            // titik 7
            temp_vector.X = _positionX - _width / 2.0f; // x
            temp_vector.Y = _positionY - _height / 2.0f; // y
            temp_vector.Z = _positionZ + _length / 2.0f; // z
            vertices.Add(temp_vector);
            // titik 8
            temp_vector.X = _positionX + _width / 2.0f; // x
            temp_vector.Y = _positionY - _height / 2.0f; // y
            temp_vector.Z = _positionZ + _length / 2.0f; // z
            vertices.Add(temp_vector);

            vertexIndices = new List<uint>
            {
                //segitiga depan 1
                0,1,2,
                //segitiga depan 2
                1,2,3,
                //segitiga atas 1
                0,4,5,
                //segitiga atas 2
                0,1,5,
                //segitiga kanan 1
                1,3,5,
                //segitiga kanan 2
                3,5,7,
                //segitiga kiri 1
                0,2,4,
                //segitiga kiri2
                2,4,6,
                //segitiga belakang 1
                4,5,6,
                //segitiga belakang 2
                5,6,7,
                //segitiga bawah 1
                2,3,6,
                //segitiga bawah 2
                3,6,7
            };
        }

        public void setupObject(string vert, string frag)
        {
            transform = Matrix4.Identity;

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, vertices.Count * Vector3.SizeInBytes, vertices.ToArray(), BufferUsageHint.StaticDraw);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, vertexIndices.Count * sizeof(float), vertexIndices.ToArray(), BufferUsageHint.StaticDraw);

            _shader = new Shader(vert, frag);
        }
        public void render(int opsi=0)
        {
            _shader.Use();
            _shader.SetMatrix4("transform", transform);
            GL.BindVertexArray(_vertexArrayObject);

            if(opsi==0)
                GL.DrawElements(PrimitiveType.Triangles, vertexIndices.Count, DrawElementsType.UnsignedInt, 0);
            else
                GL.DrawElements(PrimitiveType.Lines, vertexIndices.Count, DrawElementsType.UnsignedInt, 0);
        }


    }
}
