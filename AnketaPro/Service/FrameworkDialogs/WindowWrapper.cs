﻿using System;
using System.Windows;
using System.Windows.Interop;
using IWin32Window = System.Windows.Forms.IWin32Window;

namespace AnketaPro.Service.FrameworkDialogs
{
	/// <summary>
	/// WindowWrapper is an IWin32Window wrapper around a WPF window.
	/// </summary>
	public class WindowWrapper : IWin32Window
	{
		/// <summary>
		/// Construct a new wrapper taking a WPF window.
		/// </summary>
		/// <param name="window">The WPF window to wrap.</param>
		public WindowWrapper(Window window)
		{
			Handle = new WindowInteropHelper(window).Handle;
		}


		/// <summary>
		/// Gets the handle to the window represented by the implementer.
		/// </summary>
		/// <returns>A handle to the window represented by the implementer.</returns>
		public IntPtr Handle { get; private set; }
	}
}
