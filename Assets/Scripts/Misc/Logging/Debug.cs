using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Scripts.Misc.Logging {

    public static class Debug {

        public static string Log(object msg, [CallerLineNumber] int lineNumber = 0) {
            var callingFrame = new StackFrame(1);
            var callingMethod = callingFrame.GetMethod();
            string loggedMsg = $"[{callingMethod.DeclaringType.FullName}:{callingMethod.Name}, Ln: {lineNumber}] {msg}";
            UnityEngine.Debug.Log(loggedMsg);
            return loggedMsg;
        }
    }
}
