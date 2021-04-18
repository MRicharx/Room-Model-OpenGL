using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;

namespace Proyek_UTS_Grafkom
{
    class Tube:Mesh
    {
        Vector3 _radius; float length;

        public Tube()
        {
            _radius.X = 0.1f;
            _radius.Y = 0.1f;
            _radius.Z = 1.0f;
            length = 3.14159f;
        }
        public void createTubeVertices(float _x,float _y)
        {
            float _positionX = startPoint.X;
            float _positionY = startPoint.Y;
            float _positionZ = startPoint.Z;

            setRadius(_x, _y);

            float _pi = 3.1415f;
            Vector3 temp_vector;

            for (float u = -_pi; u <= _pi; u += _pi / 30)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                {
                    temp_vector.X = _positionX + (float)Math.Cos(u) * _radius.X; // x
                    temp_vector.Y = _positionY + (float)Math.Sin(u) * _radius.Y; // y
                    temp_vector.Z = _positionZ + v *_radius.Z; // z
                    vertices.Add(temp_vector);
                }
            }
        }

        public void setRadius(float x, float y)
        {
            _radius.X = x;
            _radius.Y = y;
        }
        public void setLength(float l)
        {
            length = l;
            _radius.Z = l;
        }
        //public void setThick(float t)
        //{
        //    _radius.Z = t;
        //}
    }
}
