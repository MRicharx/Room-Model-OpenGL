using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;

namespace Proyek_UTS_Grafkom
{
    class Cone : Mesh
    {
        public Cone()
        {

        }
        public void createConeVertices(float x, float y, float tinggi)
        {
            float _positionX = startPoint.X;
            float _positionY = startPoint.Y;
            float _positionZ = startPoint.Z;

            float _radiusx = x;
            float _radiusy = y;
            float _radiusZ = tinggi;
            float _pi = 3.14159f;
            //buat temporary vector
            Vector3 temp_vector;

            for (float u = -_pi; u < _pi; u += _pi / 160)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 160)
                {
                    temp_vector.X = _positionX + _radiusx * v * (float)Math.Cos(u); // x
                    temp_vector.Y = _positionY + _radiusy * v * (float)Math.Sin(u); // y
                    temp_vector.Z = _positionZ + _radiusZ * v * v; // z
                    vertices.Add(temp_vector);
                }
            }
        }
    }
}