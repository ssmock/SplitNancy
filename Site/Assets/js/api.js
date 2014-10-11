var API = function (apiRoot) {
    var me = this;

    // Not perfect, but it works for us.
    function buildPath(front, back) {
        var result = front + '/' + back;
        result = result.replace(/\/+/g, '/').replace(/\/$/, "").replace(":/", "://");

        return result;
    }

    me.GetAList = function () {
        return $.ajax({
            url: buildPath(apiRoot, "a"),
            type: "GET"
        });
    }

    me.GetA = function (id) {
        return $.ajax({
            url: buildPath(apiRoot, "a/" + id),
            type: "GET"
        });
    }

    me.PutA = function (id, stuff) {
        return $.ajax({
            url: buildPath(apiRoot, "a/" + id),
            type: "PUT",
            data: stuff
        });
    };

    me.PostA = function (stuff) {
        return $.ajax({
            url: buildPath(apiRoot, "a"),
            type: "POST",
            data: stuff
        });
    };

    me.DeleteA = function (id) {
        return $.ajax({
            url: buildPath(apiRoot, "a/" + id),
            type: "DELETE"
        });
    };

    return me;
};