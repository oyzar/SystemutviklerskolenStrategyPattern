using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace ConsoleApplication1
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/dn178466%28v=pandp.30%29.aspx
    /// </summary>
    public class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input,
          GetNextInterceptionBehaviorDelegate getNext)
        {
            // Before invoking the method on the original target.
            WriteLog(String.Format(
              "Kaller metode {0} - kl. {1}",
              input.MethodBase, DateTime.Now.ToLongTimeString()));

            // Invoke the next behavior in the chain.
            var result = getNext()(input, getNext);

            // After invoking the method on the original target.
            if (result.Exception != null)
            {
                WriteLog(String.Format(
                  "Metode {0} kastet exception {1} - kl. {2}",
                  input.MethodBase, result.Exception.Message,
                  DateTime.Now.ToLongTimeString()));
            }
            else
            {
                WriteLog(String.Format(
                  "Metode {0} returnerte {1} - kl. {2}",
                  input.MethodBase, result.ReturnValue,
                  DateTime.Now.ToLongTimeString()));
            }

            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private void WriteLog(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
