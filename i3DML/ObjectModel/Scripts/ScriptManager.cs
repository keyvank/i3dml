/**
 * The i3DML Project
 * Author:  Keyvan M. Kambakhsh
 * 
 * UNDER GPL V3 LICENSE
 **/

#define OLD_JINT

using System;
using i3DML.ObjectModel.Components;
using Jint;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace i3DML.ObjectModel
{
    /// <summary>
    /// Provides a JavaScript function.
    /// </summary>
    [i3DMLReaderIgnore]
    public class ScriptFunction
    {
        public string Name { get; set; }
        public Delegate Function { get; set; }
        public ScriptFunction(string name, Delegate func) { Name = name; Function = func; }
    }

    /// <summary>
    /// Provides a JavaScript engine.
    /// </summary>
    [i3DMLReaderIgnore]
    public class ScriptManager
    {
#if NEW_JINT
        public static List<ScriptFunction> GlobalFunctions = new List<ScriptFunction>();
        Engine JSEngine;
        Drawable Drawable;
        public ScriptManager(Drawable drawable)
        {
            Drawable = drawable;
            JSEngine = new Engine(o => {  });
            JSEngine.SetValue("log", new Action<object>(o => Console.WriteLine(o)));
            JSEngine.SetValue("sleep", new Action<double>(i => System.Threading.Thread.Sleep((int)i)));

            //SOLVE
            JSEngine.SetValue("doInBackground", new Action<Delegate>(f => System.Threading.Tasks.Task.Factory.StartNew(() => { f.Method.Invoke(new Jint.Native.JsValue("null"), null); })));
            //SOLVE

            JSEngine.SetValue("getElementByName", new Func<string, Drawable>((s) => { return Drawable.FindElement(s); }));
            JSEngine.SetValue("createElement", new Func<string, object>((s) =>
                {
                    Assembly a = Assembly.GetAssembly(this.GetType());
                    Type t = a.GetTypes().FirstOrDefault(f => f.Name == s&&f.GetCustomAttributes(typeof(i3DMLReaderIgnoreAttribute),true).Count()==0);
                    if (t == null)
                        return null;
                    else
                        return Activator.CreateInstance(t);
                }));
            foreach (ScriptFunction func in GlobalFunctions)
                JSEngine.SetValue(func.Name, func.Function);
            JSEngine.SetValue("THIS", Drawable);
            //JSEngine.AllowClr = true;
        }
        public bool Run(string script)
        {
            if (script != null)
            {
                try
                {
                    JSEngine.Execute(script);
                    return true;
                }
                catch { return false; }
            }
            else
                return false;
        }
        public object RunFunction(string script)
        {
            if (script != null)
                try
                {
                    return JSEngine.(script);
                }
                catch { return null; }
            else
                return null;
        }
#elif OLD_JINT
        public static List<ScriptFunction> GlobalFunctions = new List<ScriptFunction>();
        JintEngine JSEngine;
        Drawable Drawable;
        public ScriptManager(Drawable drawable)
        {
            Drawable = drawable;
            JSEngine = new JintEngine();
            JSEngine.DisableSecurity();
            JSEngine.SetParameter("tools", new ScriptingTools());
            JSEngine.SetFunction("log", new Action<object>(o => Console.WriteLine(o)));
            JSEngine.SetFunction("sleep", new Action<double>(i => System.Threading.Thread.Sleep((int)i)));
            JSEngine.SetFunction("doInBackground", new Action<Jint.Native.JsFunction>(f => System.Threading.Tasks.Task.Factory.StartNew(() => { JSEngine.CallFunction(f); })));
            JSEngine.SetFunction("getElementByName", new Func<string, Drawable>((s) => { return Drawable.FindElement(s); }));
            JSEngine.SetFunction("createElement", new Func<string, object>((s) =>
            {
                Assembly a = Assembly.GetAssembly(this.GetType());
                Type t = a.GetTypes().FirstOrDefault(f => f.Name == s && f.GetCustomAttributes(typeof(i3DMLReaderIgnoreAttribute), true).Count() == 0);
                if (t == null)
                    return null;
                else
                    return Activator.CreateInstance(t);
            }));
            foreach (ScriptFunction func in GlobalFunctions)
                JSEngine.SetFunction(func.Name, func.Function);
            JSEngine.SetParameter("THIS", Drawable);
            JSEngine.AllowClr = true;
        }
        public bool Run(string script)
        {
            if (script != null)
            {
                try
                {
                    JSEngine.Run(script);
                    return true;
                }
                catch { return false; }
            }
            else
                return false;
        }
        public object RunFunction(string script)
        {
            if (script != null)
                try
                {
                    return JSEngine.Run(script);
                }
                catch { return null; }
            else
                return null;
        }
#endif
    }
}


