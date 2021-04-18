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
    class Window : GameWindow
    {
        Terrain rumah = new Terrain();
        Flower kembang=new Flower();
        Table meja = new Table();
        Tableware piringDkk = new Tableware();
        AC ac = new AC();
        Food makanan = new Food();

        float magnitude;

        protected int count; int fcounter; int gcounter; int acounter;
        protected int rev;


        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            magnitude = 0;
            count = 0; fcounter = 0; gcounter = 0; acounter = 0;
            rev = 0;
        }

        public void rotateAll(float _x,float _y,float _z)
        {
            rumah.rotate(_x, _y, _z);
            kembang.rotate(_x, _y, _z);
            meja.rotate(_x, _y, _z);
            piringDkk.rotate(_x, _y, _z);
            ac.rotate(_x, _y, _z);
            makanan.rotate(_x, _y, _z);
        }
        public void translateAll(float _x, float _y, float _z)
        {
            rumah.translate(_x, _y, _z);
            kembang.translate(_x, _y, _z);
            meja.translate(_x, _y, _z);
            piringDkk.translate(_x, _y, _z);
            ac.translate(_x, _y, _z);
            makanan.translate(_x, _y, _z);
        }

        public void scaleAll(float _scale)
        {
            rumah.scale(_scale);
            kembang.scale(_scale);
            meja.scale(_scale);
            piringDkk.scale(_scale);
            ac.scale(_scale);
            makanan.scale(_scale);
        }
        public void renderAll()
        {
            rumah.render();
            ac.render();
            meja.render();
            kembang.render();
            piringDkk.render();
            makanan.render();
        }

        protected override void OnLoad()
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            rumah.buildObject();
            kembang.buildObject();
            kembang.rotate(0.0f, 180.0f, 0.0f);
            kembang.scale(0.2f);
            kembang.translate(-0.1f, -0.25f, -0.2f);

            meja.buildObject();
            meja.scale(0.4f);
            meja.translate(-0.1f, -0.48f, -0.2f);

            piringDkk.buildObject();
            piringDkk.scale(0.18f);
            piringDkk.translate(-0.1f, -0.365f, -0.35f);

            ac.buildObject();
            ac.scale(0.3f);
            ac.translate(-0.25f, 0.15f, 0.41f);

            makanan.buildObject();
            makanan.scale(0.07f);
            makanan.translate(-0.1f, -0.35f, -0.35f);

            rotateAll(-5.0f, -30.0f, 10.0f);

            ac.fall();

            base.OnLoad();
        }

        protected void animate()
        {
            //shake
            if (rev == 1)
            {
                if (magnitude < 0.005f)
                    magnitude += 0.000008f;
                scaleAll(1.0f + magnitude);
            }
            else
            {
                if (magnitude < 0.005f)
                    magnitude += 0.000008f;
                scaleAll(1.0f - magnitude);
            }

            //magnitude += 0.00005f;
            if (magnitude >= 0.0036f && fcounter < 90)
            {
                kembang.fall(); fcounter++;
            }
            if (magnitude >= 0.0042f && gcounter < 45)
            {
                piringDkk.glassFall(); gcounter++;
            }
            if (magnitude > 0.005f && acounter < 60)
            {
                ac.fall(); acounter++;
            }

            if (acounter >= 60)
                count = 99;
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            if (count == 99)
            { }
            else if (count < 10)
            {
                count++;
                animate();
            }
            else
            {
                if (rev == 0)
                    rev = 1;
                else
                    rev = 0;

                count = 0;
                animate();
            }

            renderAll();

            SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            if (KeyboardState.IsKeyDown(Keys.W))
            {
                rotateAll(0.5f, 0.0f, 0.0f);
            }
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                rotateAll(0.0f, -0.5f, 0.0f);
            }
            if (KeyboardState.IsKeyDown(Keys.S))
            {
                rotateAll(-0.5f, 0.0f, 0.0f);
            }
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                rotateAll(0.0f, 0.5f, 0.0f);
            }

            if (KeyboardState.IsKeyDown(Keys.Up))
            {
                rotateAll(0.0f, 0.0f, -0.5f);
            }
            if (KeyboardState.IsKeyDown(Keys.Down))
            {
                rotateAll(0.0f, 0.0f, 0.5f);
            }

            if (KeyboardState.IsKeyDown(Keys.Right))
            {
                scaleAll(1.01f);
            }
            if (KeyboardState.IsKeyDown(Keys.Left))
            {
                scaleAll(0.99f);
            }

            base.OnUpdateFrame(args);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }
    }
}
