using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Whats_New_CSharp_6
{
    /// <summary>
    /// Executes, logs, and provides diagnostics for an Action
    /// </summary>
    public class OperationLogger : IDisposable
    {
        public OperationLogger(Stream stream)
        {
            Stream = stream;
            LogWriter = new StreamWriter(Stream);
        }

        public async Task LogOperationAsync(Action action)
        {
            //var name = "no name";
            //if(action != null && action.Method != null)
            //{
            //    name = action.Method.Name;
            //}

            // '?.' introducted in C# 6, this is equalivalent to the above
            var name = action?.Method?.Name ?? "no name";

            try
            {
                action();
                await LogWriter.WriteLineAsync(name + " executed");
            }
            catch(Exception ex)
            {
                // ex just for demo, want to be more specific
                await LogWriter.WriteLineAsync(name + " failed");
            }
            finally
            {
                await LogWriter.FlushAsync();
            }

            await LogWriter.WriteLineAsync(name + " executed");
            await LogWriter.FlushAsync();
        }

        void IDisposable.Dispose()
        {
            LogWriter.Dispose();
        }

        public Stream Stream { get; set; }
        private StreamWriter LogWriter { get; } 
    }
}
