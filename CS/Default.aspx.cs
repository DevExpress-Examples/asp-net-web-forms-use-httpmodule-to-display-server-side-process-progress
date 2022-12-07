using System;
using System.Threading;
using System.Threading.Tasks;

public partial class _Default : System.Web.UI.Page {

    protected void cbak_Callback(object source, DevExpress.Web.CallbackEventArgs e) {
        e.Result = StartTask().ToString();
    }

    Int32 StartTask() {
        var startingTask = Task.Factory.StartNew(state => {
                var test = state as Test;
                while(test.Value < 100) {
                    Thread.Sleep(50);
                    test.Value++;
                }
            }, new Test());
        return TaskManager.Register(startingTask, false);
    }
}