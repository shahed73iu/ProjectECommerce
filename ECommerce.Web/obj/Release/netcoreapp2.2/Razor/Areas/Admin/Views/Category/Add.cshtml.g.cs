#pragma checksum "E:\devskill classes\ProjectsFinals\ProjectECommerce\ECommerce.Web\Areas\Admin\Views\Category\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74de6fdfb253c341291e6823c9e31dd39da12825"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category_Add), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/Add.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Category/Add.cshtml", typeof(AspNetCore.Areas_Admin_Views_Category_Add))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74de6fdfb253c341291e6823c9e31dd39da12825", @"/Areas/Admin/Views/Category/Add.cshtml")]
    public class Areas_Admin_Views_Category_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ECommerce.Web.Areas.Admin.Models.CategoryUpdateModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/category/add"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\devskill classes\ProjectsFinals\ProjectECommerce\ECommerce.Web\Areas\Admin\Views\Category\Add.cshtml"
  
    ViewData["Title"] = "Add Category";

#line default
#line hidden
            BeginContext(109, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("notification", async() => {
                BeginContext(135, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(142, 60, false);
#line 8 "E:\devskill classes\ProjectsFinals\ProjectECommerce\ECommerce.Web\Areas\Admin\Views\Category\Add.cshtml"
Write(await Html.PartialAsync("_Notification", Model.Notification));

#line default
#line hidden
                EndContext();
                BeginContext(202, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(207, 435, true);
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <!-- left column -->
        <div class=""col-md-6"">
            <!-- general form elements -->
            <div class=""card card-primary"">
                <div class=""card-header"">
                    <h3 class=""card-title"">Add a new category</h3>
                </div>
                <!-- /.card-header -->
                <!-- form start -->
                ");
            EndContext();
            BeginContext(642, 687, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74de6fdfb253c341291e6823c9e31dd39da128255301", async() => {
                BeginContext(704, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(727, 23, false);
#line 23 "E:\devskill classes\ProjectsFinals\ProjectECommerce\ECommerce.Web\Areas\Admin\Views\Category\Add.cshtml"
               Write(Html.AntiForgeryToken());

#line default
#line hidden
                EndContext();
                BeginContext(750, 572, true);
                WriteLiteral(@"
                    <div class=""card-body"">
                        <div class=""form-group"">
                            <label for=""categoryName"">Name</label>
                            <input type=""text"" class=""form-control"" name=""Name"" id=""categoryName"" placeholder=""Enter name"">
                        </div>
                    </div>
                    <!-- /.card-body -->

                    <div class=""card-footer"">
                        <button type=""submit"" class=""btn btn-primary"">Submit</button>
                    </div>
                ");
                EndContext();
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
            BeginContext(1329, 117, true);
            WriteLiteral("\r\n            </div>\r\n            <!-- /.card -->\r\n\r\n        </div>\r\n        <!--/.col (left) -->\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ECommerce.Web.Areas.Admin.Models.CategoryUpdateModel> Html { get; private set; }
    }
}
#pragma warning restore 1591