using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Wobble.Bindables;

namespace Wobble.Input
{
    public static class KeyboardManager
    {
        /// <summary>
        ///     The current keyboard state
        /// </summary>
        public static KeyboardState CurrentState { get; private set; }

        /// <summary>
        ///     The keyboard state of the previous frame
        /// </summary>
        public static KeyboardState PreviousState { get; private set; }

        /// <summary>
        ///     Keeps our keyboard states updated each frame
        /// </summary>
        internal static void Update()
        {
            PreviousState = CurrentState;
            CurrentState = Keyboard.GetState();
        }

        /// <summary>
        ///     If the key was pressed and released - useful for actions that require a single key press.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsUniqueKeyPress(Keys key) => CurrentState.IsKeyDown(key) && PreviousState.IsKeyUp(key);

        /// <summary>
        ///     If a key was previously pressed down and then released.
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool IsUniqueKeyRelease(Keys k) => CurrentState.IsKeyUp(k) && PreviousState.IsKeyDown(k);

        /// <summary>
        ///     Returns if either the control keys are down
        /// </summary>
        /// <returns></returns>
        public static bool IsCtrlDown() =>
            (CurrentState.IsKeyDown(Keys.LeftControl) || CurrentState.IsKeyDown(Keys.RightControl))
            || (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
                && (CurrentState.IsKeyDown(Keys.LeftWindows) || CurrentState.IsKeyDown(Keys.RightWindows)));

        /// <summary>
        ///     Returns if either Alt key is held down
        /// </summary>
        /// <returns></returns>
        public static bool IsAltDown() => CurrentState.IsKeyDown(Keys.LeftAlt) || CurrentState.IsKeyDown(Keys.RightAlt);

        /// <summary>
        ///     Returns if either shift key is held down
        /// </summary>
        /// <returns></returns>
        public static bool IsShiftDown() => CurrentState.IsKeyDown(Keys.LeftShift) || CurrentState.IsKeyDown(Keys.RightShift);
    }
}
