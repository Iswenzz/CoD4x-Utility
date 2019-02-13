using System;
using System.Drawing;

using Iswenzz.UI;

namespace Iswenzz.CoD4.Utility
{
    public static class Extension
    {
        /// <summary>
        /// Toggle button color.
        /// </summary>
        /// <param name="button">The button</param>
        /// <param name="state">Button state</param>
        public static void ToggleButton(this FlatButton button, bool state)
        {
            if (!state)
            {
                button.BackColor = Color.FromArgb(178, 34, 34);
                button.HoverColor = Color.FromArgb(178, 34, 34);
                button.HoverColorLeave = Color.FromArgb(178, 34, 34);
            }
            else
            {
                button.BackColor = Color.FromArgb(46, 139, 87);
                button.HoverColor = Color.FromArgb(46, 139, 87);
                button.HoverColorLeave = Color.FromArgb(46, 139, 87);
            }
        }

        /// <summary>
        /// Make one button active and reset all other buttons.
        /// </summary>
        /// <param name="active_button">Which button should be active</param>
        /// <param name="reset_buttons">All other button to reset color</param>
        public static void MainButton(FlatButton active_button, params FlatButton[] reset_buttons)
        {
            active_button.BackColor = Color.FromArgb(72, 75, 81);
            active_button.HoverColor = Color.FromArgb(72, 75, 81);
            active_button.HoverColorLeave = Color.FromArgb(72, 75, 81);

            foreach (FlatButton button in reset_buttons)
            {
                button.BackColor = Color.FromArgb(36, 35, 39);
                button.HoverColor = Color.FromArgb(36, 35, 39);
                button.HoverColorLeave = Color.FromArgb(36, 35, 39);
            }
        }
    }
}
