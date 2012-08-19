using System;
using System.Threading;
using System.Runtime.InteropServices;

namespace W8Start {
	/// <summary>
	/// Program that simulates user keystroke for WINDOWS key
	/// </summary>
	public class Program {
		// NOTE: List of virtual key codes
		// http://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx

		// NOTE: Thanks to code from fardjad
		// http://stackoverflow.com/questions/4344595/how-to-simulate-keypress

		private const int WaitTimeMS = 10;
		private const int KeyEventKeyUp = 2;
		private const byte VirtualKeyWindows = 0x5B;

		/// <summary>
		/// Program ntry point
		/// </summary>
		static void Main() {
			// Key down, wait, key up
			keybd_event(VirtualKeyWindows, 0, 0, (UIntPtr)0);
			Thread.Sleep(WaitTimeMS);
			keybd_event(VirtualKeyWindows, 0, KeyEventKeyUp, (UIntPtr)0);

			return;
		}

		/// <summary>
		/// Synthesizes a keystroke. The system can use such a synthesized keystroke to generate a WM_KEYUP or WM_KEYDOWN message. The keyboard driver's interrupt handler calls the keybd_event function.
		/// </summary>
		/// <param name="bVk">A virtual-key code. The code must be a value in the range 1 to 254. For a complete list, see Virtual Key Codes.</param>
		/// <param name="bScan">A hardware scan code for the key.</param>
		/// <param name="dwFlags">Controls various aspects of function operation. This parameter can be one or more of the following values.</param>
		/// <param name="dwExtraInfo">An additional value associated with the key stroke.</param>
		/// <remarks>
		/// An application can simulate a press of the PRINTSCRN key in order to obtain a screen snapshot and save it to the clipboard. To do this, call keybd_event with the bVk parameter set to VK_SNAPSHOT.
		/// </remarks>
		[DllImport("user32.dll")]
		static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
	}
}
