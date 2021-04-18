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
    class Food
    {
        Ellipsoid daging = new Ellipsoid();
        Tube tulang = new Tube();
        Ellipsoid tulangrawan1 = new Ellipsoid();
        Ellipsoid tulangrawan2 = new Ellipsoid();
        Cube tahu = new Cube();
        //Cube tahu1 = new Cube();
        Tube putih = new Tube();
        Ellipsoid kuning = new Ellipsoid();
        Branch asap = new Branch();
        Branch asap1 = new Branch();
        Branch asap2 = new Branch();

        private Matrix4 transform;

        public void buildObject()
        {
            tulang.setStartPoint(-0.5f, 0.2f, 0.0f);
            tulang.setLength(0.27f);
            tulang.createTubeVertices(0.07f, 0.07f);
            tulang.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");

            daging.setStartPoint(-0.5f, 0.2f, 0.4f);
            daging.createEllipsVertices(0.3f, 0.3f, -0.12f);
            daging.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/daging.frag");

            tulangrawan1.setStartPoint(-0.55f, 0.2f, -0.4f);
            tulangrawan1.createEllipsVertices(0.09f, 0.09f, 0f);
            tulangrawan1.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");

            tulangrawan2.setStartPoint(-0.45f, 0.2f, -0.4f);
            tulangrawan2.createEllipsVertices(0.09f, 0.09f, 0f);
            tulangrawan2.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");

            tahu.setStartPoint(0.2f, 0.0f, 0.7f);
            tahu.createBoxVertices(0.2f, 0.3f, 0.1f);
            tahu.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/kuning.frag");

            kuning.setStartPoint(0.3f, 0f, 0f);
            kuning.createEllipsVertices(0.2f, 0.1f, 0.02f);
            kuning.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/kuning.frag");

            putih.setStartPoint(0.3f, 0f, 0f);
            putih.setLength(0.02f);
            putih.createTubeVertices(0.5f, 0.5f);
            putih.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");
            putih.rotate(90f, 0f, 0f);

            asap.addPoint(-0.1f, 0f, 0f);
            asap.addPoint(0.3f, 0.2f, 0f);
            asap.addPoint(-0.5f, 0.4f, 0f);
            asap.addPoint(0.2f, 0.5f, 0f);
            asap.createbezierVertices();
            asap.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/grey.frag");
            asap.translate(0.1f, 0.3f, 0.3f);

            asap1.addPoint(-0.1f, 0f, 0f);
            asap1.addPoint(0.3f, 0.2f, 0f);
            asap1.addPoint(-0.5f, 0.4f, 0f);
            asap1.addPoint(0.2f, 0.53f, 0f);
            asap1.createbezierVertices();
            asap1.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/grey.frag");
            asap1.translate(0f, 0.3f, 0.3f);

            asap2.addPoint(-0.1f, 0f, 0f);
            asap2.addPoint(0.3f, 0.2f, 0f);
            asap2.addPoint(-0.5f, 0.4f, 0f);
            asap2.addPoint(0.2f, 0.56f, 0f);
            asap2.createbezierVertices();
            asap2.setupObject("C:/Users/Asus/source/repos/shader/trans.vert",
                "C:/Users/Asus/source/repos/shader/grey.frag");
            asap2.translate(-0.1f, 0.3f, 0.3f);
        }
        public void render()
        {
            tulang.render(1);
            daging.render(1);
            tulangrawan1.render(1);
            tulangrawan2.render(1);
            tahu.render();
            putih.render(1);
            kuning.render(1);
            asap.render();
            asap1.render();
            asap2.render();
        }
        public void rotate(float _x, float _y, float _z)
        {
            tulang.rotate(_x, _y, _z);
            daging.rotate(_x, _y, _z);
            tulangrawan1.rotate(_x, _y, _z);
            tulangrawan2.rotate(_x, _y, _z);
            tahu.rotate(_x, _y, _z);
            putih.rotate(_x, _y, _z);
            kuning.rotate(_x, _y, _z);
            asap.rotate(_x, _y, _z);
            asap1.rotate(_x, _y, _z);
            asap2.rotate(_x, _y, _z);
        }
        public void translate(float _x, float _y, float _z)
        {
            tulang.translate(_x, _y, _z);
            daging.translate(_x, _y, _z);
            tulangrawan1.translate(_x, _y, _z);
            tulangrawan2.translate(_x, _y, _z);
            tahu.translate(_x, _y, _z);
            putih.translate(_x, _y, _z);
            kuning.translate(_x, _y, _z);
            asap.translate(_x, _y, _z);
            asap1.translate(_x, _y, _z);
            asap2.translate(_x, _y, _z);
        }
        public void scale(float _scale)
        {
            tulang.scale(_scale);
            daging.scale(_scale);
            tulangrawan1.scale(_scale);
            tulangrawan2.scale(_scale);
            tahu.scale(_scale);
            putih.scale(_scale);
            kuning.scale(_scale);
            asap.scale(_scale);
            asap1.scale(_scale);
            asap2.scale(_scale);
        }
    }
}
