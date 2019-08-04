using System;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using WebKit;

namespace WebviewCom.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            webView.Configuration.UserContentController.AddScriptMessageHandler(new MessageHandler(this), "native");

            webView.Configuration.UserContentController.AddUserScript(
            new WKUserScript(
                new NSString("window.invokeNative=function (param) {window.webkit.messageHandlers.native.postMessage(param);}"),
                WKUserScriptInjectionTime.AtDocumentStart, false));

            string index = Path.Combine(NSBundle.MainBundle.ResourcePath, "www/index.html");
            string webAppFolder = Path.Combine(NSBundle.MainBundle.ResourcePath, "www");
            webView.LoadFileUrl(new NSUrl("file://" + index),  new NSUrl("file://" + webAppFolder));
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        partial void Btn_TouchUpInside(UIButton sender)
        {
            webView.EvaluateJavaScript("invokeWeb('Hello!')", null);
        }

        public async Task ChangeTextAsync(int delay, string msg)
        {
            await Task.Delay(delay);
            lbl.Text = msg;
        }
    }

    class MessageHandler : NSObject, IWKScriptMessageHandler
    {
        ViewController ctx;

        public MessageHandler(ViewController context)
        {
            ctx = context;
        }

        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            InvokeOnMainThread(() => {
                ctx.ChangeTextAsync(0, message.Body.ToString());
                ctx.ChangeTextAsync(1000, "Ready.");
            });
        }
    }
}
