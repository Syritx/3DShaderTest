using System;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;

using OpenTK.Graphics.OpenGL;

namespace _3d
{
    class Program
    {
        static void Main(string[] args)
        {
            NativeWindowSettings nws = new NativeWindowSettings() {
                Title = "Hello",
                Size = new Vector2i(1000,720),
                StartFocused = true,
                StartVisible = true,
                APIVersion = new Version(3,2),
                Flags = ContextFlags.ForwardCompatible,
                Profile = ContextProfile.Core,
            };
            GameWindowSettings gws = new GameWindowSettings();
            new Game(gws,nws);
        }
    }

    class Game : GameWindow {

        Tile tile;
        Camera camera;
        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings,nativeWindowSettings) {
            Run();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            tile.Render();
            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Size.X, e.Size.Y);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.End();
            base.OnResize(e);
        }

        protected override void OnLoad()
        {
            camera = new Camera(this);
            tile = new Tile(camera);
            base.OnLoad();
            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(0,0,0,1.0f);
        }
    }
}
