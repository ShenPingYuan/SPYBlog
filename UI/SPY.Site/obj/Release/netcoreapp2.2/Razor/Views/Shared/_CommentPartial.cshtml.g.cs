#pragma checksum "C:\Users\Administrator\Desktop\我的项目\SPY博客系统\MyBlog\UI\SPY.Site\Views\Shared\_CommentPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76d7857dab158a5164807aa8358f2532aa346097"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CommentPartial), @"mvc.1.0.view", @"/Views/Shared/_CommentPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_CommentPartial.cshtml", typeof(AspNetCore.Views_Shared__CommentPartial))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Administrator\Desktop\我的项目\SPY博客系统\MyBlog\UI\SPY.Site\Views\_ViewImports.cshtml"
using SPY.Site;

#line default
#line hidden
#line 2 "C:\Users\Administrator\Desktop\我的项目\SPY博客系统\MyBlog\UI\SPY.Site\Views\_ViewImports.cshtml"
using SPY.Site.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76d7857dab158a5164807aa8358f2532aa346097", @"/Views/Shared/_CommentPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83b2b857b004efe5922bade134526d1093b42ab7", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CommentPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("user-info-head"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/user-default.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("Comment-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/SPY-head.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 119, true);
            WriteLiteral("\n<div class=\"Comment\">\n    <div class=\"Comment-head\">\n        ❀发表评论❀\n    </div>\n    <div class=\"Comment-user\">\n        ");
            EndContext();
            BeginContext(119, 810, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "76d7857dab158a5164807aa8358f2532aa3460975818", async() => {
                BeginContext(156, 53, true);
                WriteLiteral("\n            <div class=\"user-info\">\n                ");
                EndContext();
                BeginContext(209, 67, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "76d7857dab158a5164807aa8358f2532aa3460976253", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(276, 646, true);
                WriteLiteral(@"
                <div class=""user-content"">
                    <div class=""user-info-details"">
                        <input type=""text"" name=""qq"" id=""qq"" placeholder=""QQ（可获取头像和昵称）"">
                        <input type=""text"" name=""nickname"" id=""nickname"" placeholder=""自动获取"" autocomplete=""off"" readonly="""">
                    </div>
                    <div class=""user-text"">
                        <textarea id=""comment-textarea"" name=""content"" placeholder=""既然来了就评论一下呗"" style=""height: 50px;""></textarea>
                    </div>
                </div>
            </div>
            <button class=""Comment-submit-btn"">提交</button>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(929, 161, true);
            WriteLiteral("\n    </div>\n    <ul class=\"Comment-ul\">\n        <li>\n            <div class=\"Comment-body\">\n                <div class=\"comment-user-image\">\n                    ");
            EndContext();
            BeginContext(1090, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "76d7857dab158a5164807aa8358f2532aa3460979751", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1153, 1024, true);
            WriteLiteral(@"
                </div>
                <div class=""comment-user-info"">
                    <div class=""Comment-top"">
                        <span class=""user-nickname"">毛豆</span>
                        <span class=""Comment-time"" style=""color: #757575;"">2019-10-27 09:49:58</span>
                    </div>
                    <div class=""Comment-content"">
                        <div class=""Comment-content-text"">
                            fdjsakl;发动机沙口路盖了房额if12666641f3s46feg
                        </div>
                    </div>
                    <div class=""Comment-footer"">
                        <span class=""reply"" style=""color: #a5a5f9;"">回复</span>
                        <span class=""support"">
                            <span>赞</span>
                            3
                        </span>
                    </div>
                </div>
            </div>
        </li>
        <li>
            <div class=""Comment-body"">
                <div class=""comment-user-image"">
                    ");
            EndContext();
            BeginContext(2177, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "76d7857dab158a5164807aa8358f2532aa34609712138", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2240, 1024, true);
            WriteLiteral(@"
                </div>
                <div class=""comment-user-info"">
                    <div class=""Comment-top"">
                        <span class=""user-nickname"">毛豆</span>
                        <span class=""Comment-time"" style=""color: #757575;"">2019-10-27 09:49:58</span>
                    </div>
                    <div class=""Comment-content"">
                        <div class=""Comment-content-text"">
                            fdjsakl;发动机沙口路盖了房额if12666641f3s46feg
                        </div>
                    </div>
                    <div class=""Comment-footer"">
                        <span class=""reply"" style=""color: #a5a5f9;"">回复</span>
                        <span class=""support"">
                            <span>赞</span>
                            3
                        </span>
                    </div>
                </div>
            </div>
        </li>
        <li>
            <div class=""Comment-body"">
                <div class=""comment-user-image"">
                    ");
            EndContext();
            BeginContext(3264, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "76d7857dab158a5164807aa8358f2532aa34609714526", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3327, 1024, true);
            WriteLiteral(@"
                </div>
                <div class=""comment-user-info"">
                    <div class=""Comment-top"">
                        <span class=""user-nickname"">毛豆</span>
                        <span class=""Comment-time"" style=""color: #757575;"">2019-10-27 09:49:58</span>
                    </div>
                    <div class=""Comment-content"">
                        <div class=""Comment-content-text"">
                            fdjsakl;发动机沙口路盖了房额if12666641f3s46feg
                        </div>
                    </div>
                    <div class=""Comment-footer"">
                        <span class=""reply"" style=""color: #a5a5f9;"">回复</span>
                        <span class=""support"">
                            <span>赞</span>
                            3
                        </span>
                    </div>
                </div>
            </div>
        </li>
        <li>
            <div class=""Comment-body"">
                <div class=""comment-user-image"">
                    ");
            EndContext();
            BeginContext(4351, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "76d7857dab158a5164807aa8358f2532aa34609716914", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4414, 1024, true);
            WriteLiteral(@"
                </div>
                <div class=""comment-user-info"">
                    <div class=""Comment-top"">
                        <span class=""user-nickname"">毛豆</span>
                        <span class=""Comment-time"" style=""color: #757575;"">2019-10-27 09:49:58</span>
                    </div>
                    <div class=""Comment-content"">
                        <div class=""Comment-content-text"">
                            fdjsakl;发动机沙口路盖了房额if12666641f3s46feg
                        </div>
                    </div>
                    <div class=""Comment-footer"">
                        <span class=""reply"" style=""color: #a5a5f9;"">回复</span>
                        <span class=""support"">
                            <span>赞</span>
                            3
                        </span>
                    </div>
                </div>
            </div>
        </li>
        <li>
            <div class=""Comment-body"">
                <div class=""comment-user-image"">
                    ");
            EndContext();
            BeginContext(5438, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "76d7857dab158a5164807aa8358f2532aa34609719302", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5501, 1024, true);
            WriteLiteral(@"
                </div>
                <div class=""comment-user-info"">
                    <div class=""Comment-top"">
                        <span class=""user-nickname"">毛豆</span>
                        <span class=""Comment-time"" style=""color: #757575;"">2019-10-27 09:49:58</span>
                    </div>
                    <div class=""Comment-content"">
                        <div class=""Comment-content-text"">
                            fdjsakl;发动机沙口路盖了房额if12666641f3s46feg
                        </div>
                    </div>
                    <div class=""Comment-footer"">
                        <span class=""reply"" style=""color: #a5a5f9;"">回复</span>
                        <span class=""support"">
                            <span>赞</span>
                            3
                        </span>
                    </div>
                </div>
            </div>
        </li>
        <li>
            <div class=""Comment-body"">
                <div class=""comment-user-image"">
                    ");
            EndContext();
            BeginContext(6525, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "76d7857dab158a5164807aa8358f2532aa34609721690", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6588, 919, true);
            WriteLiteral(@"
                </div>
                <div class=""comment-user-info"">
                    <div class=""Comment-top"">
                        <span class=""user-nickname"">毛豆</span>
                        <span class=""Comment-time"" style=""color: #757575;"">2019-10-27 09:49:58</span>
                    </div>
                    <div class=""Comment-content"">
                        <div class=""Comment-content-text"">
                            fdjsakl;发动机沙口路盖了房额if12666641f3s46feg
                        </div>
                    </div>
                    <div class=""Comment-footer"">
                        <span class=""reply"" style=""color: #a5a5f9;"">回复</span>
                        <span class=""support"">
                            <span>赞</span>
                            3
                        </span>
                    </div>
                </div>
            </div>
        </li>
    </ul>
</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591