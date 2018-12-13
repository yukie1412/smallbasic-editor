﻿// <copyright file="RectangleShape.cs" company="2018 Omar Tawfik">
// Copyright (c) 2018 Omar Tawfik. All rights reserved. Licensed under the MIT License. See LICENSE file in the project root for license information.
// </copyright>

namespace SuperBasic.Editor.Libraries.Shapes
{
    using SuperBasic.Editor.Libraries.Graphics;
    using SuperBasic.Editor.Libraries.Utilities;

    internal sealed class RectangleShape : BaseShape<RectangleGraphicsObject>
    {
        public RectangleShape(decimal width, decimal height, GraphicsWindowStyles styles)
            : base(new RectangleGraphicsObject(x: 0, y: 0, width, height, styles))
        {
        }

        public override decimal Left => this.Graphics.X;

        public override decimal Top => this.Graphics.Y;
    }
}
