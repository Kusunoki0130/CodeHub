using System.Web;
using System.Web.Optimization;

namespace CodeHub
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // navbar
            bundles.Add(new StyleBundle("~/navbar/css").Include(
                        "~/Static/bootstrap/css/*.css",
                        "~/Static/css/navbar.css"));
            bundles.Add(new ScriptBundle("~/navbar/js").Include(
                        "~/Static/jQuery/jquery-3.5.1.min.js",
                        "~/Static/bootstrap/js/bootstrap.min.js"));



            // index
            bundles.Add(new StyleBundle("~/index/css").Include(
                        "~/Static/bootstrap/css/*.css"));
            bundles.Add(new ScriptBundle("~/index/js").Include(
                        "~/Static/jQuery/jquery-3.5.1.min.js",
                        "~/Static/bootstrap/js/bootstrap.min.js"));

            // index/welcome
            bundles.Add(new StyleBundle("~/index/index/css").Include(
                        "~/Static/css/index/index.css"));
            bundles.Add(new ScriptBundle("~/index/index/js").Include(
                        "~/Static/js/index/index.js"));

            // index/register
            bundles.Add(new StyleBundle("~/index/register/css").Include(
                        "~/Static/css/index/register.css"));
            bundles.Add(new ScriptBundle("~/index/register/js").Include(
                        "~/Static/js/index/register.js"));

            // index/login
            bundles.Add(new StyleBundle("~/index/login/css").Include(
                        "~/Static/css/index/login.css"));
            bundles.Add(new ScriptBundle("~/index/login/js").Include(
                        "~/Static/js/index/login.js"));

            // home
            bundles.Add(new StyleBundle("~/home/css").Include(
                        "~/Static/bootstrap/css/*.css"));
            bundles.Add(new ScriptBundle("~/home/js").Include(
                        "~/Static/jQuery/jquery-3.5.1.min.js",
                        "~/Static/bootstrap/js/bootstrap.min.js"));

            // home/warehouse
            bundles.Add(new StyleBundle("~/home/warehouse/css").Include(
                        "~/Static/editormd/css/editormd.css",
                        "~/Static/css/home/warehouse.css"));
            bundles.Add(new ScriptBundle("~/home/warehouse/js").Include(
                        "~/Static/showdown/dist/showdown.min.js",
                        "~/Static/editormd/editormd.min.js",
                        "~/Static/js/home/warehouse.js"));

            // home/news
            bundles.Add(new StyleBundle("~/home/news/css").Include(
                        "~/Static/css/home/news.css"));
            bundles.Add(new ScriptBundle("~/home/news/js").Include(
                        "~/Static/js/home/news.js"));


            // community
            bundles.Add(new StyleBundle("~/community/css").Include(
                        "~/Static/bootstrap/css/*.css"));
            bundles.Add(new ScriptBundle("~/community/js").Include(
                        "~/Static/jQuery/jquery-3.5.1.min.js",
                        "~/Static/bootstrap/js/bootstrap.min.js"));

            // commnuity/articleBoard
            bundles.Add(new StyleBundle("~/community/articleBoard/css").Include(
                        "~/Static/editormd/css/editormd.css",
                        "~/Static/css/community/articleBoard.css"));
            bundles.Add(new ScriptBundle("~/community/articleBoard/js").Include(
                        "~/Static/showdown/dist/showdown.min.js",
                        "~/Static/editormd/editormd.min.js",
                        "~/Static/js/community/articleBoard.js"));


            // article
            bundles.Add(new StyleBundle("~/article/css").Include(
                        "~/Static/bootstrap/css/*.css",
                        "~/Static/bootstrap-fileinput/css/*.css",
                        "~/Static/codemirror/lib/codemirror.css",
                        "~/Static/codemirror/theme/3024-day.css",
                        "~/Static/codemirror/theme/base16-dark.css",
                        "~/Static/codemirror/theme/cobalt.css",
                        "~/Static/codemirror/theme/dracula.css",
                        "~/Static/codemirror/theme/idea.css",
                        "~/Static/codemirror/theme/icecoder.css",
                        "~/Static/codemirror/theme/mdn-like.css",
                        "~/Static/codemirror/theme/monokai.css",
                        "~/Static/codemirror/theme/seti.css",
                        "~/Static/codemirror/theme/the-matrix.css",
                        "~/Static/codemirror/theme/twilight.css",
                        "~/Static/editormd/css/editormd.css",
                        "~/Static/css/editorConfig.css"));
            bundles.Add(new ScriptBundle("~/article/js").Include(
                        "~/Static/jQuery/jquery-3.5.1.min.js",
                        "~/Static/bootstrap/js/bootstrap.min.js",
                        "~/Static/codemirror/lib/codemirror.js",
                        "~/Static/codemirror/mode/clike/clike.js",
                        "~/Static/codemirror/mode/python/python.js",
                        "~/Static/codemirror/mode/javascript/javascript.js",
                        "~/Static/hightlight/hightlight.pack.js",                 
                        "~/Static/showdown/dist/showdown.min.js",
                        "~/Static/editormd/editormd.min.js",
                        "~/Static/codemirror/addon/edit/*.js",
                        "~/Static/js/editorConfig.js"));

            // article/editor
            bundles.Add(new StyleBundle("~/article/editor/css").Include(
                        "~/Static/css/article/editor.css"));
            bundles.Add(new ScriptBundle("~/article/editor/js").Include(
                        "~/Static/js/article/editor.js"));

            // article/show
            bundles.Add(new StyleBundle("~/article/show/css").Include(
                        "~/Static/css/article/show.css"));
            bundles.Add(new ScriptBundle("~/article/show/js").Include(
                        "~/Static/js/article/show.js"));



            // Pastebin
            bundles.Add(new StyleBundle("~/pastebin/css").Include(
                        "~/Static/bootstrap/css/*.css",
                        "~/Static/bootstrap-fileinput/css/*.css",
                        "~/Static/codemirror/lib/codemirror.css",
                        "~/Static/codemirror/theme/3024-day.css",
                        "~/Static/codemirror/theme/base16-dark.css",
                        "~/Static/codemirror/theme/cobalt.css",
                        "~/Static/codemirror/theme/dracula.css",
                        "~/Static/codemirror/theme/idea.css",
                        "~/Static/codemirror/theme/icecoder.css",
                        "~/Static/codemirror/theme/mdn-like.css",
                        "~/Static/codemirror/theme/monokai.css",
                        "~/Static/codemirror/theme/seti.css",
                        "~/Static/codemirror/theme/the-matrix.css",
                        "~/Static/codemirror/theme/twilight.css"));
            bundles.Add(new ScriptBundle("~/pastebin/js").Include(
                        "~/Static/jQuery/jquery-3.5.1.min.js",
                        "~/Static/bootstrap/js/bootstrap.min.js",
                        "~/Static/codemirror/lib/codemirror.js",
                        "~/Static/codemirror/mode/clike/clike.js",
                        "~/Static/codemirror/mode/python/python.js",
                        "~/Static/codemirror/mode/javascript/javascript.js",
                        "~/Static/hightlight/hightlight.pack.js",
                        "~/Static/codemirror/addon/edit/*.js"));

            // Pastebin/write
            bundles.Add(new StyleBundle("~/pastebin/write/css").Include(
                        "~/Static/css/pastebin/write.css"));
            bundles.Add(new ScriptBundle("~/pastebin/write/js").Include(
                        "~/Static/js/pastebin/write.js"));

            // Pastebin/show
            bundles.Add(new StyleBundle("~/pastebin/show/css").Include(
                        "~/Static/css/pastebin/show.css"));
            bundles.Add(new ScriptBundle("~/pastebin/show/js").Include(
                        "~/Static/js/pastebin/show.js"));

        }
    }
}
