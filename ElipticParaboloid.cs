using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Proyek_UTS_Grafkom
{
    class ElipticParaboloid : Mesh
    {
        public ElipticParaboloid()
        {

        }
        public void createElipticParaboloidVertices(float x, float y, float tinggi)
        {
            float _positionX = startPoint.X;
            float _positionY = startPoint.Y;
            float _positionZ = startPoint.Z;

            float _radiusx = x;
            float _radiusy = y;
            float _radiusz = tinggi;
            float _pi = 3.14159f;
            //buat temporary vector
            Vector3 temp_vector;

            for (float u = -_pi; u < _pi; u += _pi / 50)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 50)
                {
                    temp_vector.X = _positionX + _radiusx * v * (float)Math.Cos(u); // x
                    temp_vector.Y = _positionY + _radiusy * v * (float)Math.Sin(u); // y
                    temp_vector.Z = _positionZ + _radiusz * v * v; // z
                    vertices.Add(temp_vector);
                }
            }
        }
    }
}
