using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;

namespace Proyek_UTS_Grafkom
{
    class Ellipsoid:Mesh
    {
        public Ellipsoid()
        {

        }
        public void createEllipsVertices(float _radius, float thick, float _press = 0)
        {
            float _positionX = startPoint.X;
            float _positionY = startPoint.Y;
            float _positionZ = startPoint.Z;

            float _pi = 3.14159f;
            Vector3 temp_vector;

            for (float u = -_pi; u <= _pi; u += _pi / 30)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                {

                    temp_vector.X = _positionX + _radius * (float)Math.Cos(v) * (float)Math.Cos(u); // x
                    temp_vector.Y = _positionY + thick * (float)Math.Cos(v) * (float)Math.Sin(u); // y
                    temp_vector.Z = _positionZ + (_radius-_press) * (float)Math.Sin(v); // z
                    vertices.Add(temp_vector);
                }
            }
        }
    }
}
