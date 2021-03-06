﻿// <copyright file="TextGraphicsOptions.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Drawing
{
    /// <summary>
    /// Options for influencing the drawing functions.
    /// </summary>
    public struct TextGraphicsOptions
    {
        /// <summary>
        /// Represents the default <see cref="TextGraphicsOptions"/>.
        /// </summary>
        public static readonly TextGraphicsOptions Default = new TextGraphicsOptions(true);

        /// <summary>
        /// Whether antialiasing should be applied.
        /// </summary>
        public bool Antialias;

        /// <summary>
        /// The number of subpixels to use while rendering with antialiasing enabled.
        /// </summary>
        public int AntialiasSubpixelDepth;

        /// <summary>
        /// Whether the text should be drawing with kerning enabled.
        /// </summary>
        public bool ApplyKerning;

        /// <summary>
        /// The number of space widths a tab should lock to.
        /// </summary>
        public float TabWidth;

        /// <summary>
        /// Flag weather to use the current image resultion to for point size scaling.
        /// If this is [false] the text renders at 72dpi otherwise it renders at Image resolution
        /// </summary>
        public bool UseImageResolution;

        /// <summary>
        /// If greater than zero determine the width at which text should wrap.
        /// </summary>
        public float WrapTextWidth;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextGraphicsOptions" /> struct.
        /// </summary>
        /// <param name="enableAntialiasing">If set to <c>true</c> [enable antialiasing].</param>
        public TextGraphicsOptions(bool enableAntialiasing)
        {
            this.Antialias = enableAntialiasing;
            this.ApplyKerning = true;
            this.TabWidth = 4;
            this.AntialiasSubpixelDepth = 16;
            this.UseImageResolution = false;
            this.WrapTextWidth = 0;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="GraphicsOptions"/> to <see cref="TextGraphicsOptions"/>.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator TextGraphicsOptions(GraphicsOptions options)
        {
            return new TextGraphicsOptions(options.Antialias)
            {
                AntialiasSubpixelDepth = options.AntialiasSubpixelDepth
            };
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="TextGraphicsOptions"/> to <see cref="GraphicsOptions"/>.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator GraphicsOptions(TextGraphicsOptions options)
        {
            return new GraphicsOptions(options.Antialias)
            {
                AntialiasSubpixelDepth = options.AntialiasSubpixelDepth
            };
        }
    }
}