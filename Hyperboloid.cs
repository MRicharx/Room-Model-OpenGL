using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;

namespace Proyek_UTS_Grafkom
{
    class Hyperboloid:Mesh
    {

        Vector3 _radius;
        public Hyperboloid()
        {
            _radius.X = 0.1f;
            _radius.Y = 0.1f;
            _radius.Z = 0.1f;
        }

        public void createHyperboloidVertices(float _x,float _y,float _z)
        {
            float _positionX = startPoint.X;
            float _positionY = startPoint.Y;
            float _positionZ = startPoint.Z;

            setRadius(_x, _y, _z);

            float _pi = 3.14159f;
            Vector3 temp_vector;

            for (float u = -_pi; u <= _pi; u += _pi / 30)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                {
                    temp_vector.X = _positionX + (1.0f / (float)Math.Cos(v)) * (float)Math.Cos(u) * _radius.X; // x
                    temp_vector.Y = _positionY + (1.0f / (float)Math.Cos(v)) * (float)Math.Sin(u) * _radius.Y; // y
                    temp_vector.Z = _positionZ + (float)Math.Tan(v) * _radius.Z; // z
                    vertices.Add(temp_vector);
                }
            }
        }
        public void setRadius(float x,float y,float z)
        {
            _radius.X = x;
            _radius.Y = y;
            _radius.Z = z;
        }
    }
}
