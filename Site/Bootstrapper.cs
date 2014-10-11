namespace Site
{
    using Nancy;
    using Nancy.Conventions;
    using System.Web.Optimization;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory(
                    "/Assets"));

            nancyConventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory(
                    "/Scripts"));

            nancyConventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory(
                    "/Bundles"));

            base.ConfigureConventions(nancyConventions);
        }

        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            var scriptBundle = new ScriptBundle("~/Bundles/js")
                .Include(
                    "~/Scripts/jquery-2.1.1.js",
                    "~/Scripts/underscore.js");

            //var styleBundle = new StyleBundle("~/css")
            //    .IncludeDirectory("~/Content/css", "*.css");

            BundleTable.Bundles.Add(scriptBundle);
            //BundleTable.Bundles.Add(styleBundle);

            BundleTable.EnableOptimizations = true;
        }

        protected override void RequestStartup(
            Nancy.TinyIoc.TinyIoCContainer container,
            Nancy.Bootstrapper.IPipelines pipelines,
            NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);
        }
    }
}