using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;

namespace Proyek_UTS_Grafkom
{
    class DualHyperboloid:Mesh
    {
        public DualHyperboloid()
        {

        }

        public void createDualHyperVertices(float _radiusX,float _radiusY,float _radiusZ)
        {
            float _positionX = startPoint.X;
            float _positionY = startPoint.Y;
            float _positionZ = startPoint.Z;
            Vector3 temp_vector;

            float _pi = 3.14159f;

            for (float u = -_pi / 2; u < _pi / 2; u += _pi / 30)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                {
                    temp_vector.X = (float)Math.Tan(v) * (float)Math.Cos(u) * _radiusX + _positionX;
                    temp_vector.Y = (float)Math.Tan(v) * (float)Math.Sin(u) * _radiusY + _positionY;
                    temp_vector.Z = (1.0f / (float)Math.Cos(v)) * _radiusZ + _positionZ;
                    vertices.Add(temp_vector);
                }
            }

            for (float u = -_pi / 2; u <_pi/2; u += _pi / 30)
            {
                for (float v = _pi / 2; v < 3 * _pi / 2; v += _pi / 30)
                {
                    temp_vector.X = (float)Math.Tan(v) * (float)Math.Cos(u) * _radiusX + _positionX;
                    temp_vector.Y = (float)Math.Tan(v) * (float)Math.Sin(u) * _radiusY + _positionY;
                    temp_vector.Z = (1.0f / (float)Math.Cos(v)) * _radiusZ + _positionZ;
                    vertices.Add(temp_vector);
                }
            }
        }
    }
}
