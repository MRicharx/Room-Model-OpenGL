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
    class Table
    {
        Tube meja = new Tube();
        Cube balok1 = new Cube();
        Cube balok2 = new Cube();
        Cube balok3 = new Cube();
        Cube balok4 = new Cube();

        ElipticParaboloid eliptic1 = new ElipticParaboloid();
        ElipticParaboloid eliptic2 = new ElipticParaboloid();
        ElipticParaboloid eliptic3 = new ElipticParaboloid();
        ElipticParaboloid eliptic4 = new ElipticParaboloid();

        Ellipsoid elip = new Ellipsoid();
        private Matrix4 transform;

        public Table()
        {
        }

        public void buildObject()
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            meja.setStartPoint(0.0f, 0.0f, -0.25f);
            meja.setLength(0.03f);
            meja.createTubeVertices(0.8f, 0.8f);
            meja.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/shader_tumpuan.frag");
            meja.rotate(90.0f, 0.0f, 0.0f);

            balok1.setStartPoint(-0.5f, -0.27f, 0.0f);
            balok1.createBoxVertices(0.1f, 0.1f, 0.5f);
            balok1.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/pot.frag");

            balok2.setStartPoint(0.5f, -0.27f, 0.0f);
            balok2.createBoxVertices(0.1f, 0.1f, 0.5f);
            balok2.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/pot.frag");

            balok3.setStartPoint(0.0f, -0.27f, 0.5f);
            balok3.createBoxVertices(0.1f, 0.1f, 0.5f);
            balok3.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/pot.frag");

            balok4.setStartPoint(0.0f, -0.27f, -0.5f);
            balok4.createBoxVertices(0.1f, 0.1f, 0.5f);
            balok4.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/pot.frag");

            eliptic1.setStartPoint(-0.5f, 0.09f, 0.09f);
            eliptic1.createElipticParaboloidVertices(0.05f, 0.05f, 0.05f);
            eliptic1.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/shader_tumpukecil.frag");
            eliptic1.rotate(270.0f, 0.0f, 10.0f);

            eliptic2.setStartPoint(0.5f, -0.09f, 0.09f);
            eliptic2.createElipticParaboloidVertices(0.05f, 0.05f, 0.05f);
            eliptic2.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/shader_tumpukecil.frag");
            eliptic2.rotate(270.0f, 0.0f, 10.0f);

            eliptic3.setStartPoint(0.09f, 0.5f, 0.09f);
            eliptic3.createElipticParaboloidVertices(0.05f, 0.05f, 0.05f);
            eliptic3.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/shader_tumpukecil.frag");
            eliptic3.rotate(270.0f, 0.0f, 10.0f);

            eliptic4.setStartPoint(-0.09f, -0.5f, 0.09f);
            eliptic4.createElipticParaboloidVertices(0.05f, 0.05f, 0.05f);
            eliptic4.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/shader_tumpukecil.frag");
            eliptic4.rotate(270.0f, 0.0f, 10.0f);

            elip.setStartPoint(0.0f, 0.03f, 0.0f);
            elip.createEllipsVertices(0.7f, 0.1f, 0.1f);
            elip.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/shader_tumpuan.frag");

        }
        public void render()
        {
            meja.render(1);

            balok1.render(0);
            balok2.render(0);
            balok3.render(0);
            balok4.render(0);

            eliptic1.render(0);
            eliptic2.render(0);
            eliptic3.render(0);
            eliptic4.render(0);

            elip.render(0);
        }
        public void rotate(float _x, float _y, float _z)
        {
            meja.rotate(_x, _y, _z);
            balok1.rotate(_x, _y, _z);
            balok2.rotate(_x, _y, _z);
            balok3.rotate(_x, _y, _z);
            balok4.rotate(_x, _y, _z);
            eliptic1.rotate(_x, _y, _z);
            eliptic2.rotate(_x, _y, _z);
            eliptic3.rotate(_x, _y, _z);
            eliptic4.rotate(_x, _y, _z);
            elip.rotate(_x, _y, _z);
        }
        public void translate(float _x, float _y, float _z)
        {
            meja.translate(_x, _y, _z);
            balok1.translate(_x, _y, _z);
            balok2.translate(_x, _y, _z);
            balok3.translate(_x, _y, _z);
            balok4.translate(_x, _y, _z);
            eliptic1.translate(_x, _y, _z);
            eliptic2.translate(_x, _y, _z);
            eliptic3.translate(_x, _y, _z);
            eliptic4.translate(_x, _y, _z);
            elip.translate(_x, _y, _z);
        }
        public void scale(float _scale)
        {
            meja.scale(_scale);
            balok1.scale(_scale);
            balok2.scale(_scale);
            balok3.scale(_scale);
            balok4.scale(_scale);
            eliptic1.scale(_scale);
            eliptic2.scale(_scale);
            eliptic3.scale(_scale);
            eliptic4.scale(_scale);
            elip.scale(_scale);
        }
    }
}
