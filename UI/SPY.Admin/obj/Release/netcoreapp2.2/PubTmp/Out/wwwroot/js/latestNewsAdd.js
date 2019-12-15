layui.use(['form', 'layer'], function () {
    var form = layui.form
    layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery;

    form.on("submit(add-btn)", function (data) {
        //弹出loading
        var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
        // 实际使用时的提交信息
        $.ajax({
            url: "/Content/AddLatestNews",
            type: "POST",
            data: {
                Id: data.field.newsId,
                NewsName: data.field.newsName,
                NewsUrl: data.field.newsUrl,
                IsOpen: data.field.isOpen == "on" ? true : false,
            },
            dataType: "json",
            success: function (res) {
                if (res.msg == "SUCCESS") {
                    top.layer.close(index);
                    top.layer.msg("最新消息添加成功！");
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                } else {
                    top.layer.close(index);
                    top.layer.msg("最新消息添加失败！");
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                }

            }
        });
        return false;
    })
})