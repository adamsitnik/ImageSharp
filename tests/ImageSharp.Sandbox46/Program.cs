﻿// <copyright file="Program.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Sandbox46
{
    using System;
    using System.Runtime.DesignerServices;

    using ImageSharp.Tests;
    using ImageSharp.Tests.Colors;

    using Xunit.Abstractions;

    public class Program
    {
        private class ConsoleOutput : ITestOutputHelper
        {
            public void WriteLine(string message)
            {
                Console.WriteLine(message);
            }

            public void WriteLine(string format, params object[] args)
            {
                Console.WriteLine(format, args);
            }
        }

        /// <summary>
        /// The main entry point. Useful for executing benchmarks and performance unit tests manually,
        /// when the IDE test runners lack some of the functionality. Eg.: it's not possible to run JetBrains memory profiler for unit tests.
        /// </summary>
        /// <param name="args">
        /// The arguments to pass to the program.
        /// </param>
        public static void Main(string[] args)
        {
            // RunDecodeJpegProfilingTests();
            // RunToVector4ProfilingTest();

            RunResizeProfilingTest();

            Console.ReadLine();
        }

        private static void RunResizeProfilingTest()
        {
            ResizeProfilingBenchmarks test = new ResizeProfilingBenchmarks(new ConsoleOutput());
            test.ResizeBicubic(2000, 2000);
        }

        private static void RunToVector4ProfilingTest()
        {
            BulkPixelOperationsTests.Color32 tests = new BulkPixelOperationsTests.Color32(new ConsoleOutput());
            tests.Benchmark_ToVector4();
        }

        private static void RunDecodeJpegProfilingTests()
        {
            Console.WriteLine("RunDecodeJpegProfilingTests...");
            JpegProfilingBenchmarks benchmarks = new JpegProfilingBenchmarks(new ConsoleOutput());
            foreach (object[] data in JpegProfilingBenchmarks.DecodeJpegData)
            {
                string fileName = (string)data[0];
                benchmarks.DecodeJpeg(fileName);
            }
        }
    }
}
