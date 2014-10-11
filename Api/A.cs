using Nancy;

namespace Api
{
    public class A : NancyModule
    {
        public A()
            : base("a")
        {
            Get["/"] = _ =>
            {
                return new string[] { "A1", "A2", "A3" };
            };

            Get["/{id}"] = _ =>
            {
                return string.Format("A{0}", _.id);
            };

            Put["/{id}"] = _ =>
            {
                //
                // DO STUFF
                //

                return HttpStatusCode.OK;
            };

            Post["/"] = _ =>
            {
                Response result = new Response();

                // Location for a get: it's the same path as the post, but with an ID after it.
                result.Headers.Add("Location", this.Context.Request.Url + "/123");
                result.Headers.Add("Access-Control-Expose-Headers", "Location");

                result.StatusCode = HttpStatusCode.Created;

                return result; // As if it were an ID.
            };

            Delete["/{id}"] = _ =>
            {
                return HttpStatusCode.OK;
            };
        }
    }
}