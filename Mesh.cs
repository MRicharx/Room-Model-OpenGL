using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;

namespace Proyek_UTS_Grafkom
{
    class Mesh
    {
        protected List<Vector3> vertices = new List<Vector3>();
        protected List<uint> vertexIndices = new List<uint>();
        protected int _vertexBufferObject;
        protected int _vertexArrayObject;

        protected Vector3 startPoint;

        protected Shader _shader; protected Matrix4 transform;

        public List<Mesh> child = new List<Mesh>();

        public Mesh()
        {
            transform = Matrix4.Identity;
            startPoint.X = 0.0f;
            startPoint.Y = 0.0f;
            startPoint.Z = 0.0f;
        }

        public void rotate(float degreeX, float degreeY, float degreeZ)
        {
            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degreeZ));
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degreeY));
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degreeX));
            for (int i = 0; i < child.Count; i++)
                child[i].rotate(degreeX, degreeY,degreeZ);
        }
        public void scale(float _scale)
        {
            transform = transform * Matrix4.CreateScale(_scale);
            for (int i = 0; i < child.Count; i++)
                child[i].scale(_scale);
        }
        public void translate(float degreeX, float degreeY, float degreeZ)
        {
            transform = transform * Matrix4.CreateTranslation(degreeX, degreeY, degreeZ);
            for (int i = 0; i < child.Count; i++)
                child[i].translate(degreeX, degreeY, degreeZ);
        }

        public void addChild(Mesh newChild)
        {
            child.Add(newChild);
        }

        public void setStartPoint(float _x,float _y,float _z)
        {
            startPoint.X = _x;
            startPoint.Y = _y;
            startPoint.Z = _z;
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

            _shader = new Shader(vert, frag);
        }
        public void render(int opsi=0)
        {
            _shader.Use();
            _shader.SetMatrix4("transform", transform);
            GL.BindVertexArray(_vertexArrayObject);

            if(opsi==0)
                GL.DrawArrays(PrimitiveType.Lines,
                    0, vertices.Count);
            else
                GL.DrawArrays(PrimitiveType.TriangleFan,
                    0, vertices.Count);
            for (int i = 0; i < child.Count; i++)
                child[i].render(opsi);
        }
    }
}
