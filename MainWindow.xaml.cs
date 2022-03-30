using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpGL;
using SharpGL.WPF;

namespace MinecraftSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Camera cam;
        private World world;

        public MainWindow()
        {
            Height = 450;
            Width = 800;

            cam = new Camera();

            InitializeComponent();
            world = new World();
        }

        private void sharpControl_OpenGLInitialized(object sender, OpenGLRoutedEventArgs args)
        {
            //  Get the OpenGL object.
            OpenGL gl = sharpControl.OpenGL;

            //  Set the clear color.
            gl.ClearColor(0, 0, 0, 0);
        }

        private void sharpControl_Resized(object sender, OpenGLRoutedEventArgs args)
        {
            //  Get the OpenGL object.
            OpenGL gl = sharpControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(80.0f, (double)Width / (double)Height, 0.01f, 100.0f);

            //  Use the 'look at' helper function to position and aim the camera.
            gl.LookAt(2, 2, 2, 0, 0, 0, 0, 1, 0);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void sharpControl_OpenGLDraw(object sender, OpenGLRoutedEventArgs args)
        {
            cam.Update();

            //  Get the OpenGL object.
            OpenGL gl = sharpControl.OpenGL;

            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.LoadIdentity();
            //gl.Rotate();
            //gl.Translate(cam.pos.X, -cam.pos.Y, cam.pos.Z);

            //  Draw a coloured pyramid.
            gl.Begin(SharpGL.Enumerations.BeginMode.Quads);

            gl.Color(1f, 0f, 0f);
            gl.Vertex(0f, 0f, 0f);
            gl.Vertex(1f, 0f, 0f);
            gl.Vertex(1f, 1f, 0f);
            gl.Vertex(0f, 1f, 0f);

            gl.Color(0f, 0f, 1f);
            gl.Vertex(0f, 0f, 0f);
            gl.Vertex(0f, 0f, 1f);
            gl.Vertex(0f, 1f, 1f);
            gl.Vertex(0f, 1f, 0f);

            gl.Color(0f, 1f, 0f);
            gl.Vertex(0f, 0f, 0f);
            gl.Vertex(1f, 0f, 0f);
            gl.Vertex(1f, 0f, 1f);
            gl.Vertex(0f, 0f, 1f);

            gl.End();

            gl.Begin(SharpGL.Enumerations.BeginMode.Lines);

            gl.Color(0, 0, 0);
            gl.Vertex(0, 0, 0);

            gl.Color(0f, 1f, 1f);
            gl.Vertex(0, 0, 3);

            gl.Color(0, 0, 0);
            gl.Vertex(0, 0, 0);

            gl.Color(1f, 0f, 1f);
            gl.Vertex(0, 3, 0);

            gl.Color(0, 0, 0);
            gl.Vertex(0, 0, 0);

            gl.Color(1f, 1f, 0f);
            gl.Vertex(3, 0, 0);

            gl.End();

            gl.Flush();
        }

        private void ClearView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E)
            {
                cam.LookRight();
            }

            if (e.Key == Key.Q)
            {
                cam.LookLeft();
            }

            if (e.Key == Key.W)
            {
                cam.MoveForward();
            }

            if (e.Key == Key.S)
            {
                cam.MoveBackward();
            }

            if (e.Key == Key.D)
            {
                cam.MoveRight();
            }

            if (e.Key == Key.A)
            {
                cam.MoveLeft();
            }

            if (e.Key == Key.Space)
            {
                cam.MoveUp();
            }

            if (e.Key == Key.LeftShift)
            {
                cam.MoveDown();
            }
        }
    }
}
