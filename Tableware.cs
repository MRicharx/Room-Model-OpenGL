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
    class Tableware
    {
        //sendok
        Tube batangsendok = new Tube();
        Ellipsoid sendok = new Ellipsoid();

        //garpu
        Tube[] batanggarpu = new Tube[4];
        //Cube kotakgarpu = new Cube();
        Cone kotakgarpu = new Cone();

        //piring
        Cone bawahpiring = new Cone();
        Cone tengahpiring = new Cone();

        //gelas
        Cone gelasatas = new Cone();
        Tube batanggelas = new Tube();
        Ellipsoid bawahgelas = new Ellipsoid();

        //sedotan
        TubeBranch sedotan = new TubeBranch();


        private Matrix4 transform;
        public Tableware()
        {
        }

        public void buildObject()
        {
            //sendok
            batangsendok.setLength(0.155f);
            batangsendok.createTubeVertices(0.015f, 0.015f);
            batangsendok.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");
            batangsendok.rotate(90.0f, 0.0f, 0.0f);
            batangsendok.translate(-0.015f, -0.13f, 0.0f);


            sendok.createEllipsVertices(0.12f, 0.02f, 0.05f);
            sendok.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");
            sendok.rotate(0.0f, 0.0f, -90.0f); sendok.translate(0.0f, 0.2f, 0.0f);

            batangsendok.addChild(sendok);

            //garpu
            for (int i = 0; i < 4; i++)
            {
                batanggarpu[i] = new Tube();
                if (i == 0)
                {
                    batanggarpu[i].setLength(0.185f);
                    batanggarpu[i].createTubeVertices(0.02f, 0.015f);
                    batanggarpu[i].setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");
                    batanggarpu[i].rotate(90.0f, 0.0f, 0.0f);
                    batanggarpu[i].translate(0.0f, -0.2f, 0.0f);
                }
                else if (i == 1)
                {
                    batanggarpu[i].setLength(0.065f);
                    batanggarpu[i].createTubeVertices(0.015f, 0.015f);
                    batanggarpu[i].setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");
                    batanggarpu[i].rotate(90.0f, 0.0f, 0.0f);
                    batanggarpu[i].translate(-0.1f, 0.3f, 0.0f);
                }
                else if (i == 2)
                {
                    batanggarpu[i].setLength(0.065f);
                    batanggarpu[i].createTubeVertices(0.015f, 0.015f);
                    batanggarpu[i].setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");
                    batanggarpu[i].rotate(90.0f, 0.0f, 0.0f);
                    batanggarpu[i].translate(0.0f, 0.3f, 0.0f);
                }
                else if (i == 3)
                {
                    batanggarpu[i].setLength(0.065f);
                    batanggarpu[i].createTubeVertices(0.015f, 0.015f);
                    batanggarpu[i].setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");
                    batanggarpu[i].rotate(90.0f, 0.0f, 0.0f);
                    batanggarpu[i].translate(0.1f, 0.3f, 0.0f);
                }
            }
            //kotakgarpu.setStartPoint(0.0f, 0.175f, 0.0f);
            kotakgarpu.createConeVertices(0.0760f, 0.015f, 0.06f);
            kotakgarpu.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");
            kotakgarpu.rotate(-90.0f, 0.0f, 0.0f);
            kotakgarpu.translate(0.0f, 0.05f, 0.0f);
            for (int i = 0; i < 4; i++)
            {
                kotakgarpu.addChild(batanggarpu[i]);
            }

            //piring
            tengahpiring.createConeVertices(0.225f, 0.225f, 0.04f);
            tengahpiring.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/putik.frag");
            tengahpiring.rotate(0.0f, 0.0f, 0.0f);
            tengahpiring.translate(0.0f, 0.0f, 0.005f);

            bawahpiring.createConeVertices(0.3f, 0.3f, 0.06f);
            bawahpiring.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/black.frag");
            bawahpiring.addChild(tengahpiring);

            //gelas
            gelasatas.createConeVertices(0.125f, 0.125f, 0.15f);
            gelasatas.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");
            gelasatas.rotate(270.0f, 0.0f, 0.0f);
            gelasatas.translate(0.0f, 0.0f, 0.0f);

            batanggelas.setLength(0.085f);
            batanggelas.createTubeVertices(0.015f, 0.015f);
            batanggelas.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");
            batanggelas.rotate(90.0f, 0.0f, 0.0f);
            batanggelas.translate(0.0f, -0.11f, 0.0f);

            bawahgelas.createEllipsVertices(0.1f, 0.01f);
            bawahgelas.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");
            bawahgelas.rotate(0.5f, 0.0f, 0.0f);
            bawahgelas.translate(0.0f, -0.25f, 0.0f);

            gelasatas.addChild(batanggelas);
            gelasatas.addChild(bawahgelas);

            //sedotan
            sedotan.addPoint(0.0f, 0.0f, 0.0f);
            sedotan.addPoint(0.225f, 0.9f, 0.0f);
            sedotan.addPoint(0.4f, 0.55f, 0.0f);
            sedotan.createbezierVertices(0.01f,0.01f,0.006f);
            sedotan.setupObject("C:/Users/Asus/source/repos/shader/shader.vert",
                "C:/Users/Asus/source/repos/shader/white.frag");

            bawahpiring.rotate(-90.0f, 0.0f, 0.0f);
            gelasatas.translate(0.72f, 0.27f, 0.3f);
            kotakgarpu.rotate(90.0f, 0.0f, 0.0f); kotakgarpu.scale(0.75f); kotakgarpu.translate(-0.72f, 0.05f, 0.0f);
            batangsendok.rotate(90.0f, 90.0f, 0.0f); batangsendok.translate(-0.96f, 0.05f, 0.0f);
            sedotan.translate(0.72f, 0.27f, 0.3f);
        }
        public void render()
        {
            batangsendok.render(1);
            kotakgarpu.render();
            bawahpiring.render(1);
            sedotan.render();
            gelasatas.render();
        }
        public void rotate(float _x, float _y, float _z)
        {
            batangsendok.rotate(_x,_y,_z);
            kotakgarpu.rotate(_x, _y, _z);
            bawahpiring.rotate(_x, _y, _z);
            gelasatas.rotate(_x, _y, _z);
            sedotan.rotate(_x, _y, _z);
        }
        public void translate(float _x, float _y, float _z)
        {
            batangsendok.translate(_x, _y, _z);
            kotakgarpu.translate(_x, _y, _z);
            bawahpiring.translate(_x, _y, _z);
            gelasatas.translate(_x, _y, _z);
            sedotan.translate(_x, _y, _z);
        }
        public void scale(float _scale)
        {
            batangsendok.scale(_scale);
            kotakgarpu.scale(_scale);
            bawahpiring.scale(_scale);
            gelasatas.scale(_scale);
            sedotan.scale(_scale);
        }

        public void glassFall()
        {
            //gelasatas.rotate(0.0f, 0.0f, -90.0f);
            //gelasatas.translate(0.6f, -0.14f, -0.0f);

            gelasatas.rotate(0.0f, 0.0f, -2.0f);
            gelasatas.translate(0.0225f, 0.01f, 0.005f);

            sedotan.rotate(0.0f, 0.01f, -2.0f);
            sedotan.translate(0.0225f, 0.01f, 0.009f);
        }
    }
}
