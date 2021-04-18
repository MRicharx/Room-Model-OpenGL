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
    class AC
    {
        Cube ac = new Cube();
        Cube bolongan = new Cube();

        TubeBranch bezier = new TubeBranch();

        public void buildObject()
        {
            ac.createBoxVertices(0.55f, 1.05f, 0.55f);
            ac.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/shader_tumpuan.frag");

            bolongan.setStartPoint(0.0f, -0.15f, -0.3f);
            bolongan.createBoxVertices(0.0f, 0.7f, 0.07f);
            bolongan.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/black.frag");

            bezier.addPoint(0.0f, -0.1f, 0.0f);
            bezier.addPoint(-0.2f, 0.6f, 0.0f);
            bezier.addPoint(0.5f, 0.28f, 0.0f);
            bezier.createbezierVertices(0.01f,0.01f,0.33f);
            bezier.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/grey.frag");
            bezier.rotate(0.0f, 270.0f, 0.0f);
            bezier.translate(0.0f, 0.0f, -0.3f);
        }
        public void render()
        {
            ac.render();
            bolongan.render();
            bezier.render();
        }
        public void rotate(float _x, float _y, float _z)
        {
            ac.rotate(_x, _y, _z);
            bolongan.rotate(_x, _y, _z);
            bezier.rotate(_x, _y, _z);
        }
        public void translate(float _x, float _y, float _z)
        {
            ac.translate(_x, _y, _z);
            bolongan.translate(_x, _y, _z);
            bezier.translate(_x, _y, _z);
        }
        public void scale(float _scale)
        {
            ac.scale(_scale);
            bolongan.scale(_scale);
            bezier.scale(_scale);
        }
        public void fall()
        {
            //rotate(0.0f, 0.0f, 40.0f);
            //translate(0.0f, -0.35f, 0.0f);

            rotate(-0.6f, 0.2f, 1.1f);
            translate(-0.002f, -0.006f, -0.001f);
        }

    }
}
