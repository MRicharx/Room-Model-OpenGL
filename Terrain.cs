using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Proyek_UTS_Grafkom
{
    class Terrain
    {
        Cube floor = new Cube();
        Cube wall1 = new Cube();
        Cube wall2 = new Cube();
        private Matrix4 transform;

        public Terrain()
        {
        }

        public void buildObject()
        {
            floor.createBoxVertices(1.0f, 1.0f, 0.02f);
            floor.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/floor.frag");
            floor.translate(0.0f, -0.7f, 0.0f);

            wall1.createBoxVertices(1.0f, 1.0f, 0.02f);
            wall1.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/wall.frag");
            wall1.rotate(-90.0f, 0.0f, 0.0f);
            wall1.translate(0.0f, -0.18f, 0.5f);

            wall2.createBoxVertices(0.5f, 0.5f, 0.02f);
            wall2.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/black.frag");
            wall2.rotate(0.0f, 0.0f, 90.0f);
            wall2.translate(0.5f, 0.0f, 0.0f);

        }
        public void render()
        {
            floor.render();
            wall1.render();
            //wall2.render();
        }
        public void rotate(float _x, float _y, float _z)
        {
            wall1.rotate(_x, _y, _z);
            wall2.rotate(_x, _y, _z);
            floor.rotate(_x, _y, _z);
        }
        public void translate(float _x, float _y, float _z)
        {
            wall1.translate(_x, _y, _z);
            wall2.translate(_x, _y, _z);
            floor.translate(_x, _y, _z);
        }
        public void scale(float _scale)
        {
            wall1.scale(_scale);
            wall2.scale(_scale);
            floor.scale(_scale);
        }
    }
}
