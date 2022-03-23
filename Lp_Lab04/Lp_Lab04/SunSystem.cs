using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Lp_Lab01;

namespace Lp_Lab04
{
    public class SunSystem
    {
        private readonly PictureBox _pictureBox;
        private readonly List<Ellipse> sunSystemObjects;
        private readonly Sun sun;
        private readonly Earth _earth;
        private Mars _mars;
        private Moon _moon;
        private Orbit _orbitEarth;
        private Orbit _orbitMars;
        private MovingOrbit _orbitMoon;

        private Point Center { get; set; }

        public SunSystem(PictureBox pictureBox)
        {
            // 450 250
            int rSun = 30;
            int rEarth = 20;
            int rMoon = 10;
            int rMars = 15;
            int OrbRadiusEarth = 10 * rSun; // 300
            int OrbRadiusMoon = 3 * rEarth; // 100
            int OrbRadiusMars = 6 * rSun; //180
            sun = new Sun(435, 235, rSun);
            _orbitEarth = new Orbit(OrbRadiusEarth, OrbRadiusEarth + 100, OrbRadiusEarth);
            _orbitMars = new Orbit(450 - 90, 250 + 90, OrbRadiusMars);
            _orbitMoon = new MovingOrbit(450 + OrbRadiusEarth / 2 - 29, 250 + 39, OrbRadiusMoon, 5, _orbitEarth);
            _earth = new Earth(450 + OrbRadiusEarth / 2 - 8, 250, 20, _orbitEarth, Color.Green);
            _mars = new Mars(450 + OrbRadiusMars / 2 - 8, 250, rMars, _orbitMars, Color.Brown);
            _moon = new Moon(450 + OrbRadiusEarth / 2 + OrbRadiusMoon / 2 - 3, _earth.Y0, 8, _orbitMoon, _earth,
                Color.Gray);
            sunSystemObjects = new List<Ellipse>()
            {
                _orbitEarth,
                _orbitMars,
                _orbitMoon,
                sun,
                _earth,
                _mars,
                _moon
            };
            _pictureBox = pictureBox;
            //Drawing();
        }

        public void Drawing()
        {
            foreach (var systemObject in sunSystemObjects)
            {
                systemObject.Drawing(_pictureBox);
            }
        }

        public void StartDrawing(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            foreach (var systemObject in sunSystemObjects)
            {
                systemObject.StartDrawing(gr);
            }
        }
    }


    public abstract class Ellipse
    {
        public int Radius { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Fi { get; set; }
        public int Speed { get; set; }
        public Rectangle Rectangle;

        public Ellipse(int x, int y, int radius)
        {
            Radius = radius;
            X = x;
            Y = y;
            Rectangle = new Rectangle(X, Y, Radius, Radius);
        }


        public abstract void Drawing(PictureBox pictureBox);

        public virtual void StartDrawing(Graphics e)
        {
            e.DrawEllipse(new Pen(Color.Black), Rectangle);
        }
    }

    public class Orbit : Ellipse
    {
        public Orbit(int x, int y, int radius) : base(x, y, radius)
        {
            Rectangle = new Rectangle(X, Y, Radius, -Radius);
        }


        public override void Drawing(PictureBox pictureBox)
        {
            pictureBox.CreateGraphics().DrawEllipse(new Pen(Color.Black), Rectangle);
        }
    }

    public class
        MovingOrbit : Orbit // не работает пока что добавить в орбиту планету которая крутится и вызавать в drawing planet.drawing
    {
        private CMatrix coords = new CMatrix();
        public int X0;
        public int Y0;
        private Orbit _orbit;

        public MovingOrbit(int x, int y, int radius, int speed, Orbit orbit) : base(x, y, radius)
        {
            Speed = speed;
            X0 = 450;
            Y0 = 250;
            _orbit = orbit;
            coords.RedimMatrix(3);
        }

        private void SetNewCoords(Orbit orbit)
        {
            int radius = (orbit.Rectangle.Right - orbit.Rectangle.Left) / 2;
            double ff = (Fi / 180) * Math.PI;
            double x = X0 + radius * Math.Cos(ff);
            double y = Y0 + radius * Math.Sin(ff);
            coords[0] = x - 29;
            coords[1] = y + 35;
            coords[2] = 1;
            Fi += Speed * 0.1;
            Rectangle.X = (int)coords[0];
            Rectangle.Y = (int)coords[1];
        }

        public override void Drawing(PictureBox pictureBox)
        {
            SetNewCoords(_orbit);
            pictureBox.CreateGraphics().DrawEllipse(new Pen(Color.Black), Rectangle);
        }
    }

