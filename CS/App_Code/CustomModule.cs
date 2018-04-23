using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Threading.Tasks;

public class CustomModule : IHttpModule {

    public void Dispose() { }

    public void Init(HttpApplication application) {
        application.AcquireRequestState += application_AcquireRequestState;
    }

    void application_AcquireRequestState(object sender, EventArgs e) {
        var context = (sender as HttpApplication).Context;
        var taskID = context.Request.QueryString["proc"];
        var isProgressQuery = !String.IsNullOrEmpty(taskID); 
        if(isProgressQuery) {
            context.Response.CacheControl = "No-cache";
            var task = TaskManager.FindTask(Int32.Parse(taskID));
            var progress = task.AsyncState.ToString();
            context.Response.Write(progress);
            context.Response.End();
        }
    }
}