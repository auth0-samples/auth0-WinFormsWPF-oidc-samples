using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using IdentityModel.OidcClient.Browser;
using Microsoft.Web.WebView2.Wpf;

namespace WPFSample;

public class WebViewBrowser : IBrowser
{
    private readonly Func<Window> _windowFactory;

    /// <summary>
    /// Creates a new instance of <see cref="WebViewBrowser"/> with a specified function to create the <see cref="Window"/>
    /// used to host the <see cref="WebView2"/> control.
    /// </summary>
    /// <param name="windowFactory">The function used to create the <see cref="Window"/> that will host the <see cref="WebView2"/> control.</param>
    public WebViewBrowser(Func<Window> windowFactory)
    {
        _windowFactory = windowFactory;
    }

    /// <summary>
    /// Creates a new instance of <see cref="WebViewBrowser"/> allowing parts of the <see cref="Window"/> container to be set.
    /// </summary>
    /// <param name="title">Optional title for the form - defaults to 'Authenticating...'.</param>
    /// <param name="width">Optional width for the form in pixels. Defaults to 1024.</param>
    /// <param name="height">Optional height for the form in pixels. Defaults to 768.</param>
    public WebViewBrowser(string title = "Authenticating...", int width = 1024, int height = 768)
        : this(() => new Window
        {
            Name = "WebAuthentication",
            Title = title,
            Width = width,
            Height = height
        })
    {
    }

    /// <inheritdoc />
    public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
    {
        var tcs = new TaskCompletionSource<BrowserResult>();

        var window = _windowFactory();
        var webView = new WebView2();

        webView.NavigationStarting += (sender, e) =>
        {
            if (e.Uri.StartsWith(options.EndUrl))
            {

                tcs.SetResult(new BrowserResult { ResultType = BrowserResultType.Success, Response = e.Uri.ToString() });
                window.Close();

            }

        };

        window.Closing += (sender, e) =>
        {
            if (!tcs.Task.IsCompleted)
                tcs.SetResult(new BrowserResult { ResultType = BrowserResultType.UserCancel });
        };


        window.Content = webView;
        window.Show(); 
        await webView.EnsureCoreWebView2Async();
        webView.CoreWebView2.Navigate(options.StartUrl);

        return await tcs.Task;
    }
}