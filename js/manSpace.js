this.loadData = function () {
    var url = "data/manData.txt";
    var divStr = "";
    $.get(url, '', function (result) {
        var data = $.parseJSON(result);
        $(".manSpace-footDiv-content-content-ul").remove();
        for (var i = 0; i < data.length; i++) {
            divStr += "<ul class='manSpace-footDiv-content-content-ul padding'>";
            divStr += "<li class='dateTime'>" + data[i].datetime + "</li>"
            divStr += "<li class='manSpace-footDiv-content-content-text' style='text-indent:2em'>" + data[i].content + "</li>"
            divStr += "</ul>";
        }
        $(".manSpace-footDiv-content-content").append(divStr);
    });
}
this.getData = function () {
    var date = new Date();
    var content = $("#content").val();
    var url = "jsonAPI.aspx?date=" + datetimeFormat(date, "yyyy-MM-dd") + "&content=" + content;

    if (content.trim() == '') {
        return false;
    }

    $.get(url, '', function (result) {
        if (result=='true') {
            alert("新增成功！");
            $("#content").val('');
            loadData();
        }
    });
}
