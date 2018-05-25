$(function () {
    var ajaxOnClickEdit = function () {
        var $data = $(this);
        var options = {
            url: $data.attr("href"),
            type: "GET"
        }
        $.ajax(options).done(function (data_r) {
            var $target = $($data.attr("data-ax-target"));
            $target.replaceWith(data_r);
        });
        return false;
    }

    $("a[data-ax-infopanel='true']").on("click", ajaxOnClickEdit);
});