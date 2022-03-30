using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace OpenGLTesting
{
    class Camera
    {
        public Vector3D look = new Vector3D(1,0,0);
        public Vector3D pos = new Vector3D(0, 0, 0);
        private Vector3D vel = new Vector3D(0, 0, 0);

        private const float Rotate_Deg = 0.1f;
        private readonly Vector3D Max_Vel = new Vector3D(5, 4, 5);
        private readonly float Rotate_X = (float)Math.Cos(Rotate_Deg);
        private readonly float Rotate_Y = (float)Math.Sin(Rotate_Deg);
        private readonly float Rotate_X_Neg = (float)Math.Cos(-Rotate_Deg);
        private readonly float Rotate_Y_Neg = (float)Math.Sin(-Rotate_Deg);
        private readonly Vector3D Vert_Accel = new Vector3D(0, 0.1, 0);
        private readonly Vector3D Strafe_Accel = new Vector3D(0.05, 0, 0);
        private readonly Vector3D Walk_Accel = new Vector3D(0, 0, 0.05);

        public Camera()
        {

        }

        public void Update()
        {
            if(vel.LengthSquared > Max_Vel.LengthSquared)
            {
                int sign = (vel.LengthSquared >= 0) ? 1 : -1;
                vel = Max_Vel;
                vel = Vector3D.Multiply(sign, vel);
            }
            pos = Vector3D.Add(pos, vel);
            Vector3D damping = new Vector3D(vel.X, vel.Y, vel.Z);
            damping.Normalize();
            vel = Vector3D.Subtract(vel, damping);
        }

        internal void LookRight()
        {
            double oldX = look.X;
            double oldZ = look.Z;

            look.X = oldX * Math.Cos(Rotate_Deg) - oldZ * Math.Sin(Rotate_Deg);
            look.Z = oldX * Math.Sin(Rotate_Deg) + oldZ * Math.Cos(Rotate_Deg);
        }

        internal void LookLeft()
        {
            double oldX = look.X;
            double oldZ = look.Z;

            look.X = oldX * Math.Cos(-Rotate_Deg) - oldZ * Math.Sin(-Rotate_Deg);
            look.Z = oldX * Math.Sin(-Rotate_Deg) + oldZ * Math.Cos(-Rotate_Deg);
        }

        internal void MoveForward()
        {
            Vector3D forward = new Vector3D(look.X, 0, look.Z);
            forward = Vector3D.Add(forward, Walk_Accel);
            forward.Normalize();
            vel = Vector3D.Add(vel, forward);
        }

        internal void MoveBackward()
        {
            Vector3D backward = new Vector3D(look.X, 0, look.Z);
            backward = Vector3D.Subtract(backward, Walk_Accel);
            backward.Normalize();
            vel = Vector3D.Add(vel, backward);
        }

        internal void MoveRight()
        {
            Vector3D rightward = new Vector3D(look.X, 0, look.Z);
            rightward = Vector3D.Subtract(rightward, Walk_Accel);
            rightward.Normalize();
            vel = Vector3D.Add(vel, rightward);
        }

        internal void MoveLeft()
        {
            throw new NotImplementedException();
        }

        internal void MoveUp()
        {
            pos = Vector3D.Add(pos, Up_Move);
        }

        internal void MoveDown()
        {
            pos = Vector3D.Add(pos, Down_Move);
        }
    }
}
