﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BRaVO
{
    public partial class Form1 : Form
    {
        private List<Point> _points = new List<Point>();
        private List<Segment> _segments = new List<Segment>();
        private int _so;
        private int _ss;
        private readonly Graphics _g;
        private string _id = "b0";
        private Point _startPoint, _endPoint;
        private bool _spDefined;
        private bool _epDefined;

        private readonly List<Polygon> _polygons = new List<Polygon>();
        public char Id = 'A';

        public Form1()
        {
            InitializeComponent();
            _g = pictureBox1.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (_id == "b1")
            {
                if (e.Button.Equals(MouseButtons.Left))
                {
                    _points.Add(new Point(e.X, e.Y));
                    _g.DrawRectangle(new Pen(Color.Black), e.X - 2, e.Y - 2, 4, 4);
                    if (_points.Count > 1)
                    {
                        _g.DrawLine(new Pen(Color.Black), _points[_points.Count - 1], _points[_points.Count - 2]);
                        _segments.Add(new Segment(_points[_points.Count - 1], _points[_points.Count - 2]));
                    }

                }
                else if (_points.Count > 2)
                {
                    _g.DrawLine(new Pen(Color.Black), _points[_points.Count - 1], _points[0]);
                    _segments.Add(new Segment(_points[_points.Count - 1], _points[0]));
                    if (_so > 0)
                        _g.FillPolygon(new SolidBrush(Color.Black), _points.ToArray());
                    _polygons.Add(new Polygon { Segmente = _segments });
                    _points = new List<Point>();
                    _segments = new List<Segment>();
                    _so++;
                }
            }
            if (_id == "b2")
                if (_ss < 2)
                {
                    if (_ss == 0)
                    {
                        _g.FillEllipse(new SolidBrush(Color.Green), e.X - 6, e.Y - 6, 12, 12);
                        _startPoint = new Point(e.X, e.Y);
                        _spDefined = true;
                    }
                        
                    else if (_ss == 1)
                    {
                        _g.FillEllipse(new SolidBrush(Color.Red), e.X - 6, e.Y - 6, 12, 12);
                        _endPoint = new Point(e.X, e.Y);
                        _epDefined = true;
                    }
                    _ss++;
                }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            _id = "b1";
            b1.Checked = true;
            b2.Checked = false;
            b3.Checked = false;
            b4.Checked = false;
            b5.Checked = false;
        }

        private void b2_Click(object sender, EventArgs e)
        {
            _id = "b2";
            b2.Checked = true;
            b1.Checked = false;
            b3.Checked = false;
            b4.Checked = false;
            b5.Checked = false;
        }

        private void b3_Click(object sender, EventArgs e)
        {
            _id = "b3";
            b3.Checked = true;
            b1.Checked = false;
            b2.Checked = false;
            b4.Checked = false;
            b5.Checked = false;

            if (_spDefined && _epDefined)
            {
                PolygonManager.ListOfPolygons = _polygons;
                SegmentsManager.Segments = PolygonManager.GetAllPolygonsSegments();
                var allPoints = PolygonManager.GetAllPoints();
                for (var i = 0; i < allPoints.Count; i++)
                {
                    for (var j = 0; j < allPoints.Count; j++)
                    {
                        if (i != j)
                        {
                            var s = new Segment(allPoints[i], allPoints[j]);
                            if (!SegmentsManager.CheckIfSegmentAlreadyExists(s) &&
                                IntersectieManager.CheckIfASegmentIntersectsAnotherSegment(s) &&
                                !PolygonManager.CheckIfSegmentIntersectTwoPointsFromAnInternalShape(s))
                            {
                                _g.DrawLine(new Pen(Color.Black), allPoints[i], allPoints[j]);
                                SegmentsManager.Segments.Add(s);
                            }
                        }
                    }
                }
                DefineTriangles();
                CreateGraph();
                FindTheShortestPath();
            }
            else
            {
                MessageBox.Show(@"StartPoint and EndPoint are not defined!");
            }
            
        }

        private void b4_Click(object sender, EventArgs e)
        {
            _id = "b4";
            b4.Checked = true;
            b1.Checked = false;
            b2.Checked = false;
            b3.Checked = false;
            b5.Checked = false;

            PolygonManager.ListOfPolygons = _polygons.Where(p => !p.Equals(_polygons.First())).ToList();
            PolygonManager.Contur = _polygons.First();
            SegmentsManager.Segments = PolygonManager.GetAllPolygonsSegments();
            var allPoints = PolygonManager.GetAllPoints();
            SegmentsManager.InteriorSegments = new List<Segment>();
            PolygonManager.ListOfMiddlePoints = new List<Point>();
            for (var i = 0; i < allPoints.Count; i++)
            {
                var ySus = new Point(allPoints[i].X,allPoints[i].Y - 1);
                var yJos = new Point(allPoints[i].X,allPoints[i].Y + 1);
                if (IntersectieManager.CanDraw(allPoints[i],ySus))
                {
                    var sus = new Segment(allPoints[i], new Point(allPoints[i].X, 0));
                    var ptSus = IntersectieManager.GetLastIntersectionPoint(sus);
                    var segSus = new Segment(allPoints[i], ptSus);
                    _g.DrawLine(new Pen(Color.Blue), segSus.A, segSus.B);
                    SegmentsManager.InteriorSegments.Add(segSus);
                }
                if (IntersectieManager.CanDraw(allPoints[i], yJos))
                {
                    var jos = new Segment(allPoints[i], new Point(allPoints[i].X, pictureBox1.Height));
                    var ptJos = IntersectieManager.GetFirstIntersectionPoint(jos);
                    var segJos = new Segment(allPoints[i], ptJos);
                    _g.DrawLine(new Pen(Color.Blue), segJos.A, segJos.B);
                    SegmentsManager.InteriorSegments.Add(segJos);
                }
            }

            foreach (var s in SegmentsManager.InteriorSegments)
            {
                _g.FillEllipse(new SolidBrush(Color.Blue), s.GetTheMiddlePoint().X - 6, s.GetTheMiddlePoint().Y - 6, 12, 12);
                PolygonManager.ListOfMiddlePoints.Add(new Point(s.GetTheMiddlePoint().X, s.GetTheMiddlePoint().Y));
            }

            //for (var i = 0; i < PolygonManager.ListOfMiddlePoints.Count(); i++)
            //{
            //    for (var j = 0; j < PolygonManager.ListOfMiddlePoints.Count(); j++)
            //    {
            //        if (i != j && PolygonManager.ListOfMiddlePoints[i].X!= PolygonManager.ListOfMiddlePoints[j].X)
            //        {
            //            var seg = new Segment(PolygonManager.ListOfMiddlePoints[i], PolygonManager.ListOfMiddlePoints[j]);
            //            if (!IntersectieManager.CheckIfSegmentIntersectInteriorSegment(seg))
            //            {
            //                _g.DrawLine(new Pen(Color.Blue), seg.A, seg.B);
            //            }
            //        }
            //    }
            //}
        }

        private void b5_Click(object sender, EventArgs e)
        {
            _id = "b5";
            b5.Checked = true;
            b1.Checked = false;
            b2.Checked = false;
            b3.Checked = false;
            b4.Checked = false;
            _g.Clear(Color.GhostWhite);

            _polygons.Clear();
            _points.Clear();
            _segments.Clear();

            NodManager.Noduri = new List<Nod>();
            DrumManager.Drumuri = new List<Drum>();

            _ss = 0;
            _so = 0;
        }

        private void DefineTriangles()
        {
            TriangleManager.Triangles = new List<Triangle>();
            NodManager.Noduri = new List<Nod>();
            DrumManager.Drumuri = new List<Drum>();
            foreach (var s in SegmentsManager.Segments)
            {
                var listFirstSegments = SegmentsManager.GetSegmentsThatContainsASpecificPoint(s.A);
                var listSecondSegments = SegmentsManager.GetSegmentsThatContainsASpecificPoint(s.B);
                listFirstSegments.Remove(s);
                listSecondSegments.Remove(s);
                for (var i = 0; i < listFirstSegments.Count; i++)
                {
                    var a = listFirstSegments[i].GetTheOtherPoint(s.A);
                    for (var j = 0; j < listSecondSegments.Count; j++)
                    {
                        var b = listSecondSegments[j].GetTheOtherPoint(s.B);
                        if (a.Equals(b))
                        {
                            var t = new Triangle(s.A, s.B, a);
                            if (!TriangleManager.CheckIfPointIsInsideTriangle(t) && !PolygonManager.CheckIfTriangleIsAShape(t))
                            {
                                if (TriangleManager.Triangles.Count > 0)
                                {
                                    if(!TriangleManager.CheckIfTriangleAlreadyExists(t))
                                        TriangleManager.Triangles.Add(t);
                                }
                                else
                                {
                                    TriangleManager.Triangles.Add(t);
                                }
                            }
                        }
                    }
                }
            }
            foreach (var p in TriangleManager.Triangles.Select(tr => tr.GetGravityCenter()))
            {
                var n = new Nod(Id, p);
                if (NodManager.Noduri.Count > 0)
                {
                    if (!NodManager.CheckIfNodExists(n))
                    {
                        _g.FillEllipse(new SolidBrush(Color.Blue), p.X - 6, p.Y - 6, 12, 12);
                        NodManager.Noduri.Add(n);
                        Id++;
                    }
                }
                else
                {
                    _g.FillEllipse(new SolidBrush(Color.Blue), p.X - 6, p.Y - 6, 12, 12);
                    NodManager.Noduri.Add(n);
                    Id++;
                }
            }
        }

        private void CreateGraph()
        {
            foreach (var t in TriangleManager.Triangles)
            {
                var mainT = t;
                var a = mainT.GetGravityCenter();
                var trianglesNextToMaintT = TriangleManager.GetAllTrianglesNextToMainTriangle(mainT);
                foreach (var tr in trianglesNextToMaintT)
                {
                    var b = tr.GetGravityCenter();
                    var seg = TriangleManager.GetCommonSegmentFromTwoTriangles(t, tr);
                    if (IntersectieManager.CheckIfTwoPointsIntersectOnlyASpecificSegment(a, b, seg))
                    {

                        Drum d = new Drum(NodManager.GetNod(a), NodManager.GetNod(b), new Segment(a, b).GetLength());
                        if (!DrumManager.CheckIfDrumExists(d))
                        {
                            _g.DrawLine(new Pen(Color.Blue), a, b);
                            DrumManager.Drumuri.Add(d);
                        }
                    }
                        
                    else if (IntersectieManager.CheckIfTwoPointsIntersectAShape(a,b))
                    {
                        var n = new Nod(Id, seg.GetTheMiddlePoint());
                        if (!NodManager.CheckIfNodExists(n))
                        {
                            _g.FillEllipse(new SolidBrush(Color.Blue), seg.GetTheMiddlePoint().X - 6, seg.GetTheMiddlePoint().Y - 6, 12, 12);
                            NodManager.Noduri.Add(n);
                            Id++;
                        }
                        
                        Drum d1 = new Drum(NodManager.GetNod(a), NodManager.GetNod(seg.GetTheMiddlePoint()),
                            new Segment(a, seg.GetTheMiddlePoint()).GetLength());
                        if (!DrumManager.CheckIfDrumExists(d1))
                        {
                            _g.DrawLine(new Pen(Color.Blue), a, seg.GetTheMiddlePoint());
                            DrumManager.Drumuri.Add(d1);
                        }
                        
                        Drum d2 = new Drum(NodManager.GetNod(seg.GetTheMiddlePoint()), NodManager.GetNod(b),
                            new Segment(seg.GetTheMiddlePoint(), b).GetLength());
                        if (!DrumManager.CheckIfDrumExists(d2))
                        {
                            _g.DrawLine(new Pen(Color.Blue), seg.GetTheMiddlePoint(), b);
                            DrumManager.Drumuri.Add(d2);
                        }
                    }
                }
            }
        }

        private void FindTheShortestPath()
        {
            Pen greenPen = new Pen(Color.Purple, 3);

            var tr1 = TriangleManager.ReturnTriangleWithAPointInside(_startPoint);
            var tr2 = TriangleManager.ReturnTriangleWithAPointInside(_endPoint);
            var gr1 = tr1.GetGravityCenter();
            var gr2 = tr2.GetGravityCenter();
            _g.DrawLine(greenPen, _startPoint, gr1);
            _g.DrawLine(greenPen, _endPoint, gr2);
            var startNod = NodManager.GetNod(gr1);
            var endNod = NodManager.GetNod(gr2);

            var gr = new Graph();

            foreach (var n in NodManager.Noduri)
            {
                var dict = new Dictionary<char, int>();
                var nodesThatCanBeReached = NodManager.CheckWehereANodCanGo(n);
                foreach (var nd in nodesThatCanBeReached)
                {
                    dict.Add(nd.Id, Convert.ToInt32(new Segment(n.P, nd.P).GetLength()));
                }
                gr.add_vertex(n.Id, dict);
            }

            var ls = gr.shortest_path(startNod.Id, endNod.Id);
            if (ls.Count > 0)
            {
                _g.DrawLine(greenPen, startNod.P, NodManager.GetNodWithId(ls[ls.Count - 1]).P);
                for (var i = 0; i < ls.Count() - 1; i++)
                {
                    var n = NodManager.GetNodWithId(ls[i]);
                    var n2 = NodManager.GetNodWithId(ls[i + 1]);
                    _g.DrawLine(greenPen, n.P, n2.P);
                }
            }
        }
    }
}
