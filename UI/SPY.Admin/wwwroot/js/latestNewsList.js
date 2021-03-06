﻿layui.use(['form', 'layer', 'laydate', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laydate = layui.laydate,
        laytpl = layui.laytpl,
        table = layui.table;

    //新闻列表
    var tableIns = table.render({
        elem: '#latestNewsList',
        url: '/Content/LatestNewses',
        cellMinWidth: 95,
        page: true,
        height: "full-125",
        limit: 20,
        limits: [10, 15, 20, 25],
        id: "latestNewsListTable",
        cols: [[
            { type: "checkbox", fixed: "left", width: 50 },
            { field: 'rowId', title: 'ID', width: 60, align: "center" },
            { field: 'newsId', title: '最新消息Id', width: 200, align: "center" },
            { field: 'newsName', title: '消息名', width: 300, align: "center" },
            { field: 'newsUrl', title: '消息地址', width: 500 },
            {
                field: 'isOpen', title: '是否开放', align: 'center', templet: function (d) {
                    if (d.isOpen == true) {
                        return '<input type="checkbox" name="isOpen" lay-filter="isOpen" lay-skin="switch" lay-text="是|否" checked>'
                    } else {
                        return '<input type="checkbox" name="isOpen" lay-filter="isOpen" lay-skin="switch" lay-text="是|否">'
                    }

                }
            },
            //{ field: 'newsStatus', title: '发布状态', align: 'center', templet: "#newsStatus" },
            //{ field: 'newsLook', title: '浏览权限', align: 'center' },
            { title: '操作', width: 400, templet: '#latestNewsListBar', fixed: "right", align: "center" }
        ]]
    });

    //是否置顶
    form.on('switch(isTop)', function (data) {
        var index = layer.msg('修改中，请稍候', { icon: 16, time: false, shade: 0.8 });
        setTimeout(function () {
            layer.close(index);
            if (data.elem.checked) {
                layer.msg("置顶成功！");
            } else {
                layer.msg("取消置顶成功！");
            }
        }, 500);
    })

    //搜索【此功能需要后台配合，所以暂时没有动态效果演示】
    $(".search_btn").on("click", function () {
        if ($(".searchVal").val() != '') {
            table.reload("latestNewsListTable", {
                page: {
                    curr: 1 //重新从第 1 页开始
                },
                where: {
                    key: $(".searchVal").val()  //搜索的关键字
                }
            })
        } else {
            layer.msg("请输入搜索的内容");
        }
    });

    //添加文章
    function addNews(edit) {
        var para = "";
        if (typeof (edit) != "undefined") {
            para = "?latestNewsId=" + edit.newsId;
        }
        var index = layui.layer.open({
            title: "添加最新消息",
            type: 2,
            content: "/Content/AddLatestNews" + para,
            success: function (layero, index) {
                setTimeout(function () {
                    layui.layer.tips('点击此处返回文章列表', '.layui-layer-setwin .layui-layer-close', {
                        tips: 3
                    });
                }, 500)
            }
        })
        layui.layer.full(index);
        //改变窗口大小时，重置弹窗的宽高，防止超出可视区域（如F12调出debug的操作）
        $(window).on("resize", function () {
            layui.layer.full(index);
        })
    }
    $(".addNews_btn").click(function () {
        addNews();
    })

    //批量删除
    $(".delAll_btn").click(function () {
        var checkStatus = table.checkStatus('latestNewsListTable'),
            data = checkStatus.data,
            newsId = [];
        if (data.length > 0) {
            for (var i in data) {
                newsId.push(data[i].newsId);
            }
            layer.confirm('确定删除选中的文章？', { icon: 3, title: '提示信息' }, function (index) {
                // $.get("删除文章接口",{
                //     newsId : newsId  //将需要删除的newsId作为参数传入
                // },function(data){
                tableIns.reload();
                layer.close(index);
                // })
            })
        } else {
            layer.msg("请选择需要删除的文章");
        }
    })

    //列表操作
    table.on('tool(latestNewsList)', function (obj) {
        var layEvent = obj.event,
            data = obj.data;

        if (layEvent === 'edit') { //编辑
            addNews(data);
        } else if (layEvent === 'del') { //删除
            layer.confirm('确定删除此消息？', { icon: 3, title: '提示信息' }, function (index) {
                // $.get("删除文章接口",{
                //     newsId : data.newsId  //将需要删除的newsId作为参数传入
                // },function(data){
                //tableIns.reload();
                //layer.close(index);
                // })
                var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
                $.ajax({
                    url: "/Content/DeleteLatestNews",
                    type: "POST",
                    data: {
                        latestNewsId: data.newsId,
                    },
                    dataType: "json",
                    success: function (res) {
                        tableIns.reload();
                        layer.close(index);
                    }
                })
            });
        } else if (layEvent === 'look') { //预览
            layer.alert("此功能需要前台展示，实际开发中传入对应的必要参数进行文章内容页面访问")
        }
    });

})