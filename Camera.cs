using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

namespace _3d {

    class Camera {

        public Vector3 position = new Vector3(0,0,20),
                       lookEye = new Vector3(0,0, -20),
                       up = new Vector3(0,1,0);

        Game game;

        public Camera(Game game) {
            this.game = game;
            game.UpdateFrame += Update;
        }

        void Update(FrameEventArgs e) {

        }
    }
}