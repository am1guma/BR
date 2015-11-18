using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRaVO
{
    public partial class Form1 : Form
    {
        private List<Point> points = new List<Point>();
        private List<Shape> shapes = new List<Shape>();
        private List<Shape> newLines = new List<Shape>();
        int so = 0;
        int ss = 0;
        Graphics g;
        string id = "b0";
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (id == "b1")
            {
                if (e.Button.Equals(MouseButtons.Left))
                {
                    points.Add(new Point(e.X, e.Y));
                    g.DrawRectangle(new Pen(Color.Black), e.X - 2, e.Y - 2, 4, 4);
                    if (points.Count > 1)
                        g.DrawLine(new Pen(Color.Black), points.ElementAt(points.Count - 1), points.ElementAt(points.Count - 2));
                }
                else
                if (points.Count > 2)
                {
                    g.DrawLine(new Pen(Color.Black), points.ElementAt(points.Count - 1), points.ElementAt(0));
                    if(so>0)
                        g.FillPolygon(new SolidBrush(Color.Black), points.ToArray());
                    Shape shape = new Shape();
                    shape.P = points;
                    shapes.Add(shape);
                    points = new List<Point>();
                    so++;
                }
            }
            if (id == "b2")
                if (ss<2)
                {
                    if (ss == 0)
                        g.FillEllipse(new SolidBrush(Color.Green), e.X - 6, e.Y - 6, 12, 12);
                    else if (ss == 1)
                        g.FillEllipse(new SolidBrush(Color.Red), e.X - 6, e.Y - 6, 12, 12);
                    ss++;
                }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            id = "b1";
            b1.Checked = true;
            b2.Checked = false;
            b3.Checked = false;
            b4.Checked = false;
            b5.Checked = false;
        }

        private void b2_Click(object sender, EventArgs e)
        {
            id = "b2";
            b2.Checked = true;
            b1.Checked = false;
            b3.Checked = false;
            b4.Checked = false;
            b5.Checked = false;
        }

        private void b3_Click(object sender, EventArgs e)
        {
            id = "b3";
            b3.Checked = true;
            b1.Checked = false;
            b2.Checked = false;
            b4.Checked = false;
            b5.Checked = false;
            for (int j = 1; j < shapes.Count(); j++)
            {
                for (int i = 0; i < shapes[j].P.Count; i++)
                {
                    for (int m = 0; m < shapes.Count(); m++)
                    {
                        for (int k = 0; k < shapes[m].P.Count; k++)
                        {
                            if (m != j)
                            {
                                if (CheckWithAllAxes(shapes[j].P[i], shapes[m].P[k]) && CheckWithNewLines(shapes[j].P[i], shapes[m].P[k]))
                                {
                                    g.DrawLine(new Pen(Color.Black), shapes[j].P[i], shapes[m].P[k]);
                                    Shape newL = new Shape();
                                    points = new List<Point>();
                                    points.Add(shapes[j].P[i]);
                                    points.Add(shapes[m].P[k]);
                                    points.Add(new Point((shapes[j].P[i].X+ shapes[m].P[k].X)/2, (shapes[j].P[i].Y + shapes[m].P[k].Y) / 2));
                                    newL.P = points;
                                    newLines.Add(newL);
                                }
                            }
                        }   
                    }
                }
            }
        }

        private bool CheckWithAllAxes(Point a, Point b)
        {
            for (int j = 0; j < shapes.Count(); j++)
            {
                for (int i = 0; i < shapes[j].P.Count; i++)
                {
                    Intersectie intersect = new Intersectie();
                    if (i != shapes[j].P.Count - 1)
                        intersect = new Intersectie(a, b, shapes[j].P[i], shapes[j].P[i + 1]);
                    else
                        intersect = new Intersectie(a, b, shapes[j].P[i], shapes[j].P[0]);
                    if (intersect.Intersectation())
                        return false;
                        
                }
            }
            return true;
        }

        private bool CheckWithNewLines(Point a, Point b)
        {
            for (int j = 0; j < newLines.Count(); j++)
            {
                    Intersectie intersect = new Intersectie();
                    intersect = new Intersectie(a, b, newLines[j].P[0], newLines[j].P[1]);
                    if (intersect.Intersectation())
                        return false;
            }
            return true;
        }

        private bool CheckWithNewLines2(Point a, Point b,int currentLine)
        {
            for (int j = 0; j < newLines.Count(); j++)
            {
                    Intersectie intersect = new Intersectie();
                    intersect = new Intersectie(a, b, newLines[j].P[0], newLines[j].P[1]);
                    if (intersect.Intersectation())
                        return false;
            }
            return true;
        }

        private void b4_Click(object sender, EventArgs e)
        {
            id = "b4";
            b4.Checked = true;
            b1.Checked = false;
            b2.Checked = false;
            b3.Checked = false;
            b5.Checked = false;

            for (int i = 1; i < shapes.Count; i++)
            {
                for(int j = 0; j < shapes[i].P.Count; j++)
                {
                    g.DrawLine(new Pen(Color.Black), shapes[i].P[j].X, pictureBox1.Height, shapes[i].P[j].X, 0);
                }
            }
        }

        private void b5_Click(object sender, EventArgs e)
        {
            id = "b5";
            b5.Checked = true;
            b1.Checked = false;
            b2.Checked = false;
            b3.Checked = false;
            b4.Checked = false;
            g.Clear(Color.GhostWhite);
            points.Clear();
            shapes.Clear();
            newLines.Clear();
            ss = 0;
            so = 0;
        }
    }
}
