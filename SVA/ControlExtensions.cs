using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SVA
{
    public static class ControlExtensions
    {
        public static string TimeSpanToString(this TimeSpan ATimeSpan)
        {
            return $"{ATimeSpan.ToString().Substring(0, 8)}";
        }
#if !NET20
        public static T InvokeIfRequired<T>(this T source, Action<T> action)
            where T : Control
        {
            try
            {
                if (!source.InvokeRequired)
                    action(source);
                else
                    source.Invoke(new Action(() => action(source)));
            }
            catch (Exception ex)
            {
                Debug.Write("Error on 'InvokeIfRequired': {0}", ex.Message);
            }
            return source;
        }
#else
        delegate void InvokeIfRequiredDelegate<TControl>(TControl ctrl, Action<TControl> action);

        public static void InvokeIfRequired<TControl>(TControl ctrl, Action<TControl> action)
              where TControl : Control
        {
            try
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(new InvokeIfRequiredDelegate<TControl>(ControlExtensions.InvokeIfRequired), ctrl, action);
                }
                else
                {
                    action(ctrl);
                }
            }
            catch(Exception ex)
            {
                Debug.Write("Error on 'InvokeIfRequired': {0}", ex.Message);
            }
        }
#endif
    }
}
