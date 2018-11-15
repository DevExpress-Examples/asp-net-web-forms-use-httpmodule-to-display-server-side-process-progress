<!-- default file list -->
*Files to look at*:

* [CustomModule.cs](./CS/App_Code/CustomModule.cs) (VB: [CustomModule.vb](./VB/App_Code/CustomModule.vb))
* [TaskManager.cs](./CS/App_Code/TaskManager.cs) (VB: [TaskManager.vb](./VB/App_Code/TaskManager.vb))
* [Test.cs](./CS/App_Code/Test.cs) (VB: [Test.vb](./VB/App_Code/Test.vb))
* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# How to track progress of server side processing on the client side (using HttpModule)


<p>This example demonstrates an alternative way of how to track server-side processing. In this example, a custom HttpModule is used instead of HttpHandler as demonstrated in the <a href="https://www.devexpress.com/Support/Center/p/E4651">How to track progress of server side processing on the client side (using HttpHandler)</a> example. The use of the HttpModule has multiple advantages, and here are some of them:</p>
<p>- The module will be called earlier than the handler;</p>
<p>- At this stage, a user can close the predefined request from the client.<br> In contrast to the previous example where a session object is used to store a progress value, a simple static class is defined. Note this class has a global scope and should be made thread-safe.</p>
<p>For more information about the difference between the use of HttpModule and HttpHandler, follow this article: <a href="http://msdn.microsoft.com/en-us/library/bb398986(v=vs.100).aspx"><u>HTTP Handlers and HTTP Modules Overview</u></a></p>
<p>This example extends the following one: <a href="https://www.devexpress.com/Support/Center/p/E918">How to display progress information about server-side callback processing</a></p>
<p>You can find more information on HttpModule basic concepts here: <a href="http://msdn.microsoft.com/en-us/library/ms227673(v=vs.100).aspx"><u>Walkthrough: Creating and Registering a Custom HTTP Module</u></a><br><br><strong>See Also:</strong><br><a href="https://www.devexpress.com/Support/Center/p/T156786">How to track progress of server side processing on the client side (using WebMethods)</a><br><a href="https://www.devexpress.com/Support/Center/p/T518056">ASPxGridView - How to show a lengthy operation's progress and allow canceling such operations</a></p>

<br/>


