layui.use(['form', 'layer'], function () {
    var form = layui.form
    layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery;

    form.on("submit(add-btn)", function (data) {
        //弹出loading
        var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
        // 实际使用时的提交信息
        $.ajax({
            url: "/Content/UpdateSiteInfo",
            type: "PUT",
            data: {
                Views: $("input[name='views']").val(),
                CenterTitle: $("input[name='centerTitle']").val(),
                Motto: $("input[name='motto']").val(),
            },
            dataType: "json",
            success: function (res) {
                if (res == "SUCCESS") {
                    top.layer.close(index);
                    top.layer.msg("修改成功！");
                    layer.closeAll("iframe");
                    parent.location.reload();
                } else {
                    top.layer.close(index);
                    top.layer.msg("修改失败！");
                    layer.closeAll("iframe");
                    parent.location.reload();
                }
            }
        });

        return false;
    })
})