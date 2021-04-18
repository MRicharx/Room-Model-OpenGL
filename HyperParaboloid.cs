using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;

//Masih rusak
namespace Proyek_UTS_Grafkom
{
    class HyperParaboloid:Mesh
    {
        Vector3 _radius;

        public HyperParaboloid()
        {
            setRadius(0.1f, 0.1f, 0.1f);
        }

        public void createHyperParaVertices()
        {
            float _positionX = startPoint.X;
            float _positionY = startPoint.Y;
            float _positionZ = startPoint.Z;

            float _pi = 3.14159f;
            Vector3 temp_vector;

            for (float u=-_pi;u<_pi;u+=_pi/30)
                for(float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                {
                    temp_vector.X = _positionX + _radius.X * v * (float)Math.Tan(u);
                    temp_vector.Y = _positionY + _radius.Y * v * (1.0f/(float)Math.Cos(u));
                    temp_vector.Z = _positionZ + v * v;
                    vertices.Add(temp_vector);
                }
        }
        public void setRadius(float x, float y, float z)
        {
            _radius.X = x;
            _radius.Y = y;
            _radius.Z = z;
        }
    }
}
