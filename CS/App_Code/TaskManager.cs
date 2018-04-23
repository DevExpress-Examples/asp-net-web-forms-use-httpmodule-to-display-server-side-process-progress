using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

public static class TaskManager {
    static Dictionary<Int32, Task> _tasks = new Dictionary<Int32,Task>();
    static Object l_lock = new Object();

    public static Int32 Register(Task task) {
        _tasks.Add(task.Id, task);
        return task.Id;
    }

    public static Int32 Register(Task task, Boolean dispose)
    {
        lock(l_lock) {
            if(dispose) {
                task.ContinueWith(reference => { _tasks.Remove(reference.Id); reference.Dispose(); });
            }
            return Register(task);
        }
    }

    public static Task FindTask(Int32 id)
    {
        lock (l_lock)
            return _tasks[id];
    }
}
