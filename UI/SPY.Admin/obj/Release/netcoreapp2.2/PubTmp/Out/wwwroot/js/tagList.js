﻿layui.use(['form', 'layer', 'laydate', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laydate = layui.laydate,
        laytpl = layui.laytpl,
        table = layui.table;

    //标签
    var tableIns = table.render({
        elem: '#tagList',
        url: '/Tag/TagList',
        cellMinWidth: 95,
        page: true,
        height: "full-125",
        limit: 20,
        limits: [10, 15, 20, 25],
        id: "tagListTable",
        cols: [[
            { type: "checkbox", fixed: "left", width: 80 },
            { field: 'showId', title: 'ID', width: 120, align: "center" },
            { field: 'id', title: '标签Id', width: 120, align: "center" },
            { field: 'name', title: '标签名', width: 300, align: "center" },
            { field: 'src', title: '连接地址',  },
            { field: 'isInChina', title: '是否国内', width: 200, align: 'center' },
            { field: 'isOpen', title: '是否开放', align: 'center', width: 170, templet:'#IsOpenBar' },
            { title: '操作', width: 350, templet: '#TagListBar', fixed: "right", align: "center" }
        ]]
    });

    //是否置顶
    form.on('switch(isOpen)', function (data) {
        console.log(data.elem.checked);
        var index = layer.msg('修改中，请稍候', { icon: 16, time: false, shade: 0.8 });
        $.ajax({
            url: "/Tag/SwitchOpen",
            type: "POST",
            data: {
                Id: $(this).parents("tr").find(".laytable-cell-1-id").text(),
                IsOpen: data.elem.checked,
            },
            dataType: "text",
            success: function (res) {
                layer.close(index);
                if (data.elem.checked) {
                    layer.msg("开放成功！");
                } else {
                    layer.msg("关闭开放成功！");
                }
            }
        });
        //setTimeout(function () {

        //}, 500);
    });

    //搜索【此功能需要后台配合，所以暂时没有动态效果演示】
    $(".search_btn").on("click", function () {
        if ($(".searchVal").val() != '') {
            table.reload("TagListTable", {
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

    //添加标签
    function addTag(edit) {
        var para = "";
        if (typeof (edit) != "undefined") {
            para = "?tagId=" + edit.id;
        }
        var index = layui.layer.open({
            title: "添加标签",
            type: 2,
            content: "/Tag/AddTag" + para,
            success: function (layero, index) {
                //var body = layui.layer.getChildFrame('body', index);
                //if(edit){
                ////    body.find(".newsName").val(edit.newsName);
                ////    body.find(".abstract").val(edit.abstract);
                ////    body.find(".thumbImg").attr("src",edit.newsImg);
                ////    body.find("#news_content").val(edit.content);
                ////    body.find(".newsStatus select").val(edit.newsStatus);
                //    //    body.find(".openness input[name='openness'][title='"+edit.newsLook+"']").prop("checked","checked");
                //    if (edit.isTop == true) {
                //        body.find(".newsTop input[name='newsTop']").prop("checked","checked");
                //    }
                //    form.render();
                //}
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
    $(".addTag_btn").click(function () {
        addTag();
    })

    //批量删除
    $(".delAll_btn").click(function () {
        var checkStatus = table.checkStatus('newsListTable'),
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
    table.on('tool(TagList)', function (obj) {
        var layEvent = obj.event,
            data = obj.data;

        if (layEvent === 'edit') { //编辑
            addTag(data);
        } else if (layEvent === 'del') { //删除
            layer.confirm('确定删除此标签？', { icon: 3, title: '提示信息' }, function (index) {
                // $.get("删除文章接口",{
                //     newsId : data.newsId  //将需要删除的newsId作为参数传入
                // },function(data){
                //tableIns.reload();
                //layer.close(index);
                // })
                var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
                $.ajax({
                    url: "/Tag/DeleteTag",
                    type: "POST",
                    data: {
                        tagId: data.id,
                    },
                    dataType: "text",
                    success: function (res) {
                        tableIns.reload();
                        layer.close(index);
                    }
                })
            });
        } else if (layEvent === 'look') { //预览
            layer.alert("此功能需要前台展示，实际开发中传入对应的必要参数进行文章内容页面访问");
        } else if (layEvent === 'switch') {
            alert("switch");
        };
    });

})