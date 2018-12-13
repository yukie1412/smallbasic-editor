﻿// <copyright file="ShapesLibrary.cs" company="2018 Omar Tawfik">
// Copyright (c) 2018 Omar Tawfik. All rights reserved. Licensed under the MIT License. See LICENSE file in the project root for license information.
// </copyright>

namespace SuperBasic.Editor.Libraries
{
    using System;
    using System.Collections.Generic;
    using SuperBasic.Compiler.Runtime;
    using SuperBasic.Editor.Components;
    using SuperBasic.Editor.Libraries.Shapes;
    using SuperBasic.Editor.Libraries.Utilities;
    using SuperBasic.Editor.Store;

    internal sealed class ShapesLibrary : IShapesLibrary
    {
        private readonly LibrariesCollection libraries;
        private readonly NamedCounter counter = new NamedCounter();
        private readonly Dictionary<string, BaseShape> shapes = new Dictionary<string, BaseShape>();

        public ShapesLibrary(LibrariesCollection libraries)
        {
            this.libraries = libraries;

            GraphicsDisplayStore.SetShapesComposer(this.ComposeTree);
        }

        public string AddEllipse(decimal width, decimal height)
        {
            string name = this.counter.GetNext("Ellipse");
            this.shapes.Add(name, new EllipseShape(width, height, this.libraries.Styles));
            return name;
        }

        public string AddImage(string imageName)
        {
            // TODO-now: implement after implementing images
            return string.Empty;
        }

        public string AddLine(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            string name = this.counter.GetNext("Line");
            this.shapes.Add(name, new LineShape(x1, y2, x2, y2, this.libraries.Styles));
            return name;
        }

        public string AddRectangle(decimal width, decimal height)
        {
            string name = this.counter.GetNext("Rectangle");
            this.shapes.Add(name, new RectangleShape(width, height, this.libraries.Styles));
            return name;
        }

        public string AddText(string text)
        {
            string name = this.counter.GetNext("Text");
            this.shapes.Add(name, new TextShape(text, this.libraries.Styles));
            return name;
        }

        public string AddTriangle(decimal x1, decimal y1, decimal x2, decimal y2, decimal x3, decimal y3)
        {
            string name = this.counter.GetNext("Triangle");
            this.shapes.Add(name, new TriangleShape(x1, y1, x2, y2, x3, y3, this.libraries.Styles));
            return name;
        }

        public decimal GetLeft(string shapeName)
        {
            if (this.shapes.TryGetValue(shapeName, out BaseShape shape))
            {
                return shape.Left;
            }

            return 0;
        }

        public decimal GetOpacity(string shapeName)
        {
            if (this.shapes.TryGetValue(shapeName, out BaseShape shape))
            {
                return shape.Opacity;
            }

            return 0;
        }

        public decimal GetTop(string shapeName)
        {
            if (this.shapes.TryGetValue(shapeName, out BaseShape shape))
            {
                return shape.Top;
            }

            return 0;
        }

        public void HideShape(string shapeName)
        {
            if (this.shapes.TryGetValue(shapeName, out BaseShape shape))
            {
                shape.IsVisible = false;
            }
        }

        public void Move(string shapeName, decimal x, decimal y)
        {
            if (this.shapes.TryGetValue(shapeName, out BaseShape shape))
            {
                shape.TranslateX = x;
                shape.TranslateY = y;
            }
        }

        public void Remove(string shapeName)
        {
            if (this.shapes.ContainsKey(shapeName))
            {
                this.shapes.Remove(shapeName);
            }
        }

        public void Rotate(string shapeName, decimal angle)
        {
            if (this.shapes.TryGetValue(shapeName, out BaseShape shape))
            {
                shape.Angle = angle;
            }
        }

        public void SetOpacity(string shapeName, decimal level)
        {
            if (this.shapes.TryGetValue(shapeName, out BaseShape shape))
            {
                shape.Opacity = Math.Min(100, Math.Max(0, level));
            }
        }

        public void SetText(string shapeName, string text)
        {
            if (this.shapes.TryGetValue(shapeName, out BaseShape shape) && shape is TextShape textShape)
            {
                textShape.Graphics.Text = text;
            }
        }

        public void ShowShape(string shapeName)
        {
            if (this.shapes.TryGetValue(shapeName, out BaseShape shape))
            {
                shape.IsVisible = true;
            }
        }

        public void Zoom(string shapeName, decimal scaleX, decimal scaleY)
        {
            if (this.shapes.TryGetValue(shapeName, out BaseShape shape))
            {
                shape.ScaleX = Math.Max(0.1m, Math.Min(20m, scaleX));
                shape.ScaleY = Math.Max(0.1m, Math.Min(20m, scaleY));
            }
        }

        internal void Clear()
        {
            this.shapes.Clear();
        }

        private void ComposeTree(TreeComposer composer)
        {
            foreach (var shape in this.shapes.Values)
            {
                shape.ComposeTree(composer);
            }
        }
    }
}