    public class Sun : Ellipse
    {
        private Pen _pen = new Pen(Color.Red);

        public Sun(int x, int y, int radius) : base(x, y, radius)
        {
        }


        public override void Drawing(PictureBox pictureBox)
        {
            pictureBox.CreateGraphics().FillEllipse(new SolidBrush(Color.Yellow), Rectangle);
        }

        public override void StartDrawing(Graphics e)
        {
            e.FillEllipse(new SolidBrush(Color.Yellow), Rectangle);
        }
    }

    public abstract class Planet : Ellipse
    {
        public CMatrix coords = new CMatrix();
        public Orbit Orbit;
        public int X0;
        public int Y0;
        public Color Color { get; set; }

        protected Planet(int x, int y, int radius, Orbit orbit, Color color) : base(x, y, radius)
        {
            coords.RedimMatrix(3);
            Speed = 5;
            Orbit = orbit;
            X0 = Orbit.Rectangle.X + Orbit.Rectangle.Width / 2;
            Y0 = Orbit.Rectangle.Y + Orbit.Rectangle.Height / 2;
            Color = color;
        }

        protected void SetNewCoords(Orbit orbit)
        {
            int radius = (orbit.Rectangle.Right - orbit.Rectangle.Left) / 2;
            double ff = (Fi / 180) * Math.PI;
            double x = X0 + radius * Math.Cos(ff) - 15 / 2;
            double y = Y0 + radius * Math.Sin(ff) - 15 / 2;
            coords[0] = x;
            coords[1] = y;
            coords[2] = 1;
            Fi += Speed * 0.1;
            Rectangle.X = (int)coords[0];
            Rectangle.Y = (int)coords[1];
        }

        public override void Drawing(PictureBox pictureBox)
        {
            SetNewCoords(Orbit);
            pictureBox.CreateGraphics().FillEllipse(new SolidBrush(Color), Rectangle);
        }

        public override void StartDrawing(Graphics e)
        {
            e.FillEllipse(new SolidBrush(Color), Rectangle);
        }
    }

    public class Earth : Planet
    {
        public Earth(int x, int y, int radius, Orbit orbit, Color color) : base(x, y, radius, orbit, color)
        {
            Speed = 5;
        }
    }

    public class Mars : Planet
    {
        public Mars(int x, int y, int radius, Orbit orbit, Color color) : base(x, y, radius, orbit, color)
        {
            Speed = 3;
        }
    }

    public class Moon : Planet
    {
        private Planet _planet;

        public Moon(int x, int y, int radius, Orbit orbit, Planet planet, Color color) : base(x, y, radius, orbit,
            color)
        {
            Speed = 15;
            _planet = planet;
        }

        private new void SetNewCoords(Orbit orbit)
        {
            int radius = (orbit.Rectangle.Right - orbit.Rectangle.Left) / 2;
            double ff = (Fi / 180) * Math.PI;
            double x = _planet.coords[0] + radius * Math.Cos(ff) + 3;
            double y = _planet.coords[1] + radius * Math.Sin(ff) + 6;
            coords[0] = x;
            coords[1] = y;
            coords[2] = 1;
            Fi += Speed * 0.1;
            Rectangle.X = (int)coords[0];
            Rectangle.Y = (int)coords[1];
        }

        public override void Drawing(PictureBox pictureBox)
        {
            SetNewCoords(Orbit);
            pictureBox.CreateGraphics().FillEllipse(new SolidBrush(Color), Rectangle);
        }
    }
}