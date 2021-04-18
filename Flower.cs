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
    class Flower
    {
        Cube pot = new Cube();
        Tube batang = new Tube();
        Ellipsoid putik = new Ellipsoid();
        Ellipsoid daun1 = new Ellipsoid(); Ellipsoid daun2 = new Ellipsoid();
        Ellipsoid[] petal = new Ellipsoid[6];
        Branch[] suket = new Branch[3];
        private Matrix4 transform;

        public Flower()
        {
        }

        public void buildObject()
        {
            pot.setStartPoint(0.0f, -0.4f, 0.0f);
            pot.createBoxVertices(0.2f, 0.2f, 0.35f);
            pot.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/pot.frag");

            batang.setLength(0.35f);
            batang.createTubeVertices(0.015f, 0.015f);
            batang.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/hijauDaun.frag");
            batang.rotate(90.0f, 0.0f, 0.0f);
            batang.translate(-0.015f, 0.0f, 0.0f);

            putik.setStartPoint(0.0f, 0.55f, 0.0f);
            putik.createEllipsVertices(0.2f, 0.05f);
            putik.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/putik.frag");
            putik.rotate(40.0f, 0.0f, 0.0f);
            putik.translate(0.0f, 0.15f, -0.35f);

            daun1.setStartPoint(-0.1f, 0.0f, 0.0f);
            daun1.createEllipsVertices(0.12f, 0.01f, 0.04f);
            daun1.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/hijauDaun.frag");
            daun1.rotate(-10.0f, 0.0f, -10.0f); daun1.translate(-0.025f, 0.19f, 0.0f);

            daun2.setStartPoint(0.1f, 0.0f, 0.0f);
            daun2.createEllipsVertices(0.12f, 0.01f, 0.04f);
            daun2.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/hijauDaun.frag");
            daun2.rotate(-10.0f, 0.0f, 10.0f); daun2.translate(0.01f, 0.05f, 0.0f);

            for (int i = 0; i < 6; i++)
            {
                petal[i] = new Ellipsoid();
                petal[i].createEllipsVertices(0.13f, 0.02f);
                petal[i].setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
            "C:/Users/Asus/source/repos/shader/petal.frag");
                petal[i].rotate(90.0f, 0.0f, 0.0f);
                petal[i].translate(0.0f, 0.25f, 0.0f);
                petal[i].rotate(-50.0f, 0.0f, (float)i * 60.0f);
                petal[i].translate(0.0f, 0.55f, 0.0f);
            }

            for (int i = 0; i < 3; i++)
            {
                suket[i] = new Branch();
                suket[i].addPoint(0.0f, 0.0f, 0.0f); suket[i].addPoint(0.15f, 0.2f, 0.0f); suket[i].addPoint(0.4f, 0.27f, 0.0f);
                suket[i].createbezierVertices();
                suket[i].setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/hijauDaun.frag");
            }
            suket[0].rotate(0.0f, 0.0f, 20.0f); suket[0].translate(0.0f, -0.3f, 0.0f);
            suket[1].rotate(0.0f, 130.0f, 45.0f); suket[1].translate(-0.05f, -0.5f, 0.0f);
            suket[2].rotate(0.0f, -60.0f, 30.0f); suket[2].translate(0.0f, -0.4f, 0.0f);
        }
        public void render()
        {
            batang.render();
            for (int i = 0; i < 3; i++)
                suket[i].render();
            pot.render();
            daun1.render(1);
            daun2.render(1);
            for (int i = 0; i < 6; i++)
                petal[i].render(1);
            putik.render(1);
        }
        public void rotate(float _x, float _y, float _z)
        {
            pot.rotate(_x, _y, _z);
            batang.rotate(_x, _y, _z);
            putik.rotate(_x, _y, _z);
            daun1.rotate(_x, _y, _z);
            daun2.rotate(_x, _y, _z);
            for (int i = 0; i < 6; i++)
                petal[i].rotate(_x, _y, _z);
            for (int i = 0; i < 3; i++)
                suket[i].rotate(_x, _y, _z);
        }
        public void translate(float _x, float _y, float _z)
        {
            pot.translate(_x, _y, _z);
            batang.translate(_x, _y, _z);
            putik.translate(_x, _y, _z);
            daun1.translate(_x, _y, _z);
            daun2.translate(_x, _y, _z);
            for (int i = 0; i < 6; i++)
                petal[i].translate(_x, _y, _z);
            for (int i = 0; i < 3; i++)
                suket[i].translate(_x, _y, _z);
        }
        public void scale(float _scale)
        {
            pot.scale(_scale);
            batang.scale(_scale);
            putik.scale(_scale);
            daun1.scale(_scale);
            daun2.scale(_scale);
            for (int i = 0; i < 6; i++)
                petal[i].scale(_scale);
            for (int i = 0; i < 3; i++)
                suket[i].scale(_scale);
        }

        public void fall()
        {
            //kembang.rotate(90.0f, -30.0f, 0.0f);
            //kembang.translate(0.0f, -0.45f, 0.3f);
            rotate(1.0f, 0.03f, 0.0f);
            translate(0.0f,-0.002f,0.0071f);
        }
    }
}
