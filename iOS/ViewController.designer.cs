// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WebviewCom.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        WebKit.WKWebView webView { get; set; }

        [Action ("Btn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Btn_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btn != null) {
                btn.Dispose ();
                btn = null;
            }

            if (lbl != null) {
                lbl.Dispose ();
                lbl = null;
            }

            if (webView != null) {
                webView.Dispose ();
                webView = null;
            }
        }
    }
}